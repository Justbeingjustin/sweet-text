using Newtonsoft.Json;
using SweetTextV2.Models;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace SweetTextV2.Services
{
    public class SweetMessageService : ISweetMessageService
    {
        public IMessage GetNextMessage()
        {
            string path = ConfigurationManager.AppSettings["PathToSweetMessages"];
            var messages = JsonConvert.DeserializeObject<Stack<string>>(File.ReadAllText(path));

            if (messages.Count == 0)
            {
                return new EmptyMessage();
            }

            var message = messages.Pop();
            File.WriteAllText(path, JsonConvert.SerializeObject(messages));
            return new SweetMessage() { Message = message };
        }
    }
}