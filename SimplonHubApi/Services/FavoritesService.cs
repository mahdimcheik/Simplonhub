using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimplonHubApi.Models;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des favoris (étudiants → professeurs)
    /// </summary>
    public class FavoritesService(MainContext context, UserManager<UserApp> userManager)
    {
        /// <summary>
        /// Récupère tous les favoris d'un étudiant
        /// </summary>
        /// <param name="studentId">Identifiant de l'étudiant</param>
        /// <returns>Liste des professeurs favoris</returns>
        public async Task<ResponseDTO<List<FavoriteResponseDTO>>> GetStudentFavoritesAsync(Guid studentId)
        {
            try
            {
                var student = await context.Users.FindAsync(studentId);
                if (student == null)
                {
                    return new ResponseDTO<List<FavoriteResponseDTO>>
                    {
                        Status = 404,
                        Message = "Étudiant non trouvé",
                        Data = null
                    };
                }

                var favorites = await context.Favorites
                    .Where(f => f.StudentId == studentId && f.ArchivedAt == null)
                    .Include(f => f.Teacher)
                        .ThenInclude(t => t.Languages)
                    .Include(f => f.Teacher)
                        .ThenInclude(t => t.ProgrammingLanguages)
                    .Include(f => f.Teacher.Status)
                    .Include(f => f.Teacher.Gender)
                    .OrderByDescending(f => f.CreatedAt)
                    .ToListAsync();

                var favoriteDtos = favorites.Select(f => new FavoriteResponseDTO(f, includeStudent: false, includeTeacher: true)).ToList();

                return new ResponseDTO<List<FavoriteResponseDTO>>
                {
                    Status = 200,
                    Message = "Favoris récupérés avec succès",
                    Data = favoriteDtos,
                    Count = favoriteDtos.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<FavoriteResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des favoris: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère tous les étudiants qui ont mis un professeur en favori
        /// </summary>
        /// <param name="teacherId">Identifiant du professeur</param>
        /// <returns>Liste des étudiants fans</returns>
        public async Task<ResponseDTO<List<FavoriteResponseDTO>>> GetTeacherFansAsync(Guid teacherId)
        {
            try
            {
                var teacher = await context.Users.FindAsync(teacherId);
                if (teacher == null)
                {
                    return new ResponseDTO<List<FavoriteResponseDTO>>
                    {
                        Status = 404,
                        Message = "Professeur non trouvé",
                        Data = null
                    };
                }

                var fans = await context.Favorites
                    .Where(f => f.TeacherId == teacherId && f.ArchivedAt == null)
                    .Include(f => f.Student)
                        .ThenInclude(s => s.Status)
                    .Include(f => f.Student)
                        .ThenInclude(s => s.Gender)
                    .OrderByDescending(f => f.CreatedAt)
                    .ToListAsync();

                var fanDtos = fans.Select(f => new FavoriteResponseDTO(f, includeStudent: true, includeTeacher: false)).ToList();

                return new ResponseDTO<List<FavoriteResponseDTO>>
                {
                    Status = 200,
                    Message = "Étudiants fans récupérés avec succès",
                    Data = fanDtos,
                    Count = fanDtos.Count
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<FavoriteResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des fans: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Récupère un favori spécifique par son ID
        /// </summary>
        /// <param name="favoriteId">Identifiant du favori</param>
        /// <param name="studentId">Identifiant de l'étudiant (pour vérifier les droits)</param>
        /// <returns>Favori trouvé</returns>
        public async Task<ResponseDTO<FavoriteResponseDTO>> GetFavoriteByIdAsync(Guid favoriteId, Guid studentId)
        {
            try
            {
                var favorite = await context.Favorites
                    .Include(f => f.Teacher)
                    .Include(f => f.Student)
                    .FirstOrDefaultAsync(f => f.Id == favoriteId && f.ArchivedAt == null);

                if (favorite == null)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 404,
                        Message = "Favori non trouvé",
                        Data = null
                    };
                }

                // Vérifier que l'étudiant est bien le propriétaire du favori
                if (favorite.StudentId != studentId)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 403,
                        Message = "Vous n'avez pas accès à ce favori",
                        Data = null
                    };
                }

                return new ResponseDTO<FavoriteResponseDTO>
                {
                    Status = 200,
                    Message = "Favori récupéré avec succès",
                    Data = new FavoriteResponseDTO(favorite, includeStudent: true, includeTeacher: true)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<FavoriteResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du favori: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Ajoute un professeur aux favoris d'un étudiant
        /// </summary>
        /// <param name="studentId">Identifiant de l'étudiant</param>
        /// <param name="favoriteDto">Données du favori à créer</param>
        /// <returns>Favori créé</returns>
        public async Task<ResponseDTO<FavoriteResponseDTO>> AddFavoriteAsync(Guid studentId, FavoriteCreateDTO favoriteDto)
        {
            try
            {
                // Vérifier que l'étudiant existe
                var student = await context.Users.FindAsync(studentId);
                if (student == null)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 404,
                        Message = "Étudiant non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le professeur existe
                var teacher = await context.Users.FindAsync(favoriteDto.TeacherId);
                if (teacher == null)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 404,
                        Message = "Professeur non trouvé",
                        Data = null
                    };
                }

                // Vérifier que le professeur a bien le rôle Teacher
                var isTeacher = await userManager.IsInRoleAsync(teacher, "Teacher");
                if (!isTeacher)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 400,
                        Message = "L'utilisateur spécifié n'est pas un professeur",
                        Data = null
                    };
                }

                // Vérifier qu'on ne s'ajoute pas soi-même en favori
                if (studentId == favoriteDto.TeacherId)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 400,
                        Message = "Vous ne pouvez pas vous ajouter vous-même en favori",
                        Data = null
                    };
                }

                // Vérifier que le favori n'existe pas déjà
                var existingFavorite = await context.Favorites
                    .FirstOrDefaultAsync(f => f.StudentId == studentId 
                        && f.TeacherId == favoriteDto.TeacherId 
                        && f.ArchivedAt == null);

                if (existingFavorite != null)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 400,
                        Message = "Ce professeur est déjà dans vos favoris",
                        Data = null
                    };
                }

                // Créer le favori
                var favorite = new Favorite
                {
                    Id = Guid.NewGuid(),
                    StudentId = studentId,
                    TeacherId = favoriteDto.TeacherId,
                    Note = favoriteDto.Note,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                context.Favorites.Add(favorite);
                await context.SaveChangesAsync();

                // Recharger avec les relations
                var createdFavorite = await context.Favorites
                    .Include(f => f.Teacher)
                    .Include(f => f.Student)
                    .FirstOrDefaultAsync(f => f.Id == favorite.Id);

                return new ResponseDTO<FavoriteResponseDTO>
                {
                    Status = 201,
                    Message = "Professeur ajouté aux favoris avec succès",
                    Data = new FavoriteResponseDTO(createdFavorite!, includeStudent: false, includeTeacher: true)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<FavoriteResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de l'ajout du favori: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Met à jour la note d'un favori
        /// </summary>
        /// <param name="favoriteId">Identifiant du favori</param>
        /// <param name="studentId">Identifiant de l'étudiant</param>
        /// <param name="favoriteDto">Nouvelles données du favori</param>
        /// <returns>Favori mis à jour</returns>
        public async Task<ResponseDTO<FavoriteResponseDTO>> UpdateFavoriteAsync(
            Guid favoriteId, 
            Guid studentId, 
            FavoriteUpdateDTO favoriteDto)
        {
            try
            {
                var favorite = await context.Favorites
                    .Include(f => f.Teacher)
                    .Include(f => f.Student)
                    .FirstOrDefaultAsync(f => f.Id == favoriteId && f.ArchivedAt == null);

                if (favorite == null)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 404,
                        Message = "Favori non trouvé",
                        Data = null
                    };
                }

                // Vérifier que l'étudiant est bien le propriétaire du favori
                if (favorite.StudentId != studentId)
                {
                    return new ResponseDTO<FavoriteResponseDTO>
                    {
                        Status = 403,
                        Message = "Vous n'avez pas le droit de modifier ce favori",
                        Data = null
                    };
                }

                favoriteDto.UpdateFavorite(favorite);
                await context.SaveChangesAsync();

                return new ResponseDTO<FavoriteResponseDTO>
                {
                    Status = 200,
                    Message = "Favori mis à jour avec succès",
                    Data = new FavoriteResponseDTO(favorite, includeStudent: false, includeTeacher: true)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<FavoriteResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du favori: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Supprime un professeur des favoris (suppression logique)
        /// </summary>
        /// <param name="favoriteId">Identifiant du favori</param>
        /// <param name="studentId">Identifiant de l'étudiant</param>
        /// <returns>Résultat de la suppression</returns>
        public async Task<ResponseDTO<object>> RemoveFavoriteAsync(Guid favoriteId, Guid studentId)
        {
            try
            {
                var favorite = await context.Favorites
                    .FirstOrDefaultAsync(f => f.Id == favoriteId && f.ArchivedAt == null);

                if (favorite == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Favori non trouvé",
                        Data = null
                    };
                }

                // Vérifier que l'étudiant est bien le propriétaire du favori
                if (favorite.StudentId != studentId)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 403,
                        Message = "Vous n'avez pas le droit de supprimer ce favori",
                        Data = null
                    };
                }

                // Suppression logique
                favorite.ArchivedAt = DateTimeOffset.UtcNow;
                favorite.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Favori supprimé avec succès",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression du favori: {ex.Message}",
                    Data = null
                };
            }
        }

        /// <summary>
        /// Vérifie si un professeur est dans les favoris d'un étudiant
        /// </summary>
        /// <param name="studentId">Identifiant de l'étudiant</param>
        /// <param name="teacherId">Identifiant du professeur</param>
        /// <returns>True si le professeur est en favori, false sinon</returns>
        public async Task<ResponseDTO<bool>> IsFavoriteAsync(Guid studentId, Guid teacherId)
        {
            try
            {
                var isFavorite = await context.Favorites
                    .AnyAsync(f => f.StudentId == studentId 
                        && f.TeacherId == teacherId 
                        && f.ArchivedAt == null);

                return new ResponseDTO<bool>
                {
                    Status = 200,
                    Message = isFavorite ? "Le professeur est en favori" : "Le professeur n'est pas en favori",
                    Data = isFavorite
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<bool>
                {
                    Status = 500,
                    Message = $"Erreur lors de la vérification: {ex.Message}",
                    Data = false
                };
            }
        }
    }
}
