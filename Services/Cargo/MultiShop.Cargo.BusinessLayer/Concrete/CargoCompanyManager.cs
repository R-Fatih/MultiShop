using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager:ICargoCompanyService
    {
        private readonly ICargoCompanyDal _CargoCompanyDal;
        public CargoCompanyManager(ICargoCompanyDal CargoCompanyDal)
        {
            _CargoCompanyDal = CargoCompanyDal;
        }

        public async Task TDeleteAsync(CargoCompany entity)
        {
            await _CargoCompanyDal.DeleteAsync(entity);
        }

        public async Task<List<CargoCompany>> TGetAllAsync()
        {
            return await _CargoCompanyDal.GetAllAsync();
        }

        public async Task<CargoCompany> TGetByIdAsync(int id)
        {
            return await _CargoCompanyDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(CargoCompany entity)
        {
            await _CargoCompanyDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(CargoCompany entity)
        {
            await _CargoCompanyDal.UpdateAsync(entity);
        }
    }
}
