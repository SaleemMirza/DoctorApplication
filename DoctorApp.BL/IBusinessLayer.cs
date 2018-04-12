using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorApp.DAL.Interface;
using DoctorApp.DM;

namespace DoctorApp.BL
{
    public interface IBusinessLayer
    {
        #region Specialized
        // IList<Specialized> GetCategory();
        void AddSpecialized(params Specialized[] specialized);

        void UpdateSpecialized(params Specialized[] specialized);
        void RemoveSpecialized(params Specialized[] specialized);
        Specialized GetSpecializedByGuid(string specialized);
        #endregion
        #region Country
        Country GetCountryByGuid(string countryName);
        Country GetStateByGuid(string stateName);
        void AddState(params Country[] countries);

        void UpdateState(params Country[] countries);
        void RemoveState(params Country[] countries);
        IList<Country> GetCountry();
        #endregion
        #region DoctorRegistration
        DoctorRegistration GetDoctorByGuid(string doctorName);
        //DoctorRegistration GetDoctorByGender(int gender);
        void AddDoctorRegistration(params DoctorRegistration[] doctorRegistrations);

        void UpdateDoctorRegistration(params DoctorRegistration[] doctorRegistrations);
        void RemoveDoctorRegistration(params DoctorRegistration[] doctorRegistrations);
        //IList<DoctorRegistration> GetDoctor();
        #endregion

    }


    public class BuinessLayer : IBusinessLayer
        {

            private readonly ISpecializedRepository _specializedRepository;
            private readonly ICountryRepository _countryRepository;
        private readonly IDoctorRegistrationRepository _doctorRegistrationRepository;

        public BuinessLayer()
            {
                _specializedRepository = new SpecializedRepository();
                _countryRepository=new CountryRepository();
            _doctorRegistrationRepository= new DoctorRegistrationRepository();
            }


        #region Specialized Method
        public void AddSpecialized(params Specialized[] Specialized)
            {






                foreach (var specialized in Specialized)
                {
                    specialized.Id = Guid.NewGuid();
                }
                ;
                _specializedRepository.Add(Specialized);
            }

        public void RemoveSpecialized(params Specialized[] Specialized)
        {

            
                _specializedRepository.Remove(Specialized);
           
        }
        public void UpdateSpecialized(params Specialized[] Specialized)
        {

            
                _specializedRepository.Update(Specialized);
            
           


        }

        public Specialized GetSpecializedByGuid(string specialized)
        {
            return _specializedRepository.GetSingle(d => d.SpecializedField.Equals(specialized));
        }

        #endregion
        #region Country Method
        public void AddState(params Country[] country)
        {






            foreach (var countries in country)
            {
                countries.Id = Guid.NewGuid();
            }
                ;
            _countryRepository.Add(country);
        }

        public void RemoveState(params Country[] country)
        {


            _countryRepository.Remove(country);

        }
        public void UpdateState(params Country[] country)
        {


            _countryRepository.Update(country);




        }

        public IList<Country> GetCountry()
        {

            return _countryRepository.Get();

        }

        public Country GetCountryByGuid(string countryName)
        {
            return _countryRepository.GetSingle(d => d.Area.Equals(countryName));
        }

        public Country GetStateByGuid(string stateName)
        {
            return _countryRepository.GetSingle(d => d.Area.Equals(stateName));
        }
        #endregion
        #region Doctor Registration Method
        public void AddDoctorRegistration(params DoctorRegistration[] doctorRegistrations)
        {






            foreach (var doctors in doctorRegistrations)
            {
                doctors.Id = Guid.NewGuid();
            }
                ;
            _doctorRegistrationRepository.Add(doctorRegistrations);
        }

        public void RemoveDoctorRegistration(params DoctorRegistration[] doctorRegistrations)
        {


            _doctorRegistrationRepository.Remove(doctorRegistrations);

        }
        public void UpdateDoctorRegistration(params DoctorRegistration[] doctorRegistrations)
        {


            _doctorRegistrationRepository.Update(doctorRegistrations);




        }

        public IList<DoctorRegistration> GetDoctorRegistration()
        {

            return _doctorRegistrationRepository.Get();

        }

        public DoctorRegistration GetDoctorByGuid(string doctorName)
        {
            return _doctorRegistrationRepository.GetSingle(d => d.FirstName.Equals(doctorName));
        }


        #endregion
    }
}




