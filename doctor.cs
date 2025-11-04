using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string TCNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal ConsultationFee { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        
        // Navigation properties
        public List<Appointment> Appointments { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        
        public Doctor()
        {
            Appointments = new List<Appointment>();
            Prescriptions = new List<Prescription>();
            HireDate = DateTime.Now;
            IsActive = true;
        }
        
        public Doctor(string firstName, string lastName, string specialty, string tcNumber, 
                     string phoneNumber, string email, decimal consultationFee)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty;
            TCNumber = tcNumber;
            PhoneNumber = phoneNumber;
            Email = email;
            ConsultationFee = consultationFee;
            HireDate = DateTime.Now;
            IsActive = true;
            Appointments = new List<Appointment>();
            Prescriptions = new List<Prescription>();
        }
        
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        
        public override string ToString()
        {
            return $"Dr. {GetFullName()} - {Specialty}";
        }
    }
}
