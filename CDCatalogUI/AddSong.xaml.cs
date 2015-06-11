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
        public AddSong()
        {
            InitializeComponent();
            SetUpUI();
        }

        private void SetUpUI()
        {
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

        }

        private void comboBoxAddSongArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxAddSongArtist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            comboBoxAddSongAlbum.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
            Artist selectedArtist = (Artist)comboBoxAddSongArtist.SelectedItem;
            CDCatalogProcess.FilterAlbumsByArtist(selectedArtist);
            comboBoxAddSongAlbum.DataContext = CDCatalogProcess.subWindowAlbumList;
            comboBoxAddSongArtist.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            comboBoxAddSongAlbum.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
        }

        private void btnAddSongClear_Click(object sender, RoutedEventArgs e)
        {
            SetUpUI();
        }

        private void comboBoxAddSongAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Album selectedAlbum = (Album)comboBoxAddSongAlbum.SelectedItem;
            comboBoxAddSongArtist.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            comboBoxAddSongAlbum.RemoveHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
            int albumID = selectedAlbum.AlbumID;
            //CDCatalogProcess.FilterArtistsByAlbum(selectedAlbum);
            comboBoxAddSongArtist.DataContext = CDCatalogProcess.subWindowArtistList;
            comboBoxAddSongArtist.SelectedIndex = 0;
            for (int j = 0; j < CDCatalogProcess.subWindowArtistList.Count; j++ )
            {
                if(CDCatalogProcess.subWindowArtistList[j].ArtistID == selectedAlbum.ArtistID)
                {
                    comboBoxAddSongArtist.SelectedIndex = j;
                }
            }
            comboBoxAddSongAlbum.DataContext = CDCatalogProcess.subWindowAlbumList;
            comboBoxAddSongAlbum.SelectedIndex = 0;
            for (int i = 0; i < CDCatalogProcess.subWindowAlbumList.Count; i++ )
            {
                if (CDCatalogProcess.subWindowAlbumList[i].AlbumID == selectedAlbum.AlbumID)
                {
                    comboBoxAddSongAlbum.SelectedIndex = i;
                }
            }
            comboBoxAddSongArtist.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongArtist_SelectionChanged));
            comboBoxAddSongAlbum.AddHandler(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(comboBoxAddSongAlbum_SelectionChanged));
        }
    }
}
