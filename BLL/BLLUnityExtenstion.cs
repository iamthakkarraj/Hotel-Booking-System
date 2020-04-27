using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Database;

namespace BLL {

    public class BLLUnityExtenstion : UnityContainerExtension {

        protected override void Initialize() {

            Container.Resolve<WebApiAssignmentEntities>();
            Container.RegisterType<IHotelRepository, HotelRepository>();
            Container.RegisterType<IRoomRepository, RoomRepository>();
            Container.RegisterType<IBookingRepository, BookingRepository>();

        }

    }

}