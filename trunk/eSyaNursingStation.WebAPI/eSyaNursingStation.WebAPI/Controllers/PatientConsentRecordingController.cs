using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNursingStation.DO;
using eSyaNursingStation.IF;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNursingStation.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientConsentRecordingController : ControllerBase
    {

        private readonly IPatientConsentRecordingRepository _nurseAssessmentRepository;

        public PatientConsentRecordingController(IPatientConsentRecordingRepository nurseAssessmentRepository)
        {
            _nurseAssessmentRepository = nurseAssessmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoPatientConsentRecording(DO_PatientConsentRecording obj)
        {
            var ds = await _nurseAssessmentRepository.InsertIntoPatientConsentRecording(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePatientConsentRecording(DO_PatientConsentRecording obj)
        {
            var ds = await _nurseAssessmentRepository.DeletePatientConsentRecording(obj);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GePatientConsentRecording(int businessKey, int UHID, int ipNumber)
        {
            var ds = await _nurseAssessmentRepository.GePatientConsentRecording(businessKey, UHID, ipNumber);
            return Ok(ds);
        }
    }
}