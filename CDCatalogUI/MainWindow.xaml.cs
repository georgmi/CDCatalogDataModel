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
using CDCatalogDataModel;

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
            this.Loaded += new RoutedEventHandler(rbViewOptionsAll_Checked);
            
        }

        private void rbViewOptionsAll_Checked(object sender, RoutedEventArgs e)
        {
            if(! rbViewOptionsAll.IsChecked == true )
            {
                rbViewOptionsAll.IsChecked = true;
            }
            //All ObjectActions grids Visibility="Hidden"
            HideAllActionGrids();
            HideAllFilterGrids();
            gridAllSongsFilter.Visibility = Visibility.Visible;
            //listBoxFilterList Content = clear
            comboBoxAllSongs.DataContext = null;
            //Song List = All Songs
            CDCatalogProcess.GetAllSongs();
            listBoxSongList.DataContext = CDCatalogProcess.displaySongList;
        }

        private void rbViewOptionsCD_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            HideAllActionGrids();
            HideAllFilterGrids();
            //gridAlbumActions Visibility="Visible"
            gridAlbumActions.Visibility = Visibility.Visible;
            gridAlbumFilter.Visibility = Visibility.Visible;
            //lblListBox Content = "Albums"
            CDCatalogProcess.GetAllAlbums();
            //listBoxFilterList Content = Album List
            comboBoxAlbum.DataContext = CDCatalogProcess.filterAlbumList;
            comboBoxAlbum.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAlbum_SelectionChanged));
            comboBoxAlbum.SelectedIndex = 0;

        }

        private void rbViewOptionsArtist_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            HideAllActionGrids();
            HideAllFilterGrids();
            //gridArtistActions Visibility="Visible"
            gridArtistActions.Visibility = Visibility.Visible;
            gridArtistFilter.Visibility = Visibility.Visible;
            //lblListBox Content = "Artists"
            CDCatalogProcess.GetAllArtists();
            //listBoxFilterList Content = Artist List
            comboBoxArtist.DataContext = CDCatalogProcess.filterArtistList;
            comboBoxArtist.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxArtist_SelectionChanged));
            comboBoxArtist.SelectedIndex = 0;
        }

        private void rbViewOptionsGenre_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            HideAllActionGrids();
            HideAllFilterGrids();
            //gridGenreActions Visibility="Visible"
            gridGenreActions.Visibility = Visibility.Visible;
            gridGenreFilter.Visibility = Visibility.Visible;
            //lblListBox Content = "Genres"
            CDCatalogProcess.GetAllGenres();
            //listBoxFilterList Content = Genre List
            comboBoxGenre.DataContext = CDCatalogProcess.filterGenreList;
            comboBoxGenre.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxGenre_SelectionChanged));
            comboBoxGenre.SelectedIndex = 0;
        }

        private void rbViewOptionsPlaylist_Checked(object sender, RoutedEventArgs e)
        {
            //All ObjectActions grids Visibility="Hidden"
            HideAllActionGrids();
            HideAllFilterGrids();
            //gridPlaylistActions Visibility="Visible"
            gridPlaylistActions.Visibility = Visibility.Visible;
            gridPlaylistFilter.Visibility = Visibility.Visible;
            //lblListBox Content = "Playlists"
            CDCatalogProcess.GetAllPlaylists();
            //listBoxFilterList Content = Playlist List
            comboBoxPlaylist.DataContext = CDCatalogProcess.filterPlaylistList;
            comboBoxPlaylist.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxPlaylist_SelectionChanged));
            comboBoxPlaylist.SelectedIndex = 0;
        }

        private void HideAllActionGrids()
        {
            gridAlbumActions.Visibility = Visibility.Hidden;
            gridArtistActions.Visibility = Visibility.Hidden;
            gridGenreActions.Visibility = Visibility.Hidden;
            gridPlaylistActions.Visibility = Visibility.Hidden;
        }

        private void HideAllFilterGrids()
        {
            comboBoxAlbum.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAlbum_SelectionChanged));
            comboBoxArtist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxArtist_SelectionChanged));
            comboBoxGenre.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxGenre_SelectionChanged));
            comboBoxPlaylist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxPlaylist_SelectionChanged));
            gridAllSongsFilter.Visibility = Visibility.Hidden;
            gridAlbumFilter.Visibility = Visibility.Hidden;
            gridArtistFilter.Visibility = Visibility.Hidden;
            gridGenreFilter.Visibility = Visibility.Hidden;
            gridPlaylistFilter.Visibility = Visibility.Hidden;
        }

        private void comboBoxAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CDCatalogProcess.FilterSongsByAlbum((Album)comboBoxAlbum.SelectedItem);
            listBoxSongList.DataContext = CDCatalogProcess.filteredSongList;
        }

        private void comboBoxArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CDCatalogProcess.FilterSongsByArtist((Artist)comboBoxArtist.SelectedItem);
            listBoxSongList.DataContext = CDCatalogProcess.filteredSongList;
        }

        private void comboBoxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CDCatalogProcess.FilterSongsByGenre((Genre)comboBoxGenre.SelectedItem);
            listBoxSongList.DataContext = CDCatalogProcess.filteredSongList;
        }

        private void comboBoxPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CDCatalogProcess.FilterSongsByPlaylist((Playlist)comboBoxPlaylist.SelectedItem);
            listBoxSongList.DataContext = CDCatalogProcess.filteredSongList;
        }

        private void btnAddNewSong_Click(object sender, RoutedEventArgs e)
        {
            AddSong addSongWindow = new AddSong();
            addSongWindow.Show();
            RefreshUIElements();
        }

        private void btnAddNewPlaylist_Click(object sender, RoutedEventArgs e)
        {
            CreatePlaylist createPlaylistWindow = new CreatePlaylist();
            createPlaylistWindow.ShowDialog();
            RefreshUIElements();
        }

        private void btnAddNewGenre_Click(object sender, RoutedEventArgs e)
        {
            AddGenre addGenreWindow = new AddGenre();
            addGenreWindow.ShowDialog();
            RefreshUIElements();
        }

        private void btnAddNewArtist_Click(object sender, RoutedEventArgs e)
        {
            AddArtist addArtistWindow = new AddArtist();
            addArtistWindow.ShowDialog();
            RefreshUIElements();
        }

        private void btnAddNewAlbum_Click(object sender, RoutedEventArgs e)
        {
            AddAlbum addAlbumWindow = new AddAlbum();
            addAlbumWindow.Show();
            RefreshUIElements();
        }

        private void RefreshUIElements()
        {
            comboBoxAlbum.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAlbum_SelectionChanged));
            comboBoxArtist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxArtist_SelectionChanged));
            comboBoxGenre.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxGenre_SelectionChanged));
            comboBoxPlaylist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxPlaylist_SelectionChanged));
            CDCatalogProcess.RefreshMainWindowLists();
            comboBoxAlbum.DataContext = null;
            comboBoxAlbum.DataContext = CDCatalogProcess.filterAlbumList;
            comboBoxAllSongs.DataContext = null;
            comboBoxAllSongs.DataContext = CDCatalogProcess.displaySongList;
            comboBoxArtist.DataContext = null;
            comboBoxArtist.DataContext = CDCatalogProcess.filterArtistList;
            comboBoxGenre.DataContext = null;
            comboBoxGenre.DataContext = CDCatalogProcess.filterGenreList;
            comboBoxPlaylist.DataContext = null;
            comboBoxPlaylist.DataContext = CDCatalogProcess.filterPlaylistList;
            rbViewOptionsAll.IsChecked = true;
        }
    }
}
