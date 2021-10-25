
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class vUserGroupLinkBO : BaseBO
	{
		private vUserGroupLinkFacade facade = vUserGroupLinkFacade.Instance;
		protected static vUserGroupLinkBO instance = new vUserGroupLinkBO();

		protected vUserGroupLinkBO()
		{
			this.baseFacade = facade;
		}

		public static vUserGroupLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	