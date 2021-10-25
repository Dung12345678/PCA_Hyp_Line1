
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductCheckHistoryDetailPCAFacade : BaseFacade
	{
		protected static ProductCheckHistoryDetailPCAFacade instance = new ProductCheckHistoryDetailPCAFacade(new ProductCheckHistoryDetailPCAModel());
		protected ProductCheckHistoryDetailPCAFacade(ProductCheckHistoryDetailPCAModel model) : base(model)
		{
		}
		public static ProductCheckHistoryDetailPCAFacade Instance
		{
			get { return instance; }
		}
		protected ProductCheckHistoryDetailPCAFacade():base() 
		{ 
		} 
	
	}
}
	