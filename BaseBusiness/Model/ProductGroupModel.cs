
using System;
namespace BMS.Model
{
	public partial class ProductGroupModel : BaseModel
	{
		public int ID {get; set;}
		
		public string ProductGroupCode {get; set;}
		
		public string ProductGroupName {get; set;}
		
		public string SizeBB {get; set;}
		
		public string CreatedBy {get; set;}
		
		public DateTime? CreatedDate {get; set;}
		
		public string UpdatedBy {get; set;}
		
		public DateTime? UpdatedDate {get; set;}
		
	}
}
	