using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityDataLayer.Models
{
    public class ActivityImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string MimeType { get; set; }
        public byte[] Content { get; set; }
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
