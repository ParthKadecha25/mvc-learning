using MVCSalesforceCRUD.Helpers;
using MVCSalesforceCRUD.Models;
using MVCSalesforceCRUD.Repository;
using Salesforce.Force;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSalesforceCRUD.Repository
{
    /// <summary>
    /// This class will perform the actual operations on Salesforce (CRUD operations) using the Force Client APIs
    /// </summary>
    public class SalesforceRepository : ISalesforceRepository
    {
        #region Opportunities

        /// <summary>
        /// Getting all opportunities
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <returns>List of all opportunities</returns>
        public async Task<Opportunities> GetOpportunities(ForceClient client)
        {
            Opportunities allOpportunities = new Opportunities();
            var opportunities = await client.QueryAsync<Opportunity>("SELECT ID, Name, CloseDate, StageName, Type, Amount, Probability From Opportunity ORDER BY Name ASC");
            if (opportunities.Records.Any())
            {
                foreach (Opportunity opportunity in opportunities.Records)
                {
                    allOpportunities.AllOpportunities.Add(new Opportunity
                    {
                        Id = opportunity.Id,
                        Name = opportunity.Name,
                        CloseDate = opportunity.CloseDate,
                        StageName = opportunity.StageName,
                        Type = opportunity.Type,
                        Amount = opportunity.Amount,
                        Probability = opportunity.Probability
                    });
                }
            }
            return allOpportunities;
        }

        /// <summary>
        /// Getting details of particular opportunity
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="opportunityId">Opportunity Id</param>
        /// <returns></returns>
        public async Task<Opportunity> GetOpportunityById(ForceClient client, string opportunityId)
        {
            Opportunity opportunityModel = new Opportunity();
            var opportunity = await client.QueryByIdAsync<Opportunity>(Constants.Opportunity, opportunityId);
            if (opportunity != null)
            {
                opportunityModel.Id = opportunity.Id;
                opportunityModel.StageName = opportunity.StageName;
                opportunityModel.Type = opportunity.Type;
                opportunityModel.Amount = opportunity.Amount;
                opportunityModel.Name = opportunity.Name;
                opportunityModel.Probability = opportunity.Probability;
                opportunityModel.CloseDate = opportunity.CloseDate;
            }
            return opportunityModel;
        }

        /// <summary>
        /// Adding new opportunity details
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="opportunity">Opportunity Details</param>
        /// <returns></returns>
        public async Task<SalesForceResponse> CreateOpportunity(ForceClient client, Opportunity opportunity)
        {
            var result = await client.CreateAsync(Constants.Opportunity, opportunity);
            return new SalesForceResponse
            {
                IsSuccess = result.Success,
                Details = result.Success ? Constants.MsgOpportunityAddSuccess : Constants.MsgOpportunityAddFailed
            };
        }

        /// <summary>
        /// Updating the opportunity details for the provided opportunity id
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="opportunityId">Opportunity Id</param>
        /// <param name="opportunity">Updated details of the opportunity</param>
        /// <returns></returns>
        public async Task<SalesForceResponse> UpdateOpportunity(ForceClient client, string opportunityId, Opportunity opportunity)
        {
            var result = await client.UpdateAsync(Constants.Opportunity, opportunityId, opportunity);
            return new SalesForceResponse
            {
                IsSuccess = result.Success,
                Details = result.Success ? Constants.MsgOpportunityUpdateSuccess : Constants.MsgOpportunityUpdateFailed
            };
        }

        /// <summary>
        /// Deleting provided opportunity
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="opportunityId">Opportunity Id</param>
        /// <returns></returns>
        public async Task<SalesForceResponse> DeleteOpportunity(ForceClient client, string opportunityId)
        {
            var res = await client.DeleteAsync(Constants.Opportunity, opportunityId);
            return new SalesForceResponse
            {
                IsSuccess = res,
                Details = res ? Constants.MsgOpportunityDeleteSuccess : Constants.MsgOpportunityDeleteFailed,
            };
        }
        
        #endregion
    }
}