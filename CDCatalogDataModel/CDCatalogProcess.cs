using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCatalogDataModel
{
    public class CDCatalogProcess
    {
        public static List<PlaylistSong> GeneratePlayList(string playListName, int minutes)
        {
            List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
            List<Song> workingList = CDCatalogManager.GetSongs(); //TODO: Filter songs based on Genre and/or Rating.
            int seconds = (minutes * 60); //Song lengths are stored in seconds, but the user selects a playlist duration in minutes.

            Playlist playlist = new Playlist();
            playlist.PlaylistName = playListName; //TODO: Consider checking for and preventing duplicate names.
            CDCatalogManager.AddPlaylist(playlist);

            //playlistSongList = CombinationsPlaylist(workingList, playlist, seconds); //Hoo boy, does this take a long time.
            playlistSongList = RandomPlayList(workingList, seconds, playlist);

            return playlistSongList;
        }

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

        public static List<PlaylistSong> CombinationsPlaylist(List<Song> inputList, Playlist playlist, int durationSeconds)
        {
            Random rand = new Random();
            List<List<Song>> allCombos = new List<List<Song>>();
            //List<List<Song>> reducedCombos = new List<List<Song>>();
            List<Song> workingList = Shuffle(inputList);
            List<Song> selectedList = new List<Song>();
            List<PlaylistSong> playlistSongList = new List<PlaylistSong>();
            PlaylistSong newPLS = null;
            int songOrder = 1;

            allCombos = Combinations(workingList, durationSeconds);

            if(allCombos.Count > 0)
            {
                //pick a valid playlist at random. This works around the tendency of the 
                //Combinations method to find valid playlists with fewer songs before ones
                //with more songs (which translates to a bias for longer songs).
                int index = rand.Next(0, allCombos.Count);
                selectedList = allCombos[index];

                foreach(Song s in selectedList)
                {
                    newPLS = new PlaylistSong();
                    newPLS.PlaylistID = playlist.PlaylistID;
                    newPLS.SongID = s.SongID;
                    newPLS.SongOrder = songOrder;
                    CDCatalogManager.AddPlaylistSong(newPLS);
                    playlistSongList.Add(newPLS);
                    songOrder++;
                }

            }
            else
            {
                foreach(Song s in workingList)
                {
                    newPLS = new PlaylistSong();
                    newPLS.PlaylistID = playlist.PlaylistID;
                    newPLS.SongID = s.SongID;
                    newPLS.SongOrder = songOrder;
                    CDCatalogManager.AddPlaylistSong(newPLS);
                    playlistSongList.Add(newPLS);
                    songOrder++;
                }
            }

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

        public static List<List<Song>> Combinations(List<Song> inputList, int durationSeconds)
        {
            List<List<Song>> combinationsList = new List<List<Song>>();
            Song[] workingList = new Song[inputList.Count + 1];
            int count = inputList.Count;

            recursiveCombine(inputList, workingList, durationSeconds, combinationsList, count, 0, 0);
            
            return combinationsList;
        }

        public static void recursiveCombine(List<Song> inputList, Song[] workingList, int durationSeconds, List<List<Song>> combinationsList, int count, int recursionLevel, int start)
        {
            List<Song> storageList = new List<Song>();

            for (int i = start; i < count; i++)
            {
                int totalDuration = 0;
                workingList[recursionLevel] = inputList[i];
                workingList[recursionLevel + 1] = null;
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
                    combinationsList.Add(storageList);
                    return;
                }

                if (i < (count - 1))
                {
                    recursiveCombine(inputList, workingList, durationSeconds, combinationsList, count, (recursionLevel + 1), (i + 1));
                }
            }
        }

    }
}
