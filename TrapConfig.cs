using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCPReportingSystem
{
    public class TrapConfig
    {
        private string _oid;
        private string _datatype;
        private string trapname;
        private string _unit;
        public TrapConfig(string oid, string datatype, string trapname, string unit)
        {
            _oid = oid;
            _datatype = datatype;
            this.trapname = trapname;
            _unit = unit;
        }
        public string Oid
        {
            get { return _oid; }
        }
        public string Datatype
        {
            get { return _datatype; }
        }
        public string TrapName
        {
            get { return trapname; }
        }
        public string Unit
        {
            get { return _unit; }
        }
    }
}
