using Microsoft.EntityFrameworkCore;
using SongsinkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsinkDL
{
    public class DL : IDL
    {
        private SIDbContext _context;
        public DL(SIDbContext p_context)
        {
            _context = p_context;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.Select(cat=>cat).ToListAsync();
        }

        public async Task<List<Word>> GetAllWords()
        {
            return await _context.Words.Select(word => word).ToListAsync();
        }

        
        public async Task<List<CustomWord>> GetPlayerWords(int p_userID)
        {
            return await _context.CustomWords.Where(word => word.PlayerId == p_userID).Select(word => word).ToListAsync();
        }

        public async Task<Word> GetAWord(int p_wordId)
        {
            return await _context.Words.FirstOrDefaultAsync(w => w.Id == p_wordId);
        }

        public async Task<List<Word>> GetAllWordsOfACategory(int p_categoryId)
        {
            return await _context.Words.Where(word => word.CategoryId == p_categoryId).Select(word => word).ToListAsync();
        }

        public async Task<List<Word>> GetAllWordsOfACategory(string p_categoryName)
        {
            Category c = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == p_categoryName);
            return await _context.Words.Where(word => word.CategoryId == c.Id).Select(word => word).ToListAsync();
        }

        public async Task<Song> GetASong(int p_songId)
        {
            return await _context.Songs.FirstOrDefaultAsync(song => song.Id == p_songId);
        }

        public async Task<List<Song>> GetAllSongs()
        {
            return await _context.Songs.Select(song => song).ToListAsync();
        }


        public async Task<Player> GetAPlayer(string p_email)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Email == p_email);
        }

        public async Task<Player> GetAPlayer(int p_id)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == p_id);
        }

        public async Task<Player> UpdatePlayer(Player p_player)
        {
            Player currentPlayer = await _context.Players.FirstOrDefaultAsync(p => p.Id == p_player.Id);
            currentPlayer.PlayerName = p_player.PlayerName;
            currentPlayer.PlayerScore = p_player.PlayerScore;
            currentPlayer.CurrentScore = p_player.CurrentScore;
            currentPlayer.GamesPlayed = p_player.GamesPlayed;
            currentPlayer.Email = p_player.Email;
            await _context.SaveChangesAsync();
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == p_player.Id);
        }

        public async Task<Player> CreateNewPlayer(Player p_player)
        {
            await _context.Players.AddAsync(p_player);
            await _context.SaveChangesAsync();
            return await _context.Players.FirstOrDefaultAsync(p => p.Email == p_player.Email);
        }

        public async Task<CustomWord> AddPlayerWord(CustomWord p_word)
        {
            await _context.CustomWords.AddAsync(p_word);
            await _context.SaveChangesAsync();
            return await _context.CustomWords.FirstOrDefaultAsync(word => word.CustomWordName == p_word.CustomWordName );
        }

        public async Task<CustomWord> RemovePlayerWord(CustomWord p_word)
        {
            CustomWord word = await _context.CustomWords.FirstOrDefaultAsync(word => word.Id == p_word.Id);
            _context.CustomWords.Remove(word);
            await _context.SaveChangesAsync();
            return word;
        }

        public async Task<CustomCategory> AddCustomCategory(CustomCategory p_category)
        {
            await _context.CustomCategories.AddAsync(p_category);
            await _context.SaveChangesAsync();
            return await _context.CustomCategories.FirstOrDefaultAsync(category => category.CustomCategoryName == p_category.CustomCategoryName);
        }

        public async Task<CustomCategory> RemoveCustomCategory(CustomCategory p_category)
        {
            CustomCategory category = await _context.CustomCategories.FirstOrDefaultAsync(cat => cat.Id == p_category.Id);
            _context.CustomCategories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<CustomCategory>> GetCustomCategories(int p_playerID)
        {
            return await _context.CustomCategories.Where(category => category.PlayerId == p_playerID).ToListAsync();
        }
        
    }
}
