using System;
using System.Collections.Generic;
using Xunit;
using SongsinkModel;
using SongsinkDL;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SongsinkTests
{
    public class SongsinkRepositoryTest
    {

        private readonly DbContextOptions<SIDbContext> _options;

        public SongsinkRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<SIDbContext>().UseSqlite("Filename = test.db").Options;
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
        public async Task GetAllWordsShouldGetAllWords()
        {
            using (var context = new SIDbContext(_options))
            {
                //Arrange
                IDL dl = new DL(context);

                //Act
                List<Word> allWords = await dl.GetAllWords();

                //Assert
                Assert.Equal(8, allWords.Count);
                foreach (Word word in allWords)
                {
                    Assert.NotNull(word);
                    Assert.NotEqual(0,word.Id);
                    Assert.NotEqual("", word.WordName);
                }
            }
        }
        [Fact]
        public async Task GetAllWordsOfACategoryShouldGetAllWordsOfACategory()
        {
            using (var context = new SIDbContext(_options))
            {
                //Arrange
                IDL dl = new DL(context);
                int catID = 1;
                //Act
                List<Word> wordsofCategory = await dl.GetAllWordsOfACategory(catID);

                //Assert
                Assert.Equal(2, wordsofCategory.Count);
                foreach (Word word in wordsofCategory)
                {
                    Assert.Equal(catID, word.CategoryId);
                    Assert.NotEqual("",word.WordName);
                }
            }
        }
        [Fact]
        public async Task GetASongShouldGetASong()
        {
            using (var context = new SIDbContext(_options))
            {
                //Arrange
                IDL dl = new DL(context);
                int songID = 1;
                string expectedUrl = "https://SongStorage.com/songlist/song1";

                //Act
                Song s = await dl.GetASong(songID);

                //Assert
                Assert.Equal(expectedUrl, s.SongURL);
            }
        }
        [Fact]
        public async Task GetAllSongsShouldGetAllSongs()
        {
            using (var context = new SIDbContext(_options))
            {
                // Arrange
                IDL dl = new DL(context);

                //Act
                List<Song> allSongs = await dl.GetAllSongs();

                //Assert
                Assert.NotNull(allSongs);
                Assert.NotEmpty(allSongs);
                foreach (Song song in allSongs)
                {
                    Assert.NotEqual(0, song.Id);
                    Assert.NotEqual("",song.SongName);
                    Assert.NotEqual("",song.SongURL);
                }
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
                context.Words.AddRange(
                    new Word()
                    {
                        Id = 1,
                        WordName = "word1",
                        CategoryId = 1
                    },
                   new Word()
                    {
                        Id = 2,
                        WordName = "word2",
                        CategoryId = 1
                    },
                    new Word()
                    {
                        Id = 3,
                        WordName = "word3",
                        CategoryId = 2
                    },
                   new Word()
                    {
                        Id = 4,
                        WordName = "word4",
                        CategoryId = 2
                    },
                    new Word()
                    {
                        Id = 5,
                        WordName = "word5",
                        CategoryId = 2
                    },
                     new Word()
                    {
                        Id = 6,
                        WordName = "word6",
                        CategoryId = 2
                    },
                    new Word()
                    {
                        Id = 7,
                        WordName = "word7",
                        CategoryId =2
                    },
                    new Word()
                    {
                        Id = 8,
                        WordName = "word8",
                        CategoryId = 2
                    }
                );
                context.Songs.AddRange(
                    new Song()
                    {
                        Id = 1,
                        SongName = "song1",
                        SongURL = "https://SongStorage.com/songlist/song1"
                    },
                   new Song()
                    {
                        Id = 2,
                        SongName = "song2",
                        SongURL = "https://SongStorage.com/songlist/song2"
                    },
                     new Song()
                    {
                        Id = 3,
                        SongName = "song3",
                        SongURL = "https://SongStorage.com/songlist/song3"
                    },
                    new Song()
                    {
                        Id = 4,
                        SongName = "song4",
                        SongURL = "https://SongStorage.com/songlist/song4"
                    },
                    new Song()
                    {
                        Id = 5,
                        SongName = "song5",
                        SongURL = "https://SongStorage.com/songlist/song5"
                    },
                    new Song()
                    {
                        Id = 6,
                        SongName = "song6",
                        SongURL = "https://SongStorage.com/songlist/song6"
                    },
                    new Song()
                    {
                        Id = 7,
                        SongName = "song7",
                        SongURL = "https://SongStorage.com/songlist/song7"
                    },
                    new Song()
                    {
                        Id = 8,
                        SongName = "song8",
                        SongURL = "https://SongStorage.com/songlist/song8"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
