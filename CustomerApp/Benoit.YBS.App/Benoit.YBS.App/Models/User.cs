using System;

namespace Benoit.YBS.App.Models
{
    public class User
    {
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool IsActivated { get; set; }
    }
}