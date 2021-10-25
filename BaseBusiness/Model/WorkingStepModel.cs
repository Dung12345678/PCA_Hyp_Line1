
using System;
namespace BMS.Model
{
	public partial class WorkingStepModel : BaseModel
	{
		public int ID {get; set;}
		
		public int ProductGroupID {get; set;}
		
		public string WorkingStepCode {get; set;}
		
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
	