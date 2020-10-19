using System.Collections.Generic;

namespace MVCSalesforceCRUD.Models
{
    // Model for holding all Line item details
    public class OpportunityLineItems
    {
        public List<OpportunityLineItem> AllLineItems { get; set; }

        public Opportunity OpportunityDetails { get; set; }

        public OpportunityLineItems()
        {
            AllLineItems = new List<OpportunityLineItem>();
        }
    }
}