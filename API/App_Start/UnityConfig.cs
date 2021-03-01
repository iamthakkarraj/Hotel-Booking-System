using BLL;
using BLL.Interfaces;
using BLL.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API{

    public static class UnityConfig{

        public static void RegisterComponents(){			

            GlobalConfiguration.Configuration.DependencyResolver
                = new UnityDependencyResolver(
                    new UnityContainer()
                    .RegisterType<IHotelService, HotelService>()
                    .RegisterType<IRoomService, RoomService>()
                    .RegisterType<IBookingService, BookingService>()
                    .AddNewExtension<BLLUnityExtenstion>()
                );

        }
    }
}