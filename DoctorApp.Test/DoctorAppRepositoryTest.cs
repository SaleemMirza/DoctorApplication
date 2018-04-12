using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorApp.DAL;
using DoctorApp.DAL.Interface;
using DoctorApp.DM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using DoctorApp.BL;


namespace DoctorApp.Test
{
    [TestClass]
   public class DoctorAppRepositoryTest
    {
        SpecializedRepository _specializedRepository;
        CountryRepository _countryRepository;
         DoctorRegistrationRepository _doctorRegistration;

        [TestInitialize]

        public void TestSetUp()
        {
            DocAppDbInitializer db=new DocAppDbInitializer();
            System.Data.Entity.Database.SetInitializer(db);
            _specializedRepository = new SpecializedRepository();
            _countryRepository=new CountryRepository();
            _doctorRegistration=new DoctorRegistrationRepository();

        }
        [TestMethod]
        public void AddSpecialized()
        {
            var specialized = new Specialized
            {
                Id = Guid.NewGuid(),
                SpecializedField = "Dentist",
                DataEntry =   DateTime.Now,
                Username = "Saleem"

          


            };

            
            _specializedRepository.Add(specialized);

        }
        [TestMethod]
        public void AddCountry()
        {
            var country = new Country
            {
                Id = Guid.NewGuid(),
               ParentId = new Guid(),
               Area = "Pakistan",
               Code = 92,
               Type = "Country"




            };
            _countryRepository.Add(country);

            var country1 = new Country
            {
                Id = Guid.NewGuid(),
                ParentId = new Guid(),
                Area = "Kuwait",
                Code = 965,
                Type = "Country"




            };


            _countryRepository.Add(country1);

        }
        [TestMethod]
        public void AddState()
        {
            IBusinessLayer businessLayer = new BuinessLayer();
            var countries = businessLayer.GetCountryByGuid("Pakistan");

            var state = new Country
            {
                Id = Guid.NewGuid(),
                ParentId =countries.Id,
                Area = "Karachi",
                Code = 92,
                Type = "State"




            };
            _countryRepository.Add(state);

            var countries1 = businessLayer.GetCountryByGuid("Kuwait");

            var state1 = new Country
            {
                Id = Guid.NewGuid(),
                ParentId = countries1.Id,
                Area = "Hawally",
                Code = 92,
                Type = "State"




            };
            _countryRepository.Add(state1);
        }
        public void AddDoctorRegistration()
        {
            IBusinessLayer businessLayer = new BuinessLayer();
            var countries = businessLayer.GetCountryByGuid("Pakistan");
            var states = businessLayer.GetStateByGuid("Karachi");
            var specialized = businessLayer.GetSpecializedByGuid("Dentist");

            var doctorRegistration = new DoctorRegistration
            {
                Id = Guid.NewGuid(),
                FirstName = "Saleem",
                LastName = "Mirza",
                UserName = "Saleemmirza",
                Password = "123456",
                Address = "F.B Area",
                MobileNumber = 97485962,
                CountryId = countries.Id,
                SpecializedId = specialized.Id,
                EmailAddress = "saleemmirza75@gmail.com",
                Gender =(int) Enumerations.Gender.Male,
                
                
                StateId = states.Id
                


                




            };
            




            
            _doctorRegistration.Add(doctorRegistration);
        }
    }
}
