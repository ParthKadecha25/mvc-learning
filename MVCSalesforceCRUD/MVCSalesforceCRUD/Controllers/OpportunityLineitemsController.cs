using MVCSalesforceCRUD.Helpers;
using MVCSalesforceCRUD.Models;
using MVCSalesforceCRUD.Repository;
using MVCSalesforceCRUD.Services;
using Salesforce.Force;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using static MVCSalesforceCRUD.Helpers.Enums;

namespace MVCSalesforceCRUD.Controllers
{
    /// <summary>
    /// For Managing Opportunity Lineitems
    /// </summary>
    public class OpportunityLineitemsController : Controller
    {
        private readonly SalesForceService _client; // Responsible for generating force client to perform Salesforce operations
        private readonly SalesforceRepository _repository; // Responsible for performing Saleforce operations
        
        public OpportunityLineitemsController()
        {
            _repository = new SalesforceRepository();
            _client = new SalesForceService();
        }
        
        [HttpGet]
        public async Task<ActionResult> Index(string opportunityId)
        {
            OpportunityLineItems lineitems = new OpportunityLineItems();
            try
            {
                ForceClient client = await _client.CreateForceClient();
                lineitems = await _repository.GetOpportunityLineitems(client, opportunityId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View("Index", lineitems);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            ForceClient client = await _client.CreateForceClient();
            Opportunity opportunity = await _repository.GetOpportunityById(client, Request.QueryString["opportunityId"]);
            Products products = await _repository.GetProductDetails(client, opportunity.Pricebook2Id);
            return View("Add", products);
        }

        [HttpPost]
        public async Task<ActionResult> Add(OpportunityLineItem input)
        {
            if (ModelState.IsValid)
            {
                SalesForceResponse sfResponse = new SalesForceResponse();
                ForceClient client = await _client.CreateForceClient();
 
                // Creating the Opportunity Line item
                sfResponse = await _repository.CreateOpportunityLineItem(client, input);

                // Managing the Notification
                TempData["NotificationType"] = sfResponse.IsSuccess
                    ? NotificationType.Success.ToString()
                    : NotificationType.Error.ToString();

                TempData["Notification"] = sfResponse.Details;
                return RedirectToAction("Index", "OpportunityLineitems", new { opportunityId = input.OpportunityId });
            }

            // In case the model has no valid data
            TempData["NotificationType"] = NotificationType.Error.ToString();
            TempData["Notification"] = GlobalHelper.GetErrorListFromModelState(ModelState);

            return View(input);
        }
        
        [HttpGet]
        public async Task<ActionResult> Update(string opportunityLineItem)
        {
            OpportunityLineItem model = new OpportunityLineItem();
            try
            {
                ForceClient client = await _client.CreateForceClient();
                model = await _repository.GetOpportunityLineItemById(client, opportunityLineItem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(OpportunityLineItem input)
        {
            if (ModelState.IsValid)
            {
                SalesForceResponse sfResponse = new SalesForceResponse();
                ForceClient client = await _client.CreateForceClient();
                
                // Need to provide opporunity line item id seperately
                string opportunityLineItemId = input.Id;
                input.Id = null;
                string opportunityId = input.OpportunityId;
                input.OpportunityId = null;

                // Updating the opportunity line item
                sfResponse = await _repository.UpdateOpportunityLineItem(client, opportunityLineItemId, input);

                // Managing Notification based on update operation response
                TempData["NotificationType"] = sfResponse.IsSuccess
                    ? NotificationType.Success.ToString()
                    : NotificationType.Error.ToString();
                TempData["Notification"] = sfResponse.Details;

                return RedirectToAction("Index", "OpportunityLineitems", new { opportunityId = opportunityId });
            }

            // Case when model has invalid data
            TempData["NotificationType"] = NotificationType.Error.ToString();
            TempData["Notification"] = GlobalHelper.GetErrorListFromModelState(ModelState);

            return View(input);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string itemId)
        {
            SalesForceResponse sfResponse = new SalesForceResponse();
            try
            {
                ForceClient client = await _client.CreateForceClient();
                sfResponse = await _repository.DeleteOpportunityLineItem(client, itemId);
            }
            catch (Exception ex)
            {
                sfResponse.Details = ex.Message;
            }

            return Json(new
            {
                IsDeleted = sfResponse.IsSuccess,
                Details = sfResponse.Details
            }, JsonRequestBehavior.DenyGet);
        }
    }
}
