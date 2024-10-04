using System.ComponentModel;
using System.Reflection;

namespace Example.TestAutomation.Ui.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            DescriptionAttribute[]? attributes = (DescriptionAttribute[])field!.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes?.Length > 0 && attributes is not null ? attributes[0].Description : value.ToString();
        }
    }
}
