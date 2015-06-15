using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCatalogDataModel
{
    //TODO: Prevent duplicate records being entered into the database.

    //TODO: When creating items in the database, assign foreign key IDs 
    //instead of foreign objects. (check behavior of both approaches.)

    //Data point: When you db.Table.Add(object) => db.SaveChanges(), the 
    //object you added gets updated with the objectID key value created
    //by the database.

    public class CDCatalogManager
    {
        public static List<Album> GetAlbums()
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Album> albumList = new List<Album>();
                try
                {
                    albumList = db.Albums.OrderByDescending(a => a.Rating).ToList();
                    foreach(Album alb in albumList)
                    {
                        alb.Artist = db.Artists.Where(art => art.ArtistID.Equals(alb.ArtistID)).First();
                    }
                   
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
                    Album alb = db.Albums.Where(a => a.AlbumID.Equals(albumToDelete.AlbumID)).First();

                    db.Albums.Remove(alb);
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
                try
                {
                    Album alb = db.Albums.Where(a => a.AlbumID.Equals(editedAlbum.AlbumID)).First();
                    alb.AlbumTitle = editedAlbum.AlbumTitle;
                    alb.Rating = editedAlbum.Rating;
                    alb.Year = editedAlbum.Year;
                    alb.ArtistID = editedAlbum.ArtistID;
                    //alb.Songs = editedAlbum.Songs; //Don't think I need this.
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
                    Artist art = db.Artists.Where(a => a.ArtistID.Equals(artistToDelete.ArtistID)).First();

                    db.Artists.Remove(art);
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
                try
                {
                    Artist art = db.Artists.Where(a => a.ArtistID.Equals(editedArtist.ArtistID)).First();

                    art.ArtistName = editedArtist.ArtistName;
                    //art.Albums = editedArtist.Albums; //This seems unnecessary
                    //art.Songs = editedArtist.Songs; //This, too.
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
                    Genre gen = db.Genres.Where(g => g.GenreID.Equals(genreToDelete.GenreID)).First();

                    db.Genres.Remove(gen);
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
                try
                {
                    Genre gen = db.Genres.Where(g => g.GenreID.Equals(editedGenre.GenreID)).First();
                    gen.GenreName = editedGenre.GenreName;
                    //gen.Songs = editedGenre.Songs; //This seems unnecessary?
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
                    Playlist play = db.Playlists.Where(p => p.PlaylistID.Equals(playlistToDelete.PlaylistID)).First();
                    db.Playlists.Remove(play);
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
                try
                {
                    Playlist play = db.Playlists.Where(p => p.PlaylistID.Equals(editedPlaylist.PlaylistID)).First();
                    play.PlaylistName = editedPlaylist.PlaylistName;
                    //TODO: Need to think about this process some more.
                    //play.PlaylistSongs = editedPlaylist.PlaylistSongs;
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
                    songList = db.Songs.OrderByDescending(s => s.Rating).ToList();
                    foreach(Song song in songList)
                    {
                        song.Artist = db.Artists.Where(art => art.ArtistID.Equals(song.ArtistID)).First();
                        song.Genre = db.Genres.Where(g => g.GenreID.Equals(song.GenreID)).First();
                        song.Album = db.Albums.Where(alb => (alb.AlbumID == song.AlbumID)).First();
                    }
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
                    Song son = db.Songs.Where(s => s.SongID.Equals(songToDelete.SongID)).First();

                    db.Songs.Remove(son);
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
                try
                {
                    Song son = db.Songs.Where(s => s.SongID.Equals(editedSong.SongID)).First();
                    son.SongTitle = editedSong.SongTitle;
                    son.AlbumID = editedSong.AlbumID;
                    son.ArtistID = editedSong.ArtistID;
                    son.GenreID = editedSong.GenreID;
                    son.PlaylistSongs = editedSong.PlaylistSongs;
                    son.Rating = editedSong.Rating;
                    son.TrackLength = editedSong.TrackLength;
                    son.TrackNumber = editedSong.TrackNumber;
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

        public static List<PlaylistSong> GetPlaylistSongs()
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
                try
                {
                    playlistSongList = db.PlaylistSongs.OrderBy(p => p.SongOrder).ToList();
                }
                catch
                {
                    //TODO: Figure out what to do with an exception. Business logic should handle the return of an empty List<>.
                }
                return playlistSongList;
            }
        }

        public static bool AddPlaylistSong(PlaylistSong newPlaylistSong)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.PlaylistSongs.Add(newPlaylistSong);
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

        public static List<Song> GetSongsFromPlaylist(Playlist playlist)
        {
            List<Song> songList = new List<Song>();
            List<PlaylistSong> pLSList = new List<PlaylistSong>();
            List<Song> songObjectList = new List<Song>();
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    pLSList = db.PlaylistSongs.Where(pls => pls.PlaylistID.Equals(playlist.PlaylistID)).ToList();
                    foreach (PlaylistSong pls in pLSList)
                    {
                        songList.Add(db.Songs.Where(s => s.SongID.Equals(pls.SongID)).First());
                    }
                }
                catch
                {
                    //TODO: Figure out what to do with an exception. 
                }
            }
            return songObjectList;
        }

        public static bool DeletePlaylistSong(PlaylistSong playlistSongToDelete)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    db.PlaylistSongs.Remove(playlistSongToDelete);
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

        public static bool UpdatePlaylistSong(PlaylistSong editedPlaylistSong)
        {
            bool success = false;
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    PlaylistSong playlistSong = db.PlaylistSongs.Where(p => p.PlaylistID.Equals(editedPlaylistSong.PlaylistID)
                        && p.SongID.Equals(editedPlaylistSong.SongID)).First();
                    playlistSong.SongOrder = editedPlaylistSong.SongOrder;
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

    public partial class Album
    {
        public override string ToString()
        {
            //return this.AlbumTitle;
            return ("Album\t" + this.AlbumTitle + " by " + this.Artist.ArtistName + ", rating " + this.Rating.ToString());
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
            //return this.SongTitle;
            return ("Song\t\"" + this.SongTitle + "\" by " + this.Artist.ArtistName + " in album _" + this.Album.AlbumTitle + "_, rating " + this.Rating.ToString());
        }
    }


}
