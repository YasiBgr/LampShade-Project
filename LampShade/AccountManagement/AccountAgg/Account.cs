using _0_FramBase.Domain;
using AccountManagement.RoleAgg;

namespace CommentManagement.CommentAgg
{
    public class Account : EntityBase
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public long RollId { get; private set; }
        public string Mobail { get; private set; }
        public string ProfilePhoto { get; private set; }
        public Role Role{ get; private set; }
        public Account(string fullname, string username, string password,
            long rollId, string mobail, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            RollId = rollId;
            Mobail = mobail;
            ProfilePhoto = profilePhoto;
        }
        public void Edit(string fullname, string username,long rollId, string mobail, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            RollId = rollId;
            Mobail = mobail;
            if(!string.IsNullOrWhiteSpace(profilePhoto))
            ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}

