using System;
using System.ComponentModel.DataAnnotations;

namespace ENMT_V2.Core.Model
{
    public class LoginAccount
    {
        [Key]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
