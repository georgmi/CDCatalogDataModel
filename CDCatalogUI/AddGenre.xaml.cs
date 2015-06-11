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
    /// Interaction logic for AddGenre.xaml
    /// </summary>
    public partial class AddGenre : Window
    {
        public AddGenre()
        {
            InitializeComponent();
        }

        private void btnAddGenreCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddGenreGo_Click(object sender, RoutedEventArgs e)
        {
            if(txtGenreName.Text != "")
            {
                CDCatalogProcess.AddGenreGo(txtGenreName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Genre Name cannot be empty.");
            }
        }
    }
}
