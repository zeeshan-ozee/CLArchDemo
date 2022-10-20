using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;
using CLArch.Domain.Master;

namespace CLArch.Application.Services
{
    public class MasterServices : IMasterServices
    {
        readonly IUnitOfWork _uow;
        public MasterServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public Task<int> AddNewSetting(AppSetting newSetting)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppSetting>> GetAppSettingAsync()
        {
            var appsettings = _uow.AppSettingRepo.TableNoTracking.OrderBy(x => x.Description).ToList();

            return Task.FromResult(appsettings);
        }
    }
}