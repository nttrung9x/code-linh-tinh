using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*
https://www.facebook.com/hkvn9x
skype: nttrung9x
https://mmo69.com
telegram: hkvn9x
*/
namespace API10MinuteMailNet
{
    public class API10MinuteMailNet
    {
        private HttpRequest http;
        public API10MinuteMailNet()
        {
            http = new HttpRequest();
        }    
        public string GetEmail()
        {
            return Regex.Match(http.Get("https://10minutemail.net/address.api.php").ToString(), "\"mail_get_mail\":\"(.*?)\"").Groups[1].Value;
        }
        public string NewEmail()
        {
            return Regex.Match(http.Get("https://10minutemail.net/address.api.php?new=1").ToString(), "\"mail_get_mail\":\"(.*?)\"").Groups[1].Value;
        }
        public string GetUrlAndKeyEmail()
        {
            string get = http.Get("https://10minutemail.net/address.api.php").ToString();
            return "{\"url\":\"" + Regex.Match(get, "\"url\":\"(.*?)\"").Groups[1].Value.Replace("\\/", "/") + "\",\"key\":\"" + Regex.Match(get, "\"key\":\"(.*?)\"").Groups[1].Value + "\"}";
        }
        public List<string> ReadMail(string mailid)
        {
            List<string> list = new List<string>();
            string get = http.Get("https://10minutemail.net/mail.api.php?mailid=" + mailid).ToString();
            if (get == "{\"error\":true,\"code\":\"nomail\"}")
            {
                list.Add("null");
            }
            else if (get == "null")
            {
                list.Add("null");
            }
            else
            {
                string from = Regex.Match(get, "\"from\":\"(.*?)\"").Groups[1].Value;
                string gravatar = Regex.Match(get, "\"gravatar\":\"(.*?)\"").Groups[1].Value;
                string to = Regex.Match(get, "\"to\":\"(.*?)\"").Groups[1].Value;
                string subject = Regex.Match(get, "\"subject\":\"(.*?)\"").Groups[1].Value;
                string datetime = Regex.Match(get, "\"datetime\":\"(.*?)\"").Groups[1].Value;
                string timestamp = Regex.Match(get, "\"timestamp\":(.*?),").Groups[1].Value;
                string datetime2 = Regex.Match(get, "\"datetime2\":\"(.*?)\"").Groups[1].Value;
                string html = Regex.Match(get, "\"html\":\\[\"(.*?)\"]").Groups[1].Value;
                string urls = Regex.Match(get, "\"urls\":{\"(.*?)\"}").Groups[1].Value;
                string body = Regex.Match(get, "\"body\":\\[{\"(.*?)\"}").Groups[1].Value;
                if (from == "") from = "null";
                if (gravatar == "") gravatar = "null";
                if (to == "") to = "null";
                if (subject == "") subject = "null";
                if (datetime == "") datetime = "null";
                if (timestamp == "") timestamp = "null";
                if (datetime2 == "") datetime2 = "null";
                if (html == "") html = "null";
                if (urls == "") urls = "null";
                if (body == "") body = "null";
                list.Add("{\"from\":\"" + from + "\"," + "\"gravatar\":\"" + gravatar + "\"," + "\"to\":\"" + to + "\"," + "\"subject\":\"" + subject + "\"," + "\"datetime\":\"" + datetime + "\"," + "\"timestamp\":\"" + timestamp + "\"," + "\"datetime2\":\"" + datetime2 + "\"," + "\"html\":\"" + html + "\"," + "\"urls\":\"" + urls + "\"," + "\"body\":\"" + body + "\"}");
            }
            return list;
        }
        public List<string> GetMailId()
        {
            List<string> list = new List<string>();
            string get = http.Get("https://10minutemail.net/address.api.php").ToString();
            if (get == "null")
            {
                list.Add("null");
            }
            else
            {
                dynamic jsonObj = JsonConvert.DeserializeObject(get);
                foreach (var item in jsonObj.mail_list)
                {
                    try
                    {
                        list.Add("{\"mail_id\":\"" + item.mail_id + "\"," + "\"from\":\"" + item.from + "\"," + "\"subject\":\"" + item.subject + "\"," + "\"datetime\":\"" + item.datetime + "\"," + "\"datetime2\":\"" + item.datetime2 + "\"," + "\"timeago\":\"" + item.timeago + "\"," + "\"isread\":\"" + item.isread + "\"}");
                    }
                    catch { }
                }
                return list;
            }
            return list;
        }
        public void Reset100Minutes()
        {
            http.Get("https://10minutemail.net/more100.html").ToString();
        }
        public void Reset10Minutes()
        {
            http.Get("https://10minutemail.net/more.html").ToString();
        }
        public void RecoverExpiredEmail()
        {
            http.Get("https://10minutemail.net/recover.html").ToString();
        }
    }
}
