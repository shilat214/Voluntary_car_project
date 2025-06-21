using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converter
{
    public class RequestsConverter
    {
        public static RequestsDTO ToRequestsDTO(Requests requests)
        {
            return new RequestsDTO()
            {
                IdRequest = requests.IdRequest,
                IdRequester = requests.IdRequester,
                IdService = requests.IdService,
                RequestDate = requests.RequestDate,
                RequestedHours = requests.RequestedHours,
                RequestStatus = requests.RequestStatus,
                RequestText = requests.RequestText
            };
        }
        public static List<RequestsDTO> ToRequestsDTO(List<Requests> requests)
        {
            return requests.Select(x => ToRequestsDTO(x)).ToList();
        }

        public static Requests ToRequests(RequestsDTO requestsDTO)
        {
            return new Requests()
            {
              IdRequest = requestsDTO.IdRequest,
              IdRequester =requestsDTO.IdRequester,
              IdService =requestsDTO.IdService,
              RequestDate= requestsDTO.RequestDate,
              RequestedHours=requestsDTO.RequestedHours,
              RequestStatus=requestsDTO.RequestStatus,
              RequestText=requestsDTO.RequestText
            };
        }
        public static List<Requests> ToRequests(List<RequestsDTO> RequestsDTOs)
        {
            return RequestsDTOs.Select(x => ToRequests(x)).ToList();
        }
    }
}
