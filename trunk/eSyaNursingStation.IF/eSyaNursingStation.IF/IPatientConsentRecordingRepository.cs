using eSyaNursingStation.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNursingStation.IF
{
    public interface IPatientConsentRecordingRepository
    {
        Task<DO_ReturnParameter> InsertIntoPatientConsentRecording(DO_PatientConsentRecording obj);
        Task<DO_ReturnParameter> DeletePatientConsentRecording(DO_PatientConsentRecording obj);

        Task<List<DO_PatientConsentRecording>> GePatientConsentRecording(int businessKey, int UHID, int ipNumber);

    }
}
