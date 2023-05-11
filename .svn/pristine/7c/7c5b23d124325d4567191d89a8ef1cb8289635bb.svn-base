using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNursingStation.IF;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNursingStation.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonDataController : ControllerBase
    {
        private readonly ICommonDataRepository _commonDataRepository;
        public CommonDataController(ICommonDataRepository commonDataRepository)
        {
            _commonDataRepository = commonDataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationCodesByCodeType(int codeType)
        {
            var ds = await _commonDataRepository.GetApplicationCodesByCodeType(codeType);
            return Ok(ds);
        }
    }
}