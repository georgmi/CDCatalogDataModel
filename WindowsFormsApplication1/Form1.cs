using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDCatalogDataModel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //A scratch UI to support testing and exploration of solutions. The final UI will be built in WPF.

        List<Album> albumList = new List<Album>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                albumList = db.Albums.OrderBy(a => a.AlbumTitle).ToList();
                dataGridView1.DataSource = albumList;

                //List<Playlist> artistList = db.Playlists.OrderBy(a => a.PlaylistName).ToList();

                //foreach (Playlist a in artistList)
                //{
                //    if (a.PlaylistName == "Test Playlist")
                //    {
                //        db.Playlists.Remove(a);
                //        db.SaveChanges();
                //    }

                //}

                //// Create a Genre
                //Genre genre = new Genre();
                //genre.GenreName = "Bluegrass";
                //db.Genres.Add(genre);
                //db.SaveChanges();

                ////Select genres
                //List<Genre> genres = db.Genres.OrderBy(g => g.GenreName).ToList();
                //List<Artist> artists = db.Artists.OrderBy(a => a.ArtistName).ToList();
                //listBox1.DataSource = artists;

                //foreach (Artist a in artists)
                //{
                //    if (a.ArtistName == "Updated Test Artist")
                //    {
                //        db.Artists.Remove(a);
                //        db.SaveChanges();
                //    }
                //}


                //Artist artist = new Artist();
                //artist.ArtistName = "Carl";
                //db.Artists.Add(artist);
                //db.SaveChanges();

                //Album album = new Album();
                //album.AlbumTitle = "wfwf";
                //album.ArtistID = artist.ArtistID;
                //album.Rating = 5;
                //album.Year = 2015;
                //db.Albums.Add(album);
                //db.SaveChanges();

                //List<Artist> artistResultList = db.Artists.Where(a => a.ArtistName.Contains("Car")).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                Genre genre = db.Genres.Where(g => g.GenreName.Equals("Alternative")).First();
                //Album album = db.Albums.Where(a => a.AlbumTitle.Equals("Ramones [Expanded]")).First();
                Album album = new Album();
                album.AlbumTitle = "Apollo 18";
                album.ArtistID = db.Artists.Where(a => a.ArtistName.Equals("They Might Be Giants")).First().ArtistID;
                album.Year = 2015;

                db.Albums.Add(album);
                db.SaveChanges();

                Song song = new Song();
                song.SongTitle = "Dig My Grave";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 1;
                song.TrackLength = 68;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "I Palindrome I";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 2;
                song.TrackLength = 142;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "She's Actual Size";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 3;
                song.TrackLength = 125;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "My Evil Twin";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 4;
                song.TrackLength = 157;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Mammal";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 5;
                song.TrackLength = 134;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "The Statue Got Me High";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 6;
                song.TrackLength = 186;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Spider";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 7;
                song.TrackLength = 50;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "The Guitar";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 8;
                song.TrackLength = 228;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Dinner Bell";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 9;
                song.TrackLength = 131;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Narrow Your Eyes";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 10;
                song.TrackLength = 166;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Hall of Heads";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 11;
                song.TrackLength = 173;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Which Describes How You're Feeling";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 12;
                song.TrackLength = 73;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "See the Constellation";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 13;
                song.TrackLength = 207;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "If I Wasn't Shy";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 14;
                song.TrackLength = 103;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Turn Around";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 15;
                song.TrackLength = 173;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Hypnotist of Ladies";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 16;
                song.TrackLength = 101;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Catching on Fire";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 17;
                song.TrackLength = 12;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Fingertips I";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 18;
                song.TrackLength = 6;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "I Hear the Wind Blow";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 19;
                song.TrackLength = 10;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Hey Now, Everybody";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 20;
                song.TrackLength = 5;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Standin'";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 21;
                song.TrackLength = 6;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "A New Friend";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 22;
                song.TrackLength = 7;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Wreck My Car";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 23;
                song.TrackLength = 11;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Aren't You the Guy";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 24;
                song.TrackLength = 6;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Pass the Milk";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 25;
                song.TrackLength = 8;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Leave Me Alone";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 26;
                song.TrackLength = 5;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Knockin' on the Wall";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 27;
                song.TrackLength = 4;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "All Alone";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 28;
                song.TrackLength = 5;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Blue Thing";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 29;
                song.TrackLength = 8;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Something Grabbed Ahold of My Hand";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 30;
                song.TrackLength = 11;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "I Don't Understand You";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 31;
                song.TrackLength = 27;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "I Heard a Sound";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 32;
                song.TrackLength = 4;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Mysterious Whisper";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 33;
                song.TrackLength = 28;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "The Day That Love Came to Play";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 34;
                song.TrackLength = 8;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Heart Attack";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 35;
                song.TrackLength = 22;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Fingertips II";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 36;
                song.TrackLength = 10;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Darkened Corridors";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 37;
                song.TrackLength = 61;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                song = new Song();
                song.SongTitle = "Space Suit";
                song.AlbumID = album.AlbumID;
                song.ArtistID = album.ArtistID;
                song.GenreID = genre.GenreID;
                song.TrackNumber = 38;
                song.TrackLength = 96;
                song.Rating = 3;

                db.Songs.Add(song);
                db.SaveChanges();

                albumList = db.Albums.OrderBy(a => a.AlbumTitle).ToList();
                dataGridView1.DataSource = albumList;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Song> songList = db.Songs.OrderBy(s => s.SongTitle).ToList();
                foreach (Song s in songList)
                {
                    s.TrackLength += 300;
                    db.SaveChanges();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                List<Song> songList = db.Songs.OrderBy(s => s.SongTitle).ToList();
                foreach (Song s in songList)
                {
                    s.TrackLength -= 300;
                    db.SaveChanges();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CDCatalogProcess.GeneratePlayList("Winforms Test Playlist", 120);

            Playlist playlist = CDCatalogManager.GetPlaylists().Where(p => p.PlaylistName.Equals("Winforms Test Playlist")).Last();
            List<PlaylistSong> pl = CDCatalogManager.GetPlaylistSongs().Where(p => p.PlaylistID.Equals(playlist.PlaylistID)).ToList();
            List<Song> songs = new List<Song>();

            foreach (PlaylistSong pls in pl)
            {
                songs.Add(CDCatalogManager.GetSongs().Where(s => s.SongID.Equals(pls.SongID)).First());
            }

            dataGridView1.DataSource = songs;


            //using (CDCatalogEntities db = new CDCatalogEntities())
            //{
            //    Playlist playList = new Playlist();
            //    playList.PlaylistName = "Test Playlist";
            //    db.Playlists.Add(playList);
            //    db.SaveChanges();

            //    List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
            //    double targetMinutes = 12000;
            //    double targetSeconds = (targetMinutes * 60);

            //    List<Song> songList = db.Songs.OrderByDescending(s => s.TrackLength).ToList();

            //    playlistSongList = RandomPlaylist(songList, targetSeconds, playList);

            //    List<PlaylistSong> pl = db.PlaylistSongs.Where(p => p.PlaylistID.Equals(playList.PlaylistID)).ToList();
            //    List<Song> songs = new List<Song>();
            //}
        }

        private List<PlaylistSong> RandomPlaylist(List<Song> sourceList, double targetSeconds, Playlist playList)
        {
            ///Algorithm needs to:
            ///1) Check playlist length against target--while totalLength less than or equal to targetSeconds + 60?
            ///     
            ///2) Reduce available songs to those that will fit in the time.
            ///3) Add a song, add song length to totalLength
            ///
            Random rand = new Random();
            List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
            PlaylistSong newPLS = new PlaylistSong();

            bool keepGoing = true;
            bool isFull = false;
            bool notEnoughSongs = false;
            int iterator = 0;
            int index = 0;
            int songOrder = 1;
            double totalLength = 0;

            List<Song> songList = sourceList.OrderBy(s => s.SongID).ToList();
            List<Song> filteredList = songList.Where(s => s.TrackLength <= ((targetSeconds + 60) - totalLength)).ToList();
            List<Song> workingList = new List<Song>();

            //checking the iterator keeps this from becoming an infinite loop, 
            //but all testing, even with fairly small datasets, has so far found
            //a solution before the iterator iterates out.
            while (iterator < 1000000000 && keepGoing == true) 
            {
                while (totalLength <= (targetSeconds + 60) && isFull == false && notEnoughSongs == false) 
                {
                    //reduce the available songs to only those which will not exceed the specifid playlist length plus one minute.
                    filteredList = songList.Where(s => s.TrackLength <= ((targetSeconds + 60) - totalLength)).ToList();

                    if (filteredList.Count > 0) //If we're out of songs, we can't add any more to the playlist
                    {
                        index = rand.Next(0, filteredList.Count);
                        workingList.Add(songList[index]);
                        totalLength += songList[index].TrackLength;
                        songList.RemoveAt(index);
                    }
                    else
                    {
                        notEnoughSongs = true;
                        keepGoing = false;
                    }

                    if(totalLength >= (targetSeconds - 60))
                    {
                        isFull = true;
                    }
                }

                if(totalLength >= (targetSeconds - 60) && totalLength <= (targetSeconds + 60))
                {
                    using (CDCatalogEntities db = new CDCatalogEntities())
                    {
                        songOrder = 1;
                        foreach (Song s in workingList)
                        {
                            newPLS = new PlaylistSong();
                            newPLS.PlaylistID = playList.PlaylistID;
                            newPLS.SongID = s.SongID;
                            newPLS.SongOrder = songOrder;
                            db.PlaylistSongs.Add(newPLS);
                            db.SaveChanges();
                            playlistSongList.Add(newPLS);
                            songOrder++;
                        }
                    }
                    keepGoing = false;
                }
                else
                {
                    workingList.Clear();
                    totalLength = 0;
                    isFull = false;
                    songList = sourceList.OrderBy(s => s.SongID).ToList();
                    filteredList = songList.Where(s => s.TrackLength <= ((targetSeconds + 60) - totalLength)).ToList();
                    iterator++;
                }
            }
           
            return playlistSongList;
        }
    }
}
