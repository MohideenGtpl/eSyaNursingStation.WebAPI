using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaNursingStation.DO;
using eSyaNursingStation.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaNursingStation.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientClinicalInformationController : ControllerBase
    {

        private readonly IPatientClinicalInformationRepository _patientClinicalInformationRepository;

        public PatientClinicalInformationController(IPatientClinicalInformationRepository patientClinicalInformationRepository)
        {
            _patientClinicalInformationRepository = patientClinicalInformationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoPatientClinicalInformation(DO_PatientClinicalInformation obj)
        {
            var ds = await _patientClinicalInformationRepository.InsertIntoPatientClinicalInformation(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientClinicalInformation(DO_PatientClinicalInformation obj)
        {
            var ds = await _patientClinicalInformationRepository.UpdatePatientClinicalInformation(obj);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetClinicalInformationValueForPatient(int businessKey, int UHID, int ipNumber, string clType)
        {
            var ds = await _patientClinicalInformationRepository.GetClinicalInformationValueForPatient(businessKey, UHID, ipNumber, clType);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetClinicalInformationValueView(int businessKey, int UHID, int ipNumber, string clType)
        {
            var ds = await _patientClinicalInformationRepository.GetClinicalInformationValueView(businessKey, UHID, ipNumber, clType);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetClinicalInformationValueByTransaction(int businessKey, int UHID, int ipNumber, int transactionID)
        {
            var ds = await _patientClinicalInformationRepository.GetClinicalInformationValueByTransaction(businessKey, UHID, ipNumber, transactionID);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoPatientMedicationDrug(DO_PatientMedicationDrug obj)
        {
            var ds = await _patientClinicalInformationRepository.InsertIntoPatientMedicationDrug(obj);
            return Ok(ds);
        }
        [HttpPost]
        public async Task<IActionResult> InsertIntoPatientMedicationGiven(DO_PatientMedicationGiven obj)
        {
            var ds = await _patientClinicalInformationRepository.InsertIntoPatientMedicationGiven(obj);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientMedicationDrug(int businessKey, int UHID, int ipNumber)
        {
            var ds = await _patientClinicalInformationRepository.GetPatientMedicationDrug(businessKey, UHID, ipNumber);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientMedicationDetailByDrugCode(int businessKey, int UHID, int ipNumber, int drugCode)
        {
            var ds = await _patientClinicalInformationRepository.GetPatientMedicationDetailByDrugCode(businessKey, UHID, ipNumber, drugCode);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientMedicationDrugGivenTiming(int businessKey, int UHID, int ipNumber, int drugCode)
        {
            var ds = await _patientClinicalInformationRepository.GetPatientMedicationDrugGivenTiming(businessKey, UHID, ipNumber, drugCode);
            return Ok(ds);
        }

    }
}