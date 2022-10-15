namespace BlazorAppCodingDroplets.Authentication
{
    public class UserAccountServer
    {
        //硬编码，实际项目请使用数据库
        private List<UserAccount> _users;

        public UserAccountServer()
        {
            _users = new List<UserAccount>()
            {
                new UserAccount() { UserName = "admin", Password = "admin", Role = "admin" },
                new UserAccount() { UserName = "user", Password = "user", Role = "user" },
            };
        }

        public UserAccount? GetUserByName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }

    }
}
