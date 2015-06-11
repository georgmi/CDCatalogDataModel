﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCatalogDataModel
{
    public class CDCatalogProcess
    {
        public static List<Song> displaySongList = new List<Song>();
        public static List<Song> filteredSongList = new List<Song>();
        public static List<Album> filterAlbumList = new List<Album>();
        public static List<Artist> filterArtistList = new List<Artist>();
        public static List<Genre> filterGenreList = new List<Genre>();
        public static List<Playlist> filterPlaylistList = new List<Playlist>();

        public static List<Artist> subWindowArtistList = new List<Artist>();
        public static List<Album> subWindowAlbumList = new List<Album>();
        public static List<Genre> subWindowGenreList = new List<Genre>();
        public static List<Song> subWindowPlaylistSongs = new List<Song>();

        public static void GetAllAlbums()
        {
            filterAlbumList = CDCatalogManager.GetAlbums();
        }

        public static void GetAllArtists()
        {
            filterArtistList = CDCatalogManager.GetArtists();
        }

        public static void GetAllGenres()
        {
            filterGenreList = CDCatalogManager.GetGenres();
        }

        public static void GetAllPlaylists()
        {
            filterPlaylistList = CDCatalogManager.GetPlaylists();
        }

        public static void GetAllSongs()
        {
            displaySongList = CDCatalogManager.GetSongs();
        }

        public static void FilterSongsByAlbum(Album album)
        {
            filteredSongList.Clear();
            filteredSongList = displaySongList.Where(s => s.AlbumID == album.AlbumID).ToList();
        }

        public static void FilterSongsByArtist(Artist artist)
        {
            filteredSongList.Clear();
            filteredSongList = displaySongList.Where(s => s.ArtistID == artist.ArtistID).ToList();
        }

        public static void FilterSongsByGenre(Genre genre)
        {
            filteredSongList.Clear();
            filteredSongList = displaySongList.Where(s => s.GenreID == genre.GenreID).ToList();
        }

        public static void FilterSongsByPlaylist(Playlist playlist)
        {
            filteredSongList.Clear();
            filteredSongList = CDCatalogManager.GetSongsFromPlaylist(playlist);
        }

        public static void FilterAlbumsByArtist(Artist artist)
        {
            subWindowAlbumList.Clear();
            subWindowAlbumList = CDCatalogManager.GetAlbums().Where(alb => alb.ArtistID.Equals(artist.ArtistID)).ToList();
        }

        public static void FilterArtistsByAlbum(Album album)
        {
            int artistID = album.ArtistID;
            subWindowArtistList.Clear();
            subWindowArtistList = CDCatalogManager.GetArtists().Where(art => art.ArtistID.Equals(artistID)).ToList();
            subWindowAlbumList.Clear();
            subWindowAlbumList = CDCatalogManager.GetAlbums().Where(alb => alb.ArtistID.Equals(artistID)).ToList();
        }

        public static void RefreshMainWindowLists()
        {
            GetAllAlbums();
            GetAllArtists();
            GetAllGenres();
            GetAllPlaylists();
            GetAllSongs();
        }

        public static void AddSongsFillArtists()
        {
            subWindowArtistList.Clear();
            subWindowArtistList = CDCatalogManager.GetArtists();
        }

        public static void AddSongsFillAlbums()
        {
            subWindowAlbumList.Clear();
            subWindowAlbumList = CDCatalogManager.GetAlbums();
        }

        public static void AddSongsFillGenres()
        {
            subWindowGenreList.Clear();
            subWindowGenreList = CDCatalogManager.GetGenres();
        }

        public static int CreatePlaylistValidateLength(string length)
        {
            int output = 0;

            int.TryParse(length, out output);

            if (output < 1)
            {
                output = 0;
            }

            return output;
        }

        public static int CreatePlaylistGo(string playListName, int minutes)
        {
            subWindowPlaylistSongs.Clear();
            Song song = null;
            int totalDuration = 0;
            if (minutes > 0)
            {
                List<PlaylistSong> playlistSongList = GeneratePlayList(playListName, minutes).OrderBy(pls => pls.SongOrder).ToList();
                for (int i = 0; i < playlistSongList.Count; i++)
                {
                    PlaylistSong pls = playlistSongList[i];
                    song = CDCatalogManager.GetSongs().Where(s => s.SongID.Equals(pls.SongID)).First();
                    subWindowPlaylistSongs.Add(song);
                    totalDuration += song.TrackLength;
                }
            }
            return totalDuration;
        }

        public static void AddGenreGo(string genreName)
        {
            int doesGenreExist = CDCatalogManager.GetGenres().Where(g => g.GenreName.Equals(genreName)).Count();
            if (doesGenreExist == 0)
            {
                Genre genre = new Genre();
                genre.GenreName = genreName;
                CDCatalogManager.AddGenre(genre);
            }
            else
            {
                //TODO: Message to user? Or not, because the genre they tried to add is in the database, 
                //which is what they wanted.
            }
        }

        public static void AddArtistGo(string artistName)
        {
            int doesArtistExist = CDCatalogManager.GetArtists().Where(a => a.ArtistName.Equals(artistName)).Count();
            if (doesArtistExist == 0)
            {
                Artist artist = new Artist();
                artist.ArtistName = artistName;
                CDCatalogManager.AddArtist(artist);
            }
            else
            {
                //TODO: Message to user? Or not, because the genre they tried to add is in the database, 
                //which is what they wanted.
            }
        }

        public static List<PlaylistSong> GeneratePlayList(string playListName, int minutes)
        {
            List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
            List<Song> workingList = CDCatalogManager.GetSongs(); //TODO: Filter songs based on Genre and/or Rating.
            int seconds = (minutes * 60); //Song lengths are stored in seconds, but the user selects a playlist duration in minutes.

            Playlist playlist = new Playlist();
            playlist.PlaylistName = playListName; //TODO: Consider checking for and preventing duplicate names.
            CDCatalogManager.AddPlaylist(playlist);

            playlistSongList = CombinationsPlaylist(workingList, playlist, seconds); //Works speedily now.
            //playlistSongList = RandomPlayList(workingList, seconds, playlist);  //My prior algorithm. 

            return playlistSongList;
        }

        public static List<PlaylistSong> CombinationsPlaylist(List<Song> inputList, Playlist playlist, int durationSeconds)
        {
            Random rand = new Random();
            List<Song> resultList = new List<Song>();
            List<Song> workingList = Shuffle(inputList);
            //List<Song> selectedList = new List<Song>(); //The algorithm now returns a single List<Song>; no need to pick one of several
            List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
            PlaylistSong newPLS = null;
            int songOrder = 1;

            resultList = Combinations(workingList, durationSeconds);

            //A PlaylistSong is not the same as a Song; a PlaylistSong is just a pair of foreign keys (SongID, PlaylistID)
            //plus an ordinal. In order to complete the Playlist, the PlaylistSongs need to be created from the ListSong<>.
            foreach (Song s in resultList)
            {
                newPLS = new PlaylistSong();
                newPLS.PlaylistID = playlist.PlaylistID;
                newPLS.SongID = s.SongID;
                newPLS.SongOrder = songOrder;
                CDCatalogManager.AddPlaylistSong(newPLS);
                playlistSongList.Add(newPLS);
                songOrder++;
            }

            //The code block that was here to handle the case where no valid List<Song> was found
            //is no longer necessary, because the recursion is now guaranteed to return a List<Song>.

            return playlistSongList;
        }

        public static List<T> Shuffle<T>(List<T> inputList)
        {            
            List<T> workingList = new List<T>();
            List<T> shuffledList = new List<T>();
            Random rand = new Random();
            int index = 0;

            //using an intermediary List prevents destruction of the input List.
            foreach(T item in inputList)
            {
                workingList.Add(item);
            }

            while(workingList.Count > 0)
            {
                index = rand.Next(0, workingList.Count);
                shuffledList.Add(workingList[index]);
                workingList.RemoveAt(index);
            }

            return shuffledList;
        }

        public static List<Song> Combinations(List<Song> inputList, int durationSeconds)
        {
            int totalDuration = 0;
            foreach(Song s in inputList)
            {
                totalDuration += s.TrackLength;
            }

            //If there aren't enough songs to fill the specified playlist time, don't try.
            //It takes a LONG time for this algorithm to fail.
            if (totalDuration <= (durationSeconds + 60))
            {
                return inputList;
            }

            List<Song> outputList = new List<Song>();
            Song[] workingList = new Song[inputList.Count + 1]; 
            int count = inputList.Count;

            outputList = recursiveCombine(inputList, workingList, durationSeconds, count, 0, 0);
            
            return outputList;
        }

        public static List<Song> recursiveCombine(List<Song> inputList, Song[] workingList, int durationSeconds, int count, int recursionLevel, int start)
        {
            List<Song> storageList = new List<Song>();
            
            for (int i = start; i < count; i++)
            {
                int totalDuration = 0;
                workingList[recursionLevel] = inputList[i];
                workingList[recursionLevel + 1] = null;
                //Because we're re-using the same array for everything, we need to
                //indicate to the for loop where the current combination stops.
                storageList = new List<Song>();
                for (int j = 0; j < recursionLevel; j++)
                {
                    if (null != workingList[j])
                    {
                        storageList.Add(workingList[j]);
                        totalDuration += workingList[j].TrackLength;
                    }
                    else
                    {
                        break;
                    }
                }
                if (totalDuration >= (durationSeconds - 60) && totalDuration <= (durationSeconds + 60))
                {
                    return storageList;
                }
                else if (i < (count - 1) && totalDuration < (durationSeconds - 60))
                {
                    //I'm no longer passing a List<List<Song>> through the recursion, so now I need a way to percolate my 
                    //results back up to the top. To do that, I need to know whether what's coming back is appropriate 
                    //to pass up the stack, or if instead I need to keep going.
                    storageList = recursiveCombine(inputList, workingList, durationSeconds, count, (recursionLevel + 1), (i + 1));
                    totalDuration = 0;
                    foreach(Song s in storageList)
                    {
                        if (null != s)
                        {
                            totalDuration += s.TrackLength;
                        }
                    }
                    if (totalDuration >= (durationSeconds - 60) && totalDuration <= (durationSeconds + 60))
                    {
                        return storageList;
                    }
                }
            }

            //If all else fails, return the original list of songs.
            //HOPEFULLY, the only time we'll hit this is if the input song list is so short that it'll
            //be quick to bottom out on the recursion. Otherwise, the user's likely to be pretty unhappy with the wait.
            return workingList.ToList();  
            
        }

        //No longer using this code. 
        public static List<PlaylistSong> RandomPlayList(List<Song> sourceList, int targetSeconds, Playlist playList)
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
            int totalLength = 0;

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
                    //reduce the available songs to only those which will not exceed the specified playlist length plus one minute.
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

                    if (totalLength >= (targetSeconds - 60))
                    {
                        isFull = true;
                    }
                }

                if (totalLength >= (targetSeconds - 60) && totalLength <= (targetSeconds + 60))
                {
                    songOrder = 1;
                    Song s = new Song();

                    while (workingList.Count > 0)
                    {
                        newPLS = new PlaylistSong();
                        s = workingList[rand.Next(0, workingList.Count)];
                        newPLS.PlaylistID = playList.PlaylistID;
                        newPLS.SongID = s.SongID;
                        newPLS.SongOrder = songOrder;
                        CDCatalogManager.AddPlaylistSong(newPLS);
                        playlistSongList.Add(newPLS);
                        workingList.Remove(s);
                        songOrder++;
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
