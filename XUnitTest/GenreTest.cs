using cybersport.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace cybersport.Models
{
    public class GenreTest
    {


        [Fact]
        public void IDTest()
        {
            String str = "1/Starcraft2/Strategy";
            String[] str_arr = str.Split('/');
            Boolean check = true;
            int genreID = 1;
            String genre_name = str_arr[1];
            String genre_description = str_arr[2];

            Genre genre = new Genre(genreID, genre_name, genre_description);

            Assert.Equal(1, genre.GenreID);
        }

        [Fact]
        public void ForbiddenSymbolsInNameTest()
        {
            String str = "Abyl", str2 = "!@#$%^&*()_+-=";
            Boolean check = true;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str[i] == str2[j])
                    {
                        check = false;
                    }
                }
            }
            Assert.True(check);
        }

        [Fact]
        public void NameTest()
        {
            
            int genreID = 1;
            String genre_name = "avg";
            String genre_description = "Average for last 20 matches";

            Genre genre = new Genre(genreID, genre_name, genre_description);

            Assert.Equal("avg", genre.Genre_name);
        }

        [Fact]
        public void DescriptionTest()
        {

            int genreID = 1;
            String genre_name = "Rate";
            String genre_description = "High";

            Genre genre = new Genre(genreID, genre_name, genre_description);

            Assert.Equal("Rate", genre.Genre_description);
        }
    }
}
