
#  Demo of Salesforce integration with MVC

----------
### About the project

From this solution, Opportunities and Line items (Opportunity Products) of Salesforce can be managed from MVC application. This solution uses the [SalesForce.NET Toolkit](https://github.com/developerforce/Force.com-Toolkit-for-NET) for making async-await calls to Salesforce.

- Technologies: ASP.NET MVC
- Front-End: Bootstrap, Jquery
- Back-end: C#
- Framework: .Net Framework 4.7.2

----------
## Getting started

### Prerequisits

- You must have Salesforce account with full permission. If don't have any, you can create one from the following [link](https://developer.salesforce.com/signup).
- Once the Salesforce account has been setup, you must create one custom salesforce app from Salesforce which will be used for generating the Consumer key and secret for communication with Salesforce.

### Setting up the solution

You will need to obtain below details and set the proper values in web.config file of project:

	- Username
	- Password
	- Consumer Key
	- Consumer Secret
    - Security Token

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/Webconfig-keys.JPG?raw=true)

- Your username is the email address used for the SalesForce account you just created (same goes for the password).
- The Consumer Key and the Consumer Secret can be found when previewing the details of the app you just created.
- The security token can be obtained from your account settings menu -> "Reset Security Token"

----------

## Solution in action

Once everything is setup in web.config. Then just run the project and you will be landed with below home page. which wil display the list of opportunities.

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/Homepage.JPG?raw=true)

For each opportunity, you have 3 options
- Update
- Delete
- Manage Lineitems

Also there is button on top, called "Add new Opportunity", which will allow you to create new Opportunity:

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/2-CreateNewOpportunity.JPG?raw=true)

After the successful creation of opportunity, you will be redirected on home page with the success message:

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/3-CreateNewOpportunity-Success.JPG?raw=true)

You can update the details of opportunity, by simply clicking on the "Update" button of the opportunity row, and it will open the below page which will allow you to modify the details:

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/4-UpdateOpportunity.JPG?raw=true)

You can delete the opportunity, by simply clicking on the "Delete" button of the opportunity row, and it will first ask for the confirmation to delete.

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/5-DeleteOpportunityConfirmation.JPG?raw=true)

For managing the line-items (products) associated with the opportunity, you can click on  "Manage Lineitems" buttons, and you will be landed on below page which will display all associated line items.

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/7-ViewAllLineItems.JPG?raw=true)

On the same page, there is also an option to "Add new line item", which will allow you to add existing products as line item in current opportunity:

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/6-CreateLineItem.JPG?raw=true)

You can also update the line item details by clicking "Update" button of the line item row. It will open the below page which will allow you to modify the line-item data:

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/8-UpdateLineItem.JPG?raw=true)

You can also delete the line item by clicking on "Delete" button of the line item row, which will first ask your confirmation and then delete it from the opportunity.

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/9-DeleteLineItemConfirmation.JPG?raw=true)


### Data in Salesforce

You can see in the Salesforce envrionment, all the opportunities and line items created from this MVC application are there as well:

##### Opportunities:

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/10-OpportunitiesInSalesForce.JPG?raw=true)


##### Line items associated with opportunity:

![](https://github.com/ParthKadecha25/mvc-learning/blob/master/MVCSalesforceCRUD/MVCSalesforceCRUD/GithubAssets/11-LineItemsInSalesForce.JPG?raw=true)
