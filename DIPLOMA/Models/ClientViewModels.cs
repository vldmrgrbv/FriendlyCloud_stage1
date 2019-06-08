using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DIPLOMA.Models
{
    public class CreateModelClient
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string PassportSerial { get; set; }
        [Required]
        public string PassportNumber { get; set; }
        [Required]
        public string AddressRegistration { get; set; }
        [Required]
        public string AddressResidential { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DataAboutWorkPlace { get; set; }
    }
}