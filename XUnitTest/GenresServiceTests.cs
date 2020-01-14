using cybersport.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using Xunit;
namespace cybersport.Models
{
    public class GenresServiceTests
    {

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IGenresRepository>();
            var genreService = new GenreService(fakeRepository);

            var genre = new Genre() { Genre_name = "test genre" };
            await genreService.AddAndSave(genre);
        }
        [Fact]
        public async Task NullNameAddTest()
        {
            var fakeRepository = Mock.Of<IGenresRepository>();
            var genreService = new GenreService(fakeRepository);
            String name = "";
            Assert.NotNull(name);
            var group = new Genre() { Genre_name = name };
            await genreService.AddAndSave(group);
        }

        [Fact]
        public async Task GetGenresTest()
        {
            var groups = new List<Genre>
            {
                new Genre() { Genre_name = " 1" },
                new Genre() { Genre_name = " 2" },
            };
            var fakeRepositoryMock = new Mock<IGenresRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(groups);


            var genreService = new GenreService(fakeRepositoryMock.Object);

            var resultGenres = await genreService.GetGenres();

            Assert.Collection(resultGenres, genre =>
            {
                Assert.Equal(" 1", genre.Genre_name);
            },
            genre =>
            {
                Assert.Equal(" 2", genre.Genre_name);
            });
        }




        [Fact]
        public async Task editGenreTest()
        {

            var genres = new Genre() { GenreID = 1 };

            var fakeRepository = new Mock<IGenresRepository>();
            fakeRepository.Setup(x => x.editGenre(1)).ReturnsAsync(genres);
            var genreService = new GenreService(fakeRepository.Object);

            var resultGroups = await genreService.GetGenreToEdit(1);
            
                Assert.Equal(resultGroups.GenreID, genres.GenreID);
          

            
            
        }

    }
}
