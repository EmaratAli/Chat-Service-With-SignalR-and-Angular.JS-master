using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatService.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ConnectionTime { get; set; }
        public string ConnectionId { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}