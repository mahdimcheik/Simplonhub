using SimplonHubApi.Models.Generics;
using Microsoft.AspNetCore.Identity;

namespace SimplonHubApi.Models
{
    public class RoleApp : IdentityRole<Guid>, IArchivable, ICreatable, IUpdateable
    {
        public DateTimeOffset? ArchivedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string?  Color { get; set; }
        public string DisplayName { get; set; }
        public ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }

    }
}
