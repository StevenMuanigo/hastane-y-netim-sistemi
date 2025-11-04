using System;

namespace HospitalManagementSystem.Models
{
    public class PrescriptionItem
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Instructions { get; set; }
        
        // Navigation properties
        public Prescription Prescription { get; set; }
        
        public PrescriptionItem()
        {
        }
        
        public PrescriptionItem(int prescriptionId, int medicineId, string medicineName, 
                               string dosage, string frequency, int quantity, decimal unitPrice, string instructions)
        {
            PrescriptionId = prescriptionId;
            MedicineId = medicineId;
            MedicineName = medicineName;
            Dosage = dosage;
            Frequency = frequency;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Instructions = instructions;
        }
        
        public decimal GetTotalPrice()
        {
            return Quantity * UnitPrice;
        }
        
        public override string ToString()
        {
            return $"{MedicineName} - {Dosage} - Qty: {Quantity} - ${GetTotalPrice():F2}";
        }
    }
}
