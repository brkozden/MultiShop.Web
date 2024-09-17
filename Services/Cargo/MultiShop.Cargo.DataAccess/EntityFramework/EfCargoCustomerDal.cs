using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete;
using MultiShop.Cargo.DataAccess.Repositories;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }

        public CargoCustomer GetCargoCustomerById(string id)
        {
           var values = _cargoContext.CargoCustomers.Where(x=>x.UserCustomerId == id).FirstOrDefault();
            return values;

        }
    }
}
