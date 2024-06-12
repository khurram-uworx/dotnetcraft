using System.Linq;
using UWorx.HR.Data.Linq;

namespace UWorx.HR.Data
{
    public class LinqSqlUsersGateway : IUsersGateway
    {
        readonly string connectionString;

        public LinqSqlUsersGateway(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserInfo GetUserInformation(string email)
        {
            using(var db = new HRDataClassesDataContext(this.connectionString))
            {
                var q = from u in db.Users
                        where u.UserEmail == email
                        select new { u.FirstName, u.LastName };
                var r = q.FirstOrDefault();

                if (null != r)
                    return new UserInfo()
                    {
                        FirstName = r.FirstName,
                        MiddleName = null,
                        LastName = r.LastName
                    };
            }

            return null;
        }

        public bool UpdateName(string email, string firstName, string middleName = null, string lastName = null)
        {
            using (var db = new HRDataClassesDataContext(this.connectionString))
            {
                var q = from u in db.Users
                        where u.UserEmail == email
                        select u; // we need to get the whole entity for update to work
                var r = q.FirstOrDefault();

                int rowAffected = 0;
                if (null != r)
                {
                    rowAffected++;
                    r.FirstName = firstName;
                    r.LastName = lastName;
                }

                if (rowAffected > 0)
                {
                    db.SubmitChanges(); // if we call it without any changes; will throw exception
                    return true;
                }

                return false;
            }
        }

        public bool UpdatePassword(string email, string password)
        {
            using (var db = new HRDataClassesDataContext(this.connectionString))
            {
                var q = from u in db.Users
                        where u.UserEmail == email
                        select u;
                var r = q.FirstOrDefault();

                int rowAffected = 0;
                if (null != r) // code of this method is very much like above method
                {
                    rowAffected++;
                    r.UserPassword = password;
                }

                if (rowAffected > 0)
                {
                    db.SubmitChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
