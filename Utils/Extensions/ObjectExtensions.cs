using System.Collections;
using System.Linq.Expressions;
using System.Text;

namespace Utils.Extensions
{
    public static class ObjectExtensions
    {
        public static string Str(this object value)
        {
            if (value == null)
                return string.Empty;

            return value.ToString();
        }

        public static T ToEnum<T>(this int value) where T : struct, IConvertible
        {
            try
            {
                return (T)(object)value;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static int ToInt(this object value)
        {
            if (value is Enum)
                return (int)value;
            else
            {
                if (int.TryParse(value.Str(), out int result))
                    return result;
                else return default;
            }
        }

        public static long ToLong(this object value)
        {
            return Convert.ToInt64(value);
        }

        public static T To<T>(this object obj)
        {
            return (T)obj;
        }

        public static string GetName(this object obj)
        {
            return obj.ToString();
        }

        public static decimal ToDecimal(this object value, string numberDecimalSeparator = "")
        {
            if (value == null || value.ToString().ToLower() == "null")
                return 0;

            if (string.IsNullOrEmpty(numberDecimalSeparator))
                return Convert.ToDecimal(value.ToString());
            else
            {
                if (value.ToString().Contains(','))
                {
                    value = value.ToString().Replace(".", "");
                }

                value = value.ToString().Replace(".", numberDecimalSeparator)
                                        .Replace(",", numberDecimalSeparator);

                return Convert.ToDecimal(value);
            }
        }

        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }

        public static bool IsNull(this object obj)
        {
            return (obj == null);
        }

        public static bool IsFalse(this bool obj)
        {
            return obj;
        }

        public static bool IsSuccess(this bool obj)
        {
            return obj;
        }

        public static bool IsNullOrEmpty(this ICollection obj)
        {
            return IsNull(obj) || obj.Count == 0;
        }

        public static bool IsListNotNull(this ICollection obj)
        {
            return !IsNull(obj) && obj.Count > 0;
        }
        public static bool IsListNull(this ICollection obj)
        {
            return IsNull(obj) || obj.Count == 0;
        }

        public static string JoinStr(this ICollection<string> obj)
        {
            return string.Join("", obj);
        }

        public static bool In(this decimal value, IEnumerable<decimal> source)
        {
            return source.Contains(value);
        }

        public static bool In(this string value, IEnumerable<string> source)
        {
            return source.Contains(value);
        }

        public static bool NotIn(this decimal value, IEnumerable<decimal> source)
        {
            return !value.In(source);
        }

        public static bool NotIn(this string value, IEnumerable<string> source)
        {
            return !value.In(source);
        }

        public static bool In(this int value, IEnumerable<int> source)
        {
            return source.Contains(value);
        }

        public static bool NotIn(this int value, IEnumerable<int> source)
        {
            return !value.In(source);
        }

        public static string LongToHex12Digits(this long hexNumber, string mask = "")
        {
            return string.IsNullOrEmpty(mask)
                   ? hexNumber.ToString("X12")
                   : hexNumber.ToString(mask);
        }

        public static string BiteArrayToStr(this byte[] obj)
        {
            return Encoding.ASCII.GetString(obj);
        }

        public static void RemoveRange<T>(this List<T> list, List<T> itensToRemove)
        {
            itensToRemove.ForEach(mac =>
                list.Remove(mac)
            );
        }

        public static long GetLastOdd(this List<long> itens)
        {
            if (itens.Count == 1)
                return itens.FirstOrDefault();

            foreach (var item in itens)
            {
                if (item % 2 != 0)
                    return item;
            }

            return 0;
        }

        public static string GetPropertyName<T>(this Expression<Func<T, object>> propertyFunc)
        {
            return propertyFunc.Body switch
            {
                MemberExpression member => GetPropertyName(member),
                UnaryExpression exp when exp.Operand is MemberExpression member => member.Member.Name,
                _ => throw new InvalidOperationException("Invalid property")
            };
        }

        public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty?>> propertyFunc)
            where TProperty : struct, IComparable, IComparable<TProperty>
        {
            return propertyFunc.Body switch
            {
                MemberExpression member => GetPropertyName(member),
                UnaryExpression exp when exp.Operand is MemberExpression member => member.Member.Name,
                _ => throw new InvalidOperationException("Invalid property")
            };
        }

        public static string RemoveWhiteSpace(this string str)
        {
            return string.Join(" ", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public static string GetPropertyName<T, TProperty>(this Expression<Func<T, TProperty>> propertyFunc)
        {
            return propertyFunc.Body switch
            {
                MemberExpression me => GetPropertyName(me),
                UnaryExpression exp when exp.Operand is MemberExpression member => member.Member.Name,
                _ => throw new InvalidOperationException("Invalid property"),
            };
        }

        private static string GetPropertyName(MemberExpression me)
        {
            var memberExpression = me;
            var parts = new List<string>();

            while (memberExpression != null)
            {
                parts.Add(memberExpression.Member.Name);
                memberExpression = memberExpression.Expression as MemberExpression;
            }

            parts.Reverse();
            return string.Join(".", parts);
        }

        public static string ToNullString<T>(this T? value) where T : struct
        {
            if (value == null)
                return null;

            return value.ToString();
        }
    }
}
