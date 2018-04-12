using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorApp.DM;

namespace DoctorApp.DAL.Interface
{
#region Specialized
    public interface ISpecializedRepository:IGenericDataRepository<Specialized>
    {
    }
    public class SpecializedRepository : GenericDataRepository<Specialized>, ISpecializedRepository
    {
    }
    #endregion

    #region Country
    public interface ICountryRepository : IGenericDataRepository<Country>
    {
    }
    public class CountryRepository : GenericDataRepository<Country>, ICountryRepository
    {
    }
    #endregion
    #region DoctorRegistration
    public interface IDoctorRegistrationRepository : IGenericDataRepository<DoctorRegistration>
    {
    }
    public class DoctorRegistrationRepository : GenericDataRepository<DoctorRegistration>, IDoctorRegistrationRepository
    {
    }
    #endregion
}
