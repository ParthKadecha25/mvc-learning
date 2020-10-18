namespace MVCSalesforceCRUD.Models
{
    /// <summary>
    /// For holding the response details of Salesforce operations
    /// </summary>
    public class SalesForceResponse
    {
        public bool IsSuccess { get; set; }
        public string Details { get; set; }
    }
}