﻿using System.ComponentModel.DataAnnotations;

namespace XBCAD_WebApp.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string ReplyFrom { get; set; }
        [Required]
        public string ReplyMessage { get; set; }
        public DateTime ReplyDateTime { get; set; }
    }
}
