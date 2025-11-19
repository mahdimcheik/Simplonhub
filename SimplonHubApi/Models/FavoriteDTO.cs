using SimplonHubApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SimplonHubApi.Models
{
    /// <summary>
    /// DTO pour l'affichage d'un favori
    /// </summary>
    public class FavoriteResponseDTO
    {
        /// <summary>
        /// Identifiant unique du favori
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Note ou commentaire sur le favori
        /// </summary>
        /// <example>Excellent professeur, très pédagogue</example>
        public string? Note { get; set; }

        /// <summary>
        /// Identifiant de l'étudiant
        /// </summary>
        [Required]
        public Guid StudentId { get; set; }

        /// <summary>
        /// Informations de l'étudiant
        /// </summary>
        public UserResponseDTO? Student { get; set; }

        /// <summary>
        /// Identifiant du professeur
        /// </summary>
        [Required]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Informations du professeur
        /// </summary>
        public UserResponseDTO? Teacher { get; set; }

        /// <summary>
        /// Date de création du favori
        /// </summary>
        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Date de dernière mise à jour
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; set; }

        public FavoriteResponseDTO() { }

        public FavoriteResponseDTO(Favorite favorite, bool includeStudent = false, bool includeTeacher = true)
        {
            Id = favorite.Id;
            Note = favorite.Note;
            StudentId = favorite.StudentId;
            TeacherId = favorite.TeacherId;
            CreatedAt = favorite.CreatedAt;
            UpdatedAt = favorite.UpdatedAt;

            if (includeStudent && favorite.Student != null)
            {
                Student = new UserResponseDTO(favorite.Student, null);
            }

            if (includeTeacher && favorite.Teacher != null)
            {
                Teacher = new UserResponseDTO(favorite.Teacher, null);
            }
        }
    }

    /// <summary>
    /// DTO simplifié pour l'utilisateur dans les favoris
    /// </summary>
    public class FavoriteUserDTO
    {
        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Nom de famille
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Titre/fonction
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }

        public FavoriteUserDTO() { }

        public FavoriteUserDTO(SimplonHubApi.Models.UserApp user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email ?? "";
            Title = user.Title;
            Description = user.Description;
        }
    }

    /// <summary>
    /// DTO pour créer un nouveau favori
    /// </summary>
    public class FavoriteCreateDTO
    {
        /// <summary>
        /// Identifiant du professeur à ajouter aux favoris
        /// </summary>
        /// <example>550e8400-e29b-41d4-a716-446655440000</example>
        [Required(ErrorMessage = "L'identifiant du professeur est requis")]
        public Guid TeacherId { get; set; }

        /// <summary>
        /// Note ou commentaire optionnel
        /// </summary>
        /// <example>Très bon professeur en JavaScript</example>
        [StringLength(256, ErrorMessage = "La note ne peut pas dépasser 256 caractères")]
        public string? Note { get; set; }
    }

    /// <summary>
    /// DTO pour mettre à jour un favori
    /// </summary>
    public class FavoriteUpdateDTO
    {
        /// <summary>
        /// Note ou commentaire
        /// </summary>
        /// <example>Très bon professeur en JavaScript et React</example>
        [StringLength(256, ErrorMessage = "La note ne peut pas dépasser 256 caractères")]
        public string? Note { get; set; }

        public void UpdateFavorite(Favorite favorite)
        {
            favorite.Note = Note;
            favorite.UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
