using System;
using System.Collections.Generic;

namespace eSyaNursingStation.DL.Entities
{
    public partial class GtIpnsch
    {
        public int BusinessKey { get; set; }
        public long Uhid { get; set; }
        public long Ipnumber { get; set; }
        public string AssessmentStatus { get; set; }
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
