using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHIV_PhongCachAm
{
	public partial class frmLogDetail : Form
	{
		Thread _thread = null;

		public frmLogDetail()
		{
			InitializeComponent();

			dtpFrom.Value = DateTime.Today.AddHours(00).AddMinutes(00).AddSeconds(00);
			dtpTo.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

			_thread = new Thread(new ThreadStart(LoadInfoSearch));
			_thread.IsBackground = true;
			_thread.Start();
		}
		void LoadInfoSearch()
		{
			while (true)
			{
				Thread.Sleep(20000);

				this.Invoke(new Action(() =>
				{
					loadData();
				}
			));
			}
		}
		void loadData()
		{
			try
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

				grvData.AutoGenerateColumns = false;
				grvData.DataSource = dt;
			}
			catch { }
		}
		private void btnFindDate_Click(object sender, EventArgs e)
		{
			loadData();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
