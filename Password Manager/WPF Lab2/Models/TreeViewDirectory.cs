using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Lab2.Models
{
    public class TreeViewDirectory : TreeViewNode
    {
        public TreeViewDirectory(string name)
        {
            FontWeight = FontWeights.Bold;
            FontStyle = FontStyles.Normal;
            Header = name;
            IsRenamed = false;
        }
    }
}
