using System.Security.Claims;
using MainBoilerPlate.Contexts;
using MainBoilerPlate.Models;
using MainBoilerPlate.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SimplonHubApi.Models;

namespace MainBoilerPlate.Services
{
    /// <summary>
    /// Service pour la gestion des créneaux
    /// </summary>
    public class SlotsService(MainContext context)
    {
        /// <summary>
        /// Récupère tous les créneaux
        /// </summary>
        /// <returns>Liste des créneaux</returns>
        public async Task<ResponseDTO<List<SlotResponseDTO>>> GetAllSlotsAsync(
            DynamicFilters<Slot> tableState
        )
        {
            try
            {
                var query =
                    //await
                    context
                        .Slots.AsNoTracking()
                        .Where(s => s.ArchivedAt == null)
                        .Include(s => s.Teacher)
                        .Include(s => s.Booking)
                        .ThenInclude(b => b.Student)
                        .Include(s => s.Booking)
                        .ThenInclude(b => b.Status)
                        .Include(s => s.Type)
                        .OrderBy(s => s.DateFrom);

                var slots = await query.ApplyAndCountAsync(tableState);

                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 200,
                    Message = "Créneaux récupérés avec succès",
                    Data = slots.Values.Select(s => new SlotResponseDTO(s)).ToList(),
                    Count = slots.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des créneaux: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Récupère un créneau par son identifiant
        /// </summary>
        /// <param name="id">Identifiant du créneau</param>
        /// <returns>Créneau trouvé</returns>
        public async Task<ResponseDTO<SlotResponseDTO>> GetSlotByIdAsync(Guid id)
        {
            try
            {
                var slot = await context
                    .Slots.AsNoTracking()
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .Include(s => s.Booking)
                    .ThenInclude(b => b.Student)
                    .Include(s => s.Booking)
                    .ThenInclude(b => b.Status)
                    .FirstOrDefaultAsync(s => s.Id == id && s.ArchivedAt == null);

                if (slot == null)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Créneau non trouvé",
                        Data = null,
                    };
                }

                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 200,
                    Message = "Créneau récupéré avec succès",
                    Data = new SlotResponseDTO(slot),
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// retourne les creneau reservé de l'élève et les libre du prof en question
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public async Task<ResponseDTO<List<SlotResponseDTO>>> GetSlotsByTeacherIdAsync(
            Guid teacherId
        )
        {
            try
            {
                var slots = await context
                    .Slots.AsNoTracking()
                    .Where(s => s.TeacherId == teacherId && s.ArchivedAt == null)
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .OrderBy(s => s.DateFrom)
                    .Select(x => new SlotResponseDTO(x))
                    .ToListAsync();

                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 200,
                    Message = "Créneaux de l'enseignant récupérés avec succès",
                    Data = slots,
                    Count = slots.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 500,
                    Message =
                        $"Erreur lors de la récupération des créneaux de l'enseignant: {ex.Message}",
                    Data = null,
                };
            }
        }

        public async Task<ResponseDTO<List<SlotResponseDTO>>> GetSlotsByStudentIdAsync(
            Guid studentId,
            DateTimeOffset start,
            DateTimeOffset end,
            Guid? teacherId
        )
        {
            try
            {
                var slots = await context
                    .Slots.AsNoTracking()
                    .Include(s => s.Booking)
                    .ThenInclude(b => b.Student)
                    .Where(s =>
                        s.ArchivedAt == null
                        && s.Booking.StudentId == studentId
                        && s.DateFrom >= start
                        && s.DateTo <= end
                    )
                    .Include(s => s.Booking)
                    .ThenInclude(b => b.Status)
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .OrderBy(s => s.DateFrom)
                    .Select(x => new SlotResponseDTO(x))
                    .ToListAsync();

                if (teacherId is not null)
                {
                    var startTime = DateTime.Now > start ? DateTime.Now : start;
                    var teacherSlots = await context
                        .Slots.AsNoTracking()
                        .Where(s => s.TeacherId == teacherId)
                        .Include(s => s.Booking)
                        .Where(s =>
                            s.ArchivedAt == null
                            && s.Booking == null
                            && s.DateFrom >= startTime
                            && s.DateTo <= end
                        )
                        .Include(s => s.Teacher)
                        .Include(s => s.Type)
                        .OrderBy(s => s.DateFrom)
                        .Select(x => new SlotResponseDTO(x))
                        .ToListAsync();
                    slots.AddRange(teacherSlots);
                }

                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 200,
                    Message = "Créneaux de l'enseignant récupérés avec succès",
                    Data = slots,
                    Count = slots.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 500,
                    Message =
                        $"Erreur lors de la récupération des créneaux de l'enseignant: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Récupère les créneaux disponibles
        /// </summary>
        /// <returns>Liste des créneaux disponibles</returns>
        public async Task<ResponseDTO<List<SlotResponseDTO>>> GetAvailableSlotsAsync()
        {
            try
            {
                var slots = await context
                    .Slots.AsNoTracking()
                    .Where(s => s.ArchivedAt == null && s.DateFrom > DateTimeOffset.UtcNow)
                    .Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .OrderBy(s => s.DateFrom)
                    .Select(x => new SlotResponseDTO(x))
                    .ToListAsync();

                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 200,
                    Message = "Créneaux disponibles récupérés avec succès",
                    Data = slots,
                    Count = slots.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<SlotResponseDTO>>
                {
                    Status = 500,
                    Message =
                        $"Erreur lors de la récupération des créneaux disponibles: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Crée un nouveau créneau
        /// </summary>
        /// <param name="slotDto">Données du créneau à créer</param>
        /// <returns>Créneau créé</returns>
        public async Task<ResponseDTO<SlotResponseDTO>> CreateSlotAsync(SlotCreateDTO slotDto)
        {
            try
            {
                // Validation des dates
                if (slotDto.DateFrom >= slotDto.DateTo)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être antérieure à la date de fin",
                        Data = null,
                    };
                }

                if (slotDto.DateFrom <= DateTimeOffset.UtcNow)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être dans le futur",
                        Data = null,
                    };
                }

                // Vérifier que le type de créneau existe
                var typeExists = await context.TypeSlots.AnyAsync(t =>
                    t.Id == slotDto.TypeId && t.ArchivedAt == null
                );
                if (!typeExists)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Type de créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier qu'il n'y a pas de conflit horaire pour l'enseignant
                var hasConflict = await context.Slots.AnyAsync(s =>
                    s.TeacherId == slotDto.TeacherId
                    && s.ArchivedAt == null
                    && (
                        (slotDto.DateFrom >= s.DateFrom && slotDto.DateFrom < s.DateTo)
                        || (slotDto.DateTo > s.DateFrom && slotDto.DateTo <= s.DateTo)
                        || (slotDto.DateFrom <= s.DateFrom && slotDto.DateTo >= s.DateTo)
                    )
                );

                if (hasConflict)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "Conflit horaire avec un autre créneau de l'enseignant",
                        Data = null,
                    };
                }

                var slot = new Slot
                {
                    Id = Guid.NewGuid(),
                    DateFrom = slotDto.DateFrom,
                    DateTo = slotDto.DateTo,
                    TeacherId = slotDto.TeacherId,
                    TypeId = slotDto.TypeId,
                    CreatedAt = DateTimeOffset.UtcNow,
                };

                context.Slots.Add(slot);
                await context.SaveChangesAsync();

                // Recharger avec les relations
                var createdSlot = await context
                    .Slots.Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .FirstOrDefaultAsync(s => s.Id == slot.Id);

                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 201,
                    Message = "Créneau créé avec succès",
                    Data = new SlotResponseDTO(createdSlot!),
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la création du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Met à jour un créneau existant
        /// </summary>
        /// <param name="id">Identifiant du créneau</param>
        /// <param name="slotDto">Nouvelles données du créneau</param>
        /// <returns>Créneau mis à jour</returns>
        public async Task<ResponseDTO<SlotResponseDTO>> UpdateSlotAsync(
            Guid id,
            SlotUpdateDTO slotDto,
            ClaimsPrincipal User
        )
        {
            var user = CheckUser.GetUserFromClaim(User, context);
            if (slotDto.TeacherId != user?.Id)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 400,
                    Message = "Vous ne pouvez pas modifer un créneau pour un autre enseignant",
                    Data = null,
                };
            }

            try
            {
                var slot = await context.Slots.FirstOrDefaultAsync(s =>
                    s.Id == id && s.ArchivedAt == null
                );

                if (slot == null)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier si le créneau est déjà réservé
                var isBooked = await context.Bookings.AnyAsync(b =>
                    b.SlotId == id && b.ArchivedAt == null
                );

                if (isBooked)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "Impossible de modifier un créneau déjà réservé",
                        Data = null,
                    };
                }

                // Validation des dates
                if (slotDto.DateFrom >= slotDto.DateTo)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être antérieure à la date de fin",
                        Data = null,
                    };
                }

                if (slotDto.DateFrom <= DateTimeOffset.UtcNow)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "La date de début doit être dans le futur",
                        Data = null,
                    };
                }

                // Vérifier que le type de créneau existe
                var typeExists = await context.TypeSlots.AnyAsync(t =>
                    t.Id == slotDto.TypeId && t.ArchivedAt == null
                );
                if (!typeExists)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 404,
                        Message = "Type de créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier qu'il n'y a pas de conflit horaire pour l'enseignant (exclure le créneau actuel)
                var hasConflict = await context.Slots.AnyAsync(s =>
                    s.TeacherId == slotDto.TeacherId
                    && s.Id != id
                    && s.ArchivedAt == null
                    && (slotDto.DateFrom < s.DateTo && slotDto.DateTo > s.DateFrom)
                );

                if (hasConflict)
                {
                    return new ResponseDTO<SlotResponseDTO>
                    {
                        Status = 400,
                        Message = "Conflit horaire avec un autre créneau de l'enseignant",
                        Data = null,
                    };
                }

                slotDto.UpdateSlot(slot);

                await context.SaveChangesAsync();

                // Recharger avec les relations
                var updatedSlot = await context
                    .Slots.Include(s => s.Teacher)
                    .Include(s => s.Type)
                    .FirstOrDefaultAsync(s => s.Id == id);

                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 200,
                    Message = "Créneau mis à jour avec succès",
                    Data = new SlotResponseDTO(updatedSlot!),
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<SlotResponseDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Met à jour une réservation existante
        /// </summary>
        /// <param name="id">Identifiant de la reservation</param>
        /// <param name="updatedBooking">Nouvelles données de la nouvelle reservation</param>
        /// <returns>Créneau mis à jour</returns>
        public async Task<ResponseDTO<BookingDetailsDTO>> UpdateBookingDetailsAsync(
            BookingUpdateDTO updatedBooking,
            ClaimsPrincipal User
        )
        {
            var user = CheckUser.GetUserFromClaim(User, context);
            var existedBooking = await context.Bookings.FirstOrDefaultAsync(b =>
                b.Id == updatedBooking.Id && b.StudentId == user.Id
            );
            if (existedBooking is null)
            {
                return new ResponseDTO<BookingDetailsDTO?>
                {
                    Status = 404,
                    Message = "Créneau non trouvé",
                    Data = null,
                };
            }

            try
            {
                updatedBooking.UpdateModel(existedBooking);
                await context.SaveChangesAsync();

                return new ResponseDTO<BookingDetailsDTO>
                {
                    Status = 200,
                    Message = "La réservation est mise à jour avec succès",
                    Data = new BookingDetailsDTO(existedBooking),
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<BookingDetailsDTO>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Récupère tous les créneaux
        /// </summary>
        /// <returns>Liste des créneaux</returns>
        public async Task<ResponseDTO<List<BookingDetailsDTO>>> GetAllBookings(
            DynamicFilters<Booking> tableState,
            Guid? studentId,
            Guid? TeacherId
        )
        {
            try
            {
                var query =
                    //await
                    context
                        .Bookings.AsNoTracking()
                        .Include(b => b.Student)
                        .Where(s => s.ArchivedAt == null);
                if (studentId is not null)
                {
                    query = query.Where(x => x.StudentId == studentId);
                }

                query = query.Include(b => b.Slot).ThenInclude(s => s.Teacher);

                if (TeacherId is not null)
                {
                    query = query.Where(b => b.Slot.TeacherId == TeacherId);
                }

                // filtre global : search
                if (tableState.Search is not null)
                {
                    var search = tableState.Search;

                    query = query.Where(b =>
                        EF.Functions.ILike(
                            string.Concat(b.Slot.Teacher.FirstName, " ", b.Slot.Teacher.LastName),
                            $"%{search}%"
                        )
                        || EF.Functions.ILike(b.Title, $"%{search}%")
                        || EF.Functions.ILike(b.Description, $"%{search}%")
                    );
                }

                // filtre special : fistname + lastname
                if (
                    tableState.Filters is not null
                    && tableState.Filters.ContainsKey("teacher/lastName")
                )
                {
                    var searchName = tableState
                        .Filters.GetValueOrDefault("teacher/lastName")
                        ?.Value.ToString();
                    query = query.Where(b =>
                        EF.Functions.ILike(
                            string.Concat(b.Slot.Teacher.FirstName, " ", b.Slot.Teacher.LastName),
                            $"%{searchName}%"
                        )
                    );
                }

                var bookings = await query.ApplyAndCountAsync(tableState);

                return new ResponseDTO<List<BookingDetailsDTO>>
                {
                    Status = 200,
                    Message = "Réservations récupérées avec succès",
                    Data = bookings.Values.Select(s => new BookingDetailsDTO(s)).ToList(),
                    Count = bookings.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<BookingDetailsDTO>>
                {
                    Status = 500,
                    Message = $"Erreur lors de la récupération des créneaux: {ex.Message}",
                    Data = null,
                };
            }
        }

        /// <summary>
        /// Met à jour une réservation existante
        /// </summary>
        /// <param name="id">Identifiant de la reservation</param>
        /// <param name="updatedBooking">Nouvelles données de la nouvelle reservation</param>
        /// <returns>Créneau mis à jour</returns>
        public async Task<ResponseDTO<bool>> ConfirmBookingAsync(
            Guid bookingId,
            ClaimsPrincipal User
        )
        {
            var user = CheckUser.GetUserFromClaim(User, context);
            var existedBooking = await context
                .Bookings.Where(b => b.Id == bookingId)
                .Include(b => b.Slot)
                .ThenInclude(s => s.Teacher)
                .FirstOrDefaultAsync(b => b.Slot.Teacher.Id == user.Id);

            if (existedBooking is null)
            {
                return new ResponseDTO<bool>
                {
                    Status = 404,
                    Message = "Créneau non trouvé",
                    Data = false,
                };
            }

            try
            {
                existedBooking.StatusId = HardCode.BOOKING__CONFIRMED;
                await context.SaveChangesAsync();

                return new ResponseDTO<bool>
                {
                    Status = 200,
                    Message = "La réservation est mise à jour avec succès",
                    Data = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<bool>
                {
                    Status = 500,
                    Message = $"Erreur lors de la mise à jour du créneau: {ex.Message}",
                    Data = false,
                };
            }
        }

        /// <summary>
        /// Unbook
        /// </summary>
        public async Task<ResponseDTO<bool>> UnBookingAsync(Guid bookingId, ClaimsPrincipal User)
        {
            var user = CheckUser.GetUserFromClaim(User, context);
            var existedBooking = await context
                .Bookings.Where(b => b.Id == bookingId)
                .Include(b => b.Slot)
                .Where(b => b.Slot.TeacherId == user.Id || b.StudentId == user.Id)
                .FirstOrDefaultAsync();

            if (existedBooking is null)
            {
                return new ResponseDTO<bool>
                {
                    Status = 404,
                    Message = "Réservation non trouvée",
                    Data = false,
                };
            }

            try
            {
                context.Bookings.Remove(existedBooking);

                await context.SaveChangesAsync();

                return new ResponseDTO<bool>
                {
                    Status = 200,
                    Message = "La réservation a été supprimée avec succès",
                    Data = true,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<bool>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression de la réservation: {ex.Message}",
                    Data = false,
                };
            }
        }

        /// <summary>
        /// Archive un créneau (suppression logique)
        /// </summary>
        /// <param name="id">Identifiant du créneau</param>
        /// <returns>Résultat de l'opération</returns>
        public async Task<ResponseDTO<object>> DeleteSlotAsync(
            Guid id,
            ClaimsPrincipal User,
            bool forceDelete = false
        )
        {
            try
            {
                var user = CheckUser.GetUserFromClaim(User, context);
                var slot = await context.Slots.FirstOrDefaultAsync(s =>
                    s.Id == id && s.ArchivedAt == null && s.TeacherId == user.Id
                );

                if (slot == null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Créneau non trouvé",
                        Data = null,
                    };
                }

                // Vérifier si le créneau est réservé
                if (!forceDelete)
                {
                    var isBooked = await context.Bookings.AnyAsync(b =>
                        b.SlotId == id && b.ArchivedAt == null
                    );

                    if (isBooked)
                    {
                        return new ResponseDTO<object>
                        {
                            Status = 400,
                            Message = "Impossible de supprimer un créneau déjà réservé",
                            Data = null,
                        };
                    }
                }

                slot.ArchivedAt = DateTimeOffset.UtcNow;
                slot.UpdatedAt = DateTimeOffset.UtcNow;

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Créneau supprimé avec succès",
                    Data = null,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la suppression du créneau: {ex.Message}",
                    Data = null,
                };
            }
        }

        public async Task<ResponseDTO<object>> BookSlot(
            BookingCreateDTO newBooking,
            ClaimsPrincipal User
        )
        {
            try
            {
                var student = CheckUser.GetUserFromClaim(User, context);

                var slot = await context
                    .Slots.Where(s => s.Id == newBooking.SlotId)
                    .Include(x => x.Booking)
                    .Where(x => x.Booking == null)
                    .FirstOrDefaultAsync();

                if (slot is null)
                {
                    return new ResponseDTO<object>
                    {
                        Status = 404,
                        Message = "Créneau pas trouvé",
                        Data = null,
                    };
                }

                Booking booking = new Booking(newBooking);

                booking.StudentId = student.Id;

                context.Bookings.Add(booking);

                await context.SaveChangesAsync();

                return new ResponseDTO<object>
                {
                    Status = 200,
                    Message = "Créneau reservé avec succès",
                    Data = null,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<object>
                {
                    Status = 500,
                    Message = $"Erreur lors de la réservation: {ex.Message}",
                    Data = null,
                };
            }
        }
    }
}
