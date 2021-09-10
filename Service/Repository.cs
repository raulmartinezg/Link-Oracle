using LinkOracle.Data;
using LinkOracle.Entities;
using LinkOracle.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Service
{
    public class Repository : IRepository
    {
        private readonly SID_AutoCargaV3Context _context;

        public Repository(SID_AutoCargaV3Context context)
        {
            _context = context;
        }

        public async Task<bool> Insert(List<FolioViajeGeneral> list)
        {
            try
            {
                await _context.FolioViajeGenerals.AddRangeAsync(list);
                var response = _context.SaveChanges();
                return response > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Verifica el servicio");
            }
            
        }

        public async Task<bool> UpdateShip(List<TbmaeViaje> ship)
        {
            try
            {
                var c = ship.Count();
                for(var i = 0; i < c; i++)
                {
                    var data = _context.TbmaeViajes.FirstOrDefault(x => x.FolioViaje == ship[i].FolioViaje);
                    if(data == null)
                    {
                        await _context.TbmaeViajes.AddAsync(ship[i]);
                        _context.SaveChanges();
                    }
                }

                return true;
                 
            }
            catch (Exception)
            {

                throw new Exception("Verifica el servicio");
            }
        }

        public async Task<bool> UpdateStop(List<TbmaeStop> stop)
        {
            try
            {
                var e = stop.Count();
                for (var j = 0; j < e; j++)
                {
                    var data = _context.TbmaeStop.FirstOrDefault(x => x.ClaveViaje == stop[j].ClaveViaje && x.ShipUnitId ==stop[j].ShipUnitId);
                    if (data == null)
                    {
                        await _context.TbmaeStop.AddAsync(stop[j]);
                        _context.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Verifica el servicio");
            }
        }

        public async Task<bool> UpdateLink(LinkShip stop)
        {
            try
            {
                var data = _context.TbmaeStop.FirstOrDefault(x => x.ClaveViaje == stop.ShipmentId && x.OrderRelease == stop.OrderReleaseId && x.Zone == stop.Zone);
                if(data == null)
                {
                    throw new Exception();
                }
                else
                {
                    data.EnRuta = true;
                    _context.TbmaeStop.Update(data);
                    var response = await _context.SaveChangesAsync();
                    return response > 0;
                }
            }
            catch (Exception)
            {

                throw new Exception("Verifica el servicio");
            }
        }

        public async Task Delete()
        {
            try
            {
                var items = _context.FolioViajeGenerals.ToList();
                _context.FolioViajeGenerals.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception("Verifica el servicio" + e);
            }
            
        }
    }
}
