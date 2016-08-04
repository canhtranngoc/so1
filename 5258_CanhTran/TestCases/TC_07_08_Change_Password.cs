using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sele_5258_CanhTran.Common;
using Sele_5258_CanhTran.PageObjects;


namespace Sele_5258_CanhTran.TestCases
{
    [TestClass]
    public class TC_07_08_Change_Password
    {
        [TestMethod]
        public void TC07_User_can_change_password()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with valid account
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Click on "Change Password" tab
            ChangePasswordPage changePasswordPage = loginPage.GotoChangePasswordPage();

            //4. Enter valid value into all fields.
            //5. Click on "Change Password" button
            changePasswordPage.ChangePassword(Constant.ValidPassword, Constant.NewPassword, Constant.NewPassword);

            // VP. Password isn't changed and message "The password confirmation does not match the new password." appears.
            CommonFunctions.CheckTextDisplays(Constant.ChangePasswordSuccessMessage, changePasswordPage.GetChangePasswordSuccessMessage());

            // Logout then Login again to make sure user can login with new password
            changePasswordPage.LogOut();
            homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.NewPassword);

            // VP. User is logged into Railway, Welcome user message is displayed
            CommonFunctions.CheckTextDisplays(Constant.WelcomeMessage, loginPage.GetWelcomeUserMessage());

        }

        [TestMethod]
        public void TC08_User_cannot_change_password_when_new_password_and_confirm_password_are_different()
        {
            //1. Navigate to QA Railway Website
            HomePage homePage = new HomePage();
            homePage.Open();

            //2. Login with valid account
            LoginPage loginPage = homePage.GotoLoginPage();
            loginPage.Login(Constant.ValidUsername, Constant.ValidPassword);

            //3. Click on "Change Password" tab
            ChangePasswordPage changePasswordPage = loginPage.GotoChangePasswordPage();

            //4. Enter valid information into "Current Password" textbox but enter 12345678 into "New Password" textbox and 12345679 into "Confirm Password" textbox.
            //5. Click on "Change Password" button
            changePasswordPage.ChangePassword(Constant.ValidPassword, Constant.NewPassword, Constant.NewDifferentPassword);

            //VP. Password isn't changed and message "The password confirmation does not match the new password." appears.
            CommonFunctions.CheckTextDisplays(Constant.ErrorDifferentNewAndConfirmPasswordMessage, changePasswordPage.GetErrorDifferentNewAndConfirmPasswordMessage());
        }

        public TestContext TestContext { get; set; }

        [TestCleanup]

        public void Cleanup()
        {
            switch (TestContext.TestName)
            {
                case "TC07_User_can_change_password":
                    GeneralTest.TestCleanupTC07();
                    new HomePage().LogOut();
                    break;
                case "TC08_User_can_not_change_password_when_New_Password_and_Confirm_Password_are_different":
                    new HomePage().LogOut();
                    break;
                default:
                    new HomePage().LogOut();
                    break;
            }
        }
    }
}
