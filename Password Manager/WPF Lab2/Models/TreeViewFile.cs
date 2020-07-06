using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Lab2.Models
{
    public class TreeViewFile : TreeViewNode
    {
        public TreeViewFile(string name)
        {
            FontStyle = FontStyles.Italic;
            FontWeight = FontWeights.Normal;
            Header = name;
            IsRenamed = false;
        }
    }
}
