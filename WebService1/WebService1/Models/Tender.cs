namespace WebService1.Models
{
    public class Tender
    {
        public Tender(string tenderName, DateTime startDate, DateTime endDate, string tenderUrl)
        {
            TenderName = tenderName;
            StartDate = startDate;
            EndDate = endDate;
            TenderUrl = tenderUrl;
        }

        public string TenderName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TenderUrl { get; set; }
    }
}
