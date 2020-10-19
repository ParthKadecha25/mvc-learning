﻿using MVCSalesforceCRUD.Helpers;
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
    // For managing the opportunities
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
        public ActionResult Add()
        {
            return View("Add");
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
                return RedirectToAction("Index", "OpportunityLineitems");
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
                var opportunityLineItemId = input.Id;
                input.Id = null;

                // Updating the opportunity line item
                sfResponse = await _repository.UpdateOpportunityLineItem(client, opportunityLineItemId, input);

                // Managing Notification based on update operation response
                TempData["NotificationType"] = sfResponse.IsSuccess
                    ? NotificationType.Success.ToString()
                    : NotificationType.Error.ToString();
                TempData["Notification"] = sfResponse.Details;
                return RedirectToAction("Index", "OpportunityLineitems");
            }

            // Case when model has invalid data
            TempData["NotificationType"] = NotificationType.Error.ToString();
            TempData["Notification"] = GlobalHelper.GetErrorListFromModelState(ModelState);

            return View(input);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string opportunityLineItemId)
        {
            SalesForceResponse sfResponse = new SalesForceResponse();
            try
            {
                ForceClient client = await _client.CreateForceClient();
                sfResponse = await _repository.DeleteOpportunityLineItem(client, opportunityLineItemId);
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
