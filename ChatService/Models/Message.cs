using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatService.Models
{
    public class Message
    {
            public int Id { get; set; }
            public string Text { get; set; }
            public string ConnectionTime { get; set; }
            [ForeignKey("User")]
            public int ConnectionId { get; set; }
            public virtual User User { get; set; }

    }
}