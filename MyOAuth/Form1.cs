
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MyOAuth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OAuth2 oauth = new OAuth2();

        private async void btnStep1_Click(object sender, EventArgs e)
        {
            waitingMessage(rtxb1);

            oauth.scope = "profile%20email%20openid";
            string code_grant = await oauth.RequestAuthorizationGrant();

            rtxb1.Text = code_grant;
        }

        private async void btnStep2_Click(object sender, EventArgs e)
        {
            waitingMessage(rtxb2);

            string access_token = await oauth.RequestAccessToken(rtxb1.Text);
            rtxb2.Text = access_token;
        }

        private async void btnStep3_Click(object sender, EventArgs e)
        {
            waitingMessage(rtxb3);

            string userInfo = await oauth.RequestUserInfo(rtxb2.Text);
            rtxb3.Text = userInfo;
        }

        private void btnGetProfile_Click(object sender, EventArgs e)
        {
            waitingMessage(lb1);

            Dictionary<string, string> profileUser = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(rtxb3.Text);

            // Download ảnh đại diện của user
            using (WebClient client = new WebClient())
            {
                string path = Environment.CurrentDirectory + @"/userPicture.jpg";
                client.DownloadFile(profileUser["picture"], path);

                pctbUser.Image = new Bitmap(path);
            }

            lb1.Text = "Profile User";

            string[] listInfo = { "email", "name", "locale"};

            foreach(string item in listInfo)
            {
                ListViewItem viewItem = new ListViewItem();

                viewItem.Text = item + ": " + profileUser[item];

                lstvProfile.Items.Add(viewItem);
            }
        }

        void waitingMessage(Control textBox)
        {
            textBox.Text = "Please wait a moment!";
        }
    }
}
