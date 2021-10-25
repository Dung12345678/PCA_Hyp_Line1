
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class vUserGroupLinkFacade : BaseFacade
	{
		protected static vUserGroupLinkFacade instance = new vUserGroupLinkFacade(new vUserGroupLinkModel());
		protected vUserGroupLinkFacade(vUserGroupLinkModel model) : base(model)
		{
		}
		public static vUserGroupLinkFacade Instance
		{
			get { return instance; }
		}
		protected vUserGroupLinkFacade():base() 
		{ 
		} 
	
	}
}
	