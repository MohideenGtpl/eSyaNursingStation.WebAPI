using eSyaNursingStation.DL.Entities;
using eSyaNursingStation.DO;
using eSyaNursingStation.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaNursingStation.DL.Repository
{
    public class NurseAssessmentRepository : INurseAssessmentRepository
    {
        public async Task<DO_ReturnParameter> InsertIntoNurseAssessment(DO_NurseAssessment obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var nh = db.GtIpnsch.Where(w => w.BusinessKey == obj.BusinessKey
                                     && w.Uhid == obj.UHID
                                     && w.Ipnumber == obj.IPNumber).FirstOrDefault();
                        if (nh == null)
                        {
                            nh = new GtIpnsch
                            {
                                BusinessKey = obj.BusinessKey,
                                Uhid = obj.UHID,
                                Ipnumber = obj.IPNumber,
                                AssessmentStatus = "D",
                                ActiveStatus = true,
                                FormId = obj.FormID,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            db.GtIpnsch.Add(nh);
                        }
                        else
                        {
                            nh.ModifiedBy = obj.UserID;
                            nh.ModifiedOn = System.DateTime.Now;
                            nh.ModifiedTerminal = obj.TerminalID;
                        }

                        foreach (var c in obj.l_NS_ControlValue)
                        {
                            if (!string.IsNullOrEmpty(c.Value))
                            {
                                var nd = db.GtIpnscd.Where(w => w.BusinessKey == obj.BusinessKey
                                            && w.Uhid == obj.UHID && w.Ipnumber == obj.IPNumber
                                            && w.NscontrolId == c.NSControlID).FirstOrDefault();
                                if (nd == null)
                                {
                                    nd = new GtIpnscd
                                    {
                                        BusinessKey = obj.BusinessKey,
                                        Uhid = obj.UHID,
                                        Ipnumber = obj.IPNumber,
                                        NscontrolId = c.NSControlID,
                                        ValueType = c.ValueType,
                                        Value = c.Value,
                                        ActiveStatus = true,
                                        FormId = obj.FormID,
                                        CreatedBy = obj.UserID,
                                        CreatedOn = System.DateTime.Now,
                                        CreatedTerminal = obj.TerminalID
                                    };
                                    db.GtIpnscd.Add(nd);
                                }
                                else
                                {
                                    nd.ValueType = c.ValueType;
                                    nd.Value = c.Value;
                                    nd.ModifiedBy = obj.UserID;
                                    nd.ModifiedOn = System.DateTime.Now;
                                    nd.ModifiedTerminal = obj.TerminalID;
                                }
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

        public async Task<List<DO_NS_ControlValue>> GetNurseAssessmentValueForPatient(int businessKey, int UHID, int ipNumber)
        {
            using (var db = new eSyaEnterprise())
            {
                var ns = await db.GtIpnscd
                        .Where(w => w.BusinessKey == businessKey && w.Uhid == UHID && w.Ipnumber == ipNumber
                           && w.ActiveStatus)
                        .Select(x => new DO_NS_ControlValue
                        {
                            NSControlID = x.NscontrolId,
                            ValueType = x.ValueType,
                            Value = x.Value
                        }).ToListAsync();

                return ns;
            }
        }


        public async Task<List<DO_InPatientDetail>> GetInPatientDetails()
        {
            try
            {
                using (var db = new eSyaEnterprise_SP())
                {
                    var ns = await db.GHealthInPatients.FromSql($"USP_NS_rpt_GHealthInPatient")
                        .Select(x => new DO_InPatientDetail
                        {
                            HospitalNumber = x.HospitalNumber,
                            IPNumber = x.IPNumber,
                            PatientName = x.PatientName,
                            Sex = x.Sex,
                            Age = x.Age,
                            EffectiveDateOfAdmission = x.EffectiveDateOfAdmission,
                            DischargedUnderDoctor = x.DischargedUnderDoctor,
                            DoctorName = x.DoctorName,
                            DischargedUnderSpecialty = x.DischargedUnderSpecialty,
                            SpecialtyDesc = x.SpecialtyDesc,
                            WardType = x.WardType,
                            RoomType = x.RoomType,
                            RoomTypeDesc = x.RoomTypeDesc,
                            BedNumber = x.BedNumber
                        })
                        .ToListAsync();
                    return ns;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DO_InPatientDetail> GetInPatientDetailsByIPNumber(int ipNumber)
        {
            try
            {
                using (var db = new eSyaEnterprise_SP())
                {
                    var param = new SqlParameter("@IpNumber", ipNumber);
                    var ns = await db.GHealthInPatients.FromSql($"USP_NS_rpt_GHealthInPatient @IpNumber", param)
                        .Select(x => new DO_InPatientDetail
                        {
                            HospitalNumber = x.HospitalNumber,
                            IPNumber = x.IPNumber,
                            PatientName = x.PatientName,
                            Sex = x.Sex,
                            Age = x.Age,
                            EffectiveDateOfAdmission = x.EffectiveDateOfAdmission,
                            DischargedUnderDoctor = x.DischargedUnderDoctor,
                            DoctorName = x.DoctorName,
                            DischargedUnderSpecialty = x.DischargedUnderSpecialty,
                            SpecialtyDesc = x.SpecialtyDesc,
                            WardType = x.WardType,
                            RoomType = x.RoomType,
                            RoomTypeDesc = x.RoomTypeDesc,
                            BedNumber = x.BedNumber
                        }).FirstOrDefaultAsync();
                    return ns;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

   

}
