
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace SHIV_PhongCachAm
{
	public partial class frmProductCheckHistoryDetailPCA : Form
	{
		public frmProductCheckHistoryDetailPCA()
		{
			InitializeComponent();
		}
		void LoadInfoSearch()
		{
			DataTable dt = new DataTable();
			dt = TextUtils.LoadDataFromSP(
					   "spGetProductCheckHistoryDetailPCA"
					   , "A"
					   , new string[] { "@DateStart", "@DateEnd ", "@TextFilter" }
					   , new object[] { dtpFrom.Value.ToString("yyyy/MM/dd HH:mm:ss")
										, dtpTo.Value.ToString("yyyy/MM/dd HH:mm:ss")
										, txtTextFilter.Text.Trim()
					   }
				   );

			grdData.DataSource = dt;
		}

		private void btnFindDate_Click(object sender, EventArgs e)
		{
			LoadInfoSearch();
		}

		private void frmProductCheckHistoryDetailPCA_Load(object sender, EventArgs e)
		{
			dtpFrom.Value = DateTime.Today.AddHours(00).AddMinutes(00).AddSeconds(00);
			dtpTo.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);
			LoadInfoSearch();

		}

		private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{

		}

		private void grvData_DoubleClick(object sender, EventArgs e)
		{

		}

		private void grdData_Click(object sender, EventArgs e)
		{

		}
	}
}
