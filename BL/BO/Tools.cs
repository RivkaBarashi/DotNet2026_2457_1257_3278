

using System.Reflection;
using System.Runtime.CompilerServices;

namespace BO
{
    public static class Tools
    {
        public static string ToStringProperty<T> (this T t)
        {
            string str = "";
            Type Ttype = t.GetType();
            PropertyInfo[] info = Ttype.GetProperties();
            foreach (PropertyInfo item in info)
            {
                str += string.Format("name: {0,-15} value {1,-15} ", item.Name, item.GetValue(t));
            }
            return str;

        }
    }
}
