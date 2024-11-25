using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCPReportingSystem
{
    public class ArchiveEntity
    {
        string _recordid = string.Empty;
        string _subsystemid = string.Empty;
        string _susbsystemname = string.Empty;
        string _parametername = string.Empty;
        string _parametervalue = string.Empty;
        string _timestamp = string.Empty;
        string _recorddate = string.Empty;

        public ArchiveEntity(string recordid = null, string subsystemid = null, string susbsystemname = null, string parametername = null, 
            string parametervalue = null, string timestamp = null, string recorddate = null)
        {
            _recordid = recordid;
            _subsystemid = subsystemid;
            _susbsystemname = susbsystemname;
            _parametername = parametername;
            _parametervalue = parametervalue;
            _timestamp = timestamp;
            _recorddate = recorddate;
        }
        public string Recordid
        {
            get { return _recordid; }
        }
        public string SubsystemId
        {
            get { return _subsystemid; }
        }
        public string SusbsystemName
        {
            get { return _susbsystemname; }
        }
        public string ParameterName
        {
            get { return _parametername; }
        }
        public string ParameterValue
        {
            get { return _parametervalue; }
        }
        public string Timestamp
        {
            get { return _timestamp; }
        }
        public string Recorddate
        {
            get { return _recorddate; }
        }
    }
    public class DeviceInfo
    {
        int? _driverindex = null;
        string _deviceDescription = string.Empty;
        bool? _ischecked = null;
        public DeviceInfo(int? driverindex = null, string deviceDescription = null, bool? ischecked = null)
        {
            _driverindex = driverindex;
            _deviceDescription = deviceDescription;
            _ischecked = ischecked;
        }
        public int? Driverindex
        {
            get { return _driverindex; }
            set { _driverindex = value; }
        }
        public string DeviceDescription
        {
            get { return _deviceDescription; }
            set { _deviceDescription = value; }
        }
        public bool? IsChecked
        {
            get { return _ischecked; }
            set { _ischecked = value; }
        }
    }
}
