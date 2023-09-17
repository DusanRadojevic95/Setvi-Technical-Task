using DataAccess.Entities;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Services
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly IConfiguration _configuration;

        public UserDataAccess(IConfiguration Configuration) 
        {
            _configuration = Configuration;
        }


        public List<User> getUsersForCompany(int companyId)
        {
            List<User> userList = new List<User>();
            string conString = _configuration.GetConnectionString("DefaultConnection")!;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.GetCompanyUsers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@companyId", SqlDbType.Int).Value = companyId;

                        con.Open();

                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        foreach (DataRow dr in dt.Rows)
                        {
                            userList.Add(new User(dr));
                        }

                    }
                }

                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal server error, please contact an administrator");
            }
        }


        //CompanyID was specified as NVarchar in the task, use int instead?
        public User createUserForCompany(string firstName, string lastName, string email, string companyId)
        {
            User dbUser;
            string conString = _configuration.GetConnectionString("DefaultConnection")!;

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.AddUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstName;
                        cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                        cmd.Parameters.Add("@companyId", SqlDbType.NVarChar).Value = companyId;

                        con.Open();

                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        dbUser = new User(dt.Rows[0]);
                    }
                }

                return dbUser;
            }

            catch(Exception ex) 
            {
                throw new Exception("Internal server error, please contact an administrator");
            }
        }
    }
}
