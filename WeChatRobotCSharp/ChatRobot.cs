using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
    }
}
