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
    /// Interaction logic for AddAlbum.xaml
    /// </summary>
    public partial class AddAlbum : Window
    {
        //If I do a Window.Show() from a parent window, a new thread is spawned, so the parent window cannot 
        //get an updated view of the model, because its only opportunity to do so comes before any changes are made.
        //I solve this in AddPlaylist, AddGenre, and AddArtist by using Window.ShowDialog(), but AddAlbum and AddSong 
        //have potential child windows, and ShowDialog() makes them behave oddly.
        //So instead, I call AddAlbum and AddSong with a context, and later on use the context to update the parent 
        //window from here.
        MainWindow invoker;
        public AddAlbum(MainWindow caller)
        {
            InitializeComponent();
            CDCatalogProcess.AddSongsFillArtists();
            comboBoxAddAlbumArtist.DataContext = CDCatalogProcess.subWindowArtistList;
            comboBoxAddAlbumArtist.SelectedIndex = 0;
            comboBoxAddAlbumSongArtist.DataContext = CDCatalogProcess.subWindowArtistList;
            comboBoxAddAlbumSongArtist.SelectedIndex = 0;
            CDCatalogProcess.AddSongsFillGenres();
            comboBoxAddAlbumGenreIn.DataContext = CDCatalogProcess.subWindowGenreList;
            comboBoxAddAlbumGenreIn.SelectedIndex = 0;
            CDCatalogProcess.addAlbumTrackList.Clear();
            invoker = caller;
        }

        private void btnAddAlbumCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddAlbumAddTrack_Click(object sender, RoutedEventArgs e)
        {
            //Adding a track is not the same as adding a song to the database. I don't want to add
            //anything to the DB until it's time to add everything, because if the user cancels out before finishing,
            //there will be a partial, and probably incorrect, Album and Songs in the DB.
            //So instead, I've created a temporary List<> that holds all the info I need to add a Song to the DB,
            //and when the user commits the Album, I'll iterate through the List and add all the Songs at once.
            string message;
            if (CDCatalogProcess.AddAlbumVerifyTrack(
                    txtAddAlbumTrackNumIn.Text, 
                    txtAddAlbumTrackTitleIn.Text, 
                    (Genre)comboBoxAddAlbumGenreIn.SelectedItem, 
                    (Artist)comboBoxAddAlbumSongArtist.SelectedItem,
                    txtAddAlbumTrackLengthMinIn.Text,
                    txtAddAlbumTrackLengthSecIn.Text,
                    comboBoxAddAlbumTrackRating.SelectedIndex, 
                    out message))
            {
                listBoxAddAlbumSongs.DataContext = null;
                listBoxAddAlbumSongs.DataContext = CDCatalogProcess.addAlbumTrackList;

                //Clean up input fields
                txtAddAlbumTrackNumIn.Text = "";
                txtAddAlbumTrackLengthMinIn.Text = "";
                txtAddAlbumTrackLengthSecIn.Text = "";
                txtAddAlbumTrackTitleIn.Text = "";
            }
            else
            { 
                MessageBox.Show(message);
            }
        }

        private void btnAddAlbumAddArtist_Click(object sender, RoutedEventArgs e)
        {
            //From the Add Album window, add an Artist.
            AddArtist addArtistWindow = new AddArtist();
            addArtistWindow.ShowDialog();
            comboBoxAddAlbumArtist.DataContext = null;
            comboBoxAddAlbumSongArtist.DataContext = null;
            CDCatalogProcess.AddSongsFillArtists();
            comboBoxAddAlbumArtist.DataContext = CDCatalogProcess.subWindowArtistList;
            comboBoxAddAlbumSongArtist.DataContext = CDCatalogProcess.subWindowArtistList;
            comboBoxAddAlbumArtist.SelectedIndex = 0;           
        }

        private void btnAddAlbumAddGenre_Click(object sender, RoutedEventArgs e)
        {
            //From the Add Album window, add a Genre.
            AddGenre addGenreWindow = new AddGenre();
            addGenreWindow.ShowDialog();
            comboBoxAddAlbumGenreIn.DataContext = null;
            CDCatalogProcess.AddSongsFillGenres();
            comboBoxAddAlbumGenreIn.DataContext = CDCatalogProcess.subWindowGenreList;
            comboBoxAddAlbumGenreIn.SelectedIndex = 0;
        }

        private void btnAddAlbumGo_Click(object sender, RoutedEventArgs e)
        {
            //Add the new Album and all associated Songs.
            string message;
            if(CDCatalogProcess.addAlbumGo(txtAddAlbumTitle.Text,
                    (Artist)comboBoxAddAlbumArtist.SelectedItem,
                    comboBoxAddAlbumRating.SelectedIndex,
                    txtAddAlbumYear.Text,
                    CDCatalogProcess.addAlbumTrackList, out message))
            {
                invoker.RefreshUIElements();
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void comboBoxAddAlbumArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //When the user selects an Artist for the Album, set the Song Artist to match.
            //(The user can then select a different Artist for the Song, but the default case
            //is that the two match.)
            comboBoxAddAlbumSongArtist.SelectedIndex = comboBoxAddAlbumArtist.SelectedIndex;
        }
    }
}
