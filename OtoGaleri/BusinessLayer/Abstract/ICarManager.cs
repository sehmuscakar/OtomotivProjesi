using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICarManager
    {
        List<CarListDto> GetCarListManager();
        List<Car> GetList();
        void Add(Car car);
        void Update(Car car);
        void Remove(Car car);
        Car GetByID(int id);
    }
}
