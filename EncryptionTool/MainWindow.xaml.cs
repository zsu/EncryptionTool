using NetApp.Common;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncryptionTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtKey.Focus();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var options = new EncryptionOptions { Key = txtKey.Text.Trim(), Iv = txtIV.Text.Trim() };
            var encryptionService = new EncryptionService(options);
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show(this, "Key is required.");
                return;
            }
            try
            {
                txtResult.Text = encryptionService.Encrypt(txtValue.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var options = new EncryptionOptions { Key = txtKey.Text.Trim(), Iv = txtIV.Text.Trim() };
            var encryptionService = new EncryptionService(options);
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Key is required.");
                return;
            }
            try
            {
                txtResult.Text = encryptionService.Decrypt(txtValue.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtResult_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtResult.Text))
            {
                Clipboard.SetText(txtResult.Text.Trim());
                txtResult.SelectAll();
                txtResult.Focus();
            }
        }
    }
}
