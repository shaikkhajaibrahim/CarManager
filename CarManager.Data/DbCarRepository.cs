using CarManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManager.Data
{
    public class DbCarRepository : ICarRepository
    {
        public void Add(Car car)
        {
            using (CarContext context = new CarContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (CarContext context = new CarContext())
            {
                var cars = context.Cars.Where(item => item.Id == id);
                int count = cars.Count();
                context.Cars.RemoveRange(cars);
                context.SaveChanges();
            }
        }

        public Car Get(int id)
        {
            Car car = null;
            using (CarContext context = new CarContext())
            {
                car= context.Cars.FirstOrDefault(item => item.Id == id);
                
            }
            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            IEnumerable<Car> cars = null;
            using (CarContext context = new CarContext())
            {
                cars= context.Cars.ToList();

            }
            return cars;
        }

        public void Update(Car car)
        {
            using (CarContext context = new CarContext())
            {
                var cars = context.Cars.Where(item => item.Id == car.Id);
                int count = cars.Count();
                context.Cars.RemoveRange(cars);
                context.SaveChanges();
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }
    }
}
