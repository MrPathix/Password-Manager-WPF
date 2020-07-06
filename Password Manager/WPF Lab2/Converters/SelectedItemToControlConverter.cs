using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF_Lab2.Models;
using WPF_Lab2.Views;

namespace WPF_Lab2.Converters
{
    class SelectedItemToControlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TreeViewImage)
            {
                return new ImageDisplayingPanel(value as TreeViewImage);
            }
            else if (value is TreeViewPassword)
            {
                return new PasswordManagingPanel(value as TreeViewPassword);
            }
            else if (value is TreeViewDirectory)
            {
                return new DirectoryDisplayingPanel(value as TreeViewDirectory);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
