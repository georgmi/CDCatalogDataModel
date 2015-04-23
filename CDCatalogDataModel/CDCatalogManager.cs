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
    }

}
