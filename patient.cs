using System;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNumber { get; set; } // Turkish ID number
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public Patient()
        {
            RegistrationDate = DateTime.Now;
        }
        
        public Patient(string firstName, string lastName, string tcNumber, DateTime dateOfBirth, 
                      string phoneNumber, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            TCNumber = tcNumber;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            RegistrationDate = DateTime.Now;
        }
        
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        
        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
        
        public override string ToString()
        {
            return $"Patient: {GetFullName()} (TC: {TCNumber}) - Age: {GetAge()}";
        }
    }
}
