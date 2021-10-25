
using System;
namespace BMS.Model
{
	public partial class ProductWorkingAuditModel : BaseModel
	{
		public int ID {get; set;}
		
		public int ProductWorkingID {get; set;}
		
		public int ProductID {get; set;}
		
		public int ProductStepID {get; set;}
		
		public int WorkingID {get; set;}
		
		public string WorkingName {get; set;}
		
		public int ValueType {get; set;}
		
		public string ValueTypeName {get; set;}
		
		public string PeriodValue {get; set;}
		
		public decimal MinValue {get; set;}
		
		public decimal MaxValue {get; set;}
		
		public string Unit {get; set;}
		
		public int SortOrder {get; set;}
		
		public int CheckValueType {get; set;}
		
		public string ProductStepCode {get; set;}
		
		public decimal MinValueNew {get; set;}
		
		public decimal MaxValueNew {get; set;}
		
		public string PeriodValueNew {get; set;}
		
		public string ProductStepCodeNew {get; set;}
		
		public string WorkingNameNew {get; set;}
		
		public int SortOrderNew {get; set;}
		
		public int ValueTypeNew {get; set;}
		
		public int CheckValueTypeNew {get; set;}
		
		public int ActionType {get; set;}
		
		public string ReasonChange {get; set;}
		
		public int IsApproved {get; set;}
		
		public string UserApproved {get; set;}
		
		public string CreatedBy {get; set;}
		
		public DateTime? CreatedDate {get; set;}
		
		public string UpdatedBy {get; set;}
		
		public DateTime? UpdatedDate {get; set;}
		
		public bool IsHidden {get; set;}
		
		public bool IsHiddenNew {get; set;}
		
	}
}
	