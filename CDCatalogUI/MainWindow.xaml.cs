using System;
using System.Collections.Generic;
using System.IO;
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
            //Show all songs and albums in the display listbox. 
            if(! rbViewOptionsAll.IsChecked == true )
            {
                //This is also the MainWindow.Loaded event handler, so we need to initialize 
                //the radio button th Checked to provide a consistent UI experience.
                rbViewOptionsAll.IsChecked = true;
            }
            //All ObjectActions grids Visibility="Hidden"
            HideAllActionGrids();
            HideAllFilterGrids();
            gridAllSongsFilter.Visibility = Visibility.Visible;
            //listBoxFilterList Content = clear
            comboBoxAllSongs.DataContext = null;
            //Song List = All Songs
            CDCatalogProcess.GetSongsandAlbums();
            listBoxSongList.DataContext = CDCatalogProcess.songsAndAlbums;
        }

        private void rbViewOptionsCD_Checked(object sender, RoutedEventArgs e)
        {
            //Set up the UI and display listbox to filter Songs based on the selected Album.
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
            //Set up the UI and display listbox to filter Songs and Albums  based on the selected Artist.
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
            //Set up the UI and display listbox to filter Songs based on the selected Genre,
            //and show all Albums on which a matching Song appears.
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
            //Set up the UI and display listbox to filter Songs based on the selected Playlist.
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
            //When switching between filter views, hide all ActionGrids that might be visible.
            //Each radio button_Checked handler will re-show the appropriate ActionGrid.
            gridAlbumActions.Visibility = Visibility.Hidden;
            gridArtistActions.Visibility = Visibility.Hidden;
            gridGenreActions.Visibility = Visibility.Hidden;
            gridPlaylistActions.Visibility = Visibility.Hidden;
        }

        private void HideAllFilterGrids()
        {
            //When manipulating controls in code, it's best to remove event handlers that are intended to react to user actions.
            //When each FilterGrid is enabled, its appropriate handler will be reattached.
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
            //Show the Songs on the selected Album.
            CDCatalogProcess.FilterSongsByAlbum((Album)comboBoxAlbum.SelectedItem);
            listBoxSongList.DataContext = null;
            listBoxSongList.DataContext = CDCatalogProcess.filteredSongList;
        }

        private void comboBoxArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Show the Songs and Albums from the selected Artist.
            CDCatalogProcess.FilterSongsByArtist((Artist)comboBoxArtist.SelectedItem);
            listBoxSongList.DataContext = null;
            listBoxSongList.DataContext = CDCatalogProcess.songsAndAlbums;
        }

        private void comboBoxGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Show the Songs in the selected Genre, and the Albums on which
            //those Songs appear.
            CDCatalogProcess.FilterSongsByGenre((Genre)comboBoxGenre.SelectedItem);
            listBoxSongList.DataContext = null;
            listBoxSongList.DataContext = CDCatalogProcess.songsAndAlbums;
        }

        private void comboBoxPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Show the Songs in the selected Playlist.
            CDCatalogProcess.FilterSongsByPlaylist((Playlist)comboBoxPlaylist.SelectedItem);
            listBoxSongList.DataContext = null;
            listBoxSongList.DataContext = CDCatalogProcess.filteredSongList;
        }

        private void btnAddNewSong_Click(object sender, RoutedEventArgs e)
        {
            //Open the Add Song window.
            AddSong addSongWindow = new AddSong(this);
            addSongWindow.Show();
            RefreshUIElements();
        }

        private void btnAddNewPlaylist_Click(object sender, RoutedEventArgs e)
        {
            //OPen the CreatePlaylist window.
            CreatePlaylist createPlaylistWindow = new CreatePlaylist();
            createPlaylistWindow.ShowDialog();
            RefreshUIElements();
        }

        private void btnAddNewGenre_Click(object sender, RoutedEventArgs e)
        {
            //Open the AddGenre window.
            AddGenre addGenreWindow = new AddGenre();
            addGenreWindow.ShowDialog();
            RefreshUIElements();
        }

        private void btnAddNewArtist_Click(object sender, RoutedEventArgs e)
        {
            //Open the AddArtist window.
            AddArtist addArtistWindow = new AddArtist();
            addArtistWindow.ShowDialog();
            RefreshUIElements();
        }

        private void btnAddNewAlbum_Click(object sender, RoutedEventArgs e)
        {
            //Open the AddAlbum window.
            AddAlbum addAlbumWindow = new AddAlbum(this);
            addAlbumWindow.Show();
            RefreshUIElements();
        }

        public void RefreshUIElements()
        {
            //When manipulating controls in code, it's best to remove event handlers that are intended to react to user actions.
            //When each FilterGrid is enabled, its appropriate handler will be reattached.
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
            listBoxSongList.DataContext = null;
            listBoxSongList.DataContext = CDCatalogProcess.songsAndAlbums;
            rbViewOptionsAll.IsChecked = true;
        }

        private void btnSearchTitle_Click(object sender, RoutedEventArgs e)
        {
            //Filter the Songs and Albums display based on the search string entered by the user.
            if (txtSearchTitle.Text != "")
            {
                CDCatalogProcess.GetSongsandAlbumsByTitle(txtSearchTitle.Text);
                listBoxSongList.DataContext = null;
                listBoxSongList.DataContext = CDCatalogProcess.songsAndAlbums;
                if(CDCatalogProcess.songsAndAlbums.Count == 0)
                {
                    MessageBox.Show("No matching Songs or Albums found.");
                }
            }
            else
            {
                MessageBox.Show("Cannot search on blank title.");
            }
        }

        private void btnRateSong_Click(object sender, RoutedEventArgs e)
        {
            //Open the appropriate Rate window, based on the type of the SelectedItem.
            //(This is the Rate button for the Songs and Albums list.)
            if(listBoxSongList.SelectedItem is Song)
            {
                RateSong rateSongWindow = new RateSong((Song)listBoxSongList.SelectedItem);
                rateSongWindow.ShowDialog();
                RefreshUIElements();
            }
            if(listBoxSongList.SelectedItem is Album)
            {
                RateAlbum rateAlbumWindow = new RateAlbum((Album)listBoxSongList.SelectedItem);
                rateAlbumWindow.ShowDialog();
                RefreshUIElements();
            }
        }

        private void btnRateAlbum_Click(object sender, RoutedEventArgs e)
        {
            //Open the Rate Album window.
            //(This is the Rate button for the Albums combobox.)
            RateAlbum rateAlbumWindow = new RateAlbum((Album)comboBoxAlbum.SelectedItem);
            rateAlbumWindow.ShowDialog();
            RefreshUIElements();

        }

        private void btnEditSong_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Song or Album not yet implemented.");
        }

        private void btnDeleteSong_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Song or Album not yet implemented.");
        }

        private void btnEditPlaylist_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Playlist not yet implemented.");
        }

        private void btnDeletePlaylist_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Playlist not yet implemented.");
        }

        private void btnEditGenre_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Genre not yet implemented.");
        }

        private void btnDeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Genre not yet implemented.");
        }

        private void btnDeleteArtist_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Artist not yet implemented.");
        }

        private void btnEditArtist_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Artist not yet implemented.");
        }

        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Album not yet implemented.");
        }

        private void btnEditAlbum_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Album not yet implemented.");
        }
    }
}
