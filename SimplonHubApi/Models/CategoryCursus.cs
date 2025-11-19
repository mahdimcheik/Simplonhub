using SimplonHubApi.Models.Generics;
using System.Collections.ObjectModel;

namespace SimplonHubApi.Models
{
    public class CategoryCursus : BaseModelOption
    {
        public Collection<Cursus> Cursuses { get; set; }
    }
}
