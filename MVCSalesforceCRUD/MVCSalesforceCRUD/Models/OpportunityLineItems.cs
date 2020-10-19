using System.Collections.Generic;

namespace MVCSalesforceCRUD.Models
{
    // Model for holding all line items for the oportunity
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