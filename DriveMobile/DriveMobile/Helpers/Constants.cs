using System;
using System.Collections.Generic;

using System.Text;

namespace DriveMobile.Helpers
{
    public class Constants
    {
        #region Drive API
        // Drive API
        public const string DRIVE_BASE_URL = "https://devdriveapi.hollandspecial.com{0}";
        public const string AUTH = "/api/token";
        public const string POWER = "/api/power";
        public const string MANIFEST = "/api/mobile/manifest2/";
        public const string PAYSHEET = "/api/mobile/currentPaySheet";
        public const string SAVE_MULTIPLE_PAYSHEET_ENTRIES = "/api/mobile/saveMultiplePaySheetEntry";
        public const string LOGOUT = "/api/logout";
        #endregion Drive API

        #region KeepTrucking API
        // KeepTrucking API
        public const string KEEPTRUCKIN_LOOKUP_URL = "https://api.keeptruckin.com/v1/vehicles/lookup?number={0}";
        public const string KEEPTRUCKIN_LOCATION = "https://api.keeptruckin.com/v1/vehicle_locations?vehicle_ids={0}";
        public const string KT_API_KEY = "3b08a885-6da0-4872-bd1a-a09aefbc87ab";
        #endregion KeepTrucking API

        #region Driver Survey API
        // Driver Survey API
        public const string SURVEY_BASE_URL = "https://survey.hollandspecial.com";
        public const string HAPPYINESS_QUESTION = "/api/wellness_questions/";
        public const string SURVEY_API_KEY = "m6athoKk.yJNK9IsH9Uk6zBDLBZbUZTCjamHLb98w";
        #endregion Driver Survey API

        #region Display Alerts
        // Display Alerts
        public const string PAYSHEET_WARNING_TITLE = "Paysheet Error";
        public const string PAYSHEET_WARNING_MESSAGE = "Something went wrong creating the paysheet entry, Please login again.";
        public const string PAYSHEET_EXCEPTION = "Could not create a paysheet entry, please restart the app or contact dispatch";

        public const string SWITCH_POWER_CHECK_TITLE = "Switching Power";
        public const string SWITCH_POWER_MESSAGE = "Are you switching powers?";

        public const string LOGIN_ERROR_TITLE = "Login Error";
        public const string LOGIN_ERROR_MESSAGE = "Something went wrong during the log in process, Please Try again.";
        #endregion Display Alerts

    }
}
