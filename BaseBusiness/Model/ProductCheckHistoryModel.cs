
using System;
namespace BMS.Model
{
	public partial class ProductCheckHistoryModel : BaseModel
	{
		public int ID {get; set;}
		
		public string QRCode {get; set;}
		
		public int ProductID {get; set;}
		
		public string OrderCode {get; set;}
		
		public string ProductCode {get; set;}
		
		public DateTime? DateLR {get; set;}
		
		public string CreatedBy {get; set;}
		
		public DateTime? CreatedDate {get; set;}
		
		public string UpdatedBy {get; set;}
		
		public DateTime? UpdatedDate {get; set;}
		
	}
}
	