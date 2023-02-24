using BookingHotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelBusiness.Repository.IRepository
{
    public interface IHotelRoomRepository
    {
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO);
        Task<HotelRoomDTO> UpdateHotelRoom(int roomId,HotelRoomDTO hotelRoomDTO);
        Task<HotelRoomDTO> GetHotelRoom(int roomId);
        Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms();
        Task<HotelRoomDTO>IsRoomUnique(string name);
        Task<int>DeleteHotelRoom(int roomId);
    }
}
