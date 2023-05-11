using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNursingStation.IF;
using eSyaNursingStation.DO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNursingStation.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperativeAnaesthesiaController : ControllerBase
    {
        private readonly IOperativeAnaesthesiaRepository _operativeAnaesthesiaRepository;

        public OperativeAnaesthesiaController(IOperativeAnaesthesiaRepository operativeAnaesthesiaRepository)
        {
            _operativeAnaesthesiaRepository = operativeAnaesthesiaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoOperativeAnaesthesiaInformation(DO_OperativeAnaesthesiaInformation obj)
        {
            var ds = await _operativeAnaesthesiaRepository.InsertIntoOperativeAnaesthesiaInformation(obj);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetOperativeAnaesthesiaInformationValueByTransaction(int businessKey, int UHID, int ipNumber, int transactionID)
        {
            var ds = await _operativeAnaesthesiaRepository.GetOperativeAnaesthesiaInformationValueByTransaction(businessKey, UHID, ipNumber, transactionID);
            return Ok(ds);
        }

    }
}