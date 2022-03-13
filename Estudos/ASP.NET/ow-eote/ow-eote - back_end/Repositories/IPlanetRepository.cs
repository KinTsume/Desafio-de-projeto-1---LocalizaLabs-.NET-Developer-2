using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end
{
    public interface IPlanetRepository : IDisposable
    {
        Planet GetPlanet(Guid Id);
    }
}
