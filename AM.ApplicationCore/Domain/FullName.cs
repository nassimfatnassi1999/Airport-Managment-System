using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    //type d'entité détenus = type complexe
    [Owned] //détenus
    public  class FullName
    {
        [MinLength(3, ErrorMessage = "Longeur minimale 3")]
        [MaxLength(30, ErrorMessage = "Longeur maximale 30")]
        public String firstName { get; set; }
        public String lastName { get; set; }
    }
}
