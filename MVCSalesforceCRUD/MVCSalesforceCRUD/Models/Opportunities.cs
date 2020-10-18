using System.Collections.Generic;

namespace MVCSalesforceCRUD.Models
{
    /// <summary>
    /// Model for holding all opportunities details
    /// </summary>
    public class Opportunities
    {
        public List<Opportunity> AllOpportunities { get; set; }
        public Opportunities()
        {
            AllOpportunities = new List<Opportunity>();
        }
    }
}