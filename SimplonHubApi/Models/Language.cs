using SimplonHubApi.Models.Generics;

namespace SimplonHubApi.Models
{
    public class Language : BaseModelOption
    {
        public ICollection<UserApp>? Users { get; set; }
    }
}
