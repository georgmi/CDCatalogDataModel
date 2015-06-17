using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCatalogDataModel
{
    //Data point: When you db.Table.Add(object) => db.SaveChanges(), the 
    //object you added gets updated with the objectID key value created
    //by the database. Use this info to immediately use the objects you've
    //submitted in upper layers without having to go back to the database to find them.

    public class CDCatalogManager
    {
        public static void LogError(string source, string message)
        {
            using (StreamWriter sw = File.AppendText("errorlog.txt"))
            {
                sw.WriteLine("--------------");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Source: " + source);
                sw.WriteLine(message);
            }
        }

        public static List<Album> GetAlbums()
        {
            List<Album> albumList = new List<Album>();
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    albumList = db.Albums.OrderByDescending(a => a.Rating).ToList();
                    //An Album object has an associated Artist object; this loop attaches Artists to Albums.
                    foreach (Album alb in albumList)
                    {
                        alb.Artist = db.Artists.Where(art => art.ArtistID.Equals(alb.ArtistID)).First();
                    }

                }
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.GetAlbums", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.GetAlbums");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.AddAlbum", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.AddAlbum");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.DeleteAlbum", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.DeleteAlbums");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                    db.SaveChanges();
                    success = true;
                }
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.UpdateAlbum", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.UpdateAlbum");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.GetArtists", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.GetArtists");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.AddArtist", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.AddArtist");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.DeleteArtist", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.DeleteArtist");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.UpdateArtist", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.UpdateArtist");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.GetGenres", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.GetGenres");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.AddGenre", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.AddGenre");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.DeleteGenre", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.DeleteGenre");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.UpdateGenre", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.UpdateGenre");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.GetPlaylists", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.GetPlaylists");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.AddPlaylist", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.AddPlaylist");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.DeletePlaylist", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.DeletePlaylist");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.UpdatePlaylist", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.UpdatePlaylist");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                    //A Song is a complex object. It has associated Artist, Album, and Genre objects,
                    //and the associated Album object has its own associated Artist object, which may be 
                    //different than the Artist associated with the Song.
                    //This loop populates the Song object with its necessary associated data.
                    foreach(Song song in songList)
                    {
                        song.Artist = db.Artists.Where(art => art.ArtistID.Equals(song.ArtistID)).First();
                        song.Genre = db.Genres.Where(g => g.GenreID.Equals(song.GenreID)).First();
                        song.Album = db.Albums.Where(alb => (alb.AlbumID == song.AlbumID)).First();
                        song.Album.Artist = db.Artists.Where(art => (art.ArtistID == song.Album.ArtistID)).First();
                    }
                }
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.GetSongs", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.GetSongs");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.AddSong", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.AddSong");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.DeleteSong", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.DeleteSong");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.UpdateSong", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.UpdateSong");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.GetPlaylistSongs", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.GetPlaylistSongs");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.AddPlaylistSong", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.AddPlaylistSong");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
                }
                return success;
            }
        }

        public static List<Song> GetSongsFromPlaylist(Playlist playlist)
        {
            //Take a Playlist, find all the PlaylistSongs with the matchingPlaylistID,
            //and populate a List with all the Songs that match the PlaylistSongs' SongIDs.
            List<Song> workingList = GetSongs();
            List<Song> songList = new List<Song>();
            List<PlaylistSong> pLSList = new List<PlaylistSong>();
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                try
                {
                    pLSList = db.PlaylistSongs.Where(pls => pls.PlaylistID.Equals(playlist.PlaylistID)).ToList();
                    foreach (PlaylistSong pls in pLSList)
                    {
                        songList.Add(workingList.Where(s => s.SongID.Equals(pls.SongID)).First());
                    }
                }
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.GetSongsFromPlaylist", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.GetSongsFromPlaylist");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
                }
            }
            return songList;
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.DeletePlaylistSong", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.DeletePlaylistSong");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
                catch (Exception SQLe)
                {
                    LogError("CDCatalogManager.UpdatePlaylistSong", SQLe.ToString());
                    //using (StreamWriter sw = File.AppendText("errorlog.txt"))
                    //{
                    //    sw.WriteLine("--------------");
                    //    sw.WriteLine(DateTime.Now);
                    //    sw.WriteLine("Source: CDCatalogManager.UpdatePlaylistSong");
                    //    sw.WriteLine(SQLe.ToString());
                    //}
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
