using Framework.Modelo.Entidade.Basico;
using Framework.View.Basico;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Framework.View
{
    public class ViewLogin : ViewMestre<CadastroBasico>
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            string userData = "";
            string userName = "";
            // initialize FormsAuthentication
            FormsAuthentication.Initialize();

            // create a new ticket used for authentication
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

            // encrypt the cookie using the machine key for secure transport
            string encTicket = FormsAuthentication.Encrypt(authTicket);

            // create and add the cookies to the list for outgoing response
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            Response.Cookies.Add(faCookie);

            Response.Redirect("/Admin/WebForm1.aspx");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        //HttpCookie cookie = HttpContext.Current.Request.Cookies["UserRole"];
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        // get the stored user-data, in this case it's our users' role information
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }
    }
}
