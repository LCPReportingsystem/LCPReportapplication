using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCPReportingSystem
{
    public class TrapInfo
    {
        private string _sysname;
        private string _trapname;
        private string _traptype;
        private string _systemuptime;
        private string _additionalvalue;
        private string _timestamp;
        public TrapInfo(string sysname = null, string trapname = null, string traptype = null, string systemuptime = null,
            string additionalvalue = null, string timestamp = null)
        {
            _sysname = sysname;
            _trapname = trapname;
            _traptype = traptype;
            _systemuptime = systemuptime;
            _additionalvalue = additionalvalue;
            _timestamp = timestamp;
        }
        public string SysName
        {
            get => _sysname;
        }
        public string TrapName
        {
            get => _trapname;
        }
        public string TrapType
        {
            get => $"{_traptype} ({_timestamp})";
        }
        public string SystemUpTime
        {
            get => _systemuptime;
        }
        public string AdditionalValue
        {
            get => _additionalvalue;
        }
        public string TimeStamp
        {
            get => _timestamp;
        }
    }
}
