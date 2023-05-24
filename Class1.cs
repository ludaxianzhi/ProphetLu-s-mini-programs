using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace ProphetLu_s_Translation_Reference_Tool
{



    public class TranClass
    {
        public string From { get; set; }
        public string To { get; set; }
        public List<Trans_result> Trans_result { get; set; }
    }
    public class Trans_result
    {
        public string src { get; set; }
        public string dst { get; set; }
    }
    public class ChatGPTApiClient
    {
        private const string API_URL = "https://api.openai.com/v1/chat/completions";
        private readonly HttpClient client;
        private string chatId;
        private List<dynamic> messages;

        public ChatGPTApiClient(string apiKey)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            ResetConversation();
        }

        public async Task<string> GetChatGPTResponse(List<string> conversation, string newMessage)
        {
            foreach (var message in conversation)
            {
                messages.Add(new { role = "user", content = message });
            }

            messages.Add(new { role = "user", content = newMessage });

            var payload = new
            {
                messages,
                chatId
            };

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(API_URL, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            // 解析 API 响应并获取回复
            var responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
            var reply = responseJson.choices[0].message.content;

            messages.Add(new { role = "assistant", content = reply });

            return reply;
        }


        public void ResetConversation()
        {
            chatId = Guid.NewGuid().ToString();
            messages = new List<dynamic>();
        }
    }
    public class GetTranslationFromGPT
    {
        ChatGPTApiClient client;
        List<string> messages = new List<string>

    {
        "你好，接下来我需要让你帮我将一些日语句子翻译成中文。请只写出译文即可，不需要任何的解释和其他信息。",
        "当然，我可以帮你翻译日语句子成中文。请提供需要翻译的句子。",
    };
        public GetTranslationFromGPT(string key)
        {
            this.client = new ChatGPTApiClient(key);
        }
        public async Task<string> GetTranslation(string message)
        {

            var answer = await this.client.GetChatGPTResponse(this.messages, message);
            this.messages.Add(answer.ToString());
            if (this.messages.Count > 40)
            {
                this.messages.RemoveRange(2, this.messages.Count - 2);
                this.client.ResetConversation();
            }
            return answer.ToString();
        }
    }
}
