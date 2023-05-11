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
    public class InPatientInfoRepository: IInPatientInfoRepository
    {
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
            catch (Exception ex)
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

        public async Task<List<DO_DrugCodes>> GetDrugList(string searchText)
        {
            try
            {
                using (var db = new eSyaEnterprise_SP())
                {
                    var param = new SqlParameter("@SearchText", searchText);
                    var dg = await db.DrugCodes.FromSql($"USP_NS_rpt_GHealthDrugMaster @SearchText", param)
                        .Select(x => new DO_DrugCodes
                        {
                            DrugCode = x.DrugCode,
                            DrugDescription = x.DrugDescription,
                            DrugCategoryDesc = x.DrugCategoryDesc
                        }).ToListAsync();
                    return dg;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
