using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITasks.Models
{
    public class UserEvents
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Event Id is required...")]
        public string EventId { get; set; }

        [Required(ErrorMessage = "Event Description is required...")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Event Venue is required...")]
        public string EventVenue { get; set; }
    }
}
