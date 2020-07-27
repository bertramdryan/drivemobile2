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

        // KeepTrucking API
        public const string KEEPTRUCKIN_URL = "https://api.keeptruckin.com";
        public const string KT_API_KEY = "3b08a885-6da0-4872-bd1a-a09aefbc87ab";
        public const string LOOKUP = "/v1/vehicles/lookup";
        public const string LOCATION = "/v1/vehicle_locations";

        // Driver Survey API
        public const string SURVEY_BASE_URL = "https://survey.hollandspecial.com";
        public const string HAPPYINESS_QUESTION = "/api/wellness_questions/";
        public const string SURVEY_API_KEY = "m6athoKk.yJNK9IsH9Uk6zBDLBZbUZTCjamHLb98w";
    }
}
