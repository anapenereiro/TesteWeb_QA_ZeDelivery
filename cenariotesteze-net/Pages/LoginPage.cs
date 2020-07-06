using Coypu;

namespace Zedelivery.Pages
{
    public class LoginPage
    {

        private readonly BrowserSession _browser;

        public LoginPage(BrowserSession browser)
        {
            _browser = browser;

        }

        public void Load()
        {
            _browser.Visit("/");
        }
        //Custom actions dentro do page objects
        public void Whit(string email, string pass)
        {
            _browser.ClickButton("age-gate-button-yes");
            _browser.ClickButton("welcome-button-sign-in");
            _browser.ClickButton("login-home-email-button-sign-in");
            _browser.FillIn("login-mail-input-email").With(email);
            _browser.FillIn("login-mail-input-password").With(pass);
            _browser.ClickButton("login-mail-button-sign-in");

        }

    }

}