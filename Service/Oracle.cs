using LinkOracle.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinkOracle.Service
{
    public class Oracle
    {
        const string WebApiUrl = "https://oic-prod-instance-idb0blckb1qw-ia.integration.ocp.oraclecloud.com:443/ic/api/integration/v1/flows/rest/BSS_QUERY_SHIPMENT/1.0/generalShipmentId";

        private static HttpClient Client = new HttpClient()
        {
            BaseAddress = new Uri(WebApiUrl)
        };

        

        public static async Task<Master> GetShipments()
        {
            var viaje = new List<TbmaeViaje>();
            var parada = new List<TbmaeStop>();
            var folios = new List<FolioViajeGeneral>();
            var byteArray = Encoding.ASCII.GetBytes("RMARTINEZ:EDScargo_2021");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("customerId", "EDS00014");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = $"{WebApiUrl}";
            var response = await Client.GetAsync(url);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var obj = JsonConvert.DeserializeObject<Root>(json);
                    var c = obj.items.Count;
                    for (var i = 0; i < c; i++)
                    {
                        
                        TbmaeViaje rep = new TbmaeViaje();
                        rep.ClaveFolioViaje = Convert.ToInt32(obj.items[i].shipmentId);
                        rep.FolioViaje = obj.items[i].shipmentIdKey;
                        rep.Operador = obj.items[i].drivers[0].driver;
                        rep.Placa = obj.items[i].licensePlate;
                        rep.Ruta = obj.items[i].itinerary;
                        rep.Unidad = Convert.ToInt32(obj.items[i].powerUnit);
                        rep.SalidaProgramada = obj.items[i].scheduledDeparture;
                        rep.FechaEstatus = DateTime.Now;
                        rep.ClaveEstatus = 1;
                        rep.EstatusCro = 2;
                        rep.ClaveUsuario = 0;

                        FolioViajeGeneral f = new FolioViajeGeneral();
                        f.ClaveFolioViaje = obj.items[i].shipmentId;
                        f.FolioViaje = obj.items[i].shipmentIdKey;
                        f.Operador = obj.items[i].drivers[0].driver;
                        f.Placa = obj.items[i].licensePlate;
                        f.Ruta = obj.items[i].itinerary;
                        f.SalidaProgramada = obj.items[i].scheduledDeparture;
                        f.Unidad = obj.items[i].powerUnit;

                        foreach (Stop e in obj.items[i].stops)
                        {
                            int startIndex = 0;
                            int length = 5;
                            var substring = e.zone.Substring(startIndex,length);
                            if (substring == "NSNCN")
                            {
                                TbmaeStop stp = new TbmaeStop();
                                stp.ClaveStop = 0;
                                stp.ClaveViaje = rep.ClaveFolioViaje;
                                stp.ShipUnitId = e.details == null ? 0 : Convert.ToInt32(e.details[0].shipUnitId);
                                stp.Zone = e.zone;
                                stp.OrderRelease = obj.items[i].orderRelease;
                                stp.EnRuta = false;
                                parada.Add(stp);
                                folios.Add(f);
                                viaje.Add(rep);
                            }
                            
                        }
                        

                        
                    }

                }
            }
            var master = new Master();
            master.Viaje = viaje;
            master.Stop = parada;
            master.Folios = folios;
            return master;
            
        }

        
        
    }

}
