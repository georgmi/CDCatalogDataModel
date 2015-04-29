using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDCatalogDataModel;
using NUnit.Framework;

namespace CDCatalogTester
{
    [TestFixture]
    public class CDCatalogTester
    {
        List<Album> albumList = new List<Album>();
        List<Artist> artistList = new List<Artist>();
        List<Genre> genreList = new List<Genre>();
        List<Playlist> playlistList = new List<Playlist>();
        List<Song> songList = new List<Song>();

        Artist testArtist = new Artist();
        Genre testGenre = new Genre();
        Album testAlbum = new Album();
        Song testSong = new Song();

        [SetUp]
        public void Initialize()
        {
            testArtist.ArtistName = "Test and the Artists";

            testGenre.GenreName = "Test Genre";

            testAlbum.AlbumTitle = "Songs to Test By";
            //testAlbum.ArtistID = 2; TODO: Fix this
            testAlbum.Year = 1990;

            testSong.SongTitle = "I'll Have a Blue Testmas Without You";
            testSong.TrackNumber = 1;
            testSong.TrackLength = 325.0;
            //testSong.AlbumID = 2; TODO: Fix this
            //testSong.ArtistID = 2; TODO: Fix this
            //testSong.GenreID = 2; TODO: Fix this
        }

        [Test]
        public void AddAnArtist()
        {
            bool result = false;
            result = CDCatalogManager.AddArtist(testArtist);

            Assert.IsTrue(result);
        }
        
        [Test]
        public void CheckArtists()
        {
            artistList = CDCatalogManager.GetArtists();

            Assert.IsNotEmpty(artistList);
            Assert.Contains(testArtist, artistList);
        }

        [Test]
        public void CheckGenres()
        {
            genreList = CDCatalogManager.GetGenres();

            Assert.IsNotEmpty(genreList);
        }

        [Test]
        public void CheckAlbum()
        {
            albumList = CDCatalogManager.GetAlbums();

            Assert.IsNotEmpty(albumList);
        }

        //[Test]
        //public void CheckPlaylists()
        //{
        //    playlistList = CDCatalogManager.GetPlaylists();

        //    Assert.IsNotEmpty(playlistList);
        //}

        [Test]
        public void CheckSongs()
        {
            songList = CDCatalogManager.GetSongs();

            Assert.IsNotEmpty(songList);
        }
    
        [Test]
        public void DeleteAnArtist()
        {
            bool result = false;
            artistList = CDCatalogManager.GetArtists();

            foreach(Artist a in artistList)
            {
                if(a.ArtistName == testArtist.ArtistName)
                {
                    result = CDCatalogManager.DeleteArtist(a);
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void IsArtistDeleted()
        {
            artistList = CDCatalogManager.GetArtists();

            Assert.That(artistList, Has.No.Member(testArtist));
        }
    }
}
