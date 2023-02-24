using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotelModels;

public class HotelRoomDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage ="PLease enter room name")]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int Occupancy { get; set; }
    [Range(1,2000,ErrorMessage ="Reqular rate must be between 1 and 2000")]
    [Required]
    public double RegularRate { get; set; }
    public string Details { get; set; } = string.Empty;
    public string SqFt { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
}
