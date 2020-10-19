namespace MVCSalesforceCRUD.Helpers
{
    public class Constants
    {
        #region "Salesforce Object Types"

        public const string Opportunity = "Opportunity";
        public const string OpportunityLineItem = "OpportunityLineItem";

        #endregion


        #region "Messages"

        // Opportunity
        public const string MsgOpportunityAddSuccess = "Opportunity details added successfully.";
        public const string MsgOpportunityAddFailed = "We are facing issue in adding opportunity details. Please try again.";
        public const string MsgOpportunityUpdateSuccess = "Opportunity details updated successfully.";
        public const string MsgOpportunityUpdateFailed = "We are facing issue in updating opportunity details. Please try again.";
        public const string MsgOpportunityDeleteSuccess = "Opportunity deleted successfully.";
        public const string MsgOpportunityDeleteFailed = "We are facing issue in deleting opportunity. Please try again.";

        // Opportunity Line item
        public const string MsgOpportunityLineItemAddSuccess = "Line item details added successfully.";
        public const string MsgOpportunityLineItemAddFailed = "We are facing issue in adding line item details. Please try again.";
        public const string MsgOpportunityLineItemUpdateSuccess = "Line item details updated successfully.";
        public const string MsgOpportunityLineItemUpdateFailed = "We are facing issue in updating line item details. Please try again.";
        public const string MsgOpportunityLineItemDeleteSuccess = "Line item deleted successfully.";
        public const string MsgOpportunityLineItemDeleteFailed = "We are facing issue in deleting line item. Please try again.";

        #endregion
    }
}