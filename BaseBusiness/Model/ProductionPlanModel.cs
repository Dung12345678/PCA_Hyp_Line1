
using System;
namespace BMS.Model
{
	public partial class ProductionPlanModel : BaseModel
	{
		public long ID {get; set;}
		
		public string AssemblyProduct {get; set;}
		
		public int Stt {get; set;}
		
		public DateTime? JgDate {get; set;}
		
		public string OrderCode {get; set;}
		
		public int Cnt {get; set;}
		
		public string ProductCode {get; set;}
		
		public string Description {get; set;}
		
		public int RealQty {get; set;}
		
		public int Qty {get; set;}
		
		public string SalesOrder {get; set;}
		
		public string ShipTo {get; set;}
		
		public string SVia {get; set;}
		
		public string Code {get; set;}
		
		public string OrderNew {get; set;}
		
		public string ProductCodeNew {get; set;}
		
		public string Note {get; set;}
		
		public DateTime? RequestDate {get; set;}
		
		public string CycloDick {get; set;}
		
		public DateTime? UpdatedAt {get; set;}
		
		public DateTime? CreatedAt {get; set;}
		
		public int Status {get; set;}
		
		public bool Priority {get; set;}
		
		public string MaMoto {get; set;}
		
		public string MaMoto1 {get; set;}
		
		public DateTime? AssemblyDate {get; set;}
		
		public DateTime? DeliveryDate {get; set;}
		
		public string OrderCodeFull {get; set;}
		
	}
}
	