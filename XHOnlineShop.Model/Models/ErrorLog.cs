using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XHOnlineShop.Model.Models
{
    [Table("ErrorLogs")]
    public class ErrorLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}