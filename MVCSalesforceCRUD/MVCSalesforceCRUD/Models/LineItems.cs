using System.Collections.Generic;

namespace MVCSalesforceCRUD.Models
{
    // Model for holding all Line item details
    public class LineItems
    {
        public List<LineItem> AllLineItems { get; set; }
        public LineItems()
        {
            AllLineItems = new List<LineItem>();
        }
    }
}