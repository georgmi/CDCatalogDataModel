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
    /// Interaction logic for CreatePlaylist.xaml
    /// </summary>
    public partial class CreatePlaylist : Window
    {
        public CreatePlaylist()
        {
            InitializeComponent();
        }

        private void btnCreatePlaylistCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreatePlaylistGo_Click(object sender, RoutedEventArgs e)
        {
            //Collect and validate inputs:
                //Name should be any string
                //Length should be a positive integer
            int length = CDCatalogProcess.CreatePlaylistValidateLength(txtCreatePlaylistMinutes.Text);
            if (length > 0 && txtCreatePlaylistName.Text.Length > 0)
            {
                int duration = CDCatalogProcess.CreatePlaylistGo(txtCreatePlaylistName.Text, length);
                listBoxPlaylistSongs.DataContext = CDCatalogProcess.subWindowPlaylistSongs;
                lblCreatePlaylistActualLength.Content = ("Playlist will run for " + duration.ToString() + " seconds");
            }
            else
            {
                string message = "Something is wrong.\n";
                if (length <= 0)
                {
                    message += "Time must be a positive integer.\n";
                }
                if (txtCreatePlaylistName.Text == "")
                {
                    message += "Playlist name cannot be empty.";
                }
                MessageBox.Show(message);
            }
            //Create playlist
            //Display playlist in listbox
        }
    }
}
