using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCatalogDataModel
{
    //TODO: Prevent duplicate records being entered into the database.

    public class CDCatalogManager
    {
        public static List<Album> GetAlbums()
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Album> albumList = new List<Album>();
                try
                {
                    albumList = db.Albums.OrderBy(a => a.AlbumTitle).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return albumList;
            }
        }

        public static bool AddAlbum(Album newAlbum)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Albums.Add(newAlbum);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }
        }

        public static bool DeleteAlbum(Album albumToDelete)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Albums.Remove(albumToDelete);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static bool UpdateAlbum(Album editedAlbum)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Album> albumList = new List<Album>();
                try
                {
                    albumList = db.Albums.Where(a => a.AlbumID == editedAlbum.AlbumID).ToList();
                    albumList[0] = editedAlbum;
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static List<Artist> GetArtists()
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Artist> artistList = new List<Artist>();
                try
                {
                    artistList = db.Artists.OrderBy(a => a.ArtistName).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return artistList;
            }
        }

        public static bool AddArtist(Artist newArtist)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Artists.Add(newArtist);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }
        }

        public static bool DeleteArtist(Artist artistToDelete)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Artists.Remove(artistToDelete);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static bool UpdateArtist(Artist editedArtist)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Artist> artistList = new List<Artist>();
                try
                {
                    artistList = db.Artists.Where(a => a.ArtistID == editedArtist.ArtistID).ToList();
                    artistList[0] = editedArtist;
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static List<Genre> GetGenres()
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Genre> genreList = new List<Genre>();
                try
                {
                    genreList = db.Genres.OrderBy(g => g.GenreName).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return genreList;
            }
        }

        public static bool AddGenre(Genre newGenre)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Genres.Add(newGenre);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }
        }

        public static bool DeleteGenre(Genre genreToDelete)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Genres.Remove(genreToDelete);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static bool UpdateGenre(Genre editedGenre)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Genre> genreList = new List<Genre>();
                try
                {
                    genreList = db.Genres.Where(g => g.GenreID == editedGenre.GenreID).ToList();
                    genreList[0] = editedGenre;
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static List<Playlist> GetPlaylists()
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Playlist> playlistList = new List<Playlist>();
                try
                {
                    playlistList = db.Playlists.OrderBy(p => p.PlaylistName).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return playlistList;
            }
        }

        public static bool AddPlaylist(Playlist newPlaylist)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Playlists.Add(newPlaylist);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }
        }

        public static bool DeletePlaylist(Playlist playlistToDelete)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Playlists.Remove(playlistToDelete);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static bool UpdatePlaylist(Playlist editedPlaylist)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Playlist> playlistList = new List<Playlist>();
                try
                {
                    playlistList = db.Playlists.Where(p => p.PlaylistID == editedPlaylist.PlaylistID).ToList();
                    playlistList[0] = editedPlaylist;
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static List<Song> GetSongs()
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Song> songList = new List<Song>();
                try
                {
                    songList = db.Songs.OrderBy(s => s.SongTitle).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return songList;
            }
        }

        public static bool AddSong(Song newSong)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Songs.Add(newSong);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }
        }

        public static bool DeleteSong(Song songToDelete)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.Songs.Remove(songToDelete);
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

        public static bool UpdateSong(Song editedSong)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Song> songList = new List<Song>();
                try
                {
                    songList = db.Songs.Where(s => s.SongID == editedSong.SongID).ToList();
                    songList[0] = editedSong;
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception e)
                {
                    throw e;
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

    }

    public partial class Album
    {
        public override string ToString()
        {
            return this.AlbumTitle;
        }
    }

    public partial class Artist
    {
        public override string ToString()
        {
            return this.ArtistName;
        }
    }

    public partial class Genre
    {
        public override string ToString()
        {
            return this.GenreName;
        }
    }

    public partial class Playlist
    {
        public override string ToString()
        {
            return this.PlaylistName;
        }
    }

    public partial class Song
    {
        public override string ToString()
        {
            return this.SongTitle;
        }
    }


}
