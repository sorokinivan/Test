﻿using System.Security.Principal;

namespace WebApplication1.Models
{
    public class User : IIdentity
    {
        public User(
            string authenticationType,
            bool isAuthenticated,
            string name
            )
        {
            AuthenticationType = authenticationType;
            IsAuthenticated = isAuthenticated;
            Name = name;
        }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string Name { get; }
    }
}
