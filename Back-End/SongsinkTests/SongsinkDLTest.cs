using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SongsinkModel;
using Xunit;
using SongsinkDL;

namespace SongsinkTests
{
    public class SongsinkDLTest
    {
        private readonly DbContextOptions<SIDbContext> _options;

        public SongsinkDLTest()
        {
            _options = new DbContextOptionsBuilder<SIDbContext>().UseSqlite("filename = Test.db").Options;
            this.Seed();
        }

        [Fact]
        public async Task GetAllCategoriesShouldGetAllCategories()
        {
            using (var context = new SIDbContext(_options))
            {
                //Arrange
                IDL dl = new DL(context);

                //Act
                List<Category> allCategories = await dl.GetAllCategories();

                //Assert
                Assert.Equal(6, allCategories.Count);
                foreach (Category category in allCategories)
                {
                    Assert.NotNull(category);
                    Assert.NotEqual(0,category.Id);
                    Assert.NotEqual("", category.CategoryName);
                }
            }
        }

        [Fact]
        public async Task GetCustomCategoriesShouldReturn3Categories()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                List<CustomCategory> categories = await dl.GetCustomCategories(1);

                Assert.NotNull(categories);
                Assert.Equal(3, categories.Count);
                foreach(CustomCategory category in categories)
                {
                    Assert.NotNull(category);
                    Assert.NotEqual(0, category.Id);
                    Assert.NotEqual("", category.CustomCategoryName);
                }
            }
        }

        [Fact]
        public async Task RemoveCustomCategoryShouldRemoveTheCategory()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                CustomCategory category = new CustomCategory
                {
                    Id=1
                };
                CustomCategory removedCategory = await dl.RemoveCustomCategory(category);

                Assert.NotNull(removedCategory);
                Assert.Equal(1, removedCategory.Id);
                Assert.Equal("Fantasy", removedCategory.CustomCategoryName);
            }
        }
        [Fact]
        public async Task AddCustomCategoryShouldAddACategory()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                CustomCategory category = new CustomCategory
                {
                    PlayerId = 1,
                    CustomCategoryName="Superheroes"
                };

                CustomCategory added = await dl.AddCustomCategory(category);

                Assert.NotNull(added);
                Assert.Equal("Superheroes", added.CustomCategoryName);
            }
        }

        [Fact]
        public async Task AddPlayerWordShouldAddWord()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                CustomWord word = new CustomWord
                {
                    PlayerId=1,
                    CustomWordName="Knight",
                    CustomCategoryId=1
                };

                CustomWord newWord = await dl.AddPlayerWord(word);

                Assert.NotNull(newWord);
                Assert.Equal(1, newWord.PlayerId);
                Assert.Equal("Knight", newWord.CustomWordName);
            }
        }

        [Fact]
        public async Task RemoveCustomWordShouldRemoveTheWord()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);
                CustomWord word = new CustomWord 
                {
                    Id=1
                };

                CustomWord removedWord = await dl.RemovePlayerWord(word);

                Assert.NotNull(removedWord);
                Assert.Equal(1, removedWord.Id);
                Assert.Equal("Knight", removedWord.CustomWordName);
                Assert.Equal(1, removedWord.PlayerId);
                Assert.Equal(1, removedWord.CustomCategoryId);
            }
        }

        [Fact]
        public async Task GetCustomWordsShouldReturnAListOfCustomWords()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                List<CustomWord> words = await dl.GetCustomWords(1);
                
                Assert.NotNull(words);
                Assert.NotEmpty(words);
                Assert.Equal(3, words.Count);

                foreach(CustomWord word in words)
                {
                    Assert.NotNull(word);
                    Assert.NotEqual("", word.CustomWordName);
                    Assert.NotEqual(2, word.PlayerId);
                    Assert.NotEqual(2, word.CustomCategoryId);
                }
            }
        }

        [Fact]
        public async Task GetPlayerScoreShouldGetPlayerScore()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                LeaderBoard entry = await dl.GetPlayerScore("jman9");

                Assert.NotNull(entry);
                Assert.Equal("jman9", entry.nickName);
                Assert.Equal(1, entry.Id);
                Assert.Equal(240, entry.currentScore);
                Assert.Equal(5000, entry.overallScore);
            }
        }

        [Fact]
        public async Task GetPlayers()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                List<LeaderBoard> players = await dl.GetPlayers();

                Assert.NotNull(players);
                Assert.Equal(3, players.Count);
                Assert.Equal("jman9", players[0].nickName);
                Assert.Equal(5000, players[0].overallScore);
                Assert.Equal("jonathan1", players[1].nickName);
                Assert.Equal(2000, players[1].overallScore);
                Assert.Equal("jacob1", players[2].nickName);
                Assert.Equal(500, players[2].overallScore);
            }
        }

        [Fact]
        public async Task UpdatePlayerScoreShouldUpdateScore()
        {
            using (var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                LeaderBoard entry = new LeaderBoard 
                {
                    nickName="jman9",
                    currentScore=100,
                    overallScore=2000
                };

                LeaderBoard updatedEntry = await dl.UpdatePlayerScore(entry);

                Assert.NotNull(updatedEntry);
                Assert.Equal(100, updatedEntry.currentScore);
                Assert.Equal(2000, updatedEntry.overallScore);
            }
        }

        [Fact]
        public async Task AddPlayerShouldAddPlayerToLeaderBoard()
        {
            using(var context = new SIDbContext(_options))
            {
                IDL dl = new DL(context);

                LeaderBoard newPlayer = await dl.AddPlayer("jacobm9");

                Assert.NotNull(newPlayer);
                Assert.Equal("jacobm9", newPlayer.nickName);
                Assert.Equal(0, newPlayer.currentScore);
                Assert.Equal(0, newPlayer.overallScore);
            }
        }

        private void Seed()
        {
            using (var context = new SIDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Categories.AddRange(
                    new Category()
                    {
                        Id = 1,
                        CategoryName = "cat1"
                    },
                    new Category()
                    {
                        Id = 2,
                        CategoryName = "cat2"
                    },
                    new Category()
                    {
                        Id = 3,
                        CategoryName = "cat3"
                    },
                    new Category()
                    {
                        Id = 4,
                        CategoryName = "cat4"
                    },
                    new Category() //player word category
                    {
                        Id = 5,
                        CategoryName = "playercat1"
                    },
                    new Category() //player word category
                    {
                        Id = 6,
                        CategoryName = "playercat2"
                    }
                );
                context.CustomCategories.AddRange(
                    new CustomCategory 
                    {
                        Id=1,
                        PlayerId=1,
                        CustomCategoryName="Fantasy"

                    },
                    new CustomCategory
                    {
                        Id=2,
                        PlayerId=1,
                        CustomCategoryName="Movies"
                    },
                    new CustomCategory
                    {
                        Id=3,
                        PlayerId=1,
                        CustomCategoryName="Sports"
                    }
                );

                context.CustomWords.AddRange(
                    new CustomWord 
                    {
                        PlayerId=1,
                        CustomCategoryId=1,
                        CustomWordName="Knight"
                    },
                    new CustomWord
                    {
                        PlayerId=1,
                        CustomCategoryId=1,
                        CustomWordName="Wizard"
                    },
                    new CustomWord 
                    {
                        PlayerId=1,
                        CustomCategoryId=1,
                        CustomWordName="Quest"
                    }
                );

                context.Words.AddRange(
                    new Word
                    {
                        WordName = "chimp",
                        CategoryId = 1
                    },
                    new Word
                    {
                        WordName = "lion",
                        CategoryId = 1
                    },
                    new Word
                    {
                        WordName = "apple",
                        CategoryId = 2
                    },
                    new Word
                    {
                        WordName = "banana",
                        CategoryId = 2
                    }
                );

                context.Songs.AddRange(
                    new Song
                    {
                        SongName = "abc",
                        SongURL = "abc.com"
                    },
                    new Song
                    {
                        SongName = "zxc",
                        SongURL = "zxc.com"
                    }
                );

                context.LeaderBoards.AddRange(
                    new LeaderBoard
                    {
                        Id=1,
                        nickName="jman9",
                        currentScore=240,
                        overallScore=5000
                    },
                    new LeaderBoard
                    {
                        Id=2,
                        nickName="jacob1",
                        currentScore=450,
                        overallScore=500
                    },
                    new LeaderBoard
                    {
                        Id=3,
                        nickName="jonathan1",
                        currentScore=1000,
                        overallScore=2000
                    }
                );
            context.SaveChanges();
            }
        }
    }   
}
