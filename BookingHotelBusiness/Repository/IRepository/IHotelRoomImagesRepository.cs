using BookingHotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelBusiness.Repository.IRepository
{
    public interface IHotelRoomImagesRepository
    {
        Task<int>CreateHotelRoomImage(HotelRoomImageDTO hotelRoomImageDTO);
        Task<int> DeleteHotelRoomImageByImageId(int imageId);
        Task<int> DeleteHotelRoomImageByRoomId(int roomId);
        Task<int>DeleteHotelImageByImageUrl(string imageUrl);
        Task<IEnumerable<HotelRoomImageDTO>> GetAllHotelRoomImages(int roomId);

    }
}
