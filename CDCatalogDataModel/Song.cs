//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDCatalogDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Song
    {
        public Song()
        {
            this.PlaylistSongs = new HashSet<PlaylistSong>();
        }
    
        public int SongID { get; set; }
        public string SongTitle { get; set; }
        public int ArtistID { get; set; }
        public Nullable<int> AlbumID { get; set; }
        public int TrackNumber { get; set; }
        public int GenreID { get; set; }
        public int TrackLength { get; set; }
        public Nullable<int> Rating { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
