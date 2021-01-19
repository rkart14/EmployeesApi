using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EmployeesApi.Entities
{
    public class Employee : Entity, IHasCreationTime, IEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PersonalNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public DateTime CreationTime { get; set; }

        public int NationalityId { get; set; }

        public Nationality Nationality { get; set; }

        public int? SalaryId { get; set; }

        public Salary Salary { get; set; }

        public List<PhoneNumber> PhoneNumbers { get;  set; }

        public void AddPhoneNumber(PhoneNumber number)
        {
            PhoneNumbers.Add(number);
        }

        public void EditPhoneNumber(PhoneNumber newPhoneNumber)
        {
            var existingNumber = PhoneNumbers.FirstOrDefault(x => x.Id == newPhoneNumber.Id);
            existingNumber.Number = newPhoneNumber.Number;
            existingNumber.CountryCodeId = newPhoneNumber.CountryCodeId;
        }
        public void UpdateSalary(Salary salary)
        {
            Salary = salary;
        }

        public void UpdateBasicInfo(string firstname, string lastname, string personalNumber, DateTime birthDate)
        {
            FirstName = firstname;
            LastName = lastname;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
        }

        public Employee()
        {
            CreationTime = Clock.Now;
        }
        public Employee(string firstName, string lastName, string personalNumber, DateTime birthDate, int nationalityId, List<PhoneNumber> phoneNumbers = null)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            PhoneNumbers = phoneNumbers;
            NationalityId = nationalityId;
            
        }
    }
}
