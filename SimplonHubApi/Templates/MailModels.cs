using SimplonHubApi.Models;
using SimplonHubApi.Models;

namespace SimplonHubApi.Templates
{
    public class ResetPasswordModel
    {
        public UserApp Receiver { get; set; }
        public string ValidationLink { get; set; }
        public string WebsiteLink { get; set; } 

        public ResetPasswordModel(UserApp receiver, string resetLink, string websiteLink)
        {
            Receiver = receiver;
            ValidationLink = resetLink;
            WebsiteLink = websiteLink;
        }
    }

    public class ConfirmMailModel
    {
        public UserApp Receiver { get; set; }
        public string ConfirmLink { get; set; }
        public string WebsiteLink { get; set; }

        public ConfirmMailModel(UserApp receiver, string confirmLink, string websiteLink)
        {
            Receiver = receiver;
            ConfirmLink = confirmLink;
            WebsiteLink = websiteLink;
        }
    }

    public class ReminderModel
    {
        public UserApp Teacher { get; set; }
        public UserApp Student { get; set; }
        public Slot Slot { get; set; }
        public string WebsiteLink { get; set; }
        public bool forTeacher { get; set; } = true;

        public ReminderModel(UserApp teacher, UserApp student, Slot slot, string websiteLink)
        {
            Teacher = teacher;
            Student = student;
            Slot = slot;
            WebsiteLink = websiteLink;
        }
    }
}
