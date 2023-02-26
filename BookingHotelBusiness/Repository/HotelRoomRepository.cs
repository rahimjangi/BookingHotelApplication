using AutoMapper;
using BookingHotelBusiness.Mapper;
using BookingHotelBusiness.Repository.IRepository;
using BookingHotelDataAccess.Data;
using BookingHotelModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelBusiness.Repository;

public class HotelRoomRepository : IHotelRoomRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
    {
        HotelRoom hotelRoom=_mapper.Map<HotelRoomDTO,HotelRoom>(hotelRoomDTO);
        hotelRoom.CreatedDate = DateTime.Now;
        hotelRoom.CreatedBy = "";
        var addedHotelRoom=await _db.HotelRooms.AddAsync(hotelRoom);
        await _db.SaveChangesAsync();
        HotelRoomDTO result=_mapper.Map<HotelRoom,HotelRoomDTO>(addedHotelRoom.Entity);
        return result;
    }

    public async Task<int> DeleteHotelRoom(int roomId)
    {
        var roomDetails=await _db.HotelRooms.FindAsync(roomId);
        if (roomDetails != null)
        {
            _db.HotelRooms.Remove(roomDetails);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
    {
        try
        {
            return  _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_db.HotelRooms.Include(x=>x.HotelRoomImages));
        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
    {
        try
        {
            HotelRoomDTO hotelRoomDTO= _mapper.Map<HotelRoom,HotelRoomDTO>(
                await _db.HotelRooms.Include(h=>h.HotelRoomImages).FirstOrDefaultAsync(h=>h.Id==roomId)
                );
            return hotelRoomDTO;
        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public async Task<HotelRoomDTO> IsRoomUnique(string name,int roomId=0)
    {

        try
        {
            if (roomId == 0)
            {

                HotelRoomDTO hotelRoomDTO = _mapper.Map<HotelRoom, HotelRoomDTO>(
                        await _db.HotelRooms.FirstOrDefaultAsync(h=>h.Name.ToLower()==name.ToLower())
                    );
                return hotelRoomDTO;
            }
            else
            {
                HotelRoomDTO hotelRoomDTO = _mapper.Map<HotelRoom, HotelRoomDTO>(
        await _db.HotelRooms.FirstOrDefaultAsync(h => h.Name.ToLower() == name.ToLower() && h.Id!=roomId)
    );
                return hotelRoomDTO;
            }
        }
        catch (Exception ex)
        {

            return null;
        }
    }

    public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
    {
        try
        {
            if (roomId == hotelRoomDTO.Id)
            {
                //valid
                HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
                HotelRoom hotelRoom=_mapper.Map<HotelRoomDTO,HotelRoom>(hotelRoomDTO,roomDetails);
                hotelRoom.UpdatedBy = "";
                hotelRoom.UpdatedDate = DateTime.Now;
                var UpdatedHotelRoom = _db.HotelRooms.Update(hotelRoom);
                await _db.SaveChangesAsync();
                return _mapper.Map<HotelRoom, HotelRoomDTO>(UpdatedHotelRoom.Entity);

            }
            else
            {
                //invalid
                return null;
            }
        }
        catch (Exception ex)
        {

            return null;
        }
        throw new NotImplementedException();
    }
}
