using SimplonHubApi.Models;
using SimplonHubApi.Services;
using SimplonHubApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SimplonHubApi.Models;
using System.Security.Claims;

namespace SimplonHubApi.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des favoris (étudiants → professeurs)
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize]
    public class FavoritesController(FavoritesService favoritesService) : ControllerBase
    {
        /// <summary>
        /// Récupère tous les professeurs favoris de l'étudiant connecté
        /// </summary>
        /// <returns>Liste des professeurs favoris</returns>
        /// <response code="200">Favoris récupérés avec succès</response>
        /// <response code="401">Non authentifié</response>
        /// <response code="404">Étudiant non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("my-favorites")]
        [ProducesResponseType(typeof(ResponseDTO<List<FavoriteResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<FavoriteResponseDTO>>>> GetMyFavorites([FromBody] DynamicFilters<Favorite> tableState)
        {


            var response = await favoritesService.GetStudentFavoritesAsync(tableState,User);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère tous les étudiants qui ont mis le professeur connecté en favori
        /// </summary>
        /// <returns>Liste des étudiants fans</returns>
        /// <response code="200">Fans récupérés avec succès</response>
        /// <response code="401">Non authentifié</response>
        /// <response code="404">Professeur non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("my-fans")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(typeof(ResponseDTO<List<FavoriteResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<FavoriteResponseDTO>>>> GetMyFans()
        {
            var response = await favoritesService.GetTeacherFansAsync(User);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère tous les étudiants fans d'un professeur spécifique (Admin)
        /// </summary>
        /// <param name="teacherId">Identifiant du professeur</param>
        /// <returns>Liste des étudiants fans</returns>
        /// <response code="200">Fans récupérés avec succès</response>
        /// <response code="404">Professeur non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("teacher/{teacherId:guid}/fans")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        [ProducesResponseType(typeof(ResponseDTO<List<FavoriteResponseDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<List<FavoriteResponseDTO>>>> GetTeacherFans(
            [FromRoute] Guid teacherId)
        {
            var response = await favoritesService.GetTeacherFansAsync(User);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Récupère un favori spécifique par son ID
        /// </summary>
        /// <param name="id">Identifiant du favori</param>
        /// <returns>Favori trouvé</returns>
        /// <response code="200">Favori récupéré avec succès</response>
        /// <response code="401">Non authentifié</response>
        /// <response code="403">Accès interdit</response>
        /// <response code="404">Favori non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<FavoriteResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<FavoriteResponseDTO>>> GetFavoriteById(
            [FromRoute] Guid id)
        {
            var response = await favoritesService.GetFavoriteByIdAsync(id, User);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Ajoute un professeur aux favoris de l'étudiant connecté
        /// </summary>
        /// <param name="favoriteDto">Données du favori à créer</param>
        /// <returns>Favori créé</returns>
        /// <response code="201">Favori créé avec succès</response>
        /// <response code="400">Données invalides ou professeur déjà en favori</response>
        /// <response code="401">Non authentifié</response>
        /// <response code="404">Professeur non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPost("add")]
        [ProducesResponseType(typeof(ResponseDTO<FavoriteResponseDTO>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<FavoriteResponseDTO>>> AddFavorite(
            [FromBody] FavoriteCreateDTO favoriteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Données de validation invalides",
                    Data = ModelState
                });
            }

            var response = await favoritesService.AddFavoriteAsync(favoriteDto,User);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Met à jour la note d'un favori
        /// </summary>
        /// <param name="id">Identifiant du favori</param>
        /// <param name="favoriteDto">Nouvelles données du favori</param>
        /// <returns>Favori mis à jour</returns>
        /// <response code="200">Favori mis à jour avec succès</response>
        /// <response code="400">Données invalides</response>
        /// <response code="401">Non authentifié</response>
        /// <response code="403">Accès interdit</response>
        /// <response code="404">Favori non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<FavoriteResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<FavoriteResponseDTO>>> UpdateFavorite(
            [FromRoute] Guid id,
            [FromBody] FavoriteUpdateDTO favoriteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDTO<object>
                {
                    Status = 400,
                    Message = "Données de validation invalides",
                    Data = ModelState
                });
            }

            var response = await favoritesService.UpdateFavoriteAsync(id, User, favoriteDto);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Supprime un professeur des favoris (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du favori</param>
        /// <returns>Résultat de la suppression</returns>
        /// <response code="200">Favori supprimé avec succès</response>
        /// <response code="401">Non authentifié</response>
        /// <response code="403">Accès interdit</response>
        /// <response code="404">Favori non trouvé</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpDelete("remove/{id:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<object>>> RemoveFavorite(
            [FromRoute] Guid id)
        {
            var response = await favoritesService.RemoveFavoriteAsync(id, User);
            return StatusCode(response.Status, response);
        }

        /// <summary>
        /// Vérifie si un professeur est dans les favoris de l'étudiant connecté
        /// </summary>
        /// <param name="teacherId">Identifiant du professeur</param>
        /// <returns>True si le professeur est en favori, false sinon</returns>
        /// <response code="200">Vérification réussie</response>
        /// <response code="401">Non authentifié</response>
        /// <response code="500">Erreur interne du serveur</response>
        [HttpGet("is-favorite/{teacherId:guid}")]
        [ProducesResponseType(typeof(ResponseDTO<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseDTO<object>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDTO<bool>>> IsFavorite(
            [FromRoute] Guid teacherId)
        { 

            var response = await favoritesService.IsFavoriteAsync(User, teacherId);
            return StatusCode(response.Status, response);
        }


    }
}
