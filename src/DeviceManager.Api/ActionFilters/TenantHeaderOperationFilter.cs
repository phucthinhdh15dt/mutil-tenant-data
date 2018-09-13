using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DeviceManager.Api.ActionFilters
{
    public class TenantHeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }
            operation.Parameters.Add(new NonBodyParameter
            {

                Name = "tenantid",
                In = "header",
                Description = "tenantid",
                Required = true,
                Type = "string",
            });

        }
    }
}
