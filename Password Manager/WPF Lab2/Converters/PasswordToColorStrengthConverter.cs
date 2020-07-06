using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_Lab2.Converters
{
    class PasswordToColorStrengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = (int)WPF_Lab2.Models.PasswordStrengthUtils.CalculatePasswordStrength(value as string);

            switch (result)
            {
                case 0:
                    return Brushes.Gray;
                case 1:
                    return Brushes.Red;
                case 2:
                    return Brushes.OrangeRed;
                case 3:
                    return Brushes.Orange;
                case 4:
                    return Brushes.LightGreen;
                case 5:
                    return Brushes.Green;
                default:
                    return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
