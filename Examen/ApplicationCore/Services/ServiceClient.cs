using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{

    public class ServiceClient : Service<Client>, IServiceClient
    {

        public ServiceClient(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public int NombreReservation(Client client)
        {
            return client.Reservations
                .Where(r=>r.DateReservation.Year==DateTime.Now.Year).Count();
        }

        public IEnumerable<Client> SortClients()
        {
            return GetMany().OrderBy(c=>c.Identifiant);
        }

        public double TotalPayements(Client client)
        {
            return client.Reservations
                .Select(r => r.Pack)
                .SelectMany(a => a.Activites).Sum(a => a.Prix);
        }
    }
}
