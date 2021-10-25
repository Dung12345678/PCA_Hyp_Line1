
using System;
namespace BMS.Model
{
	public partial class ProductTypeModel : BaseModel
	{
		public int ID {get; set;}
		
		public string ProductTypeCode {get; set;}
		
		public string ProductTypeName {get; set;}
		
		public string CreatedBy {get; set;}
		
		public DateTime? CreatedDate {get; set;}
		
		public string UpdatedBy {get; set;}
		
		public DateTime? UpdatedDate {get; set;}
		
	}
}
	