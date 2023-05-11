using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNursingStation.DO
{
    public class DO_NurseAssessment
    {
        public int BusinessKey { get; set; }
        public int UHID { get; set; }
        public int IPNumber { get; set; }
        public List<DO_NS_ControlValue> l_NS_ControlValue { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormID { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }

    public class DO_NS_ControlValue
    {
        public string NSControlID { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
    }
}
