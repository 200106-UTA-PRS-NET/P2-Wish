using MediaWish.DataAccess.Repositories;
using MediaWish.Library.Interfaces;
using MediaWish.Test.MockRepositories;
using MediaWish.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MediaWish.Test
{
    public class MapperTest
    {
        [Fact]
        public void MapLibraryModelUsers_TypeofWebApiModelUsers()
        {
            IUsersRepo libModelUsers = new MockLibUsersRepo();

            var apiModelUsers = Mapper.Map(libModelUsers.GetUsers());

            Assert.IsAssignableFrom<IEnumerable<Users>>(apiModelUsers);
        }

        [Fact]
        public void MapWebApiModelUsers_TypeofLibraryModelUsers()
        {
            MockApiUsersRepo apiModelUsers = new MockApiUsersRepo();

            var libModelUsers = Mapper.Map(apiModelUsers.GetUsers());

            Assert.IsAssignableFrom<IEnumerable<Library.Entities.Users>>(libModelUsers);
        }

        [Fact]
        public void MapException_MovieAPI()
        {
            IMoviesRepo<DataAccess.Models.MovieApi, DataAccess.Models.Movies> dataMoviesRepo = new MockDataMoviesRepo();

            Assert.ThrowsAny<Exception>(() => Mapper.Map(dataMoviesRepo.GetPopularMovies(1).results));
        }


    }
}
