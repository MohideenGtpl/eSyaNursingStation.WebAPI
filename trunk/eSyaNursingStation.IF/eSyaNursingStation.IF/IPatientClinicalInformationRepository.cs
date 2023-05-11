using eSyaNursingStation.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNursingStation.IF
{
    public interface IPatientClinicalInformationRepository
    {
        Task<DO_ReturnParameter> InsertIntoPatientClinicalInformation(DO_PatientClinicalInformation obj);

        Task<DO_ReturnParameter> UpdatePatientClinicalInformation(DO_PatientClinicalInformation obj);

        Task<List<DO_PatientClinicalInformation>> GetClinicalInformationValueForPatient(int businessKey, int UHID, int ipNumber, string clType);
        Task<List<DO_PatientClinicalInformation>> GetClinicalInformationValueView(int businessKey, int UHID, int ipNumber, string clType);

        Task<List<DO_PatientClinicalInformation>> GetClinicalInformationValueByTransaction(int businessKey, int UHID, int ipNumber, int transactionID);


        Task<DO_ReturnParameter> InsertIntoPatientMedicationDrug(DO_PatientMedicationDrug obj);
        Task<DO_ReturnParameter> InsertIntoPatientMedicationGiven(DO_PatientMedicationGiven obj);
        Task<List<DO_PatientMedicationDrug>> GetPatientMedicationDrug(int businessKey, int UHID, int ipNumber);
        Task<DO_PatientMedicationDrug> GetPatientMedicationDetailByDrugCode(int businessKey, int UHID, int ipNumber, int drugCode);
        Task<List<DO_PatientMedicationGiven>> GetPatientMedicationDrugGivenTiming(int businessKey, int UHID, int ipNumber, int drugCode);
    }
}
