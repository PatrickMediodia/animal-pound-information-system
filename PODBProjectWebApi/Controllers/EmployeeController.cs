using Newtonsoft.Json;
using PODBProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;

namespace PODBProjectWebApi.Controllers
{
    
    public class EmployeeController : ApiController
    {
        Employee employee;

        public SqlConnection con = new SqlConnection("Server=tcp:podbpoject.database.windows.net,1433;Initial Catalog=PODBProject;Persist Security Info=False;User ID=PODBProject;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public SqlCommand comm;

        public string hash(string password)
        {
            return BitConverter.ToString(new SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(password))).Replace("-", string.Empty);
        }
        public SqlDataReader Reader(string query, IDictionary<string, object> parameters)
        {
            comm = new SqlCommand(query, con);

            foreach (var param in parameters)
            {
                comm.Parameters.AddWithValue(param.Key, param.Value);
            }

            return comm.ExecuteReader();
        }

        private void Command(string queryString, Dictionary<string, object> values)
        {
            comm = new SqlCommand(queryString, con);

            foreach (var parameter in values)
            {
                comm.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
            comm.ExecuteNonQuery();
            comm.Connection.Close();
        }
        [HttpPost]
        public bool Register(string accountId, string employeeId, string employeeName, string email, string password)
        {

            var query = "Insert into [dbo].[CVOEmployee](accountId , employeeId , employeeName , email , password) " +
                                                    "values(@accountId, @employeeId, @employeeName , @email , @password) ";
            var param = new Dictionary<string, object>
                {
                    {"@accountId", accountId},
                    {"@employeeId" , employeeId},
                    {"@employeeName", employeeName},
                    {"@email", email},
                    {"@password", hash(password)},
                };

            con.Open();
            Command(query, param);
            con.Close();

            return true;
        }
        [HttpPost]
        public Employee Login (string email, string password)
        {
            string query = "select * from [dbo].[CVOEmployee] where email=@email and password=@password";
            var parameters = new Dictionary<string, object>
            {
                {"@email", email },
                {"@password", hash(password)}
            };
            con.Open();
            var read = Reader(query, parameters);
            if (read.HasRows)
            {
                read.Read();
                employee = new Employee()
                {
                    accountId = read["accountId"].ToString(),
                    employeeId = read["employeeId"].ToString(),
                    employeeName = read["employeeName"].ToString(),
                    email = read["email"].ToString(),
                    password = "password",
                    confirmPassword = "confirmPassword"
                };
            }
            else
            {
                return employee = null;
            }
            //read.Close();
            //con.Close();
            return employee;
        }
        public bool ChangePassword(string email, string pass, string newpass)
        {
            string query = "select * from [dbo].[CVOEmployee] where email=@email and password=@password";
            var parameters = new Dictionary<string, object> 
            {
                {"@email", email },
                {"@password", hash(pass) }
            };
            con.Open();
            var read = Reader(query, parameters);
            if (read.HasRows)
            {
                query = "update [dbo].[CVOEmployee] set password = @NewPassword where email = @email";
                parameters = new Dictionary<string, object>
                {
                    {"@email", email },
                    {"@NewPassword", hash(newpass) }
                };
                read.Close();
                Command(query, parameters);
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}  
    
