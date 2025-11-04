using System;

namespace HospitalManagementSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Reason { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        
        // Navigation properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        
        public Appointment()
        {
            Status = AppointmentStatus.Scheduled;
            CreatedDate = DateTime.Now;
        }
        
        public Appointment(int patientId, int doctorId, DateTime appointmentDate, 
                          TimeSpan appointmentTime, string reason)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            Reason = reason;
            Status = AppointmentStatus.Scheduled;
            CreatedDate = DateTime.Now;
        }
        
        public string GetFormattedDateTime()
        {
            return $"{AppointmentDate:dd/MM/yyyy} at {AppointmentTime:hh\\:mm}";
        }
        
        public bool IsCancelled()
        {
            return Status == AppointmentStatus.Cancelled;
        }
        
        public void Cancel()
        {
            Status = AppointmentStatus.Cancelled;
        }
        
        public void Complete()
        {
            Status = AppointmentStatus.Completed;
        }
        
        public override string ToString()
        {
            return $"Appointment #{Id}: {Patient?.GetFullName()} with {Doctor?.GetFullName()} on {GetFormattedDateTime()} - {Status}";
        }
    }
    
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Cancelled,
        NoShow
    }
}
