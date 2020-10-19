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
    // For managing the opportunities
    public class OpportunitiesController : Controller
    {
        private readonly SalesForceService _client; // Responsible for generating force client to perform Salesforce operations
        private readonly SalesforceRepository _repository; // Responsible for performing Saleforce operations
        
        public OpportunitiesController()
        {
            _repository = new SalesforceRepository();
            _client = new SalesForceService();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            Opportunities opportunities = new Opportunities();
            try
            {
                ForceClient client = await _client.CreateForceClient();
                opportunities = await _repository.GetOpportunities(client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View("Index", opportunities);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public async Task<ActionResult> Add(Opportunity input)
        {
            if (ModelState.IsValid)
            {
                SalesForceResponse sfResponse = new SalesForceResponse();
                ForceClient client = await _client.CreateForceClient();

                // Coverting the object value to required format
                input.StageName = GlobalHelper.GetStageName(Convert.ToInt32(input.StageName));
                input.Type = GlobalHelper.GetType(Convert.ToInt32(input.Type));
                
                // Creating the Opportunity
                sfResponse = await _repository.CreateOpportunity(client, input);

                // Managing the Notification
                TempData["NotificationType"] = sfResponse.IsSuccess
                    ? NotificationType.Success.ToString()
                    : NotificationType.Error.ToString();

                TempData["Notification"] = sfResponse.Details;
                return RedirectToAction("Index", "Opportunities");
            }

            // In case the model has no valid data
            TempData["NotificationType"] = NotificationType.Error.ToString();
            TempData["Notification"] = GlobalHelper.GetErrorListFromModelState(ModelState);

            return View(input);
        }
        
        [HttpGet]
        public async Task<ActionResult> Update(string opportunity)
        {
            Opportunity model = new Opportunity();
            try
            {
                ForceClient client = await _client.CreateForceClient();
                model = await _repository.GetOpportunityById(client, opportunity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Opportunity input)
        {
            if (ModelState.IsValid)
            {
                SalesForceResponse sfResponse = new SalesForceResponse();
                ForceClient client = await _client.CreateForceClient();

                // Coverting the object value to required format
                input.StageName = GlobalHelper.GetStageName(Convert.ToInt32(input.StageName));
                input.Type = GlobalHelper.GetType(Convert.ToInt32(input.Type));

                // Need to provide opporunity id seperately
                var opportunityId = input.Id;
                input.Id = null;

                // Updating the opportunity
                sfResponse = await _repository.UpdateOpportunity(client, opportunityId, input);

                // Managing Notification based on update operation response
                TempData["NotificationType"] = sfResponse.IsSuccess
                    ? NotificationType.Success.ToString()
                    : NotificationType.Error.ToString();
                TempData["Notification"] = sfResponse.Details;
                return RedirectToAction("Index", "Opportunities");
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
                sfResponse = await _repository.DeleteOpportunity(client, itemId);
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
