using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCPReportingSystem
{
    public class SubSysParameterConfig
    {
        string _oid = string.Empty;
        string _datatype = string.Empty;
        string _paramname = string.Empty;
        string _minvalue = string.Empty;
        string _maxvalue = string.Empty;
        string _redrange = string.Empty;
        string _amberRange = string.Empty;
        string _greenrange = string.Empty;
        public SubSysParameterConfig(string oid, string datatype, string paramname, string minvalue, string maxvalue, string redrange, string amberRange, string greenrange)
        {
            this._oid = oid;
            this._datatype = datatype;
            this._paramname = paramname;
            this._minvalue = minvalue;
            this._maxvalue = maxvalue;
            this._redrange = redrange;
            this._amberRange = amberRange;
            this._greenrange = greenrange;
        }
        public string Oid
        {
            get { return _oid; }
        }
        public string DataType
        {
            get { return _datatype; }
        }
        public string ParamName
        {
            get { return _paramname; }
        }
        public string MinValue
        {
            get { return _minvalue; }
        }
        public string MaxValue
        {
            get { return _maxvalue; }
        }
        public string RedRange
        {
            get { return _redrange; }
        }
        public string AmberRange
        {
            get { return _amberRange; }
        }
        public string GreenRange
        {
            get { return _greenrange; }
        }
    }
}
