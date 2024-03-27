using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>> TGetAllAsync();
        public Task<T> TGetByIdAsync(int id);
        public Task TInsertAsync(T entity);
        public Task TUpdateAsync(T entity);
        public Task TDeleteAsync(T entity);

    }
}
