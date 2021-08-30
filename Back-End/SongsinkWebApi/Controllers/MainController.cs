using Microsoft.AspNetCore.Mvc;
using SongsinkModel;
using SongsinkBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SongsinkWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IBL _BL;
        public MainController(IBL p_BL)
        {
            _BL = p_BL;  
        }

        [HttpGet("getAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _BL.GetAllCategories());
        }

        [HttpGet("getAllWords")]
        public async Task<IActionResult> GetAllWords()
        {
            return Ok(await _BL.GetAllWords());
        }

        [HttpGet("getAllWordsOfACategory/{p_categoryId}")]
        public async Task<IActionResult> GetAllWordsOfACategory(int p_categoryId)
        {
            return Ok(await _BL.GetAllWordsOfACategory(p_categoryId));
        }

        [HttpGet("get4RandomWordsOfACategoryWithCategoryId/{p_categoryId}")]
        public async Task<IActionResult> Get4RandomWordsOfACategoryWithCategoryId(int p_categoryId)
        {
            return Ok(await _BL.Get4RandomWordsOfACategory(p_categoryId));
        }

        [HttpGet("get4RandomWordsOfACategoryWithCategoryName/{p_categoryName}")]
        public async Task<IActionResult> Get4RandomWordsOfACategoryWithCategoryName(string p_categoryName)
        {
            return Ok(await _BL.Get4RandomWordsOfACategory(p_categoryName));
        }

        [HttpGet("getASong/{p_songId}")]
        public async Task<IActionResult> GetASong(int p_songId)
        {
            return Ok(await _BL.GetASong(p_songId));
        }

        [HttpGet("getAllSongs")]
        public async Task<IActionResult> GetAllSongs()
        {
            return Ok(await _BL.GetAllSongs());
        }

        [HttpGet("getScoreOfPlayer/{p_playerNickName}")]
        public async Task<IActionResult> GetScoreOfPlayer(string p_playerNickName)
        {
            return Ok(await _BL.GetPlayerScore(p_playerNickName));
        }

        [HttpPut("updateScoreOfPlayer")]
        public async Task<IActionResult> UpdateScoreOfPlayer([FromBody] LeaderBoard p_player)
        {
            return Ok(await _BL.UpdatePlayerScore(p_player));
        }
        
        [HttpGet("getPlayerWords/{p_id}")]
        public async Task<IActionResult> getPlayerWords(int p_id)
        {
            return Ok(await _BL.GetPlayerWords(p_id));
        }

        [HttpGet("getCustomCategories/{p_id}")]
        public async Task<IActionResult> getCustomCategories(int p_id)
        {
            return Ok(await _BL.GetCustomCategories(p_id));
        }

        [HttpPost("addCustomCategory")]
        public async Task<IActionResult> addCustomCategory(CustomCategory p_category)
        {
            return Created("api/Main/addCustomCategory", await _BL.AddCustomCategory(p_category));
        }

        [HttpPost("removeCustomCategory")]
        public async Task<IActionResult> removeCustomCategory(CustomCategory p_category)
        {
            return Ok(await _BL.RemoveCustomCategory(p_category));
        }

        [HttpPost("addPlayerWord")]
        public async Task<IActionResult> addPlayerWord(CustomWord p_word)
        {
            return Created("api/Main/addPlayerWord", await _BL.AddPlayerWord(p_word));
        }

        [HttpPost("removePlayerWord")]
        public async Task<IActionResult> removePlayerWord(CustomWord p_word)
        {
            return Ok(await _BL.RemovePlayerWord(p_word));
        }

        [HttpGet("getPlayers")]
        public async Task<IActionResult> getPlayers()
        {
            return Ok(await _BL.GetPlayers());
        }
    }
}
