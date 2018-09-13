using System;
using System.Collections.Generic;

namespace DeviceManager.Api.Data.Management
{
    public class DataBaseManager : IDataBaseManager
    {
        private readonly Dictionary<Guid, string> tenantConfigurationDictionary = new Dictionary<Guid, string>
        {
            {
                Guid.Parse("b0ed668d-7ef2-4a23-a333-94ad278f45d7"), "DB1"
            },
            {
                Guid.Parse("e7e73238-662f-4da2-b3a5-89f4abb87969"), "DB2"
            }
        };

     
        public string GetDataBaseName(string tenantId)
        {
            var dataBaseName = this.tenantConfigurationDictionary[Guid.Parse(tenantId)];
            if (dataBaseName == null)
            {
                throw new ArgumentNullException(nameof(dataBaseName));
            }

            return dataBaseName;
        }
    }
}