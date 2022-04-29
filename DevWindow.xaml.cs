using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BioReviewGame
{
    public partial class DevWindow : Window
    {
        public DevWindow()
        {
            InitializeComponent();
        }
        private void D_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose a Questions File to Decrypt",
                Filter = "Q&A Files|*.q&a;*.Q&A;"
            };
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                Security.Decrypt(openFileDialog.FileName, openFileDialog.SafeFileName, true);
            }
        }
        private void E_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Choose a Json File to Encrypt",
                Filter = "Json Files|*.json;*.JSON;"
            };
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                Security.Encrypt(openFileDialog.FileName, openFileDialog.SafeFileName);
            }
        }
    }
}
