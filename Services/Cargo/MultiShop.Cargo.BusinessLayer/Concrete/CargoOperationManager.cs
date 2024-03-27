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
    public class CargoOperationManager:ICargoOperationService
    {
        private readonly ICargoOperationDal _CargoOperationDal;
        public CargoOperationManager(ICargoOperationDal CargoOperationDal)
        {
            _CargoOperationDal = CargoOperationDal;
        }

        public async Task TDeleteAsync(CargoOperation entity)
        {
            await _CargoOperationDal.DeleteAsync(entity);
        }

        public async Task<List<CargoOperation>> TGetAllAsync()
        {
            return await _CargoOperationDal.GetAllAsync();
        }

        public async Task<CargoOperation> TGetByIdAsync(int id)
        {
            return await _CargoOperationDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(CargoOperation entity)
        {
            await _CargoOperationDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(CargoOperation entity)
        {
            await _CargoOperationDal.UpdateAsync(entity);
        }
    }
}
