namespace MVCSalesforceCRUD.Helpers
{
    public class Constants
    {
        #region "Salesforce Object Types"

        public const string Opportunity = "Opportunity";
        public const string LineItem = "LineItem";

        #endregion


        #region "Messages"

        public const string MsgOpportunityAddSuccess = "Opportunity details added successfully.";
        public const string MsgOpportunityAddFailed = "We are facing issue in adding opportunity details. Please try again.";

        public const string MsgOpportunityUpdateSuccess = "Opportunity details updated successfully.";
        public const string MsgOpportunityUpdateFailed = "We are facing issue in updating opportunity details. Please try again.";

        public const string MsgOpportunityDeleteSuccess = "Opportunity deleted successfully.";
        public const string MsgOpportunityDeleteFailed = "We are facing issue in deleting opportunity. Please try again.";

        #endregion
    }
}