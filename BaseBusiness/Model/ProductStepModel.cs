
using System;
namespace BMS.Model
{
	public partial class ProductStepModel : BaseModel
	{
		public int ID {get; set;}
		
		public int WorkingStepID {get; set;}
		
		public int ProductID {get; set;}
		
		public string ProductStepCode {get; set;}
		
		public string Description {get; set;}
		
		public int ParentID {get; set;}
		
		public int SortOrder {get; set;}
		
		public string CreatedBy {get; set;}
		
		public DateTime? CreatedDate {get; set;}
		
		public string UpdatedBy {get; set;}
		
		public DateTime? UpdatedDate {get; set;}
		
		public bool IsDeleted {get; set;}
		
	}
}
	