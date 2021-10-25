
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductCheckHistoryDetailPCABO : BaseBO
	{
		private ProductCheckHistoryDetailPCAFacade facade = ProductCheckHistoryDetailPCAFacade.Instance;
		protected static ProductCheckHistoryDetailPCABO instance = new ProductCheckHistoryDetailPCABO();

		protected ProductCheckHistoryDetailPCABO()
		{
			this.baseFacade = facade;
		}

		public static ProductCheckHistoryDetailPCABO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	