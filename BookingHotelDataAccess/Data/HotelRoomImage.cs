﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelDataAccess.Data;

public class HotelRoomImage
{
    [Key]
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string RoomImageUrl { get; set; }=string.Empty;
    [ForeignKey("RoomId")]
    public virtual HotelRoom HotelRoom { get; set; }

}
