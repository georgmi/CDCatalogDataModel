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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (CDCatalogEntities db = new CDCatalogEntities())
            {
                // Create a Genre
                Genre genre = new Genre();
                genre.GenreName = "Bluegrass";
                db.Genres.Add(genre);
                db.SaveChanges();

                //Select genres
                List<Genre> genres = db.Genres.OrderBy(g => g.GenreName).ToList();
                listBox1.DataSource = genres;


                Artist artist = new Artist();
                artist.ArtistName = "Carl";
                db.Artists.Add(artist);
                db.SaveChanges();

                Album album = new Album();
                album.AlbumTitle = "wfwf";
                album.ArtistID = artist.ArtistID;
                album.Rating = 5;
                album.Year = 2015;
                db.Albums.Add(album);
                db.SaveChanges();

                List<Artist> artistResultList = db.Artists.Where(a => a.ArtistName.Contains("Car")).ToList();
            }
        }
    }
}
