using System;

namespace MVCSalesforceCRUD.Models
{
    // Model for holding Opportunity related details
    public class Opportunity
    {
        public string Name; //Name of the Opportunity (Required).
        public DateTime CloseDate; //The closing date of the Opportunity, This needs to be in the format of YYYY-MM-DD (Required).
        public string StageName; // The stage at which the Opportunity is currently at. 
        public string Probability; //The probability of the Opportunity being successful. (Required).
        public string Amount; //The amount the Opportunity is potentially worth. (Required).
        public string AccountID; //ID of the Account to create this Opportunity against. (Required).
        public string PriceBookId; //This is the id of the price book, as text(Required)
        public string OpportnityID; // ID of the opportunity
    }
}