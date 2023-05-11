using eSyaNursingStation.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNursingStation.IF
{
    public interface IInPatientInfoRepository
    {
        Task<List<DO_InPatientDetail>> GetInPatientDetails();

        Task<DO_InPatientDetail> GetInPatientDetailsByIPNumber(int ipNumber);
        Task<List<DO_DrugCodes>> GetDrugList(string searchText);

    }
}
