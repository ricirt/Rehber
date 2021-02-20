using RehberRise.Business.Abstract;
using RehberRise.Repository.Abstract;
using RehberRise.Repository.Concrete;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Business.Concrete
{
    public class ReportManager : IReportServices
    {
        private IReportRepository _reportRepository;
        public ReportManager(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public List<DescLocations> GetLocationsInfo()
        {
           return _reportRepository.GetLocationsInfo();
        }

        public DescLocations GetLocationInfo(string location)
        {
            return _reportRepository.GetLocationInfo(location);
        }

        public DescLocations PhoneNumberInfo(string location)
        {
            return _reportRepository.PhoneNumberInfo(location);
        }
    }
}
