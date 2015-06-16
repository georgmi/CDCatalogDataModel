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
            string message;
            if (CDCatalogProcess.AddAlbumVerifyTrack(
                    txtAddAlbumTrackNumIn.Text, 
                    txtAddAlbumTrackTitleIn.Text, 
                    (Genre)comboBoxAddAlbumGenreIn.SelectedItem, 
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
            AddGenre addGenreWindow = new AddGenre();
            addGenreWindow.ShowDialog();
            comboBoxAddAlbumGenreIn.DataContext = null;
            CDCatalogProcess.AddSongsFillGenres();
            comboBoxAddAlbumGenreIn.DataContext = CDCatalogProcess.subWindowGenreList;
            comboBoxAddAlbumGenreIn.SelectedIndex = 0;
        }

        private void btnAddAlbumGo_Click(object sender, RoutedEventArgs e)
        {
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
            comboBoxAddAlbumSongArtist.SelectedIndex = comboBoxAddAlbumArtist.SelectedIndex;
        }
    }
}
