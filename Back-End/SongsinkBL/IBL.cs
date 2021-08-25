﻿using System;
using SongsinkModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongsinkBL
{
    public interface IBL
    {
        /// <summary>
        /// Calls the DL to get All Categories DB-Categories
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetAllCategories();

        /// <summary>
        /// Calls the DL to get All Words DB-Words
        /// </summary>
        /// <returns></returns>
        Task<List<Word>> GetAllWords();

        /// <summary>
        /// Calls the DL to get A Word from DB-Words
        /// </summary>
        /// <param name="p_wordId"></param>
        /// <returns></returns>
        Task<Word> GetAWord(int p_wordId);

        /// <summary>
        /// Calls the DL to get All Words Of A Specific Category DB-Words
        /// </summary>
        /// <param name="p_categoryId"></param>
        /// <returns></returns>
        Task<List<Word>> GetAllWordsOfACategory(int p_categoryId);

        /// <summary>
        /// Calls the DL to get All Words Of A Specific Category DB-Words
        /// </summary>
        /// <param name="p_categoryName"></param>
        /// <returns></returns>
        Task<List<Word>> GetAllWordsOfACategory(string p_categoryName);

        /// <summary>
        /// Calls the DL to get 4 random words of a category from DB-Words
        /// </summary>
        /// <param name="p_categoryId"></param>
        /// <returns></returns>
        Task<List<Word>> Get4RandomWordsOfACategory(int p_categoryId);

        /// <summary>
        /// Calls the DL to et 4 random words of a category from DB-Words
        /// </summary>
        /// <param name="p_categoryName"></param>
        /// <returns></returns>
        Task<List<Word>> Get4RandomWordsOfACategory(string p_categoryName);

        /// <summary>
        /// Calls the DL to get A Song Url Using Its Id DB-Songs
        /// </summary>
        /// <param name="p_songId"></param>
        /// <returns></returns>
        Task<Song> GetASong(int p_songId);

        /// <summary>
        /// Calls the DL to get A List Of All Songs For The User To Choose From
        /// </summary>
        /// <returns>
        /// Returns The List Of All Songs In The Database
        /// </returns>
        Task<List<Song>> GetAllSongs();

        /// <summary>
        /// Calls the DL to get player from DB-Players
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_password"></param>
        /// <returns></returns>
        Task<Player> GetAPlayer(string p_email);

        /// <summary>
        /// Calls the DL to get A Player from DB-Players
        /// </summary>
        /// <param name="p_id"></param>
        /// <returns></returns>
        Task<Player> GetAPlayer(int p_id);

        /// <summary>
        /// Calls the DL to update Player in DB-Players
        /// </summary>
        /// <param name="p_player"></param>
        /// <returns></returns>
        Task<Player> UpdatePlayer(Player p_player);
        /// <summary>
        /// Calls the DL to create new player in DB-Players
        /// </summary>
        /// <param name="p_player"></param>
        /// <returns></returns>
        Task<Player> CreateNewPlayer(Player p_player);

         /// <summary>
        /// Calls the DL to get all custom words created by a user
        /// </summary>
        /// <returns>List of custom words</returns>
        Task<List<CustomWord>> GetPlayerWords(int p_userID);

        /// <summary>
        /// Calls the DL to Add a custom word to the corresponding user
        /// </summary>
        /// <param name="p_word"> The word to be added</param>
        /// <returns> The custom word that was added</returns>
        Task<CustomWord> AddPlayerWord(CustomWord p_word);

        /// <summary>
        /// Calls the DL to Remove a player word from the db
        /// </summary>
        /// <param name="p_word"> The word to be removed</param>
        /// <returns>Returns the word that was removed</returns>
        Task<CustomWord> RemovePlayerWord(CustomWord p_word);
        
        /// <summary>
        /// Calls the DL to Add a custom category for the user
        /// </summary>
        /// <param name="p_category"> contains the category name and player id</param>
        /// <returns> the custom category that was created </returns>
        Task<CustomCategory> AddCustomCategory(CustomCategory p_category);

        /// <summary>
        /// Calls the DL to remove a custom category from the db
        /// </summary>
        /// <param name="p_category"> the category to be removed</param>
        /// <returns>Returns the deleted category</returns>
        Task<CustomCategory> RemoveCustomCategory(CustomCategory p_category);
        
        /// <summary>
        /// Calls the DL to get the custom categories of the specified user
        /// </summary>
        /// <param name="p_playerID">The ID of the user </param>
        /// <returns>Returns a list of custom categories</returns>
        Task<List<CustomCategory>> GetCustomCategories(int p_playerID);
    }
}
