using MainBoilerPlate.Models;
using MainBoilerPlate.Models.Generics;

namespace SimplonHubApi.Models
{
    public class Favorite : BaseModel
    {
        public string Note { get; set; }
        public UserApp Student { get; set; }
        public Guid StudentId { get; set; }
        public UserApp Teacher { get; set; }
        public Guid TeacherId { get; set; }
    }
}
