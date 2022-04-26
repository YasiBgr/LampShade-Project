namespace _0_FramBase.Infrastructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string SystemUser = "2";
        public const string ColleagueUser = "3";

        public static string GetRoleBy(long id)
        {
            return id switch
            {
                1 => "مدیرسیستم",
                3 => "همکار",
                _ => "",
            };
        }
    }
}
