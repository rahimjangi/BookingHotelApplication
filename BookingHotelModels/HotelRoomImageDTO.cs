using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelModels;

public class HotelRoomImageDTO
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string RoomImageUrl { get; set; } = string.Empty;
}
