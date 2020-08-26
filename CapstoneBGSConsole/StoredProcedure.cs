using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBGSConsole
{
    public enum StoredProcedureEnum
    {
        V_UserType,
        I_UserType,
        D_UserType,
        U_UserType,

        V_UserInformation,
        I_UserInformation,
        D_UserInformation,

        V_EnvironmentalConcern,
        I_EnvironmentalConcern,
        D_EnvironmentalConcern,
        U_EnvironmentalConcern,

        V_UpdatedStatus,
        I_UpdatedStatus,
        D_UpdatedStatus,
        U_UpdatedStatus,

        V_CaseReport,
        I_CaseReport,
        D_CaseReport,
        U_CaseReport,


        GENERATION_AreaPerMonthYear,
        GENERATION_MonthlyTotals

    }
}
