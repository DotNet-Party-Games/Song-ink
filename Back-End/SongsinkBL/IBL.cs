using System;
using SongsinkModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongsinkBL
{
    public interface IBL
    {
        /// <summary>
        /// Get All Categories DB-Categories
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetAllCategories();

        /// <summary>
        /// Get All Words DB-Words
        /// </summary>
        /// <returns></returns>
        Task<List<Word>> GetAllWords();

        /// <summary>
        /// Get A Word from DB-Words
        /// </summary>
        /// <param name="p_wordId"></param>
        /// <returns></returns>
        Task<Word> GetAWord(int p_wordId);

        /// <summary>
        /// Get All Words Of A Specific Category DB-Words
        /// </summary>
        /// <param name="p_categoryId"></param>
        /// <returns></returns>
        Task<List<Word>> GetAllWordsOfACategory(int p_categoryId);

        /// <summary>
        /// Get All Words Of A Specific Category DB-Words
        /// </summary>
        /// <param name="p_categoryName"></param>
        /// <returns></returns>
        Task<List<Word>> GetAllWordsOfACategory(string p_categoryName);

        /// <summary>
        /// Get 4 random words of a category from DB-Words
        /// </summary>
        /// <param name="p_categoryId"></param>
        /// <returns></returns>
        Task<List<Word>> Get4RandomWordsOfACategory(int p_categoryId);

        /// <summary>
        /// Get 4 random words of a category from DB-Words
        /// </summary>
        /// <param name="p_categoryName"></param>
        /// <returns></returns>
        Task<List<Word>> Get4RandomWordsOfACategory(string p_categoryName);

        /// <summary>
        /// Get A Song Url Using Its Id DB-Songs
        /// </summary>
        /// <param name="p_songId"></param>
        /// <returns></returns>
        Task<Song> GetASong(int p_songId);

        /// <summary>
        /// Get A List Of All Songs For The User To Choose From
        /// </summary>
        /// <returns>
        /// Returns The List Of All Songs In The Database
        /// </returns>
        Task<List<Song>> GetAllSongs();

        /// <summary>
        /// Get player from DB-Players
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_password"></param>
        /// <returns></returns>
        Task<Player> GetAPlayer(string p_email);

        /// <summary>
        /// Get A Player from DB-Players
        /// </summary>
        /// <param name="p_id"></param>
        /// <returns></returns>
        Task<Player> GetAPlayer(int p_id);

        /// <summary>
        /// Update Player in DB-Players
        /// </summary>
        /// <param name="p_player"></param>
        /// <returns></returns>
        Task<Player> UpdatePlayer(Player p_player);
        /// <summary>
        /// Create new player in DB-Players
        /// </summary>
        /// <param name="p_player"></param>
        /// <returns></returns>
        Task<Player> CreateNewPlayer(Player p_player);

         /// <summary>
        /// Gets all custom words created by a user
        /// </summary>
        /// <returns>List of custom words</returns>
        Task<List<CustomWord>> GetPlayerWords(int p_userID);

        /// <summary>
        /// Adds a custom word to the corresponding user
        /// </summary>
        /// <param name="p_word"> The word to be added</param>
        /// <returns> The custom word that was added</returns>
        Task<CustomWord> AddPlayerWord(CustomWord p_word);

        /// <summary>
        /// Removes a player word from the db
        /// </summary>
        /// <param name="p_word"> The word to be removed</param>
        /// <returns>Returns the word that was removed</returns>
        Task<CustomWord> RemovePlayerWord(CustomWord p_word);
        
        /// <summary>
        /// Adds a custom category for the user
        /// </summary>
        /// <param name="p_category"> contains the category name and player id</param>
        /// <returns> the custom category that was created </returns>
        Task<CustomCategory> AddCustomCategory(CustomCategory p_category);

        /// <summary>
        /// Removes a custom category from the db
        /// </summary>
        /// <param name="p_category"> the category to be removed</param>
        /// <returns>Returns the deleted category</returns>
        Task<CustomCategory> RemoveCustomCategory(CustomCategory p_category);
        
        /// <summary>
        /// Gets the custom categories of the specified user
        /// </summary>
        /// <param name="p_playerID">The ID of the user </param>
        /// <returns>Returns a list of custom categories</returns>
        Task<List<CustomCategory>> GetCustomCategories(int p_playerID);
    }
}
