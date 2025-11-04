using System;

namespace HospitalManagementSystem.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsPrescriptionRequired { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public Medicine()
        {
            CreatedDate = DateTime.Now;
        }
        
        public Medicine(string name, string description, string manufacturer, 
                       decimal unitPrice, int stockQuantity, DateTime expiryDate, 
                       bool isPrescriptionRequired)
        {
            Name = name;
            Description = description;
            Manufacturer = manufacturer;
            UnitPrice = unitPrice;
            StockQuantity = stockQuantity;
            ExpiryDate = expiryDate;
            IsPrescriptionRequired = isPrescriptionRequired;
            CreatedDate = DateTime.Now;
        }
        
        public bool IsInStock(int quantity)
        {
            return StockQuantity >= quantity;
        }
        
        public bool IsExpired()
        {
            return ExpiryDate < DateTime.Now;
        }
        
        public void ReduceStock(int quantity)
        {
            if (IsInStock(quantity))
            {
                StockQuantity -= quantity;
            }
            else
            {
                throw new InvalidOperationException("Not enough stock available");
            }
        }
        
        public void IncreaseStock(int quantity)
        {
            StockQuantity += quantity;
        }
        
        public override string ToString()
        {
            return $"{Name} - ${UnitPrice:F2} - Stock: {StockQuantity}";
        }
    }
}
