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
    /// Interaction logic for RateSong.xaml
    /// </summary>
    public partial class RateSong : Window
    {
        Song song;
        public RateSong(Song input)
        {
            InitializeComponent();
            song = input;
            if(null != song.Rating && song.Rating < 6 && song.Rating > -1)
            {
                comboBoxRateSongRating.SelectedIndex = ((int)song.Rating);
            }
            lblRateSongTitle.Content = "Title: " + song.SongTitle;
            lblRateSongArtist.Content = "By Artist: " + song.Artist.ArtistName;
            lblRateSongAlbum.Content = "On album: " + song.Album.AlbumTitle;
        }

        private void btnRateSongCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRateSongGo_Click(object sender, RoutedEventArgs e)
        {
            CDCatalogProcess.RateSongGo(song, (comboBoxRateSongRating.SelectedIndex));
            this.Close();
        }


    }
}
