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

namespace CDCatalogUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rbViewOptionsAll_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            //lblListBox Content = "No filter selected"
            //listBoxFilterList Content = clear
        }

        private void rbViewOptionsCD_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            //gridAlbumActions Visibility="Visible"
            //lblListBox Content = "Albums"
            //listBoxFilterList Content = Album List
        }

        private void rbViewOptionsArtist_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            //gridArtistActions Visibility="Visible"
            //lblListBox Content = "Artists"
            //listBoxFilterList Content = Artist List
        }

        private void rbViewOptionsGenre_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            //gridGenreActions Visibility="Visible"
            //lblListBox Content = "Genres"
            //listBoxFilterList Content = Genre List
        }

        private void rbViewOptionsPlaylist_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            //gridPlaylistActions Visibility="Visible"
            //lblListBox Content = "Playlists"
            //listBoxFilterList Content = Playlist List
        }
    }
}
