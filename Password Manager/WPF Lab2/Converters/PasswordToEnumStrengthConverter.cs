using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_Lab2.Converters
{
    class PasswordToEnumStrengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = (int)WPF_Lab2.Models.PasswordStrengthUtils.CalculatePasswordStrength(value as string);

            switch (result)
            {
                case 0:
                    return "Invalid";
                case 1:
                    return "Very weak";
                case 2:
                    return "Weak";
                case 3:
                    return "Average";
                case 4:
                    return "Strong";
                case 5:
                    return "Very strong";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
