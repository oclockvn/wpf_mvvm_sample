namespace Core.Services
{
    public interface IAuthService
    {
        Task<bool> IsValidAsync(string username, string password);
    }

    internal class AuthService : IAuthService
    {
        public async Task<bool> IsValidAsync(string username, string password)
        {
            await Task.Delay(100);

            // call services or db query
            if (password == "123")
            {
                return true;
            }

            return false;
        }
    }
}
