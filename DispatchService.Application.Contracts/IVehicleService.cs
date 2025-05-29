using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts;
public interface IVehicleService
{
    public Task<string> GetFullInfo(int key);
}
