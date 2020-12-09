using NETCore.Encrypt;
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
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show(this,"Key is required.");
                return;
            }
            try
            {
                if (string.IsNullOrWhiteSpace(txtIV.Text))
                    txtResult.Text = EncryptProvider.AESEncrypt(txtValue.Text.Trim(), txtKey.Text.Trim());
                else
                    txtResult.Text = EncryptProvider.AESEncrypt(txtValue.Text.Trim(), txtKey.Text.Trim(), txtIV.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKey.Text))
            {
                MessageBox.Show("Key is required.");
                return;
            }
            try
            {
                if (string.IsNullOrWhiteSpace(txtIV.Text))
                    txtResult.Text = EncryptProvider.AESDecrypt(txtValue.Text.Trim(), txtKey.Text.Trim());
                else
                    txtResult.Text = EncryptProvider.AESDecrypt(txtValue.Text.Trim(), txtKey.Text.Trim(), txtIV.Text.Trim());
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
