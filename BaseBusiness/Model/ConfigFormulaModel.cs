
using System;
namespace BMS.Model
{
	public partial class ConfigFormulaModel : BaseModel
	{
		public int ID {get; set;}
		
		public int ProductGroupID {get; set;}
		
		public string ProductTypeCode {get; set;}
		
		public string ProductGroupCode {get; set;}
		
		public string Formula2 {get; set;}
		
		public string Formula1 {get; set;}
		
		public string Formula3 {get; set;}
		
	}
}
	