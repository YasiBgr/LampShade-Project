namespace _0_FramBase.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public long RoleId { get; set; }

        public AuthViewModel(long id, string username, string fullName, long roleId)
        {
            Id = id;
            Username = username;
            FullName = fullName;
            RoleId = roleId;
        }
    }
}