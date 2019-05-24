using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DIPLOMA.Models
{
    public enum Cities
    {
        None, Barnaul, Novosibirsk, Biysk
    }

    public enum QualificationLevels
    {
        None, Basic, Advanced
    }

    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public QualificationLevels Qualifications { get; set; }
    }
}
