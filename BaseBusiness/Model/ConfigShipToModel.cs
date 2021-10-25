
using System;
namespace BMS.Model
{
	public partial class ConfigShipToModel : BaseModel
	{
		public int ID {get; set;}
		
		public string ShipTo {get; set;}
		
		public bool IsHidden {get; set;}
		
	}
}
	