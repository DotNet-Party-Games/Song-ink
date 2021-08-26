using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SongsinkModel;
using SongsinkDL;

namespace SongsinkBL
{
    public class BL : IBL
    {
        private readonly IDL _repo;
        public BL(IDL p_repo)
        {
            _repo = p_repo;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _repo.GetAllCategories();
        }

        public async Task<List<Word>> GetAllWords()
        {
            return await _repo.GetAllWords();
        }

        public async Task<List<CustomWord>> GetPlayerWords(int p_userID)
        {
            return await _repo.GetPlayerWords(p_userID);
        }

        public async Task<Word> GetAWord(int p_wordId)
        {
            return await _repo.GetAWord(p_wordId);
        }

        public async Task<List<Word>> GetAllWordsOfACategory(int p_categoryId)
        {
            return await _repo.GetAllWordsOfACategory(p_categoryId);
        }

        public async Task<List<Word>> GetAllWordsOfACategory(string p_categoryName)
        {
            return await _repo.GetAllWordsOfACategory(p_categoryName);
        }

        public async Task<List<Word>> Get4RandomWordsOfACategory(int p_categoryId)
        {
            List<Word> words = await this.GetAllWordsOfACategory(p_categoryId);
            List<Word> randomWords = new List<Word>();
            Random rnd = new Random();

            while(randomWords.Count != 4)
            {
                int index = rnd.Next(words.Count);
                if (!randomWords.Contains(words[index]))
                {
                    randomWords.Add(words[index]);
                }
            }

            return randomWords;
        }

        public async Task<List<Word>> Get4RandomWordsOfACategory(string p_categoryName)
        {
            List<Word> words = await this.GetAllWordsOfACategory(p_categoryName);
            List<Word> randomWords = new List<Word>();
            Random rnd = new Random();

            while (randomWords.Count != 4)
            {
                int index = rnd.Next(words.Count);
                if (!randomWords.Contains(words[index]))
                {
                    randomWords.Add(words[index]);
                }
            }

            return randomWords;
        }

        public async Task<Song> GetASong(int p_songId)
        {
            Song found = await _repo.GetASong(p_songId);
            if (found == null)
            {
                throw new Exception("Song Not Found");
            }
            return found;
        }
        public async Task<List<Song>> GetAllSongs()
        {
            return await _repo.GetAllSongs();
        }

        public async Task<CustomWord> AddPlayerWord(CustomWord p_word)
        {
            return await _repo.AddPlayerWord(p_word);
        }

        public async Task<CustomWord> RemovePlayerWord(CustomWord p_word)
        {
            return await _repo.RemovePlayerWord(p_word);
        }

        public async Task<CustomCategory> AddCustomCategory(CustomCategory p_category)
        {
            return await _repo.AddCustomCategory(p_category);
        }

        public async Task<CustomCategory> RemoveCustomCategory(CustomCategory p_category)
        {
            return await _repo.RemoveCustomCategory(p_category);
        }

        public async Task<List<CustomCategory>> GetCustomCategories(int p_playerID)
        {
            return await _repo.GetCustomCategories(p_playerID);
        }

        public async Task<List<CustomWord>> GetCustomWords(int p_customCategoryID)
        {
            return await _repo.GetCustomWords(p_customCategoryID);
        }

        public async Task<LeaderBoard> GetPlayerScore(string p_playerNickName)
        {
            return await _repo.GetPlayerScore(p_playerNickName);
        }

        public async Task<LeaderBoard> UpdatePlayerScore(LeaderBoard p_player)
        {
            return await _repo.UpdatePlayerScore(p_player);
        }

    }
}
