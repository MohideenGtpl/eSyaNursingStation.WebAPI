using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNursingStation.DO
{
    public class DO_PatientConsentRecording
    {
        public int BusinessKey { get; set; }
        public int UHID { get; set; }
        public int IPNumber { get; set; }
        public int SerialNumber { get; set; }
        public string ConsentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormID { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
