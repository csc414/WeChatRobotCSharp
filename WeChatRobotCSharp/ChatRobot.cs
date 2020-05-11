using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using static WeChatRobotCSharp.Messages;

namespace WeChatRobotCSharp
{
    public class ChatRobot
    {
        private readonly HttpClient _http;

        private readonly JavaScriptSerializer _serializer;

        public ChatRobot()
        {
            _http = new HttpClient();
            _serializer = new JavaScriptSerializer();
        }

        /// <summary>
        /// 青云客人工智能聊天
        /// </summary>
        /// <param name="wxid"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task QingYunKeAutoReply(string wxid, string content)
        {
            var response = await _http.GetAsync($"http://api.qingyunke.com/api.php?key=free&appid=0&msg={content}");
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var dict = _serializer.Deserialize<Dictionary<string, object>>(result);
                if(int.TryParse(dict["result"].ToString(), out var code) && code == 0)
                {
                    SendWechatMessage(wxid, dict["content"].ToString().Replace("{br}", "，"));
                }
            }
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        string Md5_32(string value)
        {
            return Md5_32(value, Encoding.UTF8);
        }

        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="encoding">字符编码</param>
        string Md5_32(string value, Encoding encoding)
        {
            return Md5(value, encoding, true);
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        string Md5(string value, Encoding encoding, bool _32bit)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            return Md5(encoding.GetBytes(value), _32bit);
        }

        string Md5(byte[] bytes, bool _32bit)
        {
            var md5 = new MD5CryptoServiceProvider();
            StringBuilder sb = new StringBuilder();
            try
            {
                var hash = md5.ComputeHash(bytes);
                var start = _32bit ? 0 : 4;
                var len = _32bit ? hash.Length : hash.Length - 4;
                for (int i = start; i < len; i++)
                    sb.AppendFormat("{0:x2}", hash[i]);
            }
            finally
            {
                md5.Clear();
            }
            return sb.ToString();
        }

        string GetTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        string GetGuidHashCode()
        {
            return Guid.NewGuid().ToString("N");
        }

        string GetReqSign(IEnumerable<KeyValuePair<string,string>> @params, string appKey)
        {
            var sb = new StringBuilder();
            foreach (var keyValue in @params)
            {
                if(!string.IsNullOrEmpty(keyValue.Value))
                {
                    if(keyValue.Key.Equals("nonce_str"))
                    {
                        sb.Append($"{keyValue.Key}={HttpUtility.UrlEncode(keyValue.Value)}&");
                    }
                    else
                    {
                        sb.Append($"{keyValue.Key}={HttpUtility.UrlEncode(keyValue.Value).ToUpperInvariant()}&");
                    }
                }
            }
            sb.Append($"app_key={appKey}");
            var queryString = sb.ToString();
            var sign = Md5_32(queryString).ToUpperInvariant();
            return $"{queryString}&sign={sign}";
        }

        /// <summary>
        /// 腾讯ai智能闲聊
        /// </summary>
        /// <param name="wxid"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task TencentAiAutoReply(string wxid, string content)
        {
            var dictParams = new Dictionary<string, string>();
            dictParams["app_id"] = "2138917994";
            dictParams["nonce_str"] = GetGuidHashCode();
            dictParams["question"] = content;
            dictParams["session"] = wxid;
            dictParams["time_stamp"] = GetTimestamp();
            dictParams = dictParams.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
            var queryString = GetReqSign(dictParams, "7fdynIQuqigHPsnx");
            var response = await _http.GetAsync($"https://api.ai.qq.com/fcgi-bin/nlp/nlp_textchat?{queryString}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var dict = _serializer.Deserialize<Dictionary<string, object>>(result);
                if (int.TryParse(dict["ret"].ToString(), out var code) && code == 0)
                {
                    var data = (Dictionary<string, object>)dict["data"];
                    SendWechatMessage(wxid, data["answer"].ToString());
                }
            }
        }
    }
}
