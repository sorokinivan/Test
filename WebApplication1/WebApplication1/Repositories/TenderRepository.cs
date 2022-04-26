using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private Settings _settings;

        public TenderRepository(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<IEnumerable<Tender>> GetTendersFromWebService()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = await client.GetStreamAsync(_settings.URL);

            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Tender>>(streamTask);
            if(result is not null)
                return result;
            else
                return new List<Tender>();
        }
    }
}
