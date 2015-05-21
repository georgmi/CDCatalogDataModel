using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCatalogDataModel
{
    public class CDCatalogProcess
    {
        public static List<PlaylistSong> GeneratePlayList(string playListName, double minutes)
        {
            List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
            List<Song> workingList = CDCatalogManager.GetSongs(); //TODO: Filter songs based on Genre and/or Rating.
            double seconds = (minutes * 60); //Song lengths are stored in seconds, but the user selects a playlist duration in minutes.

            Playlist playlist = new Playlist();
            playlist.PlaylistName = playListName; //TODO: Consider checking for and preventing duplicate names.
            CDCatalogManager.AddPlaylist(playlist);

            playlistSongList = RandomPlayList(workingList, seconds, playlist);

            return playlistSongList;
        }

        public static List<PlaylistSong> RandomPlayList(List<Song> sourceList, double targetSeconds, Playlist playList)
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

                    if(totalLength >= (targetSeconds - 60))
                    {
                        isFull = true;
                    }
                }

                if(totalLength >= (targetSeconds - 60) && totalLength <= (targetSeconds + 60))
                {
                    songOrder = 1;
                    Song s = new Song();

                    while(workingList.Count > 0)
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
