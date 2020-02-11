using MediaWish.DataAccess.Repositories;
using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using MediaWish.Test.MockRepositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace MediaWish.Test
{
    public class UsersRepoTest
    {

        readonly Users _user = new Users(); 

        [Fact]
        public void GetUsers_TypeofUsers_WithMockData()
        {
            // Arrange
            IUsersRepo mockRepo = new MockUsersRepo();

            // Act
            var users = mockRepo.GetUsers();

            // Assert
            Assert.Equal(typeof(List<Users>), users.GetType());
        }

        [Fact]
        public void Users_Name_NonEmptyValue_StoresCorrectly()
        {
            string name = "James";
            Users user = new Users()
            {
                Name = name
            };

            Assert.Equal(name, user.Name);
        }

        [Fact]
        public void Name_Users_Null()
        {
            Users user = new Users();
            Assert.Null(user.Name);
        }

        [Fact]
        public void GetUserById_TypeofUsers_WithMockData()
        {
            // Arrange
            IUsersRepo mockRepo = new MockUsersRepo();

            // Act
            var user = mockRepo.GetUserById(1);

            // Assert
            Assert.Equal(typeof(Users), user.GetType());
        }

        [Fact]
        public void GetUserById_EmptyValue_ThrowsInvalidOperationException()
        {
            IUsersRepo mockRepo = new MockUsersRepo();

            Assert.ThrowsAny<InvalidOperationException>(() => mockRepo.GetUserById(44));
        }

        [Theory]
        [InlineData("James")]
        public void Name_ValueStoresCorrectly(string name)
        {
            _user.Name = name;
            Assert.Equal(name, _user.Name);
        }   

        [Fact]
        public void GetUserById_ReturnsAllUsers_WithMockData()
        {
            IUsersRepo mockRepo = new MockUsersRepo();

            var users = mockRepo.GetUsers();
            Assert.Collection<Users>(users, u => Assert.Contains("Banana Man", u.Name),
                                     u => Assert.Contains("Taong Saging", u.Name));
        }
    }
}
