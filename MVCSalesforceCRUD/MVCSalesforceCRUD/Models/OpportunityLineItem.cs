using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSalesforceCRUD.Models
{
    // Model for holding Opportuniy Line item details
    public class OpportunityLineItem
    {
        [Description("Line item unique id")]
        public string Id {get; set;}

        [Description("Opportunity Product / Line item name")]
        public string Name { get; set; }

        [Description("This is the Sales Price of the Product")]
        [Required] // As we are not using Total Price
        public string UnitPrice { get; set; }
        
        [Required]
        [Description("This is the quantity of this line item for the opportunity")]
        public double Quantity { get; set; }
        
        [Description("Detailed description of the line item")]
        public string Description { get; set; }

        [Description("ID of the associated Opportunity")]
        public string OpportunityId { get; set; }

        [Description("ID of the associated PricebookEntry")]
        public string PricebookEntryId { get; set; }
    }
}