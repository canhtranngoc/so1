using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sele_5258_CanhTran.Common;
using Sele_5258_CanhTran.PageObjects;

namespace Sele_5258_CanhTran.TestCases
{
    [TestClass]
    public class TC_05_09_Create_New_Account
    {
        [TestMethod]
        public void TC05_User_can_create_new_account()
        {
            // 1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            // 2. Click on "Register" tab
            RegisterPage registerPage = homePage.GotoRegisterPage();

            // 3. Enter valid information into all fields
            // 4. Click on "Register" button
            registerPage.Register(Constant.RandomEmailRegister, Constant.ValidPassword, Constant.ValidPassword, Constant.ValidPid);

            // VP. New account is created and message "Thank you for registering your account" appears.
            CommonFunctions.CheckTextDisplays(Constant.ThanksRegisteringMessage, registerPage.GetThanksRegisteringMessage());
        }

        [TestMethod]
        public void TC09_User_cannot_create_account_with_confirm_password_isnot_the_same_as_password()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Click on "Register" tab
            RegisterPage registerPage = homePage.GotoRegisterPage();

            //3. Enter valid information into all fields except "Confirm password" is not the same as "Password"
            //4. Click on "Register" button
            registerPage.Register(Constant.RandomEmailRegister, Constant.ValidPassword, Constant.InvalidPassword, Constant.ValidPid);

            // VP. New account isn't created and message "The two passwords do not match" appears.
            CommonFunctions.CheckTextDisplays(Constant.ErrorRegisteringConfirmPasswordMessage, registerPage.GetErrorConfirmPasswordMessage());
        }
    }
}
