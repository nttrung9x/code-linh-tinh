using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;

/*
https://www.facebook.com/hkvn9x
skype: nttrung9x
https://mmo69.com
telegram: hkvn9x
*/

namespace Download_All_Images_Group_Facebook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateFolder(Application.StartupPath + "\\Images");

            TextBox.CheckForIllegalCrossThreadCalls = false;
            Button.CheckForIllegalCrossThreadCalls = false;
        }
        bool isStop = false;
        Random rand = new Random();
        public static bool IsValidJson(string src)
        {
            try
            {
                var asToken = JToken.Parse(src);
                return asToken.Type == JTokenType.Object || asToken.Type == JTokenType.Array;
            }
            catch (Exception) 
            {
                return false;
            }
        }
        public static bool CreateFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path)) //nếu không có folder images
                {
                    Directory.CreateDirectory(path); //tạo folder images
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Download")
            {
                button1.Text = "Stop";
                isStop = false; //bắt đầu download
                string[] idgroups = textBox1.Lines; //lấy danh sách id group từ textbox
                await Task.Run(async () => //tạo luồng
                {
                    foreach (var idgroup in idgroups) //lấy từng id group một
                    {
                        if (isStop) return; //isStop bằng true thì sẽ dừng lại
                        if (!string.IsNullOrEmpty(idgroup)) //nếu id group không bị rỗng
                        {
                            HttpClient httpClient = new HttpClient();
                            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36"); //thêm user agent để lấy đc danh sách ảnh
                            httpClient.DefaultRequestHeaders.Add("Cookie", "locale=vi_VN"); //đặt ngôn ngữ facebook thành ngôn ngữ Việt Nam
                            httpClient.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin"); //thêm sec-fetch-site để lấy đc danh sách ảnh
                            var content = new FormUrlEncodedContent(new[]
                            {
                            new KeyValuePair<string, string>("doc_id", "4430099110431117"),
                            new KeyValuePair<string, string>("variables", "{\"groupID\":\"" + idgroup + "\",\"scale\":1,\"useCometPhotoViewerPlaceholderFrag\":false,\"count\":1000}")
                        });
                            var response = await httpClient.PostAsync("https://www.facebook.com/api/graphql/", content);
                            string result = response.Content.ReadAsStringAsync().Result;
                            if (!IsValidJson(result)) goto DONE_ID_GROUP;
                            CreateFolder(Application.StartupPath + "\\Images\\" + idgroup);
                            dynamic json = JsonConvert.DeserializeObject(result); //parse json
                            foreach (dynamic jsonCon in json["data"]["group"]["group_mediaset"]["media"]["edges"])
                            {
                                try
                                {
                                    new WebClient().DownloadFile((string)jsonCon["node"]["image"]["uri"], (string)Application.StartupPath + "\\Images\\" + idgroup + "\\" + jsonCon["node"]["id"] + ".jpg");
                                }
                                catch (Exception) { }
                                if (isStop) return; //isStop bằng true thì sẽ dừng lại
                            }
                            var end_cursor = json["data"]["group"]["group_mediaset"]["media"]["page_info"]["end_cursor"];
                        BACK_DOWNLOAD:;
                            if (end_cursor != null)
                            {
                                Thread.Sleep(TimeSpan.FromMinutes(rand.Next(3, 6)));
                                content = new FormUrlEncodedContent(new[]
                                {
                                new KeyValuePair<string, string>("doc_id", "4544387022318594"),
                                new KeyValuePair<string, string>("variables", "{\"count\":1000,\"cursor\":\"" + (string)end_cursor + "\",\"scale\":1,\"useCometPhotoViewerPlaceholderFrag\":false,\"id\":\"" + idgroup + "\"}")
                            });
                                response = await httpClient.PostAsync("https://www.facebook.com/api/graphql/", content);
                                result = response.Content.ReadAsStringAsync().Result;
                                json = JsonConvert.DeserializeObject(result); //parse json
                                foreach (dynamic jsonCon in json["data"]["node"]["group_mediaset"]["media"]["edges"])
                                {
                                    try
                                    {
                                        new WebClient().DownloadFile((string)jsonCon["node"]["image"]["uri"], (string)Application.StartupPath + "\\Images\\" + idgroup + "\\" + jsonCon["node"]["id"] + ".jpg");
                                    }
                                    catch (Exception) { }
                                    if (isStop) return; //isStop bằng true thì sẽ dừng lại
                                }
                                end_cursor = json["data"]["node"]["group_mediaset"]["media"]["page_info"]["end_cursor"]; //lấy cursor để lấy danh sách tiếp theo
                                goto BACK_DOWNLOAD; //quay lại lấy tiếp danh sách
                            }
                        }
                    DONE_ID_GROUP:;
                    }
                    button1.Text = "Download";
                });
            }   
            else
            {
                button1.Text = "Download";
                isStop = true; //dừng download
            }    
        }
    }
}
