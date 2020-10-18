using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using static MVCSalesforceCRUD.Helpers.Enums;

namespace MVCSalesforceCRUD.Helpers
{
    public class GlobalHelper
    {
        /// <summary>
        /// Getting description of the provided enum member
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }

        /// <summary>
        /// Deciding opportunity stage name using the description data attribute
        /// </summary>
        /// <param name="stage">Opportunity Stage numeric value</param>
        /// <returns>Name of Opportunity stage</returns>
        public static string GetStageName(int stage)
        {
            var stageName = string.Empty;
            switch (stage)
            {
                case (int)(OpportunityStage.ClosedLost):
                    stageName = GetDescription(OpportunityStage.ClosedLost);
                    break;
                case (int)(OpportunityStage.IdDecisionMakers):
                    stageName = GetDescription(OpportunityStage.IdDecisionMakers);
                    break;
                case (int)(OpportunityStage.ClosedWon):
                    stageName = GetDescription(OpportunityStage.ClosedWon);
                    break;
                case (int)(OpportunityStage.NeedsAnalysis):
                    stageName = GetDescription(OpportunityStage.NeedsAnalysis);
                    break;
                case (int)(OpportunityStage.NegotiationReview):
                    stageName = GetDescription(OpportunityStage.NegotiationReview);
                    break;
                case (int)(OpportunityStage.PerceptionAnalysis):
                    stageName = GetDescription(OpportunityStage.PerceptionAnalysis);
                    break;
                case (int)(OpportunityStage.ProposalPriceQuote):
                    stageName = GetDescription(OpportunityStage.ProposalPriceQuote);
                    break;
                case (int)(OpportunityStage.Prospecting):
                    stageName = GetDescription(OpportunityStage.Prospecting);
                    break;
                case (int)(OpportunityStage.Qualification):
                    stageName = GetDescription(OpportunityStage.Qualification);
                    break;
                case (int)(OpportunityStage.ValueProposition):
                    stageName = GetDescription(OpportunityStage.ValueProposition);
                    break;
            }
            return stageName;
        }

        /// <summary>
        /// Deciding opportunity type using the description data attribute
        /// </summary>
        /// <param name="typeValue">Opportunity Type numeric value</param>
        /// <returns>Name of Opportunity Type</returns>
        public static string GetType(int typeValue)
        {
            var type = string.Empty;
            switch (typeValue)
            {
                case (int)(OpportunityType.ExistingCustomerDowngrade):
                    type = GetDescription(OpportunityType.ExistingCustomerDowngrade);
                    break;
                case (int)(OpportunityType.ExistingCustomerReplacement):
                    type = GetDescription(OpportunityType.ExistingCustomerReplacement);
                    break;
                case (int)(OpportunityType.ExistingCustomerUpgrade):
                    type = GetDescription(OpportunityType.ExistingCustomerUpgrade);
                    break;
                case (int)(OpportunityType.NewCustomer):
                    type = GetDescription(OpportunityType.NewCustomer);
                    break;
            }
            return type;
        }

        /// <summary>
        /// Getting error list for the model
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;

            var errorList = query.ToList();
            return errorList.Aggregate("", (current, err) => current + (err + " | "));
        }
    }
}