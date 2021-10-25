
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductStepBO : BaseBO
	{
		private ProductStepFacade facade = ProductStepFacade.Instance;
		protected static ProductStepBO instance = new ProductStepBO();

		protected ProductStepBO()
		{
			this.baseFacade = facade;
		}

		public static ProductStepBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	