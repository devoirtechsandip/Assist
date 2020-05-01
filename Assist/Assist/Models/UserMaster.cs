using System;
using System.Collections.Generic;
using System.Text;

namespace Assist.Models
{
    public class UserMaster
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }       
        public string CompanyId { get; set; }
        public string GenderId { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string RoleId { get; set; }
    }
}
