using SimplonHubApi.Models.Generics;

namespace SimplonHubApi.Models
{
    public class ProgrammingLanguage : BaseModelOption
    {
        public string? Description { get; set; }
        public ICollection<UserApp>? Users { get; set; }
    }
}
