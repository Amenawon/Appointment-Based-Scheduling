﻿namespace WebApi.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsRegistered { get; set; }
    }
}
