using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Mail;

namespace EmailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i <= 1; i++)
            //{
            //    SendMail(i);
            //    Thread.Sleep(1000 * 60);
            //}
            SendMail(1);
            Console.WriteLine("----------邮件发送完毕----------------");
            Console.ReadKey();
        }

        public static void SendMail(int i)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.qq.com");//发送邮件的服务器地址
            //SmtpServer.Port = 587;//端口，可以不设
            SmtpServer.Credentials = new System.Net.NetworkCredential("532029887@qq.com", "rj2001");//验证用户名，密码
            SmtpServer.EnableSsl = true;//是否加密
            MailMessage mail = new MailMessage();//创建要发送的邮件信息
            mail.From = new MailAddress("532029887@qq.com");//发件人地址
            //mail.Bcc.Add("2983237183@qq.com");
            mail.Bcc.Add("2140768898@qq.com");
            //mail.Bcc.Add("2140768898@qq.com");
            //mail.Bcc.Add("3044796305@qq.com");
            mail.Subject = "2去京都-测试邮件-"+i;//邮件标题
            mail.Body = "<a href='http://www.qujingdu.com'>去京都</a>";//邮件的具体内容
            mail.IsBodyHtml = true;//邮件的内容是否设置为html属性，
            try
            {
                SmtpServer.Send(mail);
                Console.WriteLine("成功-" + i);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"失败-{i},原因：{ex.Message}");
            }
        }
    }
}
