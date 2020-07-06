using NUnit.Framework;
using System.Threading;
using Zedelivery.Pages;
using Zedelivery.Common;


namespace Zedelivery.Tests
{
    public class LoginTests : BaseTest
    {

        //Teste de login e-mail com sucesso.
        [Test]
        [Category("Critical")]
        public void SucessfullyLoginEmail()
        {
            var loginPage = new LoginPage(Browser);

            loginPage.Load();
            loginPage.Whit("anapenereiro@gmail.com","teste123");

            Thread.Sleep(3000);

            var loggedUser = Browser.FindCss(".css-10zhe0i-textContainer .css-rcr9zy-textBase-UserCard");
            Assert.AreEqual("Olá, Ana", loggedUser.Text);
            Thread.Sleep(3000);

        }   

        [Test]        
        public void FailLoginEmail()
        {
            var loginPage = new LoginPage(Browser);

            loginPage.Load();
            loginPage.Whit("anapenereiro@gmail.com","teste587961");
            
            var alertMessage = Browser.FindId("global-message-Senha inválida");
            Assert.AreEqual("Senha inválida", alertMessage.Text);
            Thread.Sleep(3000);

        }      
   


    }
}