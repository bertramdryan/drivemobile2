using System;
using System.Collections.Generic;

using System.Text;

namespace DriveMobile.Helpers
{
    public class Constants
    {
        // Drive API
        public const string DRIVE_BASE_URL = "https://devdriveapi.hollandspecial.com{0}";
        public const string AUTH = "/api/token";
        public const string POWER = "/api/power";
        public const string MANIFEST = "/api/mobile/manifest2/";
        public const string PAYSHEET = "/api/mobile/currentPaySheet";
        public const string SAVE_MULTIPLE_PAYSHEET_ENTRIES = "/api/mobile/saveMultiplePaySheetEntry";
        public const string LOGOUT = "/api/logout";

        // KeepTrucking API
        public const string KEEPTRUCKIN_LOOKUP_URL = "https://api.keeptruckin.com/v1/vehicles/lookup?number={0}";
        public const string KEEPTRUCKIN_LOCATION = "https://api.keeptruckin.com/v1/vehicle_locations?vehicle_ids={0}";
        public const string KT_API_KEY = "3b08a885-6da0-4872-bd1a-a09aefbc87ab";

        // Driver Survey API
        public const string SURVEY_BASE_URL = "https://survey.hollandspecial.com";
        public const string HAPPYINESS_QUESTION = "/api/wellness_questions/";
        public const string SURVEY_API_KEY = "m6athoKk.yJNK9IsH9Uk6zBDLBZbUZTCjamHLb98w";
    }
}
