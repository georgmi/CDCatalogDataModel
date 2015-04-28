using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDCatalogDataModel;
using NUnit.Framework;

namespace CDCatalogTester
{
    [TestFixture]
    public class CDCatalogTester
    {
        List<Genre> genreList = new List<Genre>();

        [SetUp]
        public void Initialize()
        {
        }

        [Test]
        public void CheckGenres()
        {
            genreList = CDCatalogManager.GetGenres();

            Assert.IsNotEmpty(genreList);
        }
    
    }
}
