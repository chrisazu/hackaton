using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HealthyApp.Domain.Models;

namespace HealthyApp.Application.Models.Requests
{
    public class UserRequest
    {
        public string AspNetUserId { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

    }
}
