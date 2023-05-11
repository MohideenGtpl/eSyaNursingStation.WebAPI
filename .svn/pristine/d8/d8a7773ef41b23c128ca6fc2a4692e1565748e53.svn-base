using eSyaNursingStation.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNursingStation.IF
{
    public interface INurseAssessmentRepository
    {
        Task<DO_ReturnParameter> InsertIntoNurseAssessment(DO_NurseAssessment l_obj);

        Task<List<DO_NS_ControlValue>> GetNurseAssessmentValueForPatient(int businessKey, int UHID, int ipNumber);

        Task<List<DO_InPatientDetail>> GetInPatientDetails();
        Task<DO_InPatientDetail> GetInPatientDetailsByIPNumber(int ipNumber);
    }
}
