using System;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace LoginOWIN
{
    public partial class Startup
    {
        // Para obter mais informações sobre a autenticação de configuração, visite https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
                AuthenticationMode = AuthenticationMode.Active
                //,
                //Provider = new CookieAuthenticationProvider
                //{
                //    // Permite que o aplicativo valide o carimbo de segurança quando o usuário efetuar login.
                //    // Este é um recurso de segurança que é usado quando você altera uma senha ou adiciona um login externo à sua conta.  
                //    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                //        validateInterval: TimeSpan.FromMinutes(30),
                //        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                //}
            });            
        }
    }
}