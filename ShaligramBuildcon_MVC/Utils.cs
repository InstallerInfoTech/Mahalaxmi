using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace ShaligramBuildcon_MVC
{
    public class Utils
    {
        public static SqlParameter GetSQLParam(string paramName, SqlDbType type, dynamic value, [Optional] string typeName)
        {
            SqlParameter sqlParam = new SqlParameter(paramName, type);
            sqlParam.Value = value;
            if (typeName != null)
            {
                sqlParam.TypeName = typeName;
            }
            return sqlParam;
        }
    }
}