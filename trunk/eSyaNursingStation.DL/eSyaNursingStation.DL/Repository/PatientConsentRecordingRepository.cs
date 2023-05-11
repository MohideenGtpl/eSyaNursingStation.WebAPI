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
    public class PatientConsentRecordingRepository : IPatientConsentRecordingRepository
    {
        public async Task<DO_ReturnParameter> InsertIntoPatientConsentRecording(DO_PatientConsentRecording obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var sl = db.GtIpcnvr.Where(w => w.BusinessKey == obj.BusinessKey && w.Uhid == obj.UHID && w.Ipnumber == obj.IPNumber).Select(s => s.SerialNumber).DefaultIfEmpty(0).Max() + 1;
                        GtIpcnvr dc = new GtIpcnvr
                        {
                            BusinessKey = obj.BusinessKey,
                            Uhid = obj.UHID,
                            Ipnumber = obj.IPNumber,
                            SerialNumber = sl,
                            ConsentType = obj.ConsentType,
                            FilePath = obj.FilePath,
                            FileSize = obj.FileSize,
                            ActiveStatus = true,
                            FormId = obj.FormID,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };
                        db.GtIpcnvr.Add(dc);
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

        public async Task<DO_ReturnParameter> DeletePatientConsentRecording(DO_PatientConsentRecording obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var sl = db.GtIpcnvr.Where(w => w.BusinessKey == obj.BusinessKey && w.Uhid == obj.UHID 
                                && w.Ipnumber == obj.IPNumber && w.SerialNumber == obj.SerialNumber).FirstOrDefault();
                        db.GtIpcnvr.Remove(sl);
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

        public async Task<List<DO_PatientConsentRecording>> GePatientConsentRecording(int businessKey, int UHID, int ipNumber)
        {
            using (var db = new eSyaEnterprise())
            {
                var dc = await db.GtIpcnvr
                    .Join(db.GtEcapcd,
                        v => new { v.ConsentType },
                        a => new { ConsentType = a.ApplicationCode.ToString() },
                        (v, a) => new { v, a })
                            .Where(w => w.v.BusinessKey == businessKey && w.v.Uhid == UHID && w.v.Ipnumber == ipNumber
                           && w.v.ActiveStatus)
                        .OrderBy(o => o.v.CreatedOn)
                        .Select(x => new DO_PatientConsentRecording
                        {
                            SerialNumber = x.v.SerialNumber,
                            ConsentType = x.a.CodeDesc + " (" + x.v.CreatedOn.ToString("dd-MMM-yyyy hh:mm") + ")",
                            FilePath = x.v.FilePath,
                            FileSize = x.v.FileSize
                        }).ToListAsync();

                return dc;
            }
        }

    }
}
