
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductWorkingAuditFacade : BaseFacade
	{
		protected static ProductWorkingAuditFacade instance = new ProductWorkingAuditFacade(new ProductWorkingAuditModel());
		protected ProductWorkingAuditFacade(ProductWorkingAuditModel model) : base(model)
		{
		}
		public static ProductWorkingAuditFacade Instance
		{
			get { return instance; }
		}
		protected ProductWorkingAuditFacade():base() 
		{ 
		} 
	
	}
}
	