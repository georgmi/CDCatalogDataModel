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
        Artist editedTestArtist = new Artist();

        Genre testGenre = new Genre();
        Genre editedTestGenre = new Genre();

        Album testAlbum = new Album();
        Album editedTestAlbum = new Album();

        Song testSong = new Song();
        Song editedTestSong = new Song();

        [SetUp]
        public void Initialize()
        {
            testArtist.ArtistName = "Test and the Artists";

            testGenre.GenreName = "Test Genre";

            testAlbum.AlbumTitle = "Songs to Test By";
            testAlbum.Year = 1990;

            testSong.SongTitle = "I'll Have a Blue Testmas Without You";
            testSong.TrackNumber = 1;
            testSong.TrackLength = 325.0;

            editedTestArtist.ArtistName = "Misspelled Test Atrist";
            CDCatalogManager.AddArtist(editedTestArtist);

            editedTestGenre.GenreName = "Misspelled Gerne";
            CDCatalogManager.AddGenre(editedTestGenre);

            editedTestAlbum.AlbumTitle = "Misspelled Ablum";
            artistList.Clear();
            artistList = CDCatalogManager.GetArtists();
            foreach (Artist a in artistList)
            {
                if (a.ArtistName == editedTestArtist.ArtistName)
                {
                    editedTestAlbum.ArtistID = a.ArtistID;
                }
            }
            CDCatalogManager.AddAlbum(editedTestAlbum);

            editedTestSong.SongTitle = "Misspelled Snog";
            editedTestSong.TrackLength = 240.0;
            editedTestSong.TrackNumber = 1;
            foreach (Artist a in artistList)
            {
                if (a.ArtistName == editedTestArtist.ArtistName)
                {
                    editedTestSong.ArtistID = a.ArtistID;
                }
            }

            genreList.Clear();
            genreList = CDCatalogManager.GetGenres();
            foreach(Genre g in genreList)
            {
                if (g.GenreName == editedTestGenre.GenreName)
                {
                    editedTestSong.GenreID = g.GenreID;
                }
            }

            albumList.Clear();
            albumList = CDCatalogManager.GetAlbums();
            foreach(Album a in albumList)
            {
                if (a.AlbumTitle == editedTestAlbum.AlbumTitle)
                {
                    editedTestSong.AlbumID = a.AlbumID;
                }
            }
            CDCatalogManager.AddSong(editedTestSong);

        }

        [TearDown]
        public void TearDown()
        {
            songList = CDCatalogManager.GetSongs();
            foreach (Song s in songList)
            {
                if (s.SongTitle == "Foxed Song" || s.SongTitle == "Misspelled Snog")
                {
                    CDCatalogManager.DeleteSong(s);
                }
            }

            albumList = CDCatalogManager.GetAlbums();
            foreach(Album a in albumList)
            {
                if (a.AlbumTitle == "Fixed Album" || a.AlbumTitle == "Misspelled Ablum")
                {
                    CDCatalogManager.DeleteAlbum(a);
                }
            }

            artistList = CDCatalogManager.GetArtists();
            foreach(Artist a in artistList)
            {
                if (a.ArtistName == "Fixed Artist" || a.ArtistName == "Misspelled Test Atrist")
                {
                    CDCatalogManager.DeleteArtist(a);
                }
            }

            genreList = CDCatalogManager.GetGenres();
            foreach(Genre g in genreList)
            {
                if (g.GenreName == "Fixed Genre" || g.GenreName =="Misspelled Gerne")
                {
                    CDCatalogManager.DeleteGenre(g);
                }
            }
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
            bool result = false;
            artistList = CDCatalogManager.GetArtists();

            foreach(Artist a in artistList)
            {
                if (a.ArtistName == testArtist.ArtistName)
                { result = true; }                
            }

            Assert.IsNotEmpty(artistList);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddAGenre()
        {
            bool result = false;
            result = CDCatalogManager.AddGenre(testGenre);

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckGenres()
        {
            bool result = false;
            genreList = CDCatalogManager.GetGenres();
            foreach(Genre g in genreList)
            {
                if (g.GenreName == testGenre.GenreName)
                { result = true; }
            }

            Assert.IsNotEmpty(genreList);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddAnAlbum()
        {
            bool result = false;

            artistList = CDCatalogManager.GetArtists();

            foreach(Artist a in artistList)
            {
                if(a.ArtistName == testArtist.ArtistName)
                {
                    testAlbum.ArtistID = a.ArtistID;
                }
            }

            result = CDCatalogManager.AddAlbum(testAlbum);

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckAlbums()
        {
            bool result = false;
            albumList = CDCatalogManager.GetAlbums();

            foreach (Album a in albumList)
            {
                if (a.AlbumTitle == testAlbum.AlbumTitle)
                {
                    result = true;
                }
            }

            Assert.IsNotEmpty(albumList);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddASong()
        {
            bool result = false;

            artistList = CDCatalogManager.GetArtists();
            albumList = CDCatalogManager.GetAlbums();
            genreList = CDCatalogManager.GetGenres();

            foreach (Artist a in artistList)
            {
                if (a.ArtistName == testArtist.ArtistName)
                {
                    testSong.ArtistID = a.ArtistID;
                }
            }

            foreach (Album a in albumList)
            {
                if (a.AlbumTitle == testAlbum.AlbumTitle)
                {
                    testSong.AlbumID = a.AlbumID;
                }
            }
            
            foreach (Genre g in genreList)
            {
                if (g.GenreName == testGenre.GenreName)
                {
                    testSong.GenreID = g.GenreID;
                }
            }

            result = CDCatalogManager.AddSong(testSong);

            Assert.IsTrue(result);
        }

        [Test]
        public void CheckSongs()
        {
            bool result = false;
            songList = CDCatalogManager.GetSongs();

            foreach (Song s in songList)
            {
                if (s.SongTitle == testSong.SongTitle)
                { result = true; }
            }

            Assert.IsNotEmpty(songList);
            Assert.IsTrue(result);
        }

        //[Test]
        //public void CheckPlaylists()
        //{
        //    playlistList = CDCatalogManager.GetPlaylists();

        //    Assert.IsNotEmpty(playlistList);
        //}

        [Test]
        public void DeleteASong()
        {
            bool result = false;

            songList = CDCatalogManager.GetSongs();

            foreach (Song s in songList)
            {
                if (s.SongTitle == testSong.SongTitle)
                {
                    result = CDCatalogManager.DeleteSong(s);
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void IsSongDeleted()
        {
            songList = CDCatalogManager.GetSongs();

            foreach (Song s in songList)
            {
                Assert.IsFalse(s.SongTitle.Equals(testSong.SongTitle));
            }
        }

        [Test]
        public void DeleteAnAlbum()
        {
            bool result = false;

            albumList = CDCatalogManager.GetAlbums();

            foreach (Album a in albumList)
            {
                if (a.AlbumTitle == testAlbum.AlbumTitle)
                {
                    result = CDCatalogManager.DeleteAlbum(a);
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void IsAlbumDeleted()
        {
            albumList = CDCatalogManager.GetAlbums();

            foreach (Album a in albumList)
            {
                Assert.IsFalse(a.AlbumTitle.Equals(testAlbum.AlbumTitle));
            }
        }

        [Test]
        public void DeleteAGenre()
        {
            bool result = false;

            genreList = CDCatalogManager.GetGenres();

            foreach (Genre g in genreList)
            {
                if (g.GenreName == testGenre.GenreName)
                {
                    result = CDCatalogManager.DeleteGenre(g);
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void IsGenreDeleted()
        {
            genreList = CDCatalogManager.GetGenres();

            foreach (Genre g in genreList)
            {
                Assert.IsFalse(g.GenreName.Equals(testGenre.GenreName));
            }
        }

        [Test]
        public void DeleteAnArtist()
        {
            bool result = false;

            artistList = CDCatalogManager.GetArtists();

            foreach (Artist a in artistList)
            {
                if (a.ArtistName == testArtist.ArtistName)
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

            foreach (Artist a in artistList)
            {
                Assert.IsFalse(a.ArtistName.Equals(testArtist.ArtistName));
            }
        }

        [Test]
        public void AddAnArtistToEdit()
        {
            bool result = false;
            result = CDCatalogManager.AddArtist(editedTestArtist);

            Assert.IsTrue(result);
        }

        [Test]
        public void EditAnArtist()
        {
            bool result = false;

            artistList = CDCatalogManager.GetArtists();
            foreach (Artist a in artistList)
            {
                if (a.ArtistName == editedTestArtist.ArtistName)
                {
                    a.ArtistName = "Fixed Artist";
                    result = CDCatalogManager.UpdateArtist(a);
                }
            }

            Assert.IsNotEmpty(artistList);
            Assert.IsTrue(result);

        }

        [Test]
        public void DeleteAnEditedArtist()
        {
            bool result = false;

            artistList = CDCatalogManager.GetArtists();

            foreach (Artist a in artistList)
            {
                if (a.ArtistName == "Fixed Artist")
                {
                    result = CDCatalogManager.DeleteArtist(a);
                }
            }

            Assert.IsTrue(result);
        }

        [Test]
        public void EditAnAlbum()
        {
            bool result = false;

            albumList.Clear();
            albumList = CDCatalogManager.GetAlbums();
            foreach(Album a in albumList)
            {
                if (a.AlbumTitle == editedTestAlbum.AlbumTitle)
                {
                    a.AlbumTitle = "Fixed Album";
                    result = CDCatalogManager.UpdateAlbum(a);
                }
            }

            Assert.IsNotEmpty(albumList);
            Assert.IsTrue(result);

        }

        [Test]
        public void EditAGenre()
        {
            bool result = false;

            genreList.Clear();
            genreList = CDCatalogManager.GetGenres();

            foreach(Genre g in genreList)
            {
                if (g.GenreName == editedTestGenre.GenreName)
                {
                    g.GenreName = "Fixed Genre";
                    result = CDCatalogManager.UpdateGenre(g);
                }
            }

            Assert.IsNotEmpty(genreList);
            Assert.IsTrue(result);
        }

        [Test]
        public void EditASong()
        {
            bool result = false;

            songList.Clear();
            songList = CDCatalogManager.GetSongs();

            foreach(Song s in songList)
            {
                if (s.SongTitle == editedTestSong.SongTitle)
                {
                    s.SongTitle = "Foxed Song";
                    result = CDCatalogManager.UpdateSong(s);
                }
            }

            Assert.IsNotEmpty(songList);
            Assert.IsTrue(result);
        }
    }
}
