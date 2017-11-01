using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vols.Models
{
    public class loginModel
    {

        [Required()]
        public string userName { get; }
        [Required()]
        public string password { get; }

    }
}