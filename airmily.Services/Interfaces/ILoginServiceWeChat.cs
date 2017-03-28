namespace airmily.Services.Interfaces
{
    public interface ILoginServiceWeChat
    {
        bool IsWXSupported();
        void WXLogin();
    }
}