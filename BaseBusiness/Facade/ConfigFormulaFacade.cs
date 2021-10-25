
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ConfigFormulaFacade : BaseFacade
	{
		protected static ConfigFormulaFacade instance = new ConfigFormulaFacade(new ConfigFormulaModel());
		protected ConfigFormulaFacade(ConfigFormulaModel model) : base(model)
		{
		}
		public static ConfigFormulaFacade Instance
		{
			get { return instance; }
		}
		protected ConfigFormulaFacade():base() 
		{ 
		} 
	
	}
}
	