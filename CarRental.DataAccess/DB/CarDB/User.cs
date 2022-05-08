using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.DataAccess.DB.CarDB
{
    public partial class User
    {
        public uint Id { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public sbyte Status { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Creator { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string Updator { get; set; }
        public bool? ValidFlag { get; set; }
    }
}
