using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseDataManagement.Models
{
    public class ExternalModeration
    {
        [Key]
        [Display(Name = "CourseID")]
        [Required(ErrorMessage = "CourseID must be entered")]
        public string CourseID { get; set; }
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course name name must be entered")]
        public string CourseName { get; set; }

        [Display(Name = "Name of external moderator")]
        [Required(ErrorMessage = "Name of external moderator must be entered")]
        public string NameOfExternalModerator { get; set; }

        [Display(Name = "Date passed to external moderator")]
        [Required(ErrorMessage = "Date passed to external moderator must be entered")]
        public DateTime DatePassedToExternalModerator { get; set; }

        [Display(Name = "Date of external moderator report")]
        [Required(ErrorMessage = "Date of external moderator report must be entered")]
        public DateTime DateOfExternalmoderatorReport { get; set; }

        [Display(Name = "Date of response to report")]
        [Required(ErrorMessage = "Date of response to report must be entered")]
        public DateTime DateOfResponseToReport { get; set; }

        [Display(Name = "Next due date for external moderation")]
        [Required(ErrorMessage = "Next due date for external moderation must be entered")]
        public DateTime NextDueDateForExternalModeration { get; set; }

        [Display(Name = "Send email notification to")]
        [Required(ErrorMessage = "The emailID must be entered")]
        public string SendEmailNotificationTo { get; set; }

    }
}
