using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL.Converter
{
    public class CarHelpRequestersConverter
    {
        public static CarHelpRequestersDTO ToCarHelpRequestersDTO(CarHelpRequesters CarHelpRequesters)
        {
            return new CarHelpRequestersDTO()
            {
                Address = CarHelpRequesters.Address,
                IdRequester = CarHelpRequesters.IdRequester,
                Name = CarHelpRequesters.Name,
                Phone = CarHelpRequesters.Phone,
            };
        }
        public static List<CarHelpRequestersDTO> ToCarHelpRequestersDTO(List<CarHelpRequesters> CarHelpRequesters)
        {
            return CarHelpRequesters.Select(x => ToCarHelpRequestersDTO(x)).ToList();
        }
        public static CarHelpRequesters ToCarHelpRequesters(CarHelpRequestersDTO carHelpRequestersDTO)
        {
            return new CarHelpRequesters()
            {
                Address = carHelpRequestersDTO.Address,
                IdRequester = carHelpRequestersDTO.IdRequester,
                Name = carHelpRequestersDTO.Name,
                Phone = carHelpRequestersDTO.Phone,

            };
        }
        public static List<CarHelpRequesters> ToCarHelpRequesters(List<CarHelpRequestersDTO> carHelpRequestersDTOs)
        {
            return carHelpRequestersDTOs.Select(x => ToCarHelpRequesters(x)).ToList();
        }
    }
}
