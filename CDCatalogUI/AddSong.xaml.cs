﻿using System;
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
    /// Interaction logic for AddSong.xaml
    /// </summary>
    public partial class AddSong : Window
    {
        //If I do a Window.Show() from a parent window, a new thread is spawned, so the parent window cannot 
        //get an updated view of the model, because its only opportunity to do so comes before any changes are made.
        //I solve this in AddPlaylist, AddGenre, and AddArtist by using Window.ShowDialog(), but AddAlbum and AddSong 
        //have potential child windows, and ShowDialog() makes them behave oddly.
        //So instead, I call AddAlbum and AddSong with a context, and later on use the context to update the parent 
        //window from here.
        MainWindow invoker;
        public AddSong(MainWindow caller)
        {
            InitializeComponent();
            invoker = caller;
            SetUpUI();
        }

        private void SetUpUI()
        {
            //Populate all the combobox controls in the AddSong window.
            comboBoxAddSongArtist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            comboBoxAddSongAlbum.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
            CDCatalogProcess.AddSongsFillArtists();
            comboBoxAddSongArtist.DataContext = CDCatalogProcess.subWindowArtistList;
            comboBoxAddSongArtist.SelectedIndex = -1;
            CDCatalogProcess.AddSongsFillAlbums();
            comboBoxAddSongAlbum.DataContext = CDCatalogProcess.subWindowAlbumList;
            comboBoxAddSongAlbum.SelectedIndex = -1;
            CDCatalogProcess.AddSongsFillGenres();
            comboBoxAddSongGenre.DataContext = CDCatalogProcess.subWindowGenreList;
            comboBoxAddSongGenre.SelectedIndex = -1;
            comboBoxAddSongArtist.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            comboBoxAddSongAlbum.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
        }

        private void btnAddSongCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddSongSave_Click(object sender, RoutedEventArgs e)
        {
            //Submit the Song information for validation and DB update.
            //If validation fails, show the user the list of error messages provided by the validation code.
            string message;
            if (CDCatalogProcess.AddSongGo(txtAddSongTitle.Text, 
                    (Artist)comboBoxAddSongArtist.SelectedItem, 
                    (Album)comboBoxAddSongAlbum.SelectedItem, 
                    txtAddSongTrack.Text, 
                    (Genre)comboBoxAddSongGenre.SelectedItem,
                    txtAddSongTrackLengthMinutes.Text,
                    txtAddSongTrackLengthSeconds.Text,
                    comboBoxAddSongRating.SelectedIndex,
                    out message))
            {
                invoker.RefreshUIElements();
                this.Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }

        private void comboBoxAddSongArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BUGBUG: This handler and comboBoxAddSongAlbum_SelectionChanged were intended to make searching for Albums and Artists 
            //easier for the user, but the way they were implemented, it was not possible to create a Song that had an Artist that 
            //was different from the Album's Artist, which is problematic for compilations and soundtracks. There was not time
            //to fix the functionality, so for now, the handlers are noops.

            //comboBoxAddSongArtist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            //comboBoxAddSongAlbum.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
            //Artist selectedArtist = (Artist)comboBoxAddSongArtist.SelectedItem;
            //CDCatalogProcess.FilterAlbumsByArtist(selectedArtist);
            //comboBoxAddSongAlbum.DataContext = CDCatalogProcess.subWindowAlbumList;
            //comboBoxAddSongArtist.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            //comboBoxAddSongAlbum.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
        }

        private void btnAddSongClear_Click(object sender, RoutedEventArgs e)
        {
            SetUpUI();
        }

        private void comboBoxAddSongAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BUGBUG: This handler and comboBoxAddSongArtist_SelectionChanged were intended to make searching for Albums and Artists 
            //easier for the user, but the way they were implemented, it was not possible to create a Song that had an Artist that 
            //was different from the Album's Artist, which is problematic for compilations and soundtracks. There was not time
            //to fix the functionality, so for now, the handlers are noops.

            //Album selectedAlbum = (Album)comboBoxAddSongAlbum.SelectedItem;
            //comboBoxAddSongArtist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            //comboBoxAddSongAlbum.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
            //int albumID = selectedAlbum.AlbumID;
            ////CDCatalogProcess.FilterArtistsByAlbum(selectedAlbum);
            //comboBoxAddSongArtist.DataContext = CDCatalogProcess.subWindowArtistList;
            //comboBoxAddSongArtist.SelectedIndex = 0;
            //for (int j = 0; j < CDCatalogProcess.subWindowArtistList.Count; j++ )
            //{
            //    if(CDCatalogProcess.subWindowArtistList[j].ArtistID == selectedAlbum.ArtistID)
            //    {
            //        comboBoxAddSongArtist.SelectedIndex = j;
            //    }
            //}
            //comboBoxAddSongAlbum.DataContext = CDCatalogProcess.subWindowAlbumList;
            //comboBoxAddSongAlbum.SelectedIndex = 0;
            //for (int i = 0; i < CDCatalogProcess.subWindowAlbumList.Count; i++ )
            //{
            //    if (CDCatalogProcess.subWindowAlbumList[i].AlbumID == selectedAlbum.AlbumID)
            //    {
            //        comboBoxAddSongAlbum.SelectedIndex = i;
            //    }
            //}
            //comboBoxAddSongArtist.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            //comboBoxAddSongAlbum.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
        }

        private void btnAddSongAddArtist_Click(object sender, RoutedEventArgs e)
        {
            //Add an Artist from the Add Song window.
            AddArtist addArtistWindow = new AddArtist();
            addArtistWindow.ShowDialog();
            SetUpUI();
        }

        private void btnAddSongAddAlbum_Click(object sender, RoutedEventArgs e)
        {
            //This method intentionally left blank; I decided the workflow of adding an album from the add a song window didn't make sense.
        }

        private void btnAddSongAddGenre_Click(object sender, RoutedEventArgs e)
        {
            //Add a Genre from the Add Song window.
            AddGenre addGenreWindow = new AddGenre();
            addGenreWindow.ShowDialog();
            SetUpUI();
        }
    }
}
