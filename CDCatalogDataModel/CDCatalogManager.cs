using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCatalogDataModel
{
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
                catch 
                {
                    //TODO: Figure out what to do with an exception. Business logic should handle the return of an empty List<>.
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
                catch
                {
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
                catch
                {
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
                catch
                {
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
                catch
                {
                    //TODO: Figure out what to do with an exception. Business logic should handle the return of an empty List<>.
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
                catch
                {
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
                catch
                {
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
                catch
                {
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
                catch
                {
                    //TODO: Figure out what to do with an exception. Business logic should handle the return of an empty List<>.
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
                catch
                {
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
                catch
                {
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
                catch
                {
                    //TODO: Figure out what to do with an exception. 
                }
                return success;
            }

        }

    }

}
