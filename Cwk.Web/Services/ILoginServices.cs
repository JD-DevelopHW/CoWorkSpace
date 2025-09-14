namespace Cwk.Web.Services
{
    public interface ILoginServices
    {
        Task Login(string token);

        Task Logout();
    }
}
