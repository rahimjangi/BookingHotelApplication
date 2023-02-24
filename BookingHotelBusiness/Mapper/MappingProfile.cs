using AutoMapper;
using BookingHotelDataAccess.Data;
using BookingHotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelBusiness.Mapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<HotelRoomDTO, HotelRoom>();
        CreateMap<HotelRoom,HotelRoomDTO>();
    }
}
