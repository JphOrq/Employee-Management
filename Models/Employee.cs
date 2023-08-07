using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using PagedList;
using PagedList.Mvc;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid first name here!")]
        [Display(Name = "First Name:")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please input your complete first name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a valid middle name here!")]
        [Display(Name = "Middle Name:")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please input your complete middle name!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter a valid last name here!")]
        [Display(Name = "Last Name:")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please input your complete last name!")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the date of birth.")]
        [Display(Name = "Birthday:")]
        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                int currentYear = DateTime.Now.Year;
                int yearOfBirth = BirthDate.Year;
                int age = currentYear - yearOfBirth;
                
                if (BirthDate > DateTime.Now.AddYears(-age))
                    age--;
                return age;
            }
        }

        [Required(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Department:")]
        public Dept Department { get; set; }

        [Required]
        [Display(Name = "Salary:")]
        public int Salary { get; set; }

        public string PhotoPath { get; set; }
    }
}