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
	public partial class inputSTT : Window
	{
		public delegate void outputBarcode(string bCode);
		public event outputBarcode STTSanphamChange;
		public string Order;

		//01/04 Them Ctor input gioi han vong quay
		public inputSTT(string value, string orderInput)
		{
			InitializeComponent();
			lblInput.Content = value;
			Order = orderInput;
			FocusTextbox();
		}

		private void FocusTextbox()
		{
			txtInputSTTSanPham.Focus();
		}

		private void txtInputBarcode_TextChanged(object sender, TextChangedEventArgs e)
		{
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
				if (txtInputBarcode.Text.Length > 3)
				{
					try
					{
						// Lấy giá trị so sánh từ STT Sản phẩm
						string stringSTTCompare = GetCompareString(txtInputSTTSanPham.Text);
						// So sánh
						if (stringSTTCompare == txtInputBarcode.Text.Trim())
						{
							if (STTSanphamChange != null)
							{
								STTSanphamChange(txtInputSTTSanPham.Text);
							}
						}
						else
						{
							MessageBox.Show("Sai Order - Kiểm tra lại");
						}
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

		private string GetCompareString(string text)
		{
			if (text.Contains(" "))
			{
				if (text.Contains("-"))
				{
					try
					{
						// ABCD-0-1 => ABCD0
						return text.Substring(0, text.IndexOf("-") + 2).Replace("-", "");
					}
					catch
					{
						return "";
					}
				}
				else
				{
					try
					{
						// ABCD0 1234 => ABCD0
						return text.Substring(0, text.IndexOf(" "));
					}
					catch
					{
						return "";
					}
				}
			}
			else return "";
		}

		private void txtInputSTTSanPham_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				txtInputBarcode.Focus();
			}
		}
	}
}
