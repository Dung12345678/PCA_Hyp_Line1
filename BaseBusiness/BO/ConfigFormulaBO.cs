
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ConfigFormulaBO : BaseBO
	{
		private ConfigFormulaFacade facade = ConfigFormulaFacade.Instance;
		protected static ConfigFormulaBO instance = new ConfigFormulaBO();

		protected ConfigFormulaBO()
		{
			this.baseFacade = facade;
		}

		public static ConfigFormulaBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	