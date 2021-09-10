using LinkOracle.Entities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinkOracle.Service
{
    public class Link
    {
        const string WebApiUrl = "https://oic-prod-instance-idb0blckb1qw-ia.integration.ocp.oraclecloud.com:443/ic/api/integration/v1/flows/rest/BSS_QUERY_SHIPMENT/1.0/linkOrderToAvlShipment";

        private static HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri(WebApiUrl)
        };

        public async static Task<LinkShip> GetLinkShipment(LinkShip link)
        {
            var shipment = new LinkShip();
            var byteArray = Encoding.ASCII.GetBytes("RMARTINEZ:EDScargo_2021");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Add("orderReleaseId", link.OrderReleaseId);
            Client.DefaultRequestHeaders.Add("shipmentId", Convert.ToString(link.ShipmentId));
            Client.DefaultRequestHeaders.Add("zone", link.Zone);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiUrl}";
            var response = await Client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var obj = JsonConvert.DeserializeObject<LinkRoot>(json);
                    if(obj.items[0].inItinerary == "1")
                    {
                        
                        shipment.OrderReleaseId = obj.items[0].orderReleaseId;
                        shipment.ShipmentId = Convert.ToInt32(obj.items[0].shipmentId);
                        shipment.Zone = obj.items[0].zone;
                        
                    }
                    else
                    {
                        throw new Exception("No pertenece a la ruta");
                    }
                }
            }
            return shipment;
        }
    }
}
