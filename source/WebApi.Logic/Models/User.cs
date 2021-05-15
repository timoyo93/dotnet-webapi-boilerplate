using System;

namespace WebApi.Logic.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}