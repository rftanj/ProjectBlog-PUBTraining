using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        [Required(ErrorMessage = "Title Must be Fill")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content Must be Fill")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Picture Must be Fill")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Created Date Must be Fill")]
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Status Must be Fill")]
        public bool Status { get; set; }
    }
}
