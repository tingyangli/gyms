using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BLL;
namespace GYMS
{
    public partial class FormEmail : FormFatherPro
    {
        PersonModel personModel = new PersonModel();
        public FormEmail()
        {
            InitializeComponent();
        }

        private void FormEmail_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            label3.Text = Convert.ToString(rd.Next(100000, 999999));
        }

        private void ucBtnExt4_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            if (ucTextBoxEx2.InputText == label3.Text)
            {
                MessageBox.Show("验证码正确！");
                ucBtnExt2.Enabled = true;
                label4.Text = "新的密码";
                label2.Text = "确认密码";
                ucBtnExt1.Visible = false;
                ucBtnExt2.Visible = false;
                ucBtnExt3.Visible = true;
                ucTextBoxEx1.InputText = "";
                ucTextBoxEx2.InputText = "";//清空
                ucTextBoxEx1.PasswordChar ='*';
                ucTextBoxEx2.PasswordChar = '*';
                ucTextBoxEx1.PromptText = "请输入密码：6-15";
                ucTextBoxEx2.PromptText = "请输入密码：6-15";
                //ucBtnExt4.Visible = true;
            }
            else
            {
                MessageBox.Show("您的验证码错误了！");
                ucTextBoxEx1.InputText = "";
                ucTextBoxEx2.InputText = "";//清空
            }
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            //首先判断一下邮箱格式对不对
            if (new PersonBLL().IsEmail(ucTextBoxEx1.InputText))
            {
                personModel.Email = ucTextBoxEx1.InputText;
                if (new PersonBLL().isExistEmail(personModel) == false)
                {
                    MessageBox.Show("邮箱未被注册，请先注册");
                    return;
                }
                //实例化一个发送邮件类。
                MailMessage mailMessage = new MailMessage();
                //发件人邮箱地址，方法重载不同，可以根据需求自行选择
                mailMessage.From = new MailAddress("1871478140@qq.com");
                //收件人邮箱地址
                mailMessage.To.Add(new MailAddress(ucTextBoxEx1.InputText));//不能为空，或更改为邮箱
                                                                   //邮件标题
                mailMessage.Subject = "身份验证";
                //邮件内容
                mailMessage.Body = "这里是你的验证码：" + label3.Text;
                //实例化一个SmtpClient类
                SmtpClient client = new SmtpClient();
                //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com
                client.Host = "smtp.qq.com";
                //使用安全加密连接
                client.EnableSsl = true;
                //不和请求一块发送
                client.UseDefaultCredentials = false;
                //验证发件人身份(发件人的邮箱，邮箱里的生成授权码)
                client.Credentials = new NetworkCredential("1871478140@qq.com", "ihxcuhdkrhndggji");
                //发送
                try
                {
                    client.Send(mailMessage);//在QQ邮箱内开启IMAP/SMTP服务
                    MessageBox.Show("已成功发送。请等待约3秒以获取验证码！", "提示");
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show("发送失败，请确认网络畅通或邮箱是否存在！");
                }
            }
            else
            {
                MessageBox.Show("邮箱格式错误！");
            }
        }

        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
        {
            personModel.Password = ucTextBoxEx1.InputText.Trim();
            personModel.Password2 = ucTextBoxEx2.InputText.Trim();
            if (new PersonBLL().UpdatePwd(personModel, out string messageStr) == true)
            {
                MessageBox.Show(messageStr);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
    }
}
