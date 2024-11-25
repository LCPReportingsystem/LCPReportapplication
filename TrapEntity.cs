using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCPReportingSystem
{
    public class TrapEntity
    {
        string _subsysipset = string.Empty;
        string _trapnameset = string.Empty;
        string _traptimestampset = string.Empty;
        string _trapvalueset = string.Empty;
        string _trapgroupset = string.Empty;
        string _datetimestampset = string.Empty;

        string _recordid = string.Empty;
        string _subsysip = string.Empty;
        string _subsystemname = string.Empty;
        string _trapname = string.Empty;
        string _traptimestamp = string.Empty;
        string _trapvalue = string.Empty;
        string _trapgroup = string.Empty;
        string _datetimestamp = string.Empty;
        public TrapEntity(string RecordID = null, string SubSysIp = null, string SubsystemName = null, string TrapName = null, string TrapTimeStamp = null,
            string TrapValue = null, string TrapGroup = null, string DateTimeStamp = null)
        {
            this._recordid = RecordID;
            this._subsysip = SubSysIp;
            this._subsystemname = SubsystemName;
            this._trapname = TrapName;
            this._traptimestamp = TrapTimeStamp;
            this._trapvalue = TrapValue;
            this._trapgroup = TrapGroup;
            this._datetimestamp = DateTimeStamp;
        }
        #region Get property 
        public string GetRecordID
        {
            get { return this._recordid; }
        }
        public string GetSubsystemIp
        {
            get { return this._subsysip; }
        }
        public string GetSubsysName
        {
            get { return this._subsystemname; }
        }
        public string GetTrapName
        {
            get { return this._trapname; }
        }
        public string GetTrapTimeStamp
        {
            get { return this._traptimestamp; }
        }
        public string GetTrapValue
        {
            get { return this._trapvalue; }
        }
        public string GetTrapGroup
        {
            get { return this._trapgroup; }
        }
        public string GetDateTimestamp
        {
            get { return this._datetimestamp; }
        }

        #endregion

        public string SubsystemIP
        {
            get { return this._subsysipset; }
            set
            {
                this._subsysipset = value;
            }
        }
        public string TrapName
        {
            get { return this._trapnameset; }
            set
            {
                this._trapnameset = value;
            }
        }
        public string TrapTimeStamp
        {
            get { return this._traptimestampset; }
            set
            {
                this._traptimestampset = value;
            }
        }
        public string TrapValue
        {
            get { return this._trapvalueset; }
            set
            {
                this._trapvalueset = value;
            }
        }
        public string TrapGroup
        {
            get { return this._trapgroupset; }
            set
            {
                this._trapgroupset = value;
            }
        }
        public string DateTimestamp
        {
            get { return this._datetimestampset; }
            set
            {
                this._datetimestampset = value;
            }
        }

    }
}
