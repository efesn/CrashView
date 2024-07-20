﻿namespace CrashView.Entities
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

}
