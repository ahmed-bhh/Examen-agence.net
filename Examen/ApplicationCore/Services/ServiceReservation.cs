using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReservation : Service<Reservation>, IServiceReservation
    {
        public ServiceReservation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<IGrouping<Client, Reservation>> GroupedReservations()
        {
            return GetMany(r => (r.DateReservation - DateTime.Now).TotalDays < 7
            && (r.DateReservation - DateTime.Now).TotalDays > 0).GroupBy(r => r.Client);
        }
    }
}
