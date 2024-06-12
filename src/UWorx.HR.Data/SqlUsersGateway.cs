using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UWorx.HR.Data.Helpers;

namespace UWorx.HR.Data
{
    public class SqlUsersGateway : IUsersGateway
    {
        readonly string connectionString;

        public SqlUsersGateway(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserInfo GetUserInformation(string email)
        {
            var sql = "select FirstName, MiddleName, LastName from users where UserEmail = @email";
            var reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text,
                sql, new[] { new SqlParameter("@email", email) });

            while (reader.Read())
            {
                var info = new UserInfo()
                {
                    FirstName = SqlReaderHelper.GetValue<string>(reader, "FirstName"),
                    MiddleName = SqlReaderHelper.GetValue<string>(reader, "MiddleName"),
                    LastName = SqlReaderHelper.GetValue<string>(reader, "LastName")
                };

                return info;
            }

            return null;
        }

        public bool UpdatePassword(string email, string password)
        {
            var sql = "update users set UserPassword = @password where UserEmail = @email";
            int affectedRows = SqlHelper.ExecuteNonQuery(this.connectionString, CommandType.Text,
                sql, new[]
                {
                    new SqlParameter(@"email", email),
                    new SqlParameter(@"password", password)
                });

            return affectedRows > 0;
        }

        public bool UpdateName(string email, string firstName, string middleName = null, string lastName = null)
        {
            string sql = null;
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@email", email),
                new SqlParameter("@firstName", firstName)
            };

            if (!string.IsNullOrWhiteSpace(middleName) && !string.IsNullOrWhiteSpace(lastName))
            {
                sql = "update users set FirstName = @firstName, MiddleName = @middleName, LastName = @lastName where UserEmail = @email";
                parameters.Add(new SqlParameter("@middleName", middleName));
                parameters.Add(new SqlParameter("@lastName", lastName));
            }
            else if (!string.IsNullOrWhiteSpace(lastName))
            {
                sql = "update users set FirstName = @firstName, LastName = @lastName where UserEmail = @email";
                parameters.Add(new SqlParameter("@lastName", lastName));
            }
            else if (!string.IsNullOrWhiteSpace(middleName))
            {
                sql = "update users set FirstName = @firstName, MiddleName = @middleName where UserEmail = @email";
                parameters.Add(new SqlParameter("@middleName", middleName));
            }

            if (!string.IsNullOrWhiteSpace(sql))
            {
                int affectedRows = SqlHelper.ExecuteNonQuery(this.connectionString, CommandType.Text,
                    sql, parameters.ToArray());

                return affectedRows > 0;
            }

            return false;
        }
    }
}
