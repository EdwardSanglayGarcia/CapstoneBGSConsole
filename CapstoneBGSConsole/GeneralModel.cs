using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }

    public class EnvironmentalConcern
    {
        public int EnvironmentalConcernID { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }

    public class UpdatedStatus
    {
        public string UpdatedStatusID { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }

    public class CaseReport
    {
        public int CaseReportID { get; set; }
        public int UserInformationID { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string MaidenName { get; set; }
        public DateTime DateReported { get; set; }
        public int EnvironmentalConcernID { get; set; }
        public string Concern { get; set; }
        public int UpdatedStatusID { get; set; }
        public string UpdatedStatus { get; set; }
        public DateTime UpdatedStatusDate { get; set; }
        public string CaseLocation { get; set; }
        public string CaseReportPhoto { get; set; }
        public int XCoordinates { get; set; }
        public int YCoordinates { get; set; }
        public string Notes { get; set; }
    }

    public class UserInformation
    {
        public int UserInformationID { get; set; }
        public int UserTypeID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GivenName { get; set; }
        public string MaidenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    }

}
