using OnionArchitectureImplementation.Api.Controllers;
using OnionArchitectureImplementation.Domain.Entities;
using OnionArchitectureImplementation.Infrastructure;
using OnionArchitectureImplementation.Infrastructure.Repository;
using OnionArchitectureImplementation.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace OnionArchitectureImplementation.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
             
            container.RegisterType<IPaymentDetailService, PaymentDetailService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IRepository<PaymentDetail>, Repository<PaymentDetail>>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}