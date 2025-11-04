using System;

namespace HospitalManagementSystem.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNumber { get; set; }
        public string Role { get; set; } // Doctor, Nurse, Secretary, Admin
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        
        public Staff()
        {
            HireDate = DateTime.Now;
            IsActive = true;
        }
        
        public Staff(string firstName, string lastName, string tcNumber, string role,
                    string phoneNumber, string email, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            TCNumber = tcNumber;
            Role = role;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            HireDate = DateTime.Now;
            IsActive = true;
        }
        
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        
        public bool IsDoctor()
        {
            return Role.ToLower() == "doctor";
        }
        
        public bool IsNurse()
        {
            return Role.ToLower() == "nurse";
        }
        
        public bool IsSecretary()
        {
            return Role.ToLower() == "secretary";
        }
        
        public bool IsAdmin()
        {
            return Role.ToLower() == "admin";
        }
        
        public override string ToString()
        {
            return $"{GetFullName()} - {Role}";
        }
    }
}
