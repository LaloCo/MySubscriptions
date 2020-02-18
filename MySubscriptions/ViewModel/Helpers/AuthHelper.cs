using System;
using System.Threading.Tasks;

namespace MySubscriptions.ViewModel.Helpers
{
    public interface IAuth
    {
        Task<bool> RegisterUser(string name, string email, string password);
        Task<bool> AuthenticateUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();
    }

    public class Auth
    {
        private static IAuth auth;

        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            return await auth.RegisterUser(name, email, password);
        }

        public static async Task<bool> AuthenticateUser(string email, string password)
        {
            return await auth.AuthenticateUser(email, password);
        }

        public static bool IsAuthenticated()
        {
            return auth.IsAuthenticated();
        }

        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }
    }
}
