using eSyaNursingStation.DL.Entities;
using eSyaNursingStation.DO;
using eSyaNursingStation.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNursingStation.DL.Repository
{
    public class OperativeAnaesthesiaRepository: IOperativeAnaesthesiaRepository
    {
        public async Task<DO_ReturnParameter> InsertIntoOperativeAnaesthesiaInformation(DO_OperativeAnaesthesiaInformation obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                     //   var sl = db.GtIpotan.Where(w => w.BusinessKey == obj.BusinessKey && w.Uhid == obj.UHID && w.Ipnumber == obj.IPNumber).Select(s => s.TransactionId).DefaultIfEmpty(0).Max() + 1;

                        foreach (var c in obj.l_OT_ControlValue)
                        {
                            var ot = db.GtIpotan.Where(w => w.BusinessKey == obj.BusinessKey && w.Uhid == obj.UHID 
                                        && w.Ipnumber == obj.IPNumber && w.TransactionId == obj.TransactionID
                                        && w.OtcontrolId == c.OTControlID).FirstOrDefault();
                            if (ot == null)
                            {
                                if (!string.IsNullOrEmpty(c.Value))
                                {
                                    GtIpotan cl = new GtIpotan
                                    {
                                        BusinessKey = obj.BusinessKey,
                                        Uhid = obj.UHID,
                                        Ipnumber = obj.IPNumber,
                                        TransactionId = obj.TransactionID,
                                        TransactionDate = obj.TransactionDate,
                                        Ottype = c.OTType,
                                        OtcontrolId = c.OTControlID,
                                        ValueType = c.ValueType,
                                        Value = c.Value,
                                        ActiveStatus = true,
                                        FormId = obj.FormID,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtIpotan.Add(cl);
                                }
                            }
                            else
                            {
                                ot.ValueType = c.ValueType;
                                ot.Value = c.Value;
                                ot.ModifiedBy = obj.UserID;
                                ot.ModifiedOn = System.DateTime.Now;
                                ot.ModifiedTerminal = obj.TerminalID;
                            }
                        }

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Successfully." };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public async Task<List<DO_OperativeAnaesthesiaInformation>> GetOperativeAnaesthesiaInformationValueByTransaction(int businessKey, int UHID, int ipNumber, int transactionID)
        {
            using (var db = new eSyaEnterprise())
            {
                var ns = await db.GtIpotan
                        .Where(w => w.BusinessKey == businessKey && w.Uhid == UHID && w.Ipnumber == ipNumber
                           && w.TransactionId == transactionID
                           && w.ActiveStatus)
                        .Select(x => new DO_OperativeAnaesthesiaInformation
                        {
                            TransactionID = x.TransactionId,
                            TransactionDate = x.TransactionDate,
                            OTControlID = x.OtcontrolId,
                            ValueType = x.ValueType,
                            Value = x.Value
                        }).ToListAsync();

                return ns;
            }
        }
    }
}
