using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Business.Abstract
{
    public interface IReportServices
    {
        List<DescLocations> GetLocationsInfo();
        DescLocations GetLocationInfo(string location);
        DescLocations PhoneNumberInfo(string location);
    }
}
