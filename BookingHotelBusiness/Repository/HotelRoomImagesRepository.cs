using AutoMapper;
using BookingHotelBusiness.Repository.IRepository;
using BookingHotelDataAccess.Data;
using BookingHotelModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelBusiness.Repository;

public class HotelRoomImagesRepository : IHotelRoomImagesRepository
{
    private readonly ApplicationDbContext _db;

    private readonly IMapper _mapper;
    public HotelRoomImagesRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<int> CreateHotelRoomImage(HotelRoomImageDTO hotelRoomImageDTO)
    {
        HotelRoomImage hotelRoomImage=_mapper.Map<HotelRoomImageDTO, HotelRoomImage>(hotelRoomImageDTO);
        await _db.HotelRoomImages.AddAsync(hotelRoomImage);
        return await _db.SaveChangesAsync();
    }

    public async Task<int> DeleteHotelImageByImageUrl(string imageUrl)
    {
        var allImages=await _db.HotelRoomImages.FirstOrDefaultAsync
            (x=>x.RoomImageUrl.ToLower()==imageUrl.ToLower());
        if (allImages!=null)
        {
            _db.HotelRoomImages.Remove(allImages);
            return await _db.SaveChangesAsync();
        }
        else
        {
            return 0;
        }
    }

    public async Task<int> DeleteHotelRoomImageByImageId(int imageId)
    {
        HotelRoomImage? hotelRoomImage=await _db.HotelRoomImages.FindAsync(imageId);
        if(hotelRoomImage != null)
        {
             _db.HotelRoomImages.Remove(hotelRoomImage);
        }
        return await _db.SaveChangesAsync();
    }

    public async  Task<int> DeleteHotelRoomImageByRoomId(int roomId)
    {
        List<HotelRoomImage> hotelRoomImages= await _db.HotelRoomImages.Where(x=>x.RoomId==roomId).ToListAsync();
        _db.HotelRoomImages.RemoveRange(hotelRoomImages);
        return await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<HotelRoomImageDTO>> GetAllHotelRoomImages(int roomId)
    {
        List<HotelRoomImage> hotelRoomImages = await _db.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync();
        return _mapper.Map<IEnumerable<HotelRoomImage>,IEnumerable<HotelRoomImageDTO>>(hotelRoomImages);
    }
}
