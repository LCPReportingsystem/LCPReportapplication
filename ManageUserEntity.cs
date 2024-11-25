using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LCPReportingSystem
{
    public class ManageUserEntity
    {
        string _userid = string.Empty;
        string _username = string.Empty;
        string _password = string.Empty;
        string _usertype = string.Empty;
        string _email = string.Empty;
        string _isactive = string.Empty;
        string _creationdate = string.Empty;

        bool _isselected;
        public ManageUserEntity(string userid = null, string username = null, string password = null,
            string usertype = null, string email = null, string isactive = null, string creationdate = null)
        {
            _userid = userid;
            _username = username;
            _password = password;
            _usertype = usertype;
            _email = email;
            _isactive = isactive;
            _creationdate = creationdate;
        }
        public string Userid
        {
            get { return _userid; }
        }
        public string Username
        {
            get { return _username; }
        }
        public string Password
        {
            get { return _password; }
        }
        public string UserType
        {
            get { return _usertype; }
        }
        public string Email
        {
            get { return _email; }
        }
        public string Isactive
        {
            get { return _isactive; }
        }
        public string Creationdate
        {
            get { return _creationdate; }
        }
        public bool IsSelected
        {
            get { return _isselected; }
            set
            {
                _isselected = value;
            }
        }
    }
}
