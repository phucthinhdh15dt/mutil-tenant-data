using System;
using System.Collections.Generic;
using DeviceManager.Api.Data.Model;

namespace DeviceManager.Api.Services
{
    
    public interface IDeviceService
    {
        List<Device> GetDevices(int page, int pageSize);
        bool AddDevices(Device device);
    }
}