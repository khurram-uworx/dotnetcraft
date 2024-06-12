using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;

namespace UWorx.HR.Data.Helpers
{
    internal static class SqlReaderHelper
    {
        public static bool IsNullableType(Type valueType)
        {
            return (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public static T GetValue<T>(SqlDataReader reader, string columnName)
        {
            object value = reader[columnName];
            Type valueType = typeof(T);

            if (valueType == typeof(string) && !DBNull.Value.Equals(reader[columnName]))
            {
                if (!string.IsNullOrEmpty((string)value))
                {
                    value = ((string)value).TrimEnd(' ');
                }
            }

            if (DBNull.Value != value)
            {
                if (!IsNullableType(valueType))
                {
                    return (T)Convert.ChangeType(value, valueType, CultureInfo.InvariantCulture);
                }
                else
                {
                    NullableConverter theNullableConverter = new NullableConverter(valueType);

                    return (T)Convert.ChangeType(value, theNullableConverter.UnderlyingType, CultureInfo.InvariantCulture);
                }
            }

            return default(T);
        }
    }
}
