using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class CustomerRequestModel
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Column(TypeName = "varchar(10)")]
        public string Phone { get; set; }
    }
}
