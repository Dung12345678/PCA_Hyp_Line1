
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductWorkingAuditBO : BaseBO
	{
		private ProductWorkingAuditFacade facade = ProductWorkingAuditFacade.Instance;
		protected static ProductWorkingAuditBO instance = new ProductWorkingAuditBO();

		protected ProductWorkingAuditBO()
		{
			this.baseFacade = facade;
		}

		public static ProductWorkingAuditBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	