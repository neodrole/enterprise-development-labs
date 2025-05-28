using DispatchService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Services;
public interface IVehicleRepository : IRepository<Vehicle, int>
{
    public string GetFullInfo(int key);
}
