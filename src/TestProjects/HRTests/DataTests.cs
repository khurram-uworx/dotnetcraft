using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using UWorx.HR.Data;

namespace HRTests
{
    [TestClass]
    public class DataTests
    {
        readonly string testUser = "test@email.com";
        readonly string connectionString = "Server=.;Database=HumanResources;Integrated Security=True;";
        //TrustServerCertificate=True;Application Name=

        public DataTests()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Debug.WriteLine("Connection successful!");

                    string sql = "select UserIndex from users where UserEmail = @email";
                    var commandSelect = new SqlCommand(sql, connection);
                    commandSelect.Parameters.Add(new SqlParameter("@email", this.testUser));
                    int userIndex = Convert.ToInt32(commandSelect.ExecuteScalar()); // if row is missing we will get null
                    if (userIndex <= 0)                                             // convert will make it 0
                    {
                        //we need to create a test user
                        sql = "insert into users (UserEmail, UserPassword, FirstName) values (@email, 'SomeRandomValue', 'First')";
                        var commandInsert = new SqlCommand(sql, connection);
                        commandInsert.Parameters.Add(new SqlParameter("@email", this.testUser));
                        int affectedRows = commandInsert.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }

        void usersGatewayTests(IUsersGateway gateway)
        {
            var userInfo = gateway.GetUserInformation(this.testUser);
            Assert.IsTrue(null != userInfo);
            Assert.IsTrue(userInfo.FirstName.Length > 0);

            bool pass1 = gateway.UpdatePassword(this.testUser, "NewRandomPassword1");
            bool pass2 = gateway.UpdatePassword(this.testUser, "NewRandomPassword");
            Assert.IsTrue(pass1 || pass2); // one of this attempt should pass

            bool name1 = gateway.UpdateName(this.testUser, "First Name 1", middleName: null, lastName: null);
            bool name2 = gateway.UpdateName(this.testUser, "First Name", middleName: null, lastName: null);
            Assert.IsTrue(name1 || name2);
        }

        [TestMethod]
        public void SqlTestScenario()
        {
            IUsersGateway gateway = new SqlUsersGateway(this.connectionString);
            usersGatewayTests(gateway);
        }

        [TestMethod]
        public void LinqSqlTestScenario()
        {
            IUsersGateway gateway = new LinqSqlUsersGateway(this.connectionString);
            usersGatewayTests(gateway);
        }
    }
}
