using System;
using System.ComponentModel.DataAnnotations;

namespace MVCSalesforceCRUD.Models
{
    // Model for holding Opportunity related details
    public class Opportunity
    {
        public string Id { get; } // ID of the opportunity
        
        [Required]
        public string Name { get; set; } //Name of the Opportunity (Required).
        [Required]
        public DateTime CloseDate { get; set; } //The closing date of the Opportunity, This needs to be in the format of YYYY-MM-DD (Required).
        [Required]
        public string StageName { get; set; } // The stage at which the Opportunity is currently at. 
        [Range(1,100)]
        public string Probability { get; set; } //The probability of the Opportunity being successful. (Required).
        [Required]
        public string Amount { get; set; } //The amount the Opportunity is potentially worth. (Required).
        [Required]
        public string AccountId { get; set; } //Id of the Account to create this Opportunity against. (Required).

    }
}