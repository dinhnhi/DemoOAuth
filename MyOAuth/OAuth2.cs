using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOAuth
{
    class OAuth2
    {

        const string client_id = "898292369310-slgeq5avg6km7q0jncs89rd4ij28ra5l.apps.googleusercontent.com";
        const string client_secret = "UeZ5MJK2a75KiF1XUyIXpSfp";

        // nơi mà Server trả kết quả về
        string redirect_uri = @"http://127.0.0.1:8080/";

        // các thông tin mà app muốn lấy từ user(profile, emain, ..)
        public string scope { get; set; }


        public async Task<string> RequestAuthorizationGrant()
        {
            string urlAuthorization = "https://accounts.google.com/o/oauth2/v2/auth";

            // chuỗi state sẽ được dùng để xác nhận
            // yêu cầu và phản hồi có từ cùng 1 nguồn hay không
            string state = randomDataBase64url(48);

            // response_type=code => mặc định của Desktop App
            string urlAuthorizationRequest = String.Format("{0}?scope={1}&response_type=code&state={2}&redirect_uri={3}&client_id={4}",
                urlAuthorization,
                scope,
                state,
                redirect_uri,
                client_id);

            // Gửi yêu cầu tới 'Resource Server'
            Process.Start(urlAuthorizationRequest);

            // Chờ phản hồi
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(redirect_uri);
            listener.Start();

            // Lấy nội dung phản hồi
            HttpListenerContext context = await listener.GetContextAsync();

            listener.Stop();

            // Kiểm tra phản hồi
            if (context.Request.QueryString.Get("error") != null)
            {
                MessageBox.Show(context.Request.QueryString.Get("error"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            if (context.Request.QueryString.Get("code") == null)
            {
                MessageBox.Show("Mã xác thực không được trả về!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            // lấy mã xác nhận
            string authorizationGrant = context.Request.QueryString.Get("code");

            // kiểm tra state của nguồn được trả về
            string incoming_state = context.Request.QueryString.Get("state");
            if (incoming_state != state)
            {
                DialogResult result = MessageBox.Show(
                    "Dữ liệu được trả về từ 1 nguồn không xác định!\n" +
                    "Chúng tôi khuyên bạn không nên tiếp tục!\n " +
                    "Bạn có muốn tiếp tục?",
                     "Warning",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return null;
            }

            return authorizationGrant;
        }

        public async Task<string> RequestAccessToken(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                MessageBox.Show("Mã xác thực mang giá trị NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string tokenRequsestUri = "https://www.googleapis.com/oauth2/v4/token";
            string tokenRequestBody = String.Format("code={0}&redirect_uri={1}&client_id={2}&client_secret={3}&grant_type=authorization_code",
                code,
                redirect_uri,
                client_id,
                client_secret
                );

            // gửi yêu cầu lên "Authorization Server" để nhận "Access Token"
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tokenRequsestUri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            Stream stream = await request.GetRequestStreamAsync();

            byte[] buffer = Encoding.ASCII.GetBytes(tokenRequestBody);
            await stream.WriteAsync(buffer, 0, buffer.Length);
            stream.Close();

            try
            {
                // Nhận phản hồi
                WebResponse response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = await reader.ReadToEndAsync();

                    Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);

                    string access_token = dictionary["access_token"];
                    return access_token;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<string> RequestUserInfo(string access_token)
        {
            string infoRequestUrl = "https://www.googleapis.com/oauth2/v3/userinfo";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(infoRequestUrl);

            request.Method = "GET";
            request.Headers.Add(string.Format("Authorization: Bearer {0}", access_token));
            request.ContentType = "application/x-www-form-urlencoded";

            try
            {
                // nhận phản hồi
                WebResponse reponse = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(reponse.GetResponseStream()))
                {
                    string responseContent = await reader.ReadToEndAsync();

                    return responseContent;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Tạo ra 1 url ngẫu nhiên
        string randomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[length];

            rng.GetBytes(buffer);

            return base64EncodeUrlNoPadding(buffer);
        }

        string base64EncodeUrlNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            //convert base64 to base64url
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace(@"\", "_");

            // Strips padding
            base64 = base64.Replace("=", "");
            return base64;
        }
    }
}
