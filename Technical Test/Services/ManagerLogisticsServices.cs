using Technical_Test.Contracts;
using Technical_Test.DTOs.Company;
using Technical_Test.Models;

namespace Technical_Test.Services
{
    public class ManagerLogisticsServices
    {
        private readonly IManagerLogistics _managerLogistics;

        public ManagerLogisticsServices(IManagerLogistics managerLogistics)
        {
            _managerLogistics = managerLogistics;

        }

        public IEnumerable<GetManagerLogisticsDTO>? GetAllManager()
        {
            var manager = _managerLogistics.GetAll();
            if (!manager.Any())
            {
                return null; // manager not found
            }

            var toDto = manager.Select(manager =>
                                                new GetManagerLogisticsDTO
                                                {
                                                    ManagerID = manager.ManagerID,
                                                    ManagerName = manager.ManagerName,
                                                    ManagerEmail = manager.ManagerEmail,
                                                    ManagerPhone = manager.ManagerPhone,

                                                }).ToList();

            return toDto; // manager found
        }

        public GetManagerLogisticsDTO? GetManagerId(int id)
        {
            var manager = _managerLogistics.GetById(id);
            if (manager is null)
            {
                return null; // manager not found
            }

            var toDto = new GetManagerLogisticsDTO
            {
                ManagerID = manager.ManagerID,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
            };

            return toDto; // account roles found
        }

        public GetManagerLogisticsDTO? CreateNewManager(NewManagerLogisticsDTO newManagerLogisticsDTO)
        {
            var manager = new ManagerLogistics
            {
                ManagerName = newManagerLogisticsDTO.ManagerName,
                ManagerEmail = newManagerLogisticsDTO.ManagerEmail,
                ManagerPhone = newManagerLogisticsDTO.ManagerPhone,
            };

            var createdManager = _managerLogistics.Create(manager);
            if (createdManager is null)
            {
                return null; // manager not created
            }

            var toDto = new GetManagerLogisticsDTO
            {
                ManagerID = manager.ManagerID,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
            };

            return toDto; // manager created
        }

        public int UpdateManager(UpdateManagerLogisticsDTO updateManagerLogisticsDTO)
        {
            var isExist = _managerLogistics.IsExist(updateManagerLogisticsDTO.ManagerID);
            if (!isExist)
            {
                return -1; // Manager Not Found
            }

            var getManager = _managerLogistics.GetById(updateManagerLogisticsDTO.ManagerID);

            var manager = new ManagerLogistics
            {
                ManagerName = updateManagerLogisticsDTO.ManagerName,
                ManagerEmail = updateManagerLogisticsDTO.ManagerEmail,
                ManagerPhone = updateManagerLogisticsDTO.ManagerPhone,
            };

            var isUpdate = _managerLogistics.Update(manager);
            if (!isUpdate)
            {
                return 0; // manager not updated
            }

            return 1;
        }

        public int DeleteManager(int id)
        {
            var isExist = _managerLogistics.IsExist(id);
            if (!isExist)
            {
                return -1; // manager not found
            }

            var manager = _managerLogistics.GetById(id);
            var isDelete = _managerLogistics.Delete(manager);
            if (!isDelete)
            {
                return 0; // manager not deleted
            }

            return 1;
        }
    }
}
