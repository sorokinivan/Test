using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Tender
    {
        public Tender(
            string tenderName,
            DateTime startDate,
            DateTime endDate,
            string tenderUrl)
        {
            TenderName = tenderName;
            StartDate = startDate;
            EndDate = endDate;
            TenderUrl = tenderUrl;
        }

        [JsonPropertyName("tenderName")]
        public string TenderName { get; set; }
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("tenderUrl")]
        public string TenderUrl { get; set; }
    }
}
