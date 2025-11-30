using SimplonHubApi.Contexts;
using SimplonHubApi.Models;
using SimplonHubApi.Utilities;
using System.Security.Claims;

namespace SimplonHubApi.Services
{
    public class DocumentService(MinioService minioService, MainContext context)
    {
        public async Task AddFile(IFormFile file, DocumentInfo info, ClaimsPrincipal User)
        {
            try
            {

            if(file.FileName is  null  || file.Length == 0)
            {
                throw new Exception("Le fichier n'existe pas");
            }

            var user = CheckUser.GetUserFromClaim(User, context);
            if (user is null)
            {
                throw new Exception("Utilisateur non trouvé");
            }
            var extension = Path.GetExtension(file.Name);
            var name = $"{DateTime.Now.Ticks.ToString()}{extension}";
            var document = new Document(info, file, name, user);
            context.Documents.Add(document);
            await context.SaveChangesAsync();
            await minioService.UploadPDFAsync($"pdfs/{user.Id.ToString()}", name, file);
            }catch(Exception ex)
            {

            }
        }
    }
}
