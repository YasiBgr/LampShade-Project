namespace _0_FramBase.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        void Signin(AuthViewModel command);
        bool IsAuthenticated();
    }
}
