namespace MVCSalesforceCRUD.Models
{
    // Model for holding Opportuniy Line item details
    public class LineItem
    {
        public string SalesPrice; // UnitPrice. This is the Sales Price of the Product (Required).
        public string ListPrice; // This is the List Price of the Product(Required).
        public int Quantity; // This is the quantity of this line item for the opportunity (Required).
        public string Description; // This is the Description of the Line Item, as text (Required).
        public string OpportunityID; // This is the ID of the opportunity, as text (Required).
        public string PriceBookEntryID; // This is the id of the price book entry, as text (Required).
    }
}