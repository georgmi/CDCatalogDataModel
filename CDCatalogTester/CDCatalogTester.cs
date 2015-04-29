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

        [SetUp]
        public void Initialize()
        {
            Artist testArtist = new Artist();
            Genre testGenre = new Genre();
            Album testAlbum = new Album();
            Song testSong = new Song();
        }

        [Test]
        public void CheckArtists()
        {
            artistList = CDCatalogManager.GetArtists();

            Assert.IsNotEmpty(artistList);
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
    
    }
}
