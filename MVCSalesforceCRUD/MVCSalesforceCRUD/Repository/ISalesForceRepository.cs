using MVCSalesforceCRUD.Models;
using Salesforce.Force;
using System.Threading.Tasks;

namespace MVCSalesforceCRUD.Repository
{
    /// <summary>
    /// For Salesforce operations
    /// </summary>
    interface ISalesforceRepository
    {
        #region "Opportunities"

        Task<Opportunities> GetOpportunities(ForceClient client);
        Task<Opportunity> GetOpportunityById(ForceClient client, string opportunityId);
        Task<SalesForceResponse> CreateOpportunity(ForceClient client, Opportunity opportunity);
        Task<SalesForceResponse> UpdateOpportunity(ForceClient client, string opportunityId, Opportunity opportunity);
        Task<SalesForceResponse> DeleteOpportunity(ForceClient client, string opportunityId);

        #endregion
    }
}
