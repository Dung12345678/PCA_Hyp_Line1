using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SHIV_PhongCachAm.PopupWindows
{
	/// <summary>
	/// Interaction logic for inputSTTSanpham.xaml
	/// </summary>
	public partial class inputBarcode : Window
	{
		public delegate void outputBarcode(string bCode);
		public event outputBarcode STTSanphamChange;
		public event outputBarcode OrderChange;
		public event outputBarcode OperatorChange;
		// 01/04 Gia tri gioi han vong quay nhap
		public float vongquayMax = 0f;
		public float vongquayMin = 0f;
		// 28/04 Gia tri luu Order hien tai
		public string StrOrder = "";

		//public string LabelText;

		public inputBarcode(string value)
		{
			InitializeComponent();
			lblInput.Content = value;
			FocusTextbox();
		}

		// 28/04 Them Ctor input Order de so sanh voi QR Code
		public inputBarcode(string value, string orderInput)
		{
			InitializeComponent();
			lblInput.Content = value;
			StrOrder = orderInput;
			FocusTextbox();
		}

		//01/04 Them Ctor input gioi han vong quay
		public inputBarcode(string value, float min, float max)
		{
			vongquayMax = max;
			vongquayMin = min;
			InitializeComponent();
			lblInput.Content = value;
			FocusTextbox();
		}

		private void FocusTextbox()
		{
			txtInputBarcode.Focus();
		}

		private void txtInputBarcode_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtInputBarcode.Text.IndexOf((char)(13)) > 0)
			{
				if (txtInputBarcode.Text.IndexOf("-") > 0)
				{
					try
					{
						if (STTSanphamChange != null)
						{
							STTSanphamChange(txtInputBarcode.Text);
						}
						if (OrderChange != null) OrderChange(txtInputBarcode.Text);
						if (OperatorChange != null) OperatorChange(txtInputBarcode.Text);
						this.Close();
					}
					catch { }


				}
				else
				{
					if (txtInputBarcode.Text != "") MessageBox.Show("Wrong Input!");
					txtInputBarcode.Text = "";
				}
			}
		}

		/// <summary>
		/// Kiểm tra trạng thái nút nhấn
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtInputBarcode_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				if ((txtInputBarcode.Text.IndexOf("-") > 0) || (txtInputBarcode.Text.Length > 3) || (txtInputBarcode.Text == "+"))
				{
					try
					{
						if (STTSanphamChange != null)
						{
							if (vongquayMin > 0f)
							{
								if ((txtInputBarcode.Text == "+"))
								{
									STTSanphamChange("0.00");
									return;
								}
								float vongquayInput = float.Parse(txtInputBarcode.Text);
								if ((vongquayInput > vongquayMax) || (vongquayInput < vongquayMin))
								{
									txtInputBarcode.Focus();
									txtInputBarcode.SelectAll();
									return;
								}
								else STTSanphamChange(txtInputBarcode.Text);
							}
							else
							// 28/04 Xu ly neu nhap STT sp
							{
								STTSanphamChange(txtInputBarcode.Text);
							}
						}
						if (OrderChange != null) OrderChange(txtInputBarcode.Text);
						if (OperatorChange != null) OperatorChange(txtInputBarcode.Text);
						this.Close();
					}
					catch (Exception)
					{


					}

				}
				else
				{
					if (txtInputBarcode.Text != "") MessageBox.Show("Wrong Input!");
					txtInputBarcode.Text = "";
				}
			}
		}
	}
}
