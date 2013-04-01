﻿using System;
using System.Data;

namespace DotNetNuke.Modules.ActiveForums
{
    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            if (dr == null || string.IsNullOrWhiteSpace(columnName))
                return false;

            for (var i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static string GetString(this IDataRecord dr, string columnName, string defaultValue = null)
        {
            return !dr.HasColumn(columnName) ? defaultValue : Utilities.SafeConvertString(dr[columnName], defaultValue);
        }

        public static int GetInt(this IDataRecord dr, string columnName, int defaultValue = 0)
        {
            return !dr.HasColumn(columnName) ? defaultValue : Utilities.SafeConvertInt(dr[columnName], defaultValue);
        }

        public static double GetDouble(this IDataRecord dr, string columnName, double defaultValue = 0)
        {
            return !dr.HasColumn(columnName) ? defaultValue : Utilities.SafeConvertDouble(dr[columnName], defaultValue);
        }

        public static bool GetBoolean(this IDataRecord dr, string columnName, bool defaultValue = false)
        {
            return !dr.HasColumn(columnName) ? defaultValue : Utilities.SafeConvertBool(dr[columnName], defaultValue);
        }

        public static DateTime GetDateTime(this IDataRecord dr, string columnName, DateTime? defaultValue = null)
        {
            if (!dr.HasColumn(columnName))
                return defaultValue.HasValue ? defaultValue.Value : Utilities.NullDate();

            return Utilities.SafeConvertDateTime(dr[columnName], defaultValue);
        }
    }
}
