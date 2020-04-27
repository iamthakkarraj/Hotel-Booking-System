using BLL;
using BLL.Interfaces;
using BLL.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API{

    public static class UnityConfig{

        public static void RegisterComponents(){

			var container = new UnityContainer();                                                           

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            container.RegisterType<IHotelService, HotelService>();
            container.RegisterType<IRoomService, RoomService>();
            container.RegisterType<IBookingService, BookingService>();
            container.AddNewExtension<BLLUnityExtenstion>();

        }

    }

}