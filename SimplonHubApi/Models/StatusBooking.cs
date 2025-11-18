using SimplonHubApi.Models;
using SimplonHubApi.Models.Generics;
using System.ComponentModel.DataAnnotations;

namespace SimplonHubApi.Models
{
    public class StatusBooking : BaseModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Color { get; set; }
        public string? Icon { get; set; }
    }

    public class StatusBookingDTO(StatusBooking status)
    {
        /// <summary>
        /// Identifiant unique du statut
        /// </summary>
        [Required]
        public Guid Id => status.Id;

        /// <summary>
        /// Nom du statut
        /// </summary>
        [Required]
        public string Name => status.Name;

        /// <summary>
        /// Nom du statut
        /// </summary>
        [Required]
        public string DisplayName => status.DisplayName;

        /// <summary>
        /// Couleur associée au statut (code hexadécimal)
        /// </summary>
        [Required]
        public string Color => status.Color;

        /// <summary>
        /// Icône associée au statut
        /// </summary>
        public string? Icon => status.Icon;
    }

    public class StatusBookingCreateDTO
    {
        /// <summary>
        /// Nom du type de créneau
        /// </summary>
        /// <example>Cours individuel</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Nom du statut
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Couleur associée au type de créneau (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #ff69b4)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au type de créneau
        /// </summary>
        /// <example>fa-user</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }
    }

    /// <summary>
    /// DTO pour la mise à jour d'un type de créneau existant
    /// </summary>
    public class StatusBookingUpdateDTO
    {
        /// <summary>
        /// Nom du type de créneau
        /// </summary>
        /// <example>Cours individuel</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string Name { get; set; }

        /// <summary>
        /// Nom du type de créneau
        /// </summary>
        /// <example>Cours individuel</example>
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(64, ErrorMessage = "Le nom ne peut pas dépasser 64 caractères")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Couleur associée au type de créneau (code hexadécimal)
        /// </summary>
        /// <example>#ff69b4</example>
        [Required(ErrorMessage = "La couleur est requise")]
        [StringLength(16, ErrorMessage = "La couleur ne peut pas dépasser 16 caractères")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "La couleur doit être au format hexadécimal valide (ex: #ff69b4)")]
        public string Color { get; set; }

        /// <summary>
        /// Icône associée au type de créneau
        /// </summary>
        /// <example>fa-user</example>
        [StringLength(256, ErrorMessage = "L'icône ne peut pas dépasser 256 caractères")]
        public string? Icon { get; set; }

        public void UpdateStatusBooking(StatusBooking statusBooking)
        {
            statusBooking.Name = Name;
            statusBooking.DisplayName = DisplayName;
            statusBooking.Color = Color;
            statusBooking.Icon = Icon;
            statusBooking.UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
