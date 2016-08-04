using System;
using OpenQA.Selenium;

namespace Sele_5258_CanhTran.Common
{
    class Constant
    {
        public static IWebDriver Webdriver;
        public const string HomePageUrl = "http://192.168.189.49:8099/Page/HomePage.cshtml";

        public const string ValidUsername = "canh.tran@mailinator.com";
        public const string InvalidUsername = "canhcanhcanh@mailinator.com";
        public const string BlankUsername = "";
        
        public const string ValidPassword = "123456789";
        public const string InvalidPassword = "1x1x1x1x1x1x1";
        public const string BlankPassword = "";
        public const string NewPassword = "123456789abc";
        public const string NewDifferentPassword = "123456123456";
        
        public const string ValidPid = "123456789";
       
        public const string WelcomeMessage = "Welcome " + ValidUsername;

        public const string ThanksRegisteringMessage = "Thank you for registering your account";
        public const string ErrorRegisteringConfirmPasswordMessage = "The two passwords do not match";

        public const string ErrorLoginMsgBlankUsername = "There was a problem with your login and/or errors exist in your form.";
        public const string ErrorLoginMsgForServerTime = "You have used 4 out of 5 login attempts. After all 5 have been used, you will be unable to login for 15 minutes.";
        public const string ErrorLoginMsgInactiveAccount = "Invalid username or password. Please try again.";
        public const string ErrorLoginMsgInvalidPassword = "There was a problem with your login and/or errors exist in your form.";

        public const string ChangePasswordSuccessMessage = "Your password has been updated";
        public const string ErrorDifferentNewAndConfirmPasswordMessage = "The password confirmation does not match the new password.";
      
        public const int ServeralTimeLogin = 4;

        public static readonly string RandomEmail = Convert.ToString(DateTime.Now.ToString("dMhhmmssffff") + "@mailinator.com");
        public static readonly string RandomEmailRegister = Convert.ToString(DateTime.Now.ToString("ddMmhhmmssffff") + "@mailinator.com");

        public const string TicketBookedSuccessfullyMessage = "Ticket booked successfully!";
        public const string ConfirmCancelTicketMessage = "Are you sure?";

        public static string ErrorFilterMessage = "Sorry, can't find any results that match your filters." + Environment.NewLine + "Please change the filters and try again.";
        public static readonly string DepartDate = Convert.ToString(DateTime.Now.AddDays(3).ToString("M/d/yyyy"));
        public const string DepartStation = "Sài Gòn";
        public const string ArriveStation = "Đà Nẵng";
        public const string SeatType = "Soft bed with air conditioner";
        public const string TicketAmount = "1";
    }
}
