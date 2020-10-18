using System;
using System.ComponentModel.DataAnnotations;

namespace MVCSalesforceCRUD.Models
{
    /// <summary>
    /// Model for holding Opportunity related details
    /// </summary>
    public class Opportunity
    {
        public string Id { get; set; } // ID of the opportunity
        
        [Required]
        public string Name { get; set; } //Name of the Opportunity

        [Required]
        public DateTime CloseDate { get; set; } //The closing date of the Opportunity
        
        [Range(1,100)]
        public double Probability { get; set; } //The probability of the Opportunity being successful

        [Required]
        public string Amount { get; set; } //The amount the Opportunity is potentially worth

        public string Type { get; set; } // Type of Opportunity

        public string StageName { get; set; } // The stage at which the Opportunity is currently at. 

    }
}