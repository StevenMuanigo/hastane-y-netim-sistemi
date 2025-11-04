using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }
        
        // Navigation properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public List<PrescriptionItem> PrescriptionItems { get; set; }
        
        public Prescription()
        {
            PrescriptionDate = DateTime.Now;
            PrescriptionItems = new List<PrescriptionItem>();
        }
        
        public Prescription(int patientId, int doctorId, string diagnosis, string notes)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            PrescriptionDate = DateTime.Now;
            Diagnosis = diagnosis;
            Notes = notes;
            PrescriptionItems = new List<PrescriptionItem>();
        }
        
        public decimal GetTotalCost()
        {
            decimal total = 0;
            foreach (var item in PrescriptionItems)
            {
                total += item.GetTotalPrice();
            }
            return total;
        }
        
        public override string ToString()
        {
            return $"Prescription #{Id} for {Patient?.GetFullName()} by Dr. {Doctor?.GetFullName()} - Total: ${GetTotalCost():F2}";
        }
    }
}
