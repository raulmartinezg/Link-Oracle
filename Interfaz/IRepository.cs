using LinkOracle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Interfaz
{
    public interface IRepository
    {
        Task<bool> Insert(List<FolioViajeGeneral> list);
        Task<bool> UpdateShip(List<TbmaeViaje> ship);
        Task<bool> UpdateStop(List<TbmaeStop> stop);
        Task<bool> UpdateLink(LinkShip stop);
        Task Delete();
    }
}
