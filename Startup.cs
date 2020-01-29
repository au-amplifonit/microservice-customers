using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fox.Microservices.CommonUtils;
using Fox.Microservices.CommonUtils.Models.Entities;
using Fox.Microservices.Customers.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WebAPITools;
using WebAPITools.ErrorHandling;
using WebAPITools.Models.Configuration;

namespace Fox.Microservices.Customers
{
	public class Startup : BaseStartup
	{
		public Startup(IConfiguration configuration, ILogger<Startup> logger, ILoggerFactory loggerFactory) : base(configuration, logger, loggerFactory)
		{
		}

		public override void ConfigureServices(IServiceCollection services)
		{
			base.ConfigureServices(services);

			string ConnectionString = Configuration.GetConnectionString("ConnectionString");
			DbConnectionStringBuilder ConnBuilder = new DbConnectionStringBuilder();
			ConnBuilder.ConnectionString = ConnectionString;
			_logger.LogInformation("Using database: {0}\\{1}", ConnBuilder["Data Source"], ConnBuilder["Initial Catalog"]);

			services.AddDbContext<CustomersContext>(options =>
					options.UseLazyLoadingProxies()
					.EnableDetailedErrors()
					.UseSqlServer(ConnectionString));

			//Ensure common utils capabilities			
			services.AddDbContext<CommonUtilsContext>(options =>
					options.UseLazyLoadingProxies()
					.EnableDetailedErrors()
					.UseSqlServer(ConnectionString));

			services.AddScoped(typeof(IFoxDataService), typeof(FoxDataService));
			services.AddSwaggerGen(c =>
					{
						c.SwaggerDoc("v1", new Info { Title = "FOX Microservices - Customers API", Version = "v1" });
						var filePath = Path.Combine(System.AppContext.BaseDirectory, "Fox.Microservices.Customers.xml");
						c.IncludeXmlComments(filePath);
					});
		}
	}
}
