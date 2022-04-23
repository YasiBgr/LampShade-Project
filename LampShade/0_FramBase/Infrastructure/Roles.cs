﻿namespace _0_FramBase.Infrastructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string SystemUser = "2";
        public const string ColleagueUser = "3";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 2:
                    return "کاربر";
                case 3:
                    return "همکار";
                default:
                    return "";
            }
        }
    }
}
