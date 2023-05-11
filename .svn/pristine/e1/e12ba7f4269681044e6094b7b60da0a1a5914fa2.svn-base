using eSyaNursingStation.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNursingStation.IF
{
    public interface IOperativeAnaesthesiaRepository
    {
        Task<DO_ReturnParameter> InsertIntoOperativeAnaesthesiaInformation(DO_OperativeAnaesthesiaInformation obj);
        Task<List<DO_OperativeAnaesthesiaInformation>> GetOperativeAnaesthesiaInformationValueByTransaction(int businessKey, int UHID, int ipNumber, int transactionID);


    }
}
