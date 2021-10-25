
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class sysdiagramsBO : BaseBO
	{
		private sysdiagramsFacade facade = sysdiagramsFacade.Instance;
		protected static sysdiagramsBO instance = new sysdiagramsBO();

		protected sysdiagramsBO()
		{
			this.baseFacade = facade;
		}

		public static sysdiagramsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	