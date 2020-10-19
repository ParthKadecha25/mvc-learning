using MVCSalesforceCRUD.Helpers;
using MVCSalesforceCRUD.Models;
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
        #region "Opportunities"

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

        #region "Opportunity Line items"
        
        /// <summary>
        /// Getting details of particular opportunity line item
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="lineItemId">Line item Id</param>
        /// <returns>Details of opportunity line item</returns>
        public async Task<OpportunityLineItem> GetOpportunityLineItemById(ForceClient client, string lineItemId)
        {
            OpportunityLineItem lineitemModel = new OpportunityLineItem();
            var lineitem = await client.QueryByIdAsync<OpportunityLineItem>(Constants.OpportunityLineItem, lineItemId);
            if (lineitem != null)
            {
                lineitemModel.Id = lineitem.Id;
                lineitemModel.Description = lineitem.Description;
                lineitemModel.ListPrice = lineitem.ListPrice;
                lineitemModel.Name = lineitem.Name;
                lineitemModel.OpportunityId = lineitem.OpportunityId;
                lineitemModel.Quantity = lineitem.Quantity;
                lineitemModel.UnitPrice = lineitem.UnitPrice;
                lineitemModel.PricebookEntryId = lineitem.PricebookEntryId;
            }
            return lineitemModel;
        }
        
        /// <summary>
        /// Getting line items associated with provided opportunity id
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="opportunityId">Opportunity Id</param>
        /// <returns></returns>
        public async Task<OpportunityLineItems> GetOpportunityLineitems(ForceClient client, string opportunityId)
        {
            OpportunityLineItems allLineitems = new OpportunityLineItems();

            // Getting opportunity details
            Opportunity opportunityDetails = await GetOpportunityById(client, opportunityId);
            allLineitems.OpportunityDetails = opportunityDetails;

            // Getting line items
            var lineitems = await client.QueryAsync<OpportunityLineItem>("SELECT ID, Name, UnitPrice, ListPrice, Quantity, Description, OpportunityId, PricebookEntryId From OpportunityLineItem WHERE OpportunityId='" + opportunityId + "' ORDER BY Name ASC");
            if (lineitems.Records.Any())
            {
                foreach (OpportunityLineItem lineitem in lineitems.Records)
                {
                    // Getting associated opportunity details
                    allLineitems.AllLineItems.Add(new OpportunityLineItem
                    {
                        Id = lineitem.Id,
                        Description = lineitem.Description,
                        ListPrice = lineitem.ListPrice,
                        Name = lineitem.Name,
                        OpportunityId = lineitem.OpportunityId,
                        Quantity = lineitem.Quantity,
                        UnitPrice = lineitem.UnitPrice,
                        PricebookEntryId = lineitem.PricebookEntryId
                    });
                }
            }
            

            return allLineitems;
        }

        /// <summary>
        /// Adding new opportunity line item details
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="opportunityLineItem">Opportunity line item details</param>
        /// <returns></returns>
        public async Task<SalesForceResponse> CreateOpportunityLineItem(ForceClient client, OpportunityLineItem opportunityLineItem)
        {
            var result = await client.CreateAsync(Constants.OpportunityLineItem, opportunityLineItem);
            return new SalesForceResponse
            {
                IsSuccess = result.Success,
                Details = result.Success ? Constants.MsgOpportunityLineItemAddSuccess : Constants.MsgOpportunityLineItemAddFailed
            };
        }

        /// <summary>
        /// Updating the opportunity line item details for the provided line item id
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="lineItemId">Line item Id</param>
        /// <param name="opportunityLineItem">Updated details of the opportunity line item</param>
        /// <returns></returns>
        public async Task<SalesForceResponse> UpdateOpportunityLineItem(ForceClient client, string lineItemId, OpportunityLineItem opportunityLineItem)
        {
            var result = await client.UpdateAsync(Constants.OpportunityLineItem, lineItemId, opportunityLineItem);
            return new SalesForceResponse
            {
                IsSuccess = result.Success,
                Details = result.Success ? Constants.MsgOpportunityLineItemUpdateSuccess : Constants.MsgOpportunityLineItemUpdateFailed
            };
        }

        /// <summary>
        /// Deleting provided opportunity line item
        /// </summary>
        /// <param name="client">Force client instance</param>
        /// <param name="opportunityLineItemId">Opportunity Line item Id</param>
        /// <returns></returns>
        public async Task<SalesForceResponse> DeleteOpportunityLineItem(ForceClient client, string opportunityLineItemId)
        {
            var res = await client.DeleteAsync(Constants.OpportunityLineItem, opportunityLineItemId);
            return new SalesForceResponse
            {
                IsSuccess = res,
                Details = res ? Constants.MsgOpportunityLineItemDeleteSuccess : Constants.MsgOpportunityLineItemDeleteFailed,
            };
        }

        #endregion
    }
}