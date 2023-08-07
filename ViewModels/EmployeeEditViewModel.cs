using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please enter the date of birth.")]
        //[Display(Name = "Birthday:")]
        //[DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime EditedBirthDate { get; set; }

        //public int Age
        //{
        //    get
        //    {
        //        int currentYear = DateTime.Now.Year;
        //        int yearOfBirth = EditedBirthDate.Year;
        //        int age = currentYear - yearOfBirth;

        //        if (EditedBirthDate > DateTime.Now.AddYears(-age))
        //            age--;
        //        return age;
        //    }
        //}

        public string ExistingPhotoPath { get; set; }
    }
}