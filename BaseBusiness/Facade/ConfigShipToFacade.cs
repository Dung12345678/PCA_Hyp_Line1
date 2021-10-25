
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ConfigShipToFacade : BaseFacade
	{
		protected static ConfigShipToFacade instance = new ConfigShipToFacade(new ConfigShipToModel());
		protected ConfigShipToFacade(ConfigShipToModel model) : base(model)
		{
		}
		public static ConfigShipToFacade Instance
		{
			get { return instance; }
		}
		protected ConfigShipToFacade():base() 
		{ 
		} 
	
	}
}
	