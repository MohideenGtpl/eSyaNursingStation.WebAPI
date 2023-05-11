using System;
using System.Collections.Generic;

namespace eSyaNursingStation.DL.Entities
{
    public partial class GtIpcldg
    {
        public int BusinessKey { get; set; }
        public long Uhid { get; set; }
        public long Ipnumber { get; set; }
        public int DrugCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string DrugName { get; set; }
        public string Dosages { get; set; }
        public string Frequency { get; set; }
        public string Route { get; set; }
        public DateTime MedicationStartDate { get; set; }
        public DateTime? MedicationEndDate { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime? LastMedicationDate { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
