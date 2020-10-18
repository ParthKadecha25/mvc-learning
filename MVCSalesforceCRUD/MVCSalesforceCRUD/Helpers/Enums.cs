using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSalesforceCRUD.Helpers
{
    public class Enums
    {
        // Types notifications used in system
        public enum NotificationType
        {
            Success = 1,
            Error = 2,
            Warning = 3
        }

        // For Opportunity Stages
        public enum OpportunityStage
        {
            [Display(Name = "Prospecting")]
            [Description("Prospecting")]
            Prospecting = 1,

            [Display(Name = "Qualification")]
            [Description("Qualification")]
            Qualification = 2,

            [Display(Name = "Needs Analysis")]
            [Description("Needs Analysis")]
            NeedsAnalysis = 3,

            [Display(Name = "Value Proposition")]
            [Description("Value Proposition")]
            ValueProposition = 4,

            [Display(Name = "Id. Decision Makers")]
            [Description("Id. Decision Makers")]
            IdDecisionMakers = 5,

            [Display(Name = "Perception Analysis")]
            [Description("Perception Analysis")]
            PerceptionAnalysis = 6,

            [Display(Name = "Proposal/Price Quote")]
            [Description("Proposal/Price Quote")]
            ProposalPriceQuote = 7,

            [Display(Name = "Negotiation / Review")]
            [Description("Negotiation / Review")]
            NegotiationReview = 8,

            [Display(Name = "Closed Won")]
            [Description("Closed Won")]
            ClosedWon = 9,

            [Display(Name = "Closed Lost")]
            [Description("Closed Lost")]
            ClosedLost = 10
        }

        // For Opportunity Types
        public enum OpportunityType
        {
            [Display(Name = "None")]
            [Description("None")]
            None = 1,

            [Display(Name = "Existing Customer - Upgrade")]
            [Description("Existing Customer - Upgrade")]
            ExistingCustomerUpgrade = 2,

            [Display(Name = "Existing Customer - Replacement")]
            [Description("Existing Customer - Replacement")]
            ExistingCustomerReplacement = 3,

            [Display(Name = "Existing Customer - Downgrade")]
            [Description("Existing Customer - Downgrade")]
            ExistingCustomerDowngrade = 4,

            [Display(Name = "New Customer")]
            [Description("New Customer")]
            NewCustomer = 5
        }
    }
}