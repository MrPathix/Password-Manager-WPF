using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Lab2.Models
{
    [Serializable]
    public class TreeViewNode : TreeViewItem, INotifyPropertyChanged
    {
        public bool IsRenamed
        {
            get { return (bool)GetValue(IsRenamedProperty); }
            set { SetValue(IsRenamedProperty, value); OnPropertyChanged("IsRenamed"); }
        }

        public static readonly DependencyProperty IsRenamedProperty =
            DependencyProperty.Register("IsRenamed", typeof(bool), typeof(TreeViewNode), new PropertyMetadata(false));

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
