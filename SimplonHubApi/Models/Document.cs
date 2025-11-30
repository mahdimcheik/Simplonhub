using SimplonHubApi.Models.Generics;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SimplonHubApi.Models
{
    public class Document : BaseModel
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Note { get; set; }
        public decimal Size { get; set; }
        public string Type { get; set; }
        public Guid OwnerId { get; set; }
        public UserApp? Owner { get; set; }
        public Guid? AdminId { get; set; }
        public UserApp? Admin { get; set; }
        public Document()
        {
            
        }
        [SetsRequiredMembers]
        public Document(DocumentInfo info, IFormFile file, string name, UserApp user)
        {
            Name = name;
            OriginalName = file.Name;
            Note = info.Note;
            Size = file.Length;         
            Type = file.GetType().Name;
            OwnerId = user.Id;
        }

    }

    public class DocumentInfo
    {
        [Required]
        public string Note { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
