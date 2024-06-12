namespace UWorx.HR.Data
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public interface IUsersGateway
    {
        UserInfo GetUserInformation(string email);
        bool UpdatePassword(string email, string password);
        bool UpdateName(string email, string firstName, string middleName = null, string lastName = null);
    }
}
