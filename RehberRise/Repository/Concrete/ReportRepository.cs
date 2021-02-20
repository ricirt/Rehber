using RehberRise.DataBase;
using RehberRise.Repository.Abstract;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Repository.Concrete
{
    public class ReportRepository : IReportRepository
    {
        private DatabaseContext dc = new DatabaseContext();
        public List<DescLocations> GetLocationsInfo()
        {
            var locations = (from l in dc.Locations
                             group l by l.LocationName
                             into g
                             orderby g.Count() descending
                             select new DescLocations
                             {
                                 Count = g.Count(),
                                 LocationName = g.Key
                             }).ToList();
            return locations;
        }
        public DescLocations GetLocationInfo(string location)
        {
            var locationInfo = (from l in dc.Locations
                                group l by l.LocationName
                            into g
                                orderby g.Count() descending
                                select new DescLocations
                                {
                                    Count = g.Count(),
                                    LocationName = g.Key
                                }).FirstOrDefault(x => x.LocationName == location);
            return locationInfo;
        }
        public DescLocations PhoneNumberInfo(string location)
        {
            var phoneInfo = (from l in dc.Locations
                             join p in dc.PhoneNumbers
                             on l.UserId equals p.UserId
                             group l by l.LocationName
                                into g
                             orderby g.Count() descending
                             select new DescLocations
                             {
                                 Count = g.Count(),
                                 LocationName = g.Key
                             }).FirstOrDefault(x => x.LocationName == location);
            return phoneInfo;
        }
    }
}
