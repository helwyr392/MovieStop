using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieStop.Dtos;
using MovieStop.Models;

namespace MovieStop.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public int MembershipTypeID { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [Required]
        //[Min18YearsIfMember]
        public DateTime Birthdate { get; set; }
    }
}