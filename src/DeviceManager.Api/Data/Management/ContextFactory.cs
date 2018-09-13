using System;
using System.Data.SqlClient;
using DeviceManager.Api.Configuration.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DeviceManager.Api.Data.Management
{
    public class ContextFactory : IContextFactory
    {
        private const string TenantIdFieldName = "tenantid";
        private readonly HttpContext httpContext;
        private readonly IDataBaseManager dataBaseManager;
        public ContextFactory(
            IHttpContextAccessor httpContentAccessor,
            IDataBaseManager dataBaseManager)
        {
            this.httpContext = httpContentAccessor.HttpContext;
            this.dataBaseManager = dataBaseManager;
        }
        public IDbContext DbContext => new DeviceContext(ChangeDatabaseNameInConnectionString(this.TenantId).Options);
        private string TenantId
        {
            get
            {
                string tenantId = this.httpContext.Request.Headers[TenantIdFieldName].ToString();
                return tenantId;
            }
        }
        private DbContextOptionsBuilder<DeviceContext> ChangeDatabaseNameInConnectionString(string tenantId)
        {
            String a = "Server=PHUCTHINH\\SQL;Database={changeDatabase};User Id=sa;Password=1;";
            string conect = a.Replace("{changeDatabase}", this.dataBaseManager.GetDataBaseName(tenantId));
            var contextOptionsBuilder = new DbContextOptionsBuilder<DeviceContext>();
            contextOptionsBuilder.UseSqlServer(conect);
            return contextOptionsBuilder;
        }
    }
}
