using DataAccessLayer.Dtos.AdminDtos;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IServiceManager
    {
        List<ServiceListDto> GetServiceListManager();
        List<Service> GetList();
        void Add(Service service);
        void Update(Service service);
        void Remove(Service service);
        Service GetByID(int id);
    }
}
