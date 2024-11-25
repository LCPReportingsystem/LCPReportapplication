using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using LCPReportingSystem.DAL;
using LCPReportingSystem.Model;
using System.IO;
using Newtonsoft.Json;

namespace LCPReportingSystem
{
    public class Utility
    {
        private DataAccessLayer _layer;
        public Utility()
        {
            _layer = new DataAccessLayer();
        }

        public bool userLogin(string username, string password)
        {
            bool? IsloginSucess = null;
            try
            {
                string LoginMessage = _layer.userAuthendication(username, password);
                if (!string.IsNullOrEmpty(LoginMessage))
                {
                    if (LoginMessage == "Sucess")
                    {
                        IsloginSucess = true;
                    }
                    else
                    {
                        IsloginSucess = false;
                    }
                }
                return Convert.ToBoolean(IsloginSucess);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }

        }

        public bool IsadminUser(string username, string password)
        {
            bool? IsAdmin = null;
            try
            {
                string getUserRole = _layer.getUserRole(username, password);
                if (!string.IsNullOrEmpty(getUserRole))
                {
                    if (getUserRole == "Admin")
                    {
                        IsAdmin = true;
                    }
                    else
                    {
                        IsAdmin = false;
                    }
                }
                return Convert.ToBoolean(IsAdmin);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }
        public bool IsUserExists(string username, string password)
        {
            bool? IsUserExists = null;
            try
            {
                string IsResultMessage = _layer.CheckUserExists(username, password);
                if (!string.IsNullOrEmpty(IsResultMessage))
                {
                    if (IsResultMessage != "Exists")
                    {
                        IsUserExists = true;
                    }
                    else
                    {
                        IsUserExists = false;
                    }
                }
                return Convert.ToBoolean(IsUserExists);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }
        public bool IsSucessAddNewuser(Admin admin)
        {
            bool? IsUserMessage = null;
            try
            {
                string getMessage = _layer.CreateNewUser(admin);
                if (!string.IsNullOrEmpty(getMessage))
                {
                    if (getMessage == "Sucess")
                    {
                        IsUserMessage = true;
                    }
                    else
                    {
                        IsUserMessage = false;
                    }
                }
                return Convert.ToBoolean(IsUserMessage);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }
        public bool IsDeleteUserData(string Userid, string Username)
        {
            string IsMessage;
            bool? IsDeleted = null;
            try
            {
                IsMessage = _layer.DeleteUserData(Userid, Username);
                if (!string.IsNullOrEmpty(IsMessage))
                {
                    if (IsMessage == "Success")
                    {
                        IsDeleted = true;
                    }
                    else
                    {
                        IsDeleted = false;
                    }
                }
                return Convert.ToBoolean(IsDeleted);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }

        public ObservableCollection<ManageUserEntity> getUserCollection()
        {
            ObservableCollection<ManageUserEntity> _usercollection = null;
            try
            {
                if (_usercollection == null)
                {
                    _usercollection = new ObservableCollection<ManageUserEntity>();
                    DataTable UserDt = new DataTable();
                    UserDt = _layer.getAllUserData();
                    if (UserDt != null)
                    {
                        foreach (DataRow row in UserDt.Rows)
                        {
                            string UserID = Convert.ToString(row["UserId"]);
                            string Username = row["Username"].ToString();
                            string Password = row["Password"].ToString();
                            string UserType = row["UserType"].ToString();
                            string Email = row["Email"].ToString();
                            string IsActive = row["IsActive"].ToString();

                            string CreationDate = Convert.ToDateTime(row["CreationDate"].ToString()).ToString("dd/MM/yyyy");

                            _usercollection.Add(new ManageUserEntity(UserID, Username, Password, UserType, Email, IsActive, CreationDate));
                        }
                    }
                }
                return _usercollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }

        public bool SaveSubSystemArchiveLastData(DashBoard dashBoard)
        {
            bool? isSaveConform = null;
            try
            {
                string IsSaveStatus = _layer.SaveSubSystemArchiveData(dashBoard);
                if (!string.IsNullOrEmpty(IsSaveStatus))
                {
                    if (IsSaveStatus == "Sucess")
                    {
                        isSaveConform = true;
                    }
                    else
                    {
                        isSaveConform = false;
                    }
                }
                return Convert.ToBoolean(isSaveConform);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }
        public bool IsResetPassword(string username, string password, string newpassword)
        {
            bool? IsRestPass = null;
            try
            {
                string resetMsg = _layer.RestPassword(username, password, newpassword);
                if (!string.IsNullOrEmpty(resetMsg))
                {
                    if (resetMsg == "Sucess")
                    {
                        IsRestPass = true;
                    }
                    else
                    {
                        IsRestPass = false;
                    }
                }
                return Convert.ToBoolean(IsRestPass);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }

        public bool IsConformPassword(string password, string conformpassword)
        {
            bool? IsPasswordMach = null;
            try
            {
                if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(conformpassword))
                {
                    if (password == conformpassword)
                    {
                        IsPasswordMach = true;
                    }
                    else
                    {
                        IsPasswordMach = false;
                    }
                }
                return Convert.ToBoolean(IsPasswordMach);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }

        public bool IsCredential(string username, string password, string conformpassword)
        {
            bool? IsResult;
            try
            {
                if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(conformpassword))
                {
                    IsResult = true;
                }
                else
                {
                    IsResult = false;
                }
                return Convert.ToBoolean(IsResult);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }
        public bool IsEmailValid(string email)
        {
            bool? IsEmailValid;
            if (!string.IsNullOrEmpty(email))
            {
                Regex regex = new Regex(_layer.getEmailChar());
                Match match = regex.Match(email);
                if (match.Success)
                {
                    IsEmailValid = true;
                }
                else
                {
                    IsEmailValid = false;
                }
            }
            else
            {
                IsEmailValid = false;
            }
            return Convert.ToBoolean(IsEmailValid);
        }

        public Dictionary<string, ParameterSetConfig> getLoadSnmplastLivedata(byte[] pdu, string _subsysIp, IsSubSystem isSubSystem)
        {
            Dictionary<string, ParameterSetConfig> keyValuePairs;
            try
            {
                keyValuePairs = new Dictionary<string, ParameterSetConfig>();
                keyValuePairs = _layer.getSnmpNonTrapLastLiveMessage(pdu, _subsysIp, isSubSystem);
                return keyValuePairs;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        public ObservableCollection<TrapInfo> LoadSnmpTrap(byte[] pdu, string subsysIp, IsSubSystem isSubSystem)
        {
            ObservableCollection<TrapInfo> TrapResult;
            try
            {
                TrapResult = new ObservableCollection<TrapInfo>();
                _layer.getLoadSnmpTrap(pdu, subsysIp, isSubSystem);
                TrapResult = _layer.getTrap();

                return TrapResult;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        public ObservableCollection<SubSysParameterConfig> getSubSystemConfig(IsSubSystem isSubSystem)
        {
            ObservableCollection<SubSysParameterConfig> _subsystemcollection = null;
            try
            {
                if (_subsystemcollection == null)
                {
                    _subsystemcollection = new ObservableCollection<SubSysParameterConfig>();
                    _subsystemcollection = _layer.getSubSystemConfiguration(isSubSystem);
                }
                return _subsystemcollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }

        }
        public string loadSubsystemConfigPath(IsSubSystem isSubSystem)
        {
            string getFilePath = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(getFilePath))
                {
                    getFilePath = _layer.getSubSystemConfigPath(isSubSystem);
                }
                return getFilePath;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        public string IsMenuActiveStatus(IsMenuActiveStatus isMenuActiveStatus)
        {
            int IsIndex = (int)isMenuActiveStatus;
            string getStatus = string.Empty;
            switch (IsIndex)
            {
                case 0:
                    getStatus = "MenuActive";
                    break;
                case 1:
                    getStatus = "MenuInactive";
                    break;
            }
            return getStatus;
        }
        public string GetSubsystemName(IsSubSystem isSubSystem)
        {
            int IsSubSysIndex = (int)isSubSystem;
            string SubsystemName = string.Empty;
            switch (IsSubSysIndex)
            {
                case 0:
                    SubsystemName = "Diesel Generator";
                    break;
                case 1:
                    SubsystemName = "Router";
                    break;
                case 2:
                    SubsystemName = "Radio";
                    break;
                case 3:
                    SubsystemName = "Switch";
                    break;
                case 4:
                    SubsystemName = "UPS";
                    break;
            }
            return SubsystemName;
        }
        public ObservableCollection<ArchiveEntity> getArchiveCollection(IsSubSystem isSubSystem, IsSqlFlag isSqlFlag)
        {
            ObservableCollection<ArchiveEntity> _archivecollection = null;
            try
            {
                if (_archivecollection == null)
                {
                    _archivecollection = new ObservableCollection<ArchiveEntity>();
                    DataTable ArchiveDt = new DataTable();
                    ArchiveDt = _layer.getSubsystemArchiveData(isSubSystem, isSqlFlag);
                    if (ArchiveDt != null)
                    {

                        foreach (DataRow row in ArchiveDt.Rows)
                        {
                            string RecordID = row["RecordID"].ToString();
                            string SubSystemIP = row["SubSystemIP"].ToString();
                            string SystemName = row["SystemName"].ToString();
                            string PrameterName = row["PrameterName"].ToString();
                            string PrameterValue = row["PrameterValue"].ToString();
                            string DateTimeStamp = row["DateTimeStamp"].ToString();
                            string CurrentDate = Convert.ToDateTime(row["CurrentDate"].ToString()).ToString("dd/MM/yyyy");

                            _archivecollection.Add(new ArchiveEntity(RecordID, SubSystemIP, SystemName, PrameterName, PrameterValue, DateTimeStamp, CurrentDate));
                        }
                    }
                }
                return _archivecollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSubSystem"></param>
        /// <param name="isSqlFlag"></param>
        /// <returns></returns>
        public ObservableCollection<ArchiveData> getArchiveCollection2(IsSubSystem isSubSystem, IsSqlFlag isSqlFlag)
        {
            ObservableCollection<ArchiveData> _archivecollection = null;
            StringBuilder ArchiveJsion = new StringBuilder();
            try
            {
                if (_archivecollection == null)
                {
                    _archivecollection = new ObservableCollection<ArchiveData>();
                    DataTable ArchiveDt = new DataTable();
                    ArchiveDt = _layer.getSubsystemArchiveData(isSubSystem, isSqlFlag);
                    if (ArchiveDt != null && ArchiveDt.Rows.Count > 0)
                    {
                        ArchiveJsion.Append(JsonConvert.SerializeObject(ArchiveDt));
                        _archivecollection = JsonConvert.DeserializeObject<ObservableCollection<ArchiveData>>(ArchiveJsion.ToString());
                    }
                }
                return _archivecollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
            finally 
            { 
                _archivecollection = null; 
            }
        }
        public ObservableCollection<ArchiveEntity> getArchiveCollection(IsSubSystem isSubSystem, IsSqlFlag isSqlFlag, IsRequestType isRequestType)
        {
            ObservableCollection<ArchiveEntity> _paramsCollection = null;
            try
            {
                if (_layer.GetRequestType(isRequestType).Equals("BindByCombo"))
                {
                    _paramsCollection = new ObservableCollection<ArchiveEntity>();
                    DataTable DtParams = new DataTable();
                    DtParams = _layer.getSubsystemArchiveData(isSubSystem, isSqlFlag);
                    if (DtParams != null)
                    {
                        foreach (DataRow row in DtParams.Rows)
                        {
                            string ParamsId = Convert.ToString(row["ParamsId"]);
                            string ParameterName = Convert.ToString(row["ParameterName"]);
                            string SystemName = Convert.ToString(row["SystemName"]);

                            _paramsCollection.Add(new ArchiveEntity(ParamsId, string.Empty, SystemName, ParameterName, string.Empty, string.Empty, string.Empty));
                        }
                    }
                }
                return _paramsCollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        public ObservableCollection<ArchiveData> ArchiveFilterCollection(IsSubSystem isSubSystem, string FromDate, string ToDate)
        {
            ObservableCollection<ArchiveData> _archivefiltercollection = null;
            try
            {
                if (_archivefiltercollection == null)
                {
                    _archivefiltercollection = new ObservableCollection<ArchiveData>();
                    DataTable FilterDt = new DataTable();
                    FilterDt = _layer.getArchiveFilterData(isSubSystem, FromDate, ToDate);
                    if (FilterDt != null)
                    {
                        foreach (DataRow row in FilterDt.Rows)
                        {
                            string RecordID = row["RecordID"].ToString();
                            string SubSystemIP = row["SubSystemIP"].ToString();
                            string SystemName = row["SystemName"].ToString();
                            string PrameterName = row["PrameterName"].ToString();
                            string PrameterValue = row["PrameterValue"].ToString();
                            string DateTimeStamp = row["DateTimeStamp"].ToString();
                            string CurrentDate = Convert.ToDateTime(row["CurrentDate"].ToString()).ToString("dd/MM/yyyy");
                            _archivefiltercollection.Add(new ArchiveData(RecordID, SubSystemIP, SystemName, PrameterName, PrameterValue, DateTimeStamp, CurrentDate));
                        }
                    }
                }
                return _archivefiltercollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }

        public ObservableCollection<ArchiveEntity> ArchiveFilterCollection(IsSubSystem isSubSystem, string FromDate, string ToDate, IsSqlFlag isSqlFlag, string ParamName)
        {
            ObservableCollection<ArchiveEntity> _linegraphCollection = null;
            try
            {
                if (_linegraphCollection == null)
                {
                    _linegraphCollection = new ObservableCollection<ArchiveEntity>();
                    DataTable DtLineGraph = new DataTable();
                    DtLineGraph = _layer.getArchiveFilterData(isSubSystem, isSqlFlag, FromDate, ToDate, ParamName);

                    if (DtLineGraph != null)
                    {
                        foreach (DataRow row in DtLineGraph.Rows)
                        {
                            string SystemName = Convert.ToString(row["SystemName"]);
                            string ParameterName = Convert.ToString(row["ParameterName"]);
                            string ParameterValue = Convert.ToString(row["ParameterValue"]);
                            string DateTimeStamp = Convert.ToString(row["DateTimeStamp"]);
                            string CurrentDate = Convert.ToDateTime(row["CurrentDate"].ToString()).ToString("dd/MM/yyyy");

                            _linegraphCollection.Add(new ArchiveEntity("", "", SystemName, ParameterName, ParameterValue, DateTimeStamp, CurrentDate));
                        }
                    }
                }
                return _linegraphCollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        public ObservableCollection<TrapEntity> GetSubsystemTrapCollection(IsSubSystem isSubSystem)
        {
            ObservableCollection<TrapEntity> TrapCollection = null;
            try
            {
                if (TrapCollection == null)
                {
                    TrapCollection = new ObservableCollection<TrapEntity>();
                    DataTable DtTrapData = new DataTable();
                    DtTrapData = _layer.GetSubsystemTrapData(isSubSystem);
                    if (DtTrapData != null)
                    {
                        if (DtTrapData.Rows.Count > 0)
                        {
                            foreach (DataRow traps in DtTrapData.Rows)
                            {
                                string RecordID = Convert.ToString(traps["RecordID"]);
                                string SubSystemIP = Convert.ToString(traps["SubSystemIP"]);
                                string SystemName = Convert.ToString(traps["SystemName"]);
                                string TrapName = Convert.ToString(traps["TrapName"]);
                                string TrapTimeStamp = Convert.ToString(traps["TrapTimeStamp"]);
                                string TrapValue = Convert.ToString(traps["TrapValue"]);
                                string TrapGroup = Convert.ToString(traps["TrapGroup"]);
                                string DateTimeStamp = Convert.ToString(traps["DateTimeStamp"]);

                                TrapCollection.Add(new TrapEntity(RecordID, SubSystemIP, SystemName, TrapName, TrapTimeStamp, TrapValue, TrapGroup, DateTimeStamp));
                            }
                        }
                    }
                }
                return TrapCollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSubSystem"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public ObservableCollection<ArchiveData> GetSubsystemTrapFilterData(IsSubSystem isSubSystem, string FromDate, string ToDate)
        {
            ObservableCollection<ArchiveData> TrapFilterCollection = null;
            try
            {
                if (TrapFilterCollection == null)
                {
                    TrapFilterCollection = new ObservableCollection<ArchiveData>();
                    DataTable TrapTable = new DataTable();
                    TrapTable = _layer.GetSubsystemTrapDatewise(isSubSystem, FromDate, ToDate);
                    if (TrapTable != null)
                    {
                        if (TrapTable.Rows.Count > 0)
                        {
                            foreach (DataRow traps in TrapTable.Rows)
                            {
                                string RecordID = Convert.ToString(traps["RecordID"]);
                                string SubSystemIP = Convert.ToString(traps["SubSystemIP"]);
                                string SystemName = Convert.ToString(traps["SystemName"]);
                                string TrapName = Convert.ToString(traps["TrapName"]);
                                string TrapTimeStamp = Convert.ToString(traps["TrapTimeStamp"]);
                                string TrapValue = Convert.ToString("TrapValue");
                                string TrapGroup = Convert.ToDateTime(traps["CurrentDate"].ToString()).ToString("dd/MM/yyyy");
                                string DateTimeStamp = Convert.ToString(traps["DateTimeStamp"]);
                                string CurrentDate = Convert.ToDateTime(traps["CurrentDate"].ToString()).ToString("dd/MM/yyyy");
                                TrapFilterCollection.Add(new ArchiveData(RecordID, SubSystemIP, SystemName, TrapName, TrapValue, CurrentDate, DateTimeStamp));
                            }
                        }
                    }
                }
                return TrapFilterCollection;
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return null;
            }
        }
        public bool IsDeleteArchiveData(IsSubSystem isSubSystem, string FromDate, string ToDate)
        {
            string IsMessage;
            bool? IsDeleted = null;
            try
            {
                IsMessage = _layer.DeleteArchiveData(isSubSystem, FromDate, ToDate);
                if (!string.IsNullOrEmpty(IsMessage))
                {
                    if (IsMessage == "Success")
                    {
                        IsDeleted = true;
                    }
                    else
                    {
                        IsDeleted = false;
                    }
                }
                return Convert.ToBoolean(IsDeleted);
            }
            catch (Exception ex)
            {
                CreateLogFile(ex);
                return false;
            }
        }
        public string LoadSubsystemName(string Ip)
        {
            string Result = string.Empty;
            if (!string.IsNullOrEmpty(Ip))
            {
                Result = _layer.GetSubsystemName(Ip);
            }
            return Result;
        }
        public void CreateLogFile(Exception exception)
        {
            _layer.GenerateErrorLog(exception);
        }
        public string getSubSystemDirectory(IsAppService isAppService)
        {
            string GetSystemFilePath = string.Empty;
            if (string.IsNullOrEmpty(GetSystemFilePath))
            {
                GetSystemFilePath = _layer.getSubSystemFilePath(isAppService);
            }
            return GetSystemFilePath;
        }
        public void GenerateSubsystemNonTrapText(string SysName, string ParmsName, string value, string timestamp)
        {
            _layer.GenerateTrapNonTrapTxt(SysName, ParmsName, value, timestamp);
        }
    }
}
