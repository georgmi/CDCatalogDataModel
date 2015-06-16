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
    /// Interaction logic for RateAlbum.xaml
    /// </summary>
    public partial class RateAlbum : Window
    {
        Album album;

        public RateAlbum(Album input)
        {
            InitializeComponent();
            album = input;
            if (null != album.Rating && album.Rating < 6 && album.Rating > -1)
            {
                comboBoxRateSongRating.SelectedIndex = ((int)album.Rating);
            }
            lblRateAlbumTitle.Content = "Title: " + album.AlbumTitle;
            lblRateAlbumArtist.Content = "By artist: " + album.Artist.ArtistName;
        }

        private void btnRateAlbumCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRateAlbumGo_Click(object sender, RoutedEventArgs e)
        {
            CDCatalogProcess.RateAlbumGo(album, (comboBoxRateSongRating.SelectedIndex));
            this.Close();
        }
    }
}
