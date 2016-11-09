using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Util;

namespace mailsendingtest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MailMessage message = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); // gmail은 587번 포트 사용

            message.From = new MailAddress(Global.MAILADDR); // 발신자
            message.To.Add(new MailAddress(Global.MAILREC)); // 수신자
            message.IsBodyHtml = true;
            message.Subject = "c#에서 전송하는 메일입니다"; // 메일 제목
            message.Body = "c#에서 전송한 메일의 내용입니다"; // 메일 내용 
            message.SubjectEncoding = System.Text.Encoding.UTF8; // 제목 텍스트 인코딩
            message.BodyEncoding = System.Text.Encoding.UTF8; // 내용 텍스트 인코딩

            try
            { 
                client.EnableSsl = true; // ssl 허용
                client.DeliveryMethod = SmtpDeliveryMethod.Network; // 전송메소드 설정
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Global.MAILID, Global.MAILPW); // 메일 자격 내용 설정
                client.Send(message); // 메일 전송
            }
            catch (Exception e)
            {
                var a = e.ToString();
            }

            return View();
        }
    }
}