using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Domain.Master;

namespace CLArch.Application.Interfaces
{
    public interface IMasterServices
    {
        Task<List<AppSetting>> GetAppSettingAsync();

        Task<int> AddNewSetting(AppSetting newSetting);

    }
}