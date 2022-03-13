using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end.Services
{
    public interface IPlanetServices : IDisposable
    {
        Planet GetPlanet(Guid Id);
        void AddPlanet(Planet planet);
        void UpdatePlanet(Guid Id);
    }
}
