using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }

        public User(DataRow dr)
        {

            this.Id = dr.Field<int>("Id");
            this.FirstName = dr.Field<string>("FirstName")!;
            this.LastName = dr.Field<string>("LastName")!;
            this.Email = dr.Field<string>("Email")!;
            this.CompanyId = dr.Field<int>("CompanyId");

        }

    }
}
