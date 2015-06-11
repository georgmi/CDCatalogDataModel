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
using CDCatalogDataModel;

namespace CDCatalogUI
{
    /// <summary>
    /// Interaction logic for AddArtist.xaml
    /// </summary>
    public partial class AddArtist : Window
    {
        public AddArtist()
        {
            InitializeComponent();
        }

        private void btnAddArtistCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddArtistGo_Click(object sender, RoutedEventArgs e)
        {
            if (txtArtistName.Text != "")
            {
                CDCatalogProcess.AddArtistGo(txtArtistName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Artist Name cannot be empty.");
            }
        }
    }
}
