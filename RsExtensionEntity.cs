using LCPReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCPReportingSystem
{
    public static class RsExtensionEntity
    {
        public static string GetRouerLinkStatus(this string Meta, RouterStatus routerStatus)
        {
            int IsIndex = (int)routerStatus;
            string getStatus = string.Empty;
            switch (IsIndex)
            {
                case 0:
                    getStatus = "UP";
                    break;
                case 1:
                    getStatus = "DOWN";
                    break;
            }
            return getStatus;
        }
        public static string GetColorIndicator(this string Meta, IsIndicatorColors isIndicatorColors)
        {
            int IsIndex = (int)isIndicatorColors;
            string getColor = string.Empty;
            switch (IsIndex)
            {
                case 0:
                    getColor = "red";
                    break;
                case 1:
                    getColor = "green";
                    break;
                case 2:
                    getColor = "amber";
                    break;
                case 3:
                    getColor = "gray";
                    break;
            }
            return getColor;
        }
        public static string GetRouterStatus(this string Meta, string PramsVal)
        {
            string ReturnStatus = string.Empty;
            if (!string.IsNullOrEmpty(PramsVal))
            {
                if (PramsVal.Equals("1"))
                {
                    ReturnStatus = "UP";
                }
                else
                {
                    ReturnStatus = "DOWN";
                }
            }
            return ReturnStatus;
        }
        public static string GetRdioTarminalStatus(this string Meta, string status)
        {
            string TerminalStatus = string.Empty;
            if (!string.IsNullOrEmpty(status))
            {
                if (status.Equals("1"))
                {
                    TerminalStatus = "Base";
                }
                if (status.Equals("2"))
                {
                    TerminalStatus = "Remote";
                }
                if (status.Equals("3"))
                {
                    TerminalStatus = "Repeater";
                }
            }
            return TerminalStatus;
        }
        public static string GetSqlConString(this string SqlConString, IsDbConString isDbConString)
        {
            int IsIndex = (int)isDbConString;
            string ReturnStatus = string.Empty;
            switch (IsIndex)
            {
                case 0:
                    ReturnStatus = "dbReports";
                    break;
                case 1:
                    ReturnStatus = "WindowdbReports";
                    break;
            }
            return ReturnStatus;
        }
        public static string GetSwitchEnvTempStatus(this string tempstatus, string Envtempstatus)
        {
            string GetEnvTempStatus = string.Empty;
            if (!string.IsNullOrEmpty(Envtempstatus))
            {
                switch (Envtempstatus)
                {
                    case "1":
                        GetEnvTempStatus = "Normal";
                        break;
                    case "2":
                        GetEnvTempStatus = "Warning";
                        break;
                    case "3":
                        GetEnvTempStatus = "Critical";
                        break;
                    case "4":
                        GetEnvTempStatus = "Shutdown";
                        break;
                    case "5":
                        GetEnvTempStatus = "Not Present";
                        break;
                    case "6":
                        GetEnvTempStatus = "Not Function";
                        break;
                }
            }
            return GetEnvTempStatus;
        }
        public static string GetDgTrapStatus(this string gtrapstatus, string IsStatus)
        {
            string Status = string.Empty;
            string valDefault = IsStatus;
            if (!string.IsNullOrEmpty(IsStatus))
            {
                switch (IsStatus)
                {
                    case "1":
                        Status = "alarmNormal";
                        break;
                    case "2":
                        Status = "alarmWarning";
                        break;
                    case "3":
                        Status = "alarmElectricalTrip";
                        break;
                    case "4":
                        Status = "alarmShutdown";
                        break;
                    case "5":
                        Status = "modeStop";
                        break;
                    case "6":
                        Status = "modeManual";
                        break;
                    case "7":
                        Status = "modeTest";
                        break;
                    case "8":
                        Status = "modeAuto";
                        break;
                    case "9":
                        Status = "modeConfig";
                        break;
                    case "10":
                        Status = "singleEventNotification";
                        break;
                    case "11":
                        Status = "ecuLampOff";
                        break;
                    case "12":
                        Status = "ecuLampFlashSlow";
                        break;
                    case "13":
                        Status = "ecuLampFlashFast";
                        break;
                    case "14":
                        Status = "ecuLampOnSteady";
                        break;
                    case "15":
                        Status = "fuelLevelUsageNormal";
                        break;
                    case "16":
                        Status = "fuelLevelEndFill";
                        break;
                    case "17":
                        Status = "fuelLevelStartFill";
                        break;
                    case "18":
                        Status = "fuelLevelUsageTheftAlarm";
                        break;
                    case "19":
                        Status = "fuelLevelUsageLevelAlarm";
                        break;
                    default:
                        Status = valDefault;
                        break;
                }
            }
            return Status;
        }
    }
}
