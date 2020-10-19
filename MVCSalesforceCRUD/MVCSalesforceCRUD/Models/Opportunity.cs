using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSalesforceCRUD.Models
{
    /// <summary>
    /// Model for holding Opportunity related details
    /// </summary>
    public class Opportunity
    {
        [Description("ID of the opportunity")]
        public string Id { get; set; } // 
        
        [Required]
        [Description("Name of the Opportunity")]
        public string Name { get; set; }

        [Required]
        [Description("The closing date of the Opportunity")]
        public DateTime CloseDate { get; set; }
        
        [Range(1,100)]
        [Description("The probability of the Opportunity being successful")]
        public double Probability { get; set; }

        [Required]
        [Description("The amount the Opportunity is potentially worth")]
        public string Amount { get; set; }

        [Description("Type of Opportunity")]
        public string Type { get; set; }

        [Description("The stage at which the Opportunity is currently at. ")]
        public string StageName { get; set; }

        [Description("Pricebook ID associated with the opportunity")]
        public string Pricebook2Id { get; set; }

    }
}