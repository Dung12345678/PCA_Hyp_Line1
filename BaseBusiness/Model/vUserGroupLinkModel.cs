
using System;
namespace BMS.Model
{
	public partial class vUserGroupLinkModel : BaseModel
	{
		public int ID {get; set;}
		
		public int UserGroupID {get; set;}
		
		public int UserID {get; set;}
		
		public string Code {get; set;}
		
		public string Name {get; set;}
		
		public int DepartmentID {get; set;}
		
	}
}
	