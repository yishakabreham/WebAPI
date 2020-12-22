using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataServices;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MiscellaneousController : ControllerBase
    {
        IDataManager _dataManager;
        public MiscellaneousController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("getConfigurations")]
        public async Task<IActionResult> getConfigs()
        {
            var result = await _dataManager.GetConfigurations();

            return Ok(new { configs = result?.Select(c => new ConfigurationResult {
                    Attribute = c.Attribute, CurrentValue = c.CurrentValue, Reference = c.Reference
            }) });
        }
    }
}
