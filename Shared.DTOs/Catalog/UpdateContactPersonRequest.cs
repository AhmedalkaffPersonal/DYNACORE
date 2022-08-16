﻿namespace Shared.DTOs.Catalog
{
    public class UpdateContactPersonRequest : IMustBeValid
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
