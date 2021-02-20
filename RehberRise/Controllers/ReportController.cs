using Microsoft.AspNetCore.Mvc;
using RehberRise.Business.Abstract;
using RehberRise.Business.Concrete;
using RehberRise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehberRise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController:ControllerBase
    {
        private readonly IReportServices _reportServices;

        public ReportController(IReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        [HttpGet("GetLocationsInfo")]
        public List<DescLocations> GetLocationsInfo()
        {
            return _reportServices.GetLocationsInfo();
        }
        [HttpGet("GetLocationInfo/{location}")]
        public DescLocations GetLocationInfo(string location)
        {
            return _reportServices.GetLocationInfo(location);
        }
        [HttpGet("Phone/{location}")]
        public DescLocations GetPhoneInfo(string location)
        {
            return _reportServices.PhoneNumberInfo(location);
        }
    }
}
