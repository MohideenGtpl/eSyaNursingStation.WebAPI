using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNursingStation.DL.Repository;
using eSyaNursingStation.DO;
using eSyaNursingStation.IF;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNursingStation.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NurseAssessmentController : ControllerBase
    {
        private readonly INurseAssessmentRepository _nurseAssessmentRepository;

        public NurseAssessmentController(INurseAssessmentRepository nurseAssessmentRepository)
        {
            _nurseAssessmentRepository = nurseAssessmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoNurseAssessment(DO_NurseAssessment obj)
        {
            var ds = await _nurseAssessmentRepository.InsertIntoNurseAssessment(obj);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetNurseAssessmentValueForPatient(int businessKey, int UHID, int ipNumber)
        {
            var ds = await _nurseAssessmentRepository.GetNurseAssessmentValueForPatient(businessKey, UHID, ipNumber);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetInPatientDetails()
        {
            var ds = await _nurseAssessmentRepository.GetInPatientDetails();
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetInPatientDetailsByIPNumber(int ipNumber)
        {
            var ds = await _nurseAssessmentRepository.GetInPatientDetailsByIPNumber(ipNumber);
            return Ok(ds);
        }
    }
}