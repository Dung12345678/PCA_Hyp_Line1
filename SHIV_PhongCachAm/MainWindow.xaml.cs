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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ActUtlTypeLib;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Timers;
using SHIV_PhongCachAm.PopupWindows;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Windows.Controls.DataVisualization.Charting;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using WMPLib;
using System.Globalization;
using System.Net;
using SHIV_PhongCachAm;
using BMS.Utils;
using System.Data;
using BMS.Business;
using System.Text.RegularExpressions;
using BMS.Model;
using System.Collections;
using System.Net.Sockets;
using System.Windows.Forms.Integration;
using System.Reflection;
using Expression = BMS.Utils.Expression;
using BMS;

// Test Save F5
namespace SHIV_PhongCachAm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Khai báo logging log4net
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#region <Khai báo biến>
		int currentStageRun = 0;
		int currentChart = 0;
		int TimerFwd = 200;
		int TimerBwd = 200;
		int TimerCurrentT1 = 0;
		int TimerCurrentT2 = 0;

		float fA1 = 0, fA2 = 0, fA3 = 0;
		//bool isheck = false;
		private bool plcButtonForward;
		private bool plcButtonBackward;

		private DataStoreObject dtVongquay, dtDongdien, dtNhapluc, dtDorung, dtTiengon, dtDienap;
		private valueNguoidanhgiaObject dtAmsac, dtHuongquay;
		private dulieuStruct dlDorung, dlTiengon;
		private labelObject lbdMaOrder, lbdSoThuTuSanPham, lbdNguoiVanHanh, lbdPID, lbdMoTaSanPham, lbdGiamToc;
		private labelObject lbdDatetime, lbdStatus;
		private labelObject lbdDienap;
		private labelObject lbdTanso;
		private labelObject lbTcDongdien, lbTcNhapluc, lbTcVongquay, lbTcDorung, lbTcTiengon, lbTcDienap, lbTcTanso;
		private labelObject lbdTimerCountCycle = new labelObject();
		private labelObject lbdStatusComNoise;
		private labelObject lbdStatusComCurrent;
		private valueParse is1Parse;
		private specialOutputObject specialOutputObject;

		string pathSub = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Sub.txt";
		private float htVongquay;
		private float htDongdien;
		private float htDienap;

		private float htTanso;
		private float htNhapluc;
		private float htDorung;
		private float htTiengon;
		private int htCountVongquayRS232;

		double STDEVTiengOnThuan;
		double STDEVTiengOnNghich;
		double AVGTiengOn;
		double GTNghich;
		double GTThuan;
		double GT;
		//Check có phải con hàng dùng điện áp tăng dần khi chạy không
		int Check = 0;
		int IsNGTiengOnThuan = 0;
		int IsNGTiengOnNghich = 0;
		List<float> lstThuan = new List<float>();
		List<float> lstNghich = new List<float>();

		// Kết nối Excel
		//Excel.Application myExcel;
		// myExcel.Application.Interactive = false;

		//Excel.Worksheet workSheetDatabase;
		//Excel.Worksheet workSheetKehoach;
		//Excel.Worksheet myDataTemplateWorksheet;

		private int countDatainTemplate;


		// Kết nối PLC
		ActUtlType plcFX5U = new ActUtlType();
		ActUtlType plcFX3G_Shiv = new ActUtlType();
		// Kết nối RS232
		SerialPort COMCurrent, COMNoise, COMRotation;
		private System.Timers.Timer timerCOM;
		private checkDone checkDoneForward;
		private checkDone checkDoneBackward;

		// Thread
		private Thread continuesThread;
		private Thread PLC;
		private Thread PLC_Shiv;
		//private string excelLink;
		private string DatabasePath;
		private string tempCurrentString;
		private string tempNoiseString;
		private int countGetCurrent;
		private int countGetNoise;
		private DateTime beginTimeCycle;
		private TimeSpan currentTimeCycle;
		private valueObject valueSettingMaxRange;
		private Style styleDorung;
		private Style styleTiengon;
		private int _taktTime;
		//private int currentM0, currentM1, currentM3;
		//private int oldM0, oldM1, oldM3;
		private int endRangeCollum;
		string Sub = "";
		private bool chartBusy;
		private DateTime _startMakeTime;

		public ObservableCollection<ChartViewItem> MyValue { get; private set; }
		public ObservableCollection<ChartViewItem> MyValue_TempTiengon { get; private set; }
		public ObservableCollection<ChartViewItem> MyMax { get; private set; }
		public ObservableCollection<ChartViewItem> MyMin { get; private set; }
		#endregion

		string _socketIPAddress = "192.168.1.46";
		int _socketPort = 3000;
		Socket _socket;
		ASCIIEncoding _encoding = new ASCIIEncoding();

		private Thread _threadSocket;
		int andonActive = 0;
		private int _PeriodTime;

		private string uri = "ftp://172.21.9.248";
		private string user = "rtc";
		private string pass = "123456";
		private FtpWebRequest ftpRequest;
		private FtpWebResponse ftpResponse;
		private Stream ftpStream;
		Thread _threadTakeTime;
		Thread _threadGetAndonDetailsByCD;
		Thread _threadCheckColorCD;

		public MainWindow()
		{
			InitializeComponent();

			if (!File.Exists(pathSub))
			{
				File.WriteAllText(pathSub, "0");
			}
			_startMakeTime = DateTime.Now;
			Sub = File.ReadAllText(pathSub);
			cboSub.SelectedIndex = TextUtils.ToInt(Sub);
			frmLogDetail frm = new frmLogDetail();
			frm.Show();

			lblIsUse.Content = "Khong Su Dung";
			//specialOutputObject = new specialOutputObject();
			log.Info("Mo file excel");
			StartExcelApplication();
			log.Info("Khoi tao du lieu");
			DataInitialize();
			log.Info("Khoi tao ket noi chuong trinh");
			ConnectionInitialize();
			log.Info("Khoi tao thread lay du lieu lien tuc");
			StartContinues();
			andonActive = TextUtils.ToInt(TextUtils.ExcuteScalar($"select top 1 KeyValue from ConfigSystem where KeyName = 'IsAndonActiveHyp'"));
			if (andonActive == 0) return;

			//Load ra config trong database lấy takt time, địa chỉ tcp, port
			DataTable dtConfig = TextUtils.Select("SELECT TOP 1 * FROM dbo.AndonConfig with (nolock)");
			//_taktTime =TextUtils.ToInt( dtConfig.Rows[0]["Takt"]);
			_socketIPAddress = TextUtils.ToString(dtConfig.Rows[0]["TcpIp"]);
			_socketPort = TextUtils.ToInt(dtConfig.Rows[0]["SocketPort"]);
			try
			{
				IPAddress ipAddOut = IPAddress.Parse(_socketIPAddress);
				IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPort);
				_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				_socket.Connect(endPoint);
			}
			catch (Exception ex)
			{
				_socket = null;
			}
			startThreadSocket();

			//Nhận giá trị TaktTime
			_threadTakeTime = new Thread(new ThreadStart(TakeTime));
			_threadTakeTime.IsBackground = true;
			_threadTakeTime.Start();

			_threadCheckColorCD = new Thread(checkColorCD);
			_threadCheckColorCD.IsBackground = true;
			_threadCheckColorCD.Start();

			//Thread hiển thị giá trị delay
			_threadGetAndonDetailsByCD = new Thread(new ThreadStart(threadShowAndonDetails));
			_threadGetAndonDetailsByCD.IsBackground = true;
			_threadGetAndonDetailsByCD.Start();
		}

		void threadShowAndonDetails()
		{
			while (true)
			{
				Thread.Sleep(1000);
				//if (string.IsNullOrWhiteSpace(_step)) continue;
				try
				{
					DataSet dts = TextUtils.GetListDataFromSP("spGetAndonDetailsByCD", "AnDonDetails"
						   , new string[] { "@CD" }
						   , new object[] { "CD14" });
					DataTable data = dts.Tables[0];

					Dispatcher.Invoke(() =>
					{
						txtNumDelay.Content = TextUtils.ToString(data.Rows[0]["TotalDelayNum"]);
						txtTimeDelay.Content = TextUtils.ToString(data.Rows[0]["TotalDelayTime"]);
					});
				}
				catch (Exception ex)
				{
					//File.AppendAllText(_pathError + "/Error_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt",
					//		 DateTime.Now.ToString("HH:mm:ss") + ":threadShowAndonDetails(): " + ex.ToString() + Environment.NewLine);
				}
			}
		}
		void checkColorCD()
		{
			while (true)
			{
				Thread.Sleep(300);
				try
				{
					//DataTable dt = TextUtils.Select("select top 1 CD14 from StatusColorCD with (nolock)");
					//DataTable dt = TextUtils.Select("select top 1 CD14 from StatusColorCD with (nolock)");
					//if (dt.Rows.Count == 0) continue;

					//string step = "CD14";

					//int _status = TextUtils.ToInt(dt.Rows[0][step]);
					int _status = TextUtils.ToInt(TextUtils.ExcuteScalar("select top 1 CD14 from StatusColorCD with (nolock)"));
					Dispatcher.Invoke(() =>
					{
						switch (_status)
						{
							case 1:
								lblCD.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
								break;
							case 2:
								lblCD.Background = new SolidColorBrush(Color.FromRgb(245, 245, 15));
								break;
							case 3:
								lblCD.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
								break;
							case 4:
								lblCD.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
								break;
							case 5:
								lblCD.Background = new SolidColorBrush(Color.FromRgb(192, 192, 255));
								break;
							case 6:
								lblCD.Background = new SolidColorBrush(Color.FromRgb(255, 192, 128));
								break;
							default:
								break;
						}
					});


				}
				catch (Exception)
				{

				}
			}
		}
		void TakeTime()
		{
			ASCIIEncoding encoding = new ASCIIEncoding();

			while (true)
			{
				Thread.Sleep(100);
				try
				{
					string value = "";
					//Nhận giá trị TaktTime
					if (_socket != null && _socket.Connected)
					{
						try
						{
							byte[] buffer = new byte[500];
							_socket.Receive(buffer);
							value = encoding.GetString(buffer).Replace("\0", "").Trim();
						}
						catch (Exception ex)
						{
							//ConnectAnDon();
						}
					}

					if (value == "")
					{
						continue;
					}
					Dispatcher.Invoke(() =>
					{
						lblTakt.Content = value.Trim();
						if (TextUtils.ToInt(lblTakt.Content) == _taktTime - 1)
						{
							_startMakeTime = DateTime.Now;
							_PeriodTime = 0;
						}
						if (TextUtils.ToInt(lblTakt.Content) < 0)
						{
							_PeriodTime = TextUtils.ToInt(value.Trim()) * -1;
						}
					});
				}
				catch
				{

				}
			}
		}

		void startThreadSocket()
		{
			_threadSocket = new Thread(resetSocket);
			_threadSocket.IsBackground = true;
			_threadSocket.Start();
		}

		void resetSocket()
		{
			while (true)
			{
				Thread.Sleep(800);
				if (_socket == null)
				{
					//Load ra config trong database lấy takt time, địa chỉ tcp, port
					DataTable dtConfig = TextUtils.Select("SELECT TOP 1 * FROM dbo.AndonConfig with (nolock)");
					_taktTime = TextUtils.ToInt(dtConfig.Rows[0]["Takt"]);
					_socketIPAddress = TextUtils.ToString(dtConfig.Rows[0]["TcpIp"]);
					_socketPort = TextUtils.ToInt(dtConfig.Rows[0]["SocketPort"]);
					try
					{
						IPAddress ipAddOut = IPAddress.Parse(_socketIPAddress);
						IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPort);
						_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						_socket.Connect(endPoint);
					}
					catch (Exception ex)
					{
						_socket = null;
					}
				}
			}
		}
		DataTable _dtData;

		/// <summary>
		/// Gửi thông điệp lên andon
		/// </summary>
		/// <param name="value">Giá trị, trạng thái</param>
		/// <param name="type">1:sự cố, 2: đã hoàn thành, 3: cập nhật SL thực tế, 4: khởi động ca</param>
		void sendDataTCP(string value, string type)
		{
			if (andonActive == 0) return;
			try
			{
				Dispatcher.Invoke(new Action(() =>
				{
					//Gửi tín hiệu delay xuống server Andon qua TCP/IP
					if (_socket != null && _socket.Connected)
					{
						if (cboSub.SelectedIndex != 0) return;
						string sendData = string.Format("{0};{1};{2}", "CD14", value, type);
						byte[] data = _encoding.GetBytes(sendData);
						_socket.Send(data);
					}
				}));
			}
			catch (Exception ex)
			{
				File.AppendAllText(string.Format("F:\\SaveLog\\SendTCP_{0}.txt", DateTime.Now.ToString("dd_MM_yyyy"))
						, DateTime.Now + ": Loi send tcp ip sau khi nhap barcode.\n" + ex.ToString() + Environment.NewLine);
				_socket = null;
			}
		}
		/// <summary>
		/// Khởi tạo giá trị dt, dl
		/// </summary>
		private void DataInitialize()
		{
			// Cập nhật trạng thái điện áp
			is1Parse = new valueParse();

			// Cập nhật trạng thái xuất đặc biệt
			specialOutputObject = new specialOutputObject();

			// Load DB File _ Cập nhật Database khi bắt đầu chương trình
			//if (Settingsm.Default.DBLocation != "")
			//{
			//	log.Info("Cap nhat file database");
			//	if (File.Exists(Settingsm.Default.DBLocation))
			//		UpdateExcelDatabaseWhenChangeLink(Settingsm.Default.DBLocation);
			//	log.Info("Cap nhat file luu du lieu do");
			//	OpenExcelResultFile();
			//}

			log.Info("Khoi tao tat ca bien trang thai");
			// Trạng thái PLC
			//currentM0 = currentM1 = currentM3 = 0;

			// Trạng thái điện 1 pha
			is1Parse.Value = false;

			// Đặt lại trạng thái lấy dữ liệu
			currentStageRun = 1;

			dtVongquay = new DataStoreObject();
			dtDongdien = new DataStoreObject();
			dtNhapluc = new DataStoreObject();
			dtDorung = new DataStoreObject();
			dtTiengon = new DataStoreObject();
			dtTiengon.dataTiengon = true;
			dtDienap = new DataStoreObject();
			dtAmsac = new valueNguoidanhgiaObject();
			dtHuongquay = new valueNguoidanhgiaObject();


			dlDorung = new dulieuStruct(1000, 1000);
			dlTiengon = new dulieuStruct(1000, 1000);
			lbdNguoiVanHanh = new labelObject();
			lbdMaOrder = new labelObject();
			lbdSoThuTuSanPham = new labelObject();
			lbdPID = new labelObject();
			lbdMoTaSanPham = new labelObject();
			lbdGiamToc = new labelObject();
			lbdDienap = new labelObject();
			lbdTanso = new labelObject();
			lbdStatusComNoise = new labelObject();
			lbdStatusComCurrent = new labelObject();


			lbTcDongdien = new labelObject();
			lbTcNhapluc = new labelObject();
			lbTcVongquay = new labelObject();
			lbTcDorung = new labelObject();
			lbTcTiengon = new labelObject();
			lbTcDienap = new labelObject();
			lbTcTanso = new labelObject();

			// Khởi tạo giá trị ht
			htVongquay = 0;
			htDongdien = 0;
			htNhapluc = 0;
			htDorung = 0;
			htTiengon = 0;
			htDienap = 0;
			htDorung = 0;

			for (int i = 0; i < 1000; i++)
			{
				dlDorung.thuan[i] = (float)0.00001;
				dlDorung.nghich[i] = (float)0.00001;
				dlTiengon.thuan[i] = (float)0.00001;
				dlTiengon.nghich[i] = (float)0.00001;
			}

			lblVongquayFwdMax.DataContext = dtVongquay.GiatriThuan;
			lblVongquayBwdMax.DataContext = dtVongquay.GiatriNghich;
			lblVongquayLech.DataContext = dtVongquay.giatriLech;
			lblOKVongquay.DataContext = dtVongquay.GiatriDanhgia;
			//dtVongquay.giatriDanhgia.Value = 2;
			lblNGVongquay.DataContext = dtVongquay.GiatriDanhgia;

			//lblDongdienFwdMax.DataContext = dtDongdien.giatriThuan;
			lblDongdienFwdMax.DataContext = dtDongdien.GiatriThuan;
			lblDongdienBwdMax.DataContext = dtDongdien.GiatriNghich;
			lblDongdienLech.DataContext = dtDongdien.giatriLech;
			lblOKDongdien.DataContext = dtDongdien.GiatriDanhgia;
			//dtDongdien.giatriDanhgia.Value = 1;
			lblNGDongdien.DataContext = dtDongdien.GiatriDanhgia;

			lblDorungFwdMax.DataContext = dtDorung.GiatriThuan;
			//lblDorungFwdMax.DataContext = dtDorung;

			lblDorungBwdMax.DataContext = dtDorung.GiatriNghich;
			lblDorungLech.DataContext = dtDorung.giatriLech;
			lblOKDorung.DataContext = dtDorung.GiatriDanhgia;
			lblNGDorung.DataContext = dtDorung.GiatriDanhgia;

			lblTiengonFwdMax.DataContext = dtTiengon.GiatriThuan;
			lblTiengonBwdMax.DataContext = dtTiengon.GiatriNghich;
			lblTiengonLech.DataContext = dtTiengon.giatriLech;
			lblOKTiengon.DataContext = dtTiengon.GiatriDanhgia;
			lblNGTiengon.DataContext = dtTiengon.GiatriDanhgia;

			lblNhaplucFwdMax.DataContext = dtNhapluc.GiatriThuan;
			//lblNhaplucFwdMax.DataContext = dtNhapluc;
			lblNhaplucBwdMax.DataContext = dtNhapluc.GiatriNghich;
			lblNhaplucLech.DataContext = dtNhapluc.giatriLech;
			lblOKNhapluc.DataContext = dtNhapluc.GiatriDanhgia;
			lblNGNhapluc.DataContext = dtNhapluc.GiatriDanhgia;

			// Binding Tiêu chuẩn
			lblTcVongquay.DataContext = lbTcVongquay;
			lblTcDongdien.DataContext = lbTcDongdien;
			lblTCNhapluc.DataContext = lbTcNhapluc;
			lblTcDorung.DataContext = lbTcDorung;
			lblTcTiengon.DataContext = lbTcTiengon;
			lblDienapChuan.DataContext = lbTcDienap;
			lblTansoChuan.DataContext = lbTcTanso;
			lblStatusComCurrent.DataContext = lbdStatusComCurrent;
			lblStatusComNoise.DataContext = lbdStatusComNoise;

			// Binding giá trị Order - PID
			lblSTTSanpham.DataContext = lbdSoThuTuSanPham;
			lblMaOrder.DataContext = lbdMaOrder;
			lblNguoiVanhanh.DataContext = lbdNguoiVanHanh;
			lblPID.DataContext = lbdPID;
			lblMotaSanpham.DataContext = lbdMoTaSanPham;
			lblGiamtoc.DataContext = lbdGiamToc;

			// Binding các giá trị tự đánh giá
			lblHuongquayMax.DataContext = dtHuongquay.giatriMax;
			lblAmsacThuan.DataContext = dtAmsac.giatriThuan;
			lblAmsacNghich.DataContext = dtAmsac.giatriNghich;

			lblOKXuatluc.DataContext = dtHuongquay.giatriDanhgia;
			lblNGXuatluc.DataContext = dtHuongquay.giatriDanhgia;
			lblOKAmsac.DataContext = dtAmsac.giatriDanhgia;
			lblNGAmsac.DataContext = dtAmsac.giatriDanhgia;

			lblDienapThucte.DataContext = lbdDienap;
			lblTansoThucte.DataContext = lbdTanso;

			// Get Datetime
			lbdDatetime = new labelObject();
			lblDatetime.DataContext = lbdDatetime;
			lbdDatetime.Value = DateTime.Now.ToString("yy/MM/dd");
			// Reset Status
			lbdStatus = new labelObject();
			lblStatus.DataContext = lbdStatus;
			lbdStatus.Value = "Ready";

			// Khai báo hiển thị số đếm Cycle
			lblTimerCycle.DataContext = lbdTimerCountCycle;

			// Khởi tạo Binding đồ thị
			valueSettingMaxRange = new valueObject();
			valueSettingMaxRange.Value = 1;

			styleDorung = new Style(typeof(LineDataPoint));
			Setter tempSet1 = new Setter(LineDataPoint.BackgroundProperty, Brushes.MidnightBlue);
			styleDorung.Setters.Add(tempSet1);
			tempSet1 = new Setter(LineDataPoint.WidthProperty, (double)0);
			styleDorung.Setters.Add(tempSet1);
			tempSet1 = new Setter(LineDataPoint.HeightProperty, (double)0);
			styleDorung.Setters.Add(tempSet1);

			styleTiengon = new Style(typeof(LineDataPoint));
			tempSet1 = new Setter(LineDataPoint.BackgroundProperty, Brushes.DarkGreen);
			styleTiengon.Setters.Add(tempSet1);
			tempSet1 = new Setter(LineDataPoint.WidthProperty, (double)0);
			styleTiengon.Setters.Add(tempSet1);
			tempSet1 = new Setter(LineDataPoint.HeightProperty, (double)0);
			styleTiengon.Setters.Add(tempSet1);
		}

		/// <summary>
		/// Tạo mới và mở ứng dụng Excel
		/// Update các file Excel dữ liệu từ Server nếu có
		/// </summary>
		private void StartExcelApplication()
		{
			log.Info("Dong tat ca file excel dang mo");
			//killAppExcel();
			//myExcel = new Excel.Application();
			//U:\GearMotorG\100. Ke hoach lap rap\2. KE HOACH LR HYPOINIC & PREST.xlsm
			// Copy DB File	DB và KH từ Server
			//string DBServerStr = Settingsm.Default.DBServer;
			//string KHServerStr = Settingsm.Default.KHServer;//U:\GearMotorG\100. Ke hoach lap rap\2. KE HOACH LR HYPOINIC & PREST
			//string DbLocalStri = Settingsm.Default.DBLocation;
			//string KhLoalStri = DbLocalStri.Substring(0, DbLocalStri.LastIndexOf("\\") + 1) + "KHLocal.xlsm";
			//log.Info("Copy file Database va Ke hoach tu Server");
			//if (File.Exists(DBServerStr)) File.Copy(DBServerStr, DbLocalStri, true);
			//if (File.Exists(KHServerStr)) File.Copy(KHServerStr, KhLoalStri, true);
		}

		/// <summary>
		/// Tạo luồng lấy dữ liệu phần mềm (nhiệm vụ kiểm tra bước hiện tại, chạy lần lượt các bước lấy dữ liệu)
		/// </summary>
		private void StartContinues()
		{
			log.Info("Khoi tao thread lay du lieu lien tuc --Chutrinh_LayDuLieu--");
			continuesThread = new Thread(Chutrinh_LayDuLieu);
			continuesThread.Name = "Thread chu trinh Lay du lieu";
			continuesThread.IsBackground = false;
			continuesThread.Start();
		}

		/// <summary>
		/// Khởi tạo kết nối PLC, cổng COM
		/// Tạo timer gửi dữ liệu cổng COM
		/// </summary>
		private void ConnectionInitialize()
		{
			log.Info("Tao ket noi du lieu voi PLC FX5U");
			// Khởi tạo Thread cập nhật dữ liệu từ PLC
			plcFX5U.ActLogicalStationNumber = 11;
			plcFX5U.Open();
			PLC = new Thread(UpdateDataFromPLC);
			PLC.IsBackground = false;
			PLC.Name = "PLC Thread";
			PLC.Start();

			log.Info("Tao ket noi du lieu voi PLC FX3G");
			//// tạo Thread cập nhật dữ liệu từ PLC - Shiv
			plcFX3G_Shiv.ActLogicalStationNumber = 12;
			plcFX3G_Shiv.Open();

			//PLC_Shiv = new Thread(UpdateDataFromPLCShiv);
			//PLC_Shiv.IsBackground = false;
			//PLC_Shiv.Name = "PLC Shiv Thread";

			log.Info("Ket noi cong COM2 - lay du lieu dong dien nhap luc");
			// Khởi tạo kết nối COM lấy dữ liệu dòng điện nhập lực
			COMCurrent = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
			COMCurrent.DataReceived += receiveDataFromCOMCurrent;
			COMCurrent.ReadTimeout = 2000;
			COMCurrent.WriteTimeout = 2000;
			try
			{

				COMCurrent.Open();
			}
			catch (Exception)
			{
				MessageBox.Show("Loi ket noi cong com dien nhap luc");

			}


			// Khởi tạo kết nối COM lấy dữ liệu tiếng ồn
			log.Info("Ket noi cong COM3 - lay du lieu tieng on");
			COMNoise = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
			COMNoise.DataReceived += receiveDataFromCOMNoise;
			COMNoise.ReadTimeout = 2000;
			COMNoise.WriteTimeout = 2000;
			try
			{
				COMNoise.Open();
			}
			catch (Exception)
			{

				MessageBox.Show("Loi ket noi cong com du lieu tieng on");
			}

			log.Info("Ket noi cong COM8 - lay du lieu vong quay");
			// Khởi tạo kết nối COM lấy dữ liệu tốc độ vòng quay
			COMRotation = new SerialPort("COM8", 9600, Parity.None, 8, StopBits.One);
			COMRotation.DtrEnable = true;
			COMRotation.DataReceived += receiveDataFromCOM_MotorRotation;
			COMRotation.ReadTimeout = 2000;
			COMRotation.WriteTimeout = 2000;
			//COMRotation.Open();

			// Chạy Timer Request Data COM
			timerCOM = new System.Timers.Timer();
			timerCOM.Interval = 450;
			timerCOM.Elapsed += SentRequetDataCOM;
			timerCOM.Start();
		}
		string _receiveData = "";
		private bool allow_collect_Rotation = false;
		private bool mediaPlayerFwdFile = true;

		/// <summary>
		/// Cập nhật giá trị vòng quay khi nhận được tín hiệu từ COM Motor Rotation
		/// Dạng dữ liệu cần xử lý: 41280100000024
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void receiveDataFromCOM_MotorRotation(object sender, SerialDataReceivedEventArgs e)
		{
			// Nhận dữ liệu từ cổng COM
			try
			{
				var countErrDatetime = DateTime.Now;
				string tempReceiveString = "";
				tempReceiveString = COMRotation.ReadExisting().Replace(@"\u0002", "").Replace("\r", ""); //"\u000241270000000000\r"
				_receiveData += tempReceiveString.Trim();
				if (_receiveData.Substring(0, 1) != "4") _receiveData = "";
				if (_receiveData.Length < 14)
				{
					return;
				}
				else
				{
					tempReceiveString = _receiveData;
					_receiveData = "";
				}
				// Tính toán dữ liệu vòng quay từ chuỗi
				tempReceiveString = tempReceiveString.Replace("\r", "");
				if (tempReceiveString.IndexOf("41") >= 0)
				{
					tempReceiveString = tempReceiveString.Substring((tempReceiveString.IndexOf("41") + 5), 9);
					int commaPoint = int.Parse(tempReceiveString.Substring(0, 1));
					string tempRotationS = tempReceiveString.Substring(tempReceiveString.Length - 5);
					var tempVongquay = (float)((float.Parse(tempRotationS)) / (Math.Pow((double)10, (double)commaPoint)));

					if ((htCountVongquayRS232 < 2) && (tempVongquay > 0) && (allow_collect_Rotation))
					{
						//htVongquay = tempVongquay;
						htCountVongquayRS232 += 1;
						if (!File.Exists("F:\\testVongquay.txt")) File.WriteAllText("F:\\testVongquay.txt", DateTime.Now.ToString() + "Vong quay ++ Vong quay hien tai: " + htVongquay.ToString() + " count: " + htCountVongquayRS232.ToString() + "\r\n");
						else File.AppendAllText("F:\\testVongquay.txt", DateTime.Now.ToString() + "Vong quay ++ Vong quay hien tai: " + htVongquay.ToString() + " count: " + htCountVongquayRS232.ToString() + "\r\n");
					}
					else
					{
						if (htCountVongquayRS232 == 2)
						{
							// 06/01/2019 Tu - Sua them dieu kien lay du lieu vong quay bat ky thoi diem nao gia tri #0
							if ((tempVongquay > 0) && (allow_collect_Rotation))
							{
								if (dtVongquay.GiatriDanhgia.Value != 1)
								{
									//htVongquay = tempVongquay;
								}
							}
							//if (currentStageRun == 3) dtVongquay.GiatriThuan.Value = htVongquay;
							//if (currentStageRun == 13) dtVongquay.GiatriNghich.Value = htVongquay;

							dtVongquay.GiatriThuan.Value = htVongquay;
							dtVongquay.GiatriNghich.Value = htVongquay;

						}
						else
						{
							if (allow_collect_Rotation) File.AppendAllText("F:\\testVongquay.txt", DateTime.Now.ToString() + "Vong quay ++ Vong quay hien tai: " + htVongquay.ToString() + " tempVQ: " + tempVongquay.ToString() + "\r\n");
						}
					}
					Console.WriteLine("Vong quay: " + htVongquay.ToString() + "\r\n");
				}
			}
			catch
			{
				//if (htCountVongquayRS232 < 2) //htVongquay = 0;
			}
		}
		int i_CheckPLCConnect = 0;
		/// <summary>
		/// Lấy dữ liệu từ PLC
		/// Vòng quay: D100
		/// Độ rung: D200
		/// </summary>
		private void UpdateDataFromPLC()
		{
			string errLogPath = $"F:\\ERRLog\\ERR_PLC_{DateTime.Now.ToString("yyMMdd")}.txt";

			while (true)
			{

				int temp1;
				int iret1 = plcFX5U.ReadDeviceRandom("D100", 1, out temp1);
				try
				{
					htVongquay = (float)((float)temp1 * 3.0 / 12.0);
				}
				catch
				{
					htVongquay = 0;
				}
				// Lay gia tri do rung

				int temp;
				int iret = plcFX5U.ReadDeviceRandom("D200", 1, out temp);
				try
				{
					htDorung = (float)(temp * 0.026);
				}
				catch
				{
					htDorung = 0;
				}
				Thread.Sleep(50);

				// Lay gia tri quay nguoc
				iret = plcFX3G_Shiv.ReadDeviceRandom("Y7", 1, out temp);
				if (iret == 0)
				{
					i_CheckPLCConnect = 0;
					if (temp == 1)
					{
						plcButtonBackward = true;
					}
					else
					{
						plcButtonBackward = false;
					}
				}
				else
				{
					i_CheckPLCConnect++;
					if (i_CheckPLCConnect == 5)
					{
						MessageBox.Show("Loi ket noi PLC va PC, Tut cong USB ket noi giua PLC va PLC FX3G cam lai");
						if (File.Exists(errLogPath))
						{
							File.AppendAllText(errLogPath, $"ERR_PLC3 - Cannot get data - {iret} - {DateTime.Now.ToString()}" + "\r\n");
						}
						else
						{
							File.WriteAllText(errLogPath, $"ERR_PLC3 - Cannot get data - {iret} - {DateTime.Now.ToString()}" + "\r\n");
						}
					}


				}

				// Lấy giá trị quay thuan
				iret = plcFX3G_Shiv.ReadDeviceRandom("Y6", 1, out temp);
				if (iret == 0)
				{
					i_CheckPLCConnect = 0;
					if (temp == 1)
					{
						plcButtonForward = true;
					}
					else
					{
						plcButtonForward = false;
					}
				}
				else
				{


					i_CheckPLCConnect++;
					if (i_CheckPLCConnect == 5)
					{
						MessageBox.Show("Loi ket noi PLC va PC, Tut cong USB ket noi giua PLC va PLC FX3G cam lai");
						if (File.Exists(errLogPath))
						{
							File.AppendAllText(errLogPath, $"ERR_PLC3 - Cannot get data - {iret} - {DateTime.Now.ToString()}" + "\r\n");
						}
						else
						{
							File.WriteAllText(errLogPath, $"ERR_PLC3 - Cannot get data - {iret} - {DateTime.Now.ToString()}" + "\r\n");
						}
					}

				}

				// Lấy giá trị X? Nút nhấn Stop
				iret = plcFX3G_Shiv.ReadDeviceRandom("M100", 1, out temp);
				if (iret == 0)
				{
					if (temp == 1)
					{
						plcFX3G_Shiv.SetDevice("M300", 0);
						NutnhanStopDungChutrinh();
					}
				}
			}
		}

		/// <summary>
		/// Lấy dữ liệu chiều quay, nút nhấn đầu vào từ PLC của Sumitomo
		/// </summary>
		private void UpdateDataFromPLCShiv()
		{

			//while (false)
			//{
			//    Thread.Sleep(50);
			//    // Lấy giá trị X3
			//    int temp = 0;
			//    int iret = plcFX3G_Shiv.ReadDeviceRandom("M203", 1, out temp);
			//    if (iret == 0)
			//    {
			//        if (temp == 1)
			//        {
			//            plcButtonBackward = true;
			//        }
			//        else
			//        {
			//            plcButtonBackward = false;
			//        }
			//    }

			//    // Lấy giá trị X4
			//    iret = plcFX3G_Shiv.ReadDeviceRandom("M204", 1, out temp);
			//    if (iret == 0)
			//    {
			//        if (temp == 1)
			//        {
			//            plcButtonForward = true;
			//        }
			//        else
			//        {
			//            plcButtonForward = false;
			//        }
			//    }

			//    // Lấy giá trị X? Nút nhấn Stop

			//    oldM0 = currentM0;
			//    oldM1 = currentM1;
			//    oldM3 = currentM3;

			//    iret = plcFX3G_Shiv.ReadDeviceRandom("M208", 1, out temp);
			//    if (temp == 0)
			//    {
			//        iret = plcFX3G_Shiv.ReadDeviceRandom("M0", 1, out currentM0);
			//        iret = plcFX3G_Shiv.ReadDeviceRandom("M1", 1, out currentM1);
			//        iret = plcFX3G_Shiv.ReadDeviceRandom("M3", 1, out currentM3);
			//    }

			//    if (iret == 0)
			//    {
			//        if ((temp == 1) && ((oldM0 == 1) || (oldM1 == 1) || (oldM3 == 1)))
			//        {
			//            NutnhanStopDungChutrinh();
			//        }
			//    }
			//}
		}

		/// <summary>
		/// Nhấn nút Stop khi PLC đang chạy Auto, sẽ dừng chương trình, về trạng thái đợi tín hiệu bắt đầu chạy lại
		/// </summary>
		private void NutnhanStopDungChutrinh()
		{
			currentStageRun = 0;
			lbdStatus.Value = "Dừng chu trình kiểm tra - đợi chạy lại";
		}

		private int CountNGNoise = 0;
		/// <summary>
		/// Gửi lệnh lấy dữ liệu qua cổng COM, tần số lấy theo timerCOM theo chu kỳ timer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SentRequetDataCOM(object sender, ElapsedEventArgs e)
		{
			// Path file log Error
			string errLogPath = $"F:\\ERRLog\\ERR_COM_{DateTime.Now.ToString("yyMMdd")}.txt";
			//Get Current
			// Get data from Com Current
			if (countGetCurrent == 3)
			{
				try
				{
					// Reconect Port Com Current
					if (!COMCurrent.IsOpen)
					{
						lbdStatusComCurrent.Value = "COM Current Close";
						lbdStatusComCurrent.Color = Brushes.Red;
						COMCurrent.Close();
						Thread.Sleep(500);
						COMCurrent.Open();
					}
					else
					{
						lbdStatusComCurrent.Value = "COM Current Open";
						lbdStatusComCurrent.Color = Brushes.Green;
					}
					COMCurrent.WriteLine("MEASure?\r\n");
				}
				catch (Exception ex)
				{
					if (File.Exists(errLogPath))
					{
						File.AppendAllText(errLogPath, $"ERR_COM_Current - Error write to port - {DateTime.Now.ToString()} - {ex}" + "\r\n");
					}
					else
					{
						File.WriteAllText(errLogPath, $"ERR_COM_Current - Error write to port - {DateTime.Now.ToString()} - {ex}" + "\r\n");
					}
					// Try to Reconnect Com Current
					try
					{
						COMCurrent.Close();
						Thread.Sleep(300);
						COMCurrent.Open();
					}
					catch { }
				}
				countGetCurrent = 0;
			}
			else
			{
				countGetCurrent += 1;
			}

			// Request Current
			// Request Noise
			try
			{

				if (countGetNoise == 4)
				{
					if (!COMNoise.IsOpen)
					{
						lbdStatusComNoise.Value = "COM Noise Close";
						lbdStatusComNoise.Color = Brushes.Red;
					}
					else
					{
						lbdStatusComNoise.Value = "COM Noise Open";
						lbdStatusComNoise.Color = Brushes.Green;
					}
					COMNoise.WriteLine("DOD?\r\n");
					countGetNoise = 0;
					CountNGNoise += 1;
				}
				else
				{
					countGetNoise += 1;
				}


				if (CountNGNoise > 4)
				{
					CountNGNoise = 0;
					if (File.Exists(errLogPath))
					{
						File.AppendAllText(errLogPath, $"ERR_COM_Noise - Cannot get data - {DateTime.Now.ToString()}" + "\r\n");
					}
					else
					{
						File.WriteAllText(errLogPath, $"ERR_COM_Noise - Cannot get data - {DateTime.Now.ToString()}" + "\r\n");
					}
					if (COMNoise.IsOpen)
					{
						COMNoise.Close();
						Thread.Sleep(100);
					}
					COMNoise.Open();

				}

			}
			catch (Exception ex)
			{
				if (File.Exists(errLogPath))
				{
					File.AppendAllText(errLogPath, $"ERR_COM_Noise - Error write to port - {DateTime.Now.ToString()} - {ex}" + "\r\n");
				}
				else
				{
					File.WriteAllText(errLogPath, $"ERR_COM_Noise - Error write to port - {DateTime.Now.ToString()} - {ex}" + "\r\n");
				}

				try
				{
					COMNoise.Close();
					Thread.Sleep(100);
					COMNoise.Open();

				}
				catch { }


			}
			// Temp Test htTiengon
			//htTiengon = htTiengon + (float)0.456789;

			//SimulationCOMReceive();
		}

		/// <summary>
		/// Xử lý dữ liệu nhận về từ cổng COM máy đo tiếng ồn
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void receiveDataFromCOMNoise(object sender, SerialDataReceivedEventArgs e)
		{

			// Sua ngay 12/08 them try/catch khi doc du lieu ve
			string tempReceiveString = "";
			try
			{
				tempReceiveString = COMNoise.ReadExisting();
			}
			catch { }
			try
			{
				if (tempReceiveString.IndexOf("$") >= 0)
				{
					CountNGNoise = 0;
					tempReceiveString = tempNoiseString + tempReceiveString;
					tempNoiseString = "";
					if (tempReceiveString.IndexOf("R") >= 0)
					{
						//MessageBox.Show(tempReceiveString.IndexOf(" ").ToString());
						tempReceiveString = tempReceiveString.Substring(tempReceiveString.IndexOf(" "));
					}
					if (tempReceiveString.Length > 5)
					{
						string tempNoise = tempReceiveString.Split(',')[0];
						htTiengon = float.Parse(tempNoise);
					}

					//htTiengon = htTiengon + (float)0.456789;
				}
				else
				{
					tempNoiseString += tempReceiveString;
				}
			}
			catch { }
		}
		int i_CheckLossPhase = 0;
		int i_CheckOverVolt = 0;
		/// <summary>
		/// Xử lý dữ liệu nhận về từ cổng COM đo dòng điện, điện áp, công suất
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void receiveDataFromCOMCurrent(object sender, SerialDataReceivedEventArgs e)
		{
			Thread.Sleep(100);
			string tempReceiveString = "";
			//"V1 +222.74E+0;V2 +224.03E+0;V3 +224.77E+0;V0 +223.85E+0;A1 +000.58E-3;A2 +000.00E-3;A3 +000.00E-3;A0 +000.19E-3;W1 +777.77E+9;W2 +777.77E+9;W0 +000.00E+0;VA1 +777.77E+9;VA2 +777.77E+9;VA0 +000.07E+0;VAR1 +777.77E+9;VAR2 -777.77E+9;VAR0 +000.13E+0;PF1 +777.77E+9;PF2 -777.77E+9;PF0 +0.0000E+0;DEG1 +777.77E+9;DEG2 -777.77E+9;DEG0 +090.00E+0;IP1 +0.0000E+0;IP2 +0.0000E+0;IP3 +0.0000E+0;FREQ +59.997E+0;AH1 +000.000E-3;AH2 +000.000E-3;AH3 +000.000E-3;PWH1 +7777.77E+9;PWH2 +7777.77E+9;PWH0 +000.000E+0;MWH1 +7777.77E+9;MWH2 +7777.77E+9;MWH0 +000.000E+0;WH1 +7777.77E+9;WH2 +7777.77E+9;WH0 +000.000E+0;TIME 00000,00,00";
			try
			{
				tempReceiveString = COMCurrent.ReadExisting();
			}
			catch { }
			//Console.WriteLine(tempReceiveString);
			if (tempReceiveString.IndexOf("\n") >= 0)
			{
				tempReceiveString = tempCurrentString + tempReceiveString;
				tempCurrentString = "";
				string[] tempArr = tempReceiveString.Split(';');
				foreach (var item in tempArr)
				{
					try
					{
						// Lấy giá trị dòng điện
						if (is1Parse.Value)
						{
							if ((item.IndexOf("A1") >= 0) && (item.IndexOf("VA") < 0))
							{
								htDongdien = float.Parse(item.Substring(3), System.Globalization.NumberStyles.Float);
								//Console.WriteLine("Dong Dien " + htDongdien.ToString() + item);
							}
						}
						else
						{
							if ((item.IndexOf("A0") >= 0) && (item.IndexOf("VA") < 0))
							{
								htDongdien = float.Parse(item.Substring(3), System.Globalization.NumberStyles.Float);
								Console.WriteLine("Dong Dien " + htDongdien.ToString() + item);
							}
						}
					}
					catch { }

					// Get curent checl loss phase
					try
					{
						//Dòng Pha 1
						if (item.IndexOf("A1") == 0)
						{
							var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
							culture.NumberFormat.NumberDecimalSeparator = ".";
							string currentA1 = item.Substring(item.IndexOf('+'));
							fA1 = float.Parse(currentA1, culture);
						}
						//Dòng Pha 2
						if (item.IndexOf("A2") == 0)
						{
							var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
							culture.NumberFormat.NumberDecimalSeparator = ".";
							string currentA2 = item.Substring(item.IndexOf('+'));
							fA2 = float.Parse(currentA2, culture);
						}
						//Dòng Pha 3
						if (item.IndexOf("A3") == 0)
						{
							var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
							culture.NumberFormat.NumberDecimalSeparator = ".";
							string currentA3 = item.Substring(item.IndexOf('+'));
							fA3 = float.Parse(currentA3, culture);
						}
					}
					catch { }
					try
					{
						// Lấy giá trị nhập lực
						if (item.IndexOf("W0") >= 0)
						{
							htNhapluc = float.Parse(item.Substring(3), System.Globalization.NumberStyles.Float);
						}
						// Lấy giá trị điện áp Phase 1
						// Kiểm tra giá trị điện áp có đúng với động cơ không
						if (item.IndexOf("V1") >= 0)
						{
							Check = TextUtils.ToInt(TextUtils.ExcuteScalar($"SELECT TOP 1 IsVoltage FROM SumitomoHyp.dbo.SkipCD WHERE Product='{TextUtils.ToString(lbdPID.Value)}'"));
							if (Check == 0)
							{
								htDienap = float.Parse(item.Substring((item.IndexOf("V1") + 3)), System.Globalization.NumberStyles.Float);
								if ((htDienap > 1) && (dtDienap.Max > 1))
								{
									if ((Math.Abs(htDienap - dtDienap.Max) / dtDienap.Max) > 0.1)
									{
										i_CheckOverVolt++;
										if (i_CheckOverVolt >= 3)
										{
											plcFX3G_Shiv.SetDevice("M300", 1);
											currentStageRun = 0;
											lbdStatus.Value = "Dừng chu trình kiểm tra - đợi chạy lại";
											MessageBox.Show("Sai điện áp".ToUpper(), "Lỗi sai điện áp", MessageBoxButton.OK, MessageBoxImage.Error);
										}
									}
									else
									{
										i_CheckOverVolt = 0;
									}
								}
							}

						}
						// Lấy giá trị tần số
						if (item.IndexOf("FREQ") >= 0)
						{
							htTanso = float.Parse(item.Substring(5), System.Globalization.NumberStyles.Float);
						}
					}
					catch { }


				}

				//Thời gian chạy của động cơ
				plcFX3G_Shiv.ReadDeviceBlock("TN2", 1, out TimerCurrentT1);
				plcFX3G_Shiv.ReadDeviceBlock("TN2", 1, out TimerCurrentT2);
				int timeTurnForward = numberDataPerTurn + 60 + 50;
				//if (TimerCurrentT1 > 10 && TimerCurrentT1 < numberDataPerTurn + 40)
				// Kiểm tra mất pha chiều thuận của động cơ
				if (((TimerCurrentT1 > 10) && (TimerCurrentT1 < numberDataPerTurn + 40)) || ((TimerCurrentT1 > (10 + timeTurnForward)) && (TimerCurrentT1 < (numberDataPerTurn + 40 + timeTurnForward))))
				{

					if (fA1 < 0.1 || fA2 < 0.1 || fA3 < 0.1)
					{
						i_CheckLossPhase++;
						if (i_CheckLossPhase >= 10)
						{
							plcFX3G_Shiv.SetDevice("M300", 1);
							MessageBox.Show("Mất pha, kiểm tra kết nối dây điện giữa động cơ và nguồn cấp.");
							currentStageRun = 0;
							lbdStatus.Value = "Dừng chu trình kiểm tra - đợi chạy lại";
						}

					}
					else
					{
						i_CheckLossPhase = 0;
					}
				}
				// Kiểm tra mất pha động cơ chiều nghịch
				if (TimerCurrentT2 > 10 && TimerCurrentT2 < numberDataPerTurn + 40)
				{
					if (fA1 < 0.1 || fA2 < 0.1 || fA3 < 0.1)
					{
						i_CheckLossPhase++;
						if (i_CheckLossPhase >= 10)
						{
							plcFX3G_Shiv.SetDevice("M300", 1);
							MessageBox.Show("Mat pha, kiem tra ket noi day");
							//isheck = true;
							currentStageRun = 0;
							lbdStatus.Value = "Dừng chu trình kiểm tra - đợi chạy lại";
						}
					}
					else
					{
						i_CheckLossPhase = 0;
					}
				}

			}
			else
			{
				tempCurrentString += tempReceiveString;
			}
		}

		/// <summary>
		/// Chưa dùng
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lblSTTSanpham_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			/// Spare
		}

		private void lblLanguage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			currentStageRun = 19;
		}
		private void lblDatetime_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			currentStageRun = 1;
		}

		/// <summary>
		/// Cập nhật vị trí hiện tại trong file dữ liệu tổng
		/// Tính toán và trả về dòng trống đầu tiên countDatainTemplate
		/// </summary>
		//private void OpenExcelResultFile()
		//{
		//	string currentDir = Environment.CurrentDirectory + "\\" + "Temp_Sum_PCA_UD.xlsx";
		//	string currentDailyData = "F:\\LOG_ALL\\" + DateTime.Now.ToString("yyyy_MM_dd") + "_DataCollect" + ".xlsx";
		//	if (!File.Exists(@currentDailyData))
		//	{
		//		File.Copy(@currentDir, @currentDailyData);
		//	}

		//	if (File.Exists(@currentDailyData))
		//	{
		//		myExcel.Workbooks.Open(@currentDailyData);
		//		myDataTemplateWorksheet = myExcel.ActiveWorkbook.Worksheets["Main"];
		//		//for (int i = 1; i < 10000; i++)
		//		//{
		//		//	if (((Excel.Range)myDataTemplateWorksheet.Cells[i, 1]).Value2 == "") { countDatainTemplate = i - 1; break; }
		//		//	Excel.Range temp111 = (Excel.Range)myDataTemplateWorksheet.Cells[i, 1];
		//		//	temp111.FindNext("");
		//		//}
		//		Excel.Range tempRange = myDataTemplateWorksheet.Range[myDataTemplateWorksheet.Cells[1, 1], myDataTemplateWorksheet.Cells[10000, 1]];
		//		tempRange = tempRange.Find("");
		//		countDatainTemplate = tempRange.Row - 1;
		//		myDataTemplateWorksheet.Application.Interactive = false;
		//	}
		//}

		/// <summary>
		/// Nhấn nút F1 để chuyển qua lại giữa 4 đồ thị
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnF1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (currentChart < 3) currentChart += 1;
			else currentChart = 0;
			try
			{
				PlotChart(currentChart);
			}
			catch { }
		}


		public int numberDataPerTurn = 0;
		public Stopwatch countCycleTime;
		/// <summary>
		/// Chu trình Stage lấy dữ liệu
		/// Chiều thuận, chiều nghịch
		/// </summary>
		private void Chutrinh_LayDuLieu()
		{
			//Sua sang gia tri Timer 30s tuong ung 300
			//numberDataPerTurn = TimerFwd-50;
			int sleepTime = 0;
			currentStageRun = 0;
			countCycleTime = new Stopwatch();
			countCycleTime.Start();
			while (true)
			{
				// Chu kỳ 100ms
				if ((95 - countCycleTime.ElapsedMilliseconds) > 0)
				{
					sleepTime = (95 - (int)countCycleTime.ElapsedMilliseconds);
				}
				else
				{
					sleepTime = 0;
					log.Error("Thoi gian chu trinh vuot qua 100ms");
				}
				Thread.Sleep(sleepTime);
				countCycleTime.Restart();

				if (currentStageRun <= 1) currentTimeCycle = beginTimeCycle - beginTimeCycle;
				else currentTimeCycle = DateTime.Now - beginTimeCycle;

				if (currentTimeCycle.Seconds > 0) lbdTimerCountCycle.Value = currentTimeCycle.Seconds.ToString();
				else lbdTimerCountCycle.Value = "";

				if (currentStageRun > 1) UpdateDisplayColor();
				switch (currentStageRun)
				{
					// Reset Data to Default 
					case 0:
						log.Info("Chu trinh - 0 - Khoi tao + Doi tin hieu bat dau chay");
						//ResetAllData();
						checkDoneForward = new checkDone(false);
						checkDoneBackward = new checkDone(false);
						currentStageRun = 1;
						allow_collect_Rotation = false;
						break;
					// Wait Button Forward + Wait 5s
					case 1:
						if ((plcButtonForward)) // Mô phỏng nút nhấn
						{
							if (CheckConditionRun())
							{

								ResetValueData();
								plcFX5U.SetDevice2("M2000", 0); // Giá trị cho phép chạy chiều nghịch => false
								beginTimeCycle = DateTime.Now;
								lbdStatus.Value = "Đợi 3s cho động cơ chạy ổn định";
								plcFX5U.SetDevice("Y3", 1);
								//teaching sensor
								plcFX5U.SetDevice("Y0", 1);
								Thread.Sleep(100);
								plcFX5U.SetDevice("Y0", 0);
								// Sua ngay 23/12 - Them dieu kien while doi 10s de khong bi dong bang thoi gian - leanh.tu@rtc.edu.vn
								var startWait = DateTime.Now;
								allow_collect_Rotation = true;
								htCountVongquayRS232 = 0;
								//int waitTime = 5; // Thoi gian doi dong co chay on dinh - sua theo thoi gian PLC
								//while (((DateTime.Now.Second + DateTime.Now.Minute * 60) - (startWait.Second + startWait.Minute * 60)) < waitTime)
								//{
								//try
								// {
								//currentTimeCycle = DateTime.Now - beginTimeCycle;
								//lbdTimerCountCycle.Value = currentTimeCycle.Seconds.ToString();
								//}
								//catch { }
								//}

								Thread.Sleep(3000);
								//await Wait5Second();
								//await Wait3Second();
								plcFX5U.SetDevice("Y3", 0);
								currentStageRun = 3;
								RecordStart();

								currentChart = 0;

								// 23/12 them ghi log thoi gian bat dau do
								try
								{
									if (!File.Exists("F:\\testVongquay.txt")) File.WriteAllText("F:\\testVongquay.txt", DateTime.Now.ToString() + "Bat dau lay du lieu " + "\r\n");
									else File.AppendAllText("F:\\testVongquay.txt", DateTime.Now.ToString() + "Bat dau lay du lieu" + "\r\n");
								}
								catch { }

							}
							else
							{
								MessageBox.Show("Thiếu điều kiện chạy!", "Missing", MessageBoxButton.OK);
							}
						}
						break;
					// Collect and Update Data
					case 3:
						log.Info("Chu trinh - 3 - Lay du lieu chieu thuan");
						// Get Datetime
						OnMotorCount();
						lbdStatus.Value = "Lấy dữ liệu chiều thuận";

						lbdDatetime.Value = DateTime.Now.ToString("yy/MM/dd");

						//System.Console.Write("One Step Run - ");
						UpdateDulieu("Forward", ref checkDoneForward);
						if (checkDoneForward.Sum())
						{
							currentStageRun = 5;
						}
						//if (plcButtonBackward && !checkDoneForward.Sum())
						//{
						//	plcFX3G_Shiv.SetDevice("M300", 0);
						//	currentStageRun = 0;
						//	lbdStatus.Value = "Dừng chu trình kiểm tra - đợi chạy lại";
						//	MessageBox.Show("Du Lieu Do bat Thuong, Xin Hay Nhan Stop Va Do Lai");
						//}
						break;
					// Check Direction
					case 5:

						dtVongquay.GiatriThuan.Value = htVongquay;
						currentStageRun = 7;
						break;
					// Check Amsac
					case 7:

						// Chỉnh sửa
						Thread.Sleep(100);
						plcFX5U.SetDevice2("M2000", 1); // Giá trị cho phép chạy chiều nghịch => true
						currentStageRun = 9;
						break;
					// Finish Forward
					case 9:
						//RecordStopAndSave("F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_fwd");
						log.Info("Chu trinh - 9 - Ghi du lieu am thanh chieu thuan");
						for (int i = 0; i < 5; i++)
						{
							RecordStopAndSave("F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_fwd");
							if (File.Exists("F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_fwd"))
							{
								break;
							}
						}
						System.IO.FileInfo fi = new System.IO.FileInfo("F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_fwd" + ".wav");
						if (TextUtils.ToDouble(fi.Length) <= 44)
						{
							MessageBox.Show("Không lấy được dữ liệu file âm thanh. Có do Sensor độ rung hỏng hoặc dây kết nối tín hiệu hỏng");
						}
						currentStageRun = 11;
						log.Info("Chu trinh - 11 - Doi du lieu bat dau chieu nghich");
						break;
					// Wait Button Backward
					case 11:

						OffMotorCount();
						if ((plcButtonBackward))
						{
							beginTimeCycle = DateTime.Now;
							lbdStatus.Value = "Đợi 3s quay nghịch";
							Thread.Sleep(3000);
							//await Wait5Second();
							//await Wait5Second();
							currentStageRun = 13;
							RecordStart();
							currentChart = 1;
							//htCountVongquayRS232 = 0;
						}
						break;
					// Collect and Update Data
					case 13:
						OnMotorCount();
						lbdStatus.Value = "Lấy dữ liệu chiều nghịch";
						log.Info("Chu trinh - 13 - Lay du lieu chieu nghich");

						UpdateDulieu("Backward", ref checkDoneBackward);
						if (checkDoneBackward.Sum())
						{
							currentStageRun = 15;
						}
						break;
					// Check Direction
					case 15:

						//Save File Record
						log.Info("Chu trinh - 15 - Ghi du lieu am thanh chieu nghich");
						string fileSound = "F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_rwd";
						for (int i = 0; i < 5; i++)
						{
							RecordStopAndSave(fileSound);
							if (File.Exists(fileSound))
							{
								break;
							}
						}
						System.IO.FileInfo fi1 = new System.IO.FileInfo("F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_rwd" + ".wav");
						if (TextUtils.ToDouble(fi1.Length) <= 44)
						{
							MessageBox.Show("Không lấy được dữ liệu file âm thanh. Có do Sensor độ rung hỏng hoặc dây kết nối tín hiệu hỏng");
						}
						// Latus  - 30/11 - Them dien du lieu do vong quay Manual
						if (htVongquay < 0.5)
						{
							// Hien thi nhap gia tri vong quay 
							Dispatcher.Invoke(new Action(() =>
							{
								try
								{
									inputBarcode temp = new PopupWindows.inputBarcode("Nhap gia tri vong quay:", dtVongquay.Min, dtVongquay.Max);
									temp.STTSanphamChange += CapNhatGiaTriVongQuayManual;
									temp.ShowDialog();
								}
								catch (Exception ex)
								{ }
							}));
						}
						dtVongquay.GiatriNghich.Value = htVongquay;
						dtVongquay.GiatriThuan.Value = htVongquay;
						if (IsNGTiengOnNghich == 1 || IsNGTiengOnThuan == 1)
						{
							//Chạy xong 2 chiều so sánh tiếng ồn chiều thuận hay nghịch lớn nhất thì lấy 
							if (GTThuan > GTNghich) GT = GTThuan;
							else if (GTNghich > GTThuan) GT = GTNghich;


							if (dlTiengon.thuan.Max() > GT || dlTiengon.nghich.Max() > GT)
							{
								//Xóa max của nó đi
								lstThuan = new List<float>();
								lstNghich = new List<float>();
								//dlTiengon.thuan.ToList().Remove(dlTiengon.thuan.Max());
								//Tìm max của nó sau khi xóa max đầu tiên
								//Gán giá trị hiển thị lên pm
								if (IsNGTiengOnThuan == 1)
								{
									lstThuan = dlTiengon.thuan.ToList();
									lstThuan.RemoveAll(x => x == lstThuan.Max());
									dtTiengon.GiatriThuan.Value = lstThuan.Max();
								}
								else
								{
									dtTiengon.GiatriThuan.Value = dlTiengon.thuan.Max();
								}
								//dlTiengon.nghich.ToList().Remove(dlTiengon.nghich.Max());
								//Tìm max của nó sau khi xóa max đầu tiên
								//Gán giá trị hiển thị lên PM
								if (IsNGTiengOnNghich == 1)
								{
									lstNghich = dlTiengon.nghich.ToList();
									lstNghich.RemoveAll(x => x == lstNghich.Max());
									dtTiengon.GiatriNghich.Value = lstNghich.Max();
								}
								else
								{
									dtTiengon.GiatriNghich.Value = dlTiengon.nghich.Max();
								}
							}
						}
						else
						{
							dtTiengon.GiatriThuan.Value = dlTiengon.thuan.Max();
							dtTiengon.GiatriNghich.Value = dlTiengon.nghich.Max();
						}
						IsNGTiengOnNghich = 0;
						IsNGTiengOnThuan = 0;

						CheckAmsac("Forward");
						CheckAmsac("Backward");

						currentStageRun = 17;
						break;
					// Check Amsac
					case 17:
						checkRotaryDirection();
						currentStageRun = 19;
						OffMotorCount();
						break;
					// Finish Forward
					case 19:
						log.Info("Chu trinh - 19 - Hoan tat lay du lieu - bat dau ghi ra file");

						lbdStatus.Value = "Hoàn tất lấy dữ liệu";

						//MessageBox.Show("Done");
						//Dispatcher.Invoke(new Action(() =>
						//{
						//    //DataInitialize();
						//}));
						XuatRaFileCSVvaExcel();
						lbdSoThuTuSanPham.Value = "";
						currentStageRun = 0;
						break;
					default:
						break;
				}
			}
		}

		private void CapNhatGiaTriVongQuayManual(string bCode)
		{
			try
			{
				htVongquay = float.Parse(bCode);
			}
			catch { }
		}

		/// <summary>
		/// Cập nhật màu của các ô Data trong giao diện khi giá trị dữ liệu thay đổi
		/// </summary>
		private void UpdateDisplayColor()
		{
			Dispatcher.Invoke(() =>
			{
				float tempValue, tempMax, tempMin;
				tempValue = dtVongquay.GiatriThuan.Value; tempMax = dtVongquay.Max; tempMin = dtVongquay.Min;
				dtVongquay.GiatriThuan.Color = checkInRange(tempValue, tempMax, tempMin);
				tempValue = dtVongquay.GiatriNghich.Value; tempMax = dtVongquay.Max; tempMin = dtVongquay.Min;
				dtVongquay.GiatriNghich.Color = checkInRange(tempValue, tempMax, tempMin);

				tempValue = dtDongdien.GiatriThuan.Value; tempMax = dtDongdien.Max; tempMin = dtDongdien.Min;
				dtDongdien.GiatriThuan.Color = checkInRange(tempValue, tempMax, tempMin);
				tempValue = dtDongdien.GiatriNghich.Value; tempMax = dtDongdien.Max; tempMin = dtDongdien.Min;
				dtDongdien.GiatriNghich.Color = checkInRange(tempValue, tempMax, tempMin);

				tempValue = dtNhapluc.GiatriThuan.Value; tempMax = dtNhapluc.Max; tempMin = dtNhapluc.Min;
				dtNhapluc.GiatriThuan.Color = checkInRange(tempValue, tempMax, tempMin);
				tempValue = dtNhapluc.GiatriNghich.Value; tempMax = dtNhapluc.Max; tempMin = dtNhapluc.Min;
				dtNhapluc.GiatriNghich.Color = checkInRange(tempValue, tempMax, tempMin);

				tempValue = dtDorung.GiatriThuan.Value; tempMax = dtDorung.Max; tempMin = dtDorung.Min;
				dtDorung.GiatriThuan.Color = checkInRange(tempValue, tempMax, tempMin);
				tempValue = dtDorung.GiatriNghich.Value; tempMax = dtDorung.Max; tempMin = dtDorung.Min;
				dtDorung.GiatriNghich.Color = checkInRange(tempValue, tempMax, tempMin);

				tempValue = dtTiengon.GiatriThuan.Value; tempMax = dtTiengon.Max; tempMin = dtTiengon.Min;
				dtTiengon.GiatriThuan.Color = checkInRange(tempValue, tempMax, tempMin);
				tempValue = dtTiengon.GiatriNghich.Value; tempMax = dtTiengon.Max; tempMin = dtTiengon.Min;
				dtTiengon.GiatriNghich.Color = checkInRange(tempValue, tempMax, tempMin);
			});
		}

		/// <summary>
		/// Hàm kiểm tra dữ liệu trong khoảng cho phép
		/// Trả về giá trị 1 nếu OK, 2 nếu NG, 0 nếu chưa đủ đk đánh giá
		/// </summary>
		private int checkInRange(float tempValue, float tempMax, float tempMin)
		{
			if (tempValue > 0.00001)
			{
				if ((tempValue >= tempMin) && (tempValue <= tempMax)) return 1;
				else return 2;
			}
			else return 0;
		}

		/// <summary>
		/// Kiểm tra đủ điều kiện chạy Auto
		/// </summary>
		private bool CheckConditionRun()
		{
			// 30-11: Them dieu kien kiem tra dien ap dung voi tieu chuan, neu khong thi bao loi
			if (dtDienap.Max > 0)
			{
				if (Check == 0)
				{
					if (((Math.Abs(dtDienap.Max - htDienap)) / dtDienap.Max) > 0.1)
					{
						MessageBox.Show("Cai dat dien ap sai tieu chuan!!!");
						return false;
					}
				}
			}
			else
			{
				MessageBox.Show("Dien ap tieu chuan = 0 !!!");
				return false;
			}

			if ((lbdMaOrder.Value != "") && (lbdSoThuTuSanPham.Value != "") && (lbdPID.Value != "") && (lbdNguoiVanHanh.Value != ""))
			{
				//Kiểm tra điều khiển điện áp
				//if (conditionVolt)
				//{
				//lbdStatus.Value = "Ready";
				return true;
				//}
				//else
				//{
				//lbdStatus.Value = "Mất pha, kiểm tra cấp nguồn cho động cơ";
				//}
			}


			return false;
		}

		/// <summary>
		/// Khởi tạo lại giá trị đo, đồ thị khi bắt đầu chu trình Auto mới
		/// </summary>
		private void ResetValueData()
		{
			// Chart Busy
			chartBusy = false;

			// Reset xuất đặc biệt
			specialOutputObject = new specialOutputObject();

			// Reset giao diện
			Dispatcher.Invoke(() =>
			{
				dtVongquay.GiatriThuan.Color = 0;
				dtVongquay.GiatriNghich.Color = 0;
				dtDongdien.GiatriThuan.Color = 0;
				dtDongdien.GiatriNghich.Color = 0;
				dtNhapluc.GiatriThuan.Color = 0;
				dtNhapluc.GiatriNghich.Color = 0;
				dtTiengon.GiatriThuan.Color = 0;
				dtTiengon.GiatriNghich.Color = 0;
				dtDorung.GiatriThuan.Color = 0;
				dtDorung.GiatriNghich.Color = 0;
			});

			// Khởi tạo giá trị ht
			htVongquay = 0;
			htDongdien = 0;
			htNhapluc = 0;
			htDorung = 0;
			htTiengon = 0;
			htDienap = 0;
			htDorung = 0;

			// Khởi tạo các giá trị hiển thị
			dtVongquay.GiatriThuan.Value = (float)-0.00001;
			dtVongquay.GiatriNghich.Value = (float)-0.00001;
			dtDongdien.GiatriThuan.Value = (float)-0.00001;
			dtDongdien.GiatriNghich.Value = (float)-0.00001;
			dtNhapluc.GiatriThuan.Value = (float)-0.00001;
			dtNhapluc.GiatriNghich.Value = (float)-0.00001;
			dtDorung.GiatriThuan.Value = (float)-0.00001;
			dtDorung.GiatriNghich.Value = (float)-0.00001;
			dtTiengon.GiatriThuan.Value = (float)-0.00001;
			dtTiengon.GiatriNghich.Value = (float)-0.00001;
			dtHuongquay.giatriThuan.Value = 0;
			dtHuongquay.giatriNghich.Value = 0;
			dtAmsac.giatriThuan.Value = 0;
			dtAmsac.giatriNghich.Value = 0;
			lbdDienap.Value = "";
			lbdTanso.Value = "";
			dtTiengon.giatriLech.Color = 0;

			for (int i = 0; i < 1000; i++)
			{
				dlDorung.thuan[i] = (float)0.00001;
				dlDorung.nghich[i] = (float)0.00001;
				dlTiengon.thuan[i] = (float)0.00001;
				dlTiengon.nghich[i] = (float)0.00001;
			}

			// Khởi tạo lại đồ thị
			try
			{
				PlotChart(0);
			}
			catch { }
		}

		/// <summary>
		/// Tắt lấy dữ liệu vòng quay PLC
		/// </summary>
		private void OffMotorCount()
		{
			plcFX5U.SetDevice("M100", 0);
		}
		/// <summary>
		/// Bật lấy dữ liệu vòng quay PLC
		/// </summary>
		private void OnMotorCount()
		{
			plcFX5U.SetDevice("M100", 1);
		}

		private void LabelF9_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			var temp = MessageBox.Show("RESET ALL?", "TEST", MessageBoxButton.OKCancel);
			if (temp == MessageBoxResult.OK) DataInitialize();
		}

		private void mainWD_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			File.WriteAllText(pathSub, $"{cboSub.SelectedIndex}");
			plcFX3G_Shiv.Close();
			plcFX5U.Close();
			continuesThread.Abort();
			if (PLC != null) PLC.Abort();
			//PLC_Shiv.Abort();
			try { if (COMCurrent != null) COMCurrent.Close(); }
			catch { }
			try { if (COMNoise != null) COMNoise.Close(); }
			catch { }
			//Đóng ứng dụng Excel

			//myDataTemplateWorksheet.Application.Interactive = true;
			//try
			//{
			//	//myExcel.ActiveWorkbook.Close(true, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//	var temp = myExcel.Workbooks.Count;
			//	myExcel.ActiveWorkbook.Save();
			//	switch (temp)
			//	{
			//		case 1:
			//			myExcel.Workbooks[1].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//			break;
			//		case 2:
			//			myExcel.Workbooks[1].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//			myExcel.ActiveWorkbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//			break;
			//		default:
			//			myExcel.ActiveWorkbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//			myExcel.Workbooks[2].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//			myExcel.Workbooks[1].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//			myExcel.Quit();
			//			break;
			//	}
			//}
			//catch { }
		}

		private void lblMaOrder_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			SHIV_PhongCachAm.PopupWindows.inputBarcode temp = new PopupWindows.inputBarcode("Barcode mã Order");
			//temp.LabelText = "Barcode mã Order";
			temp.OrderChange += CapnhatGiatriOrderPID;
			temp.ShowDialog();
		}

		/// <summary>
		/// nvthao
		/// Tổng hợp giá trị thành từng line dạng csv để ghi ra file
		/// </summary>
		private void XuatRaFileCSVvaExcel()
		{
			try
			{
				this.sendDataTCP("4", "2");
			}
			catch (Exception ex)
			{
			}

			if (!Directory.Exists("F:\\LogSHIV")) Directory.CreateDirectory("F:\\LogSHIV");
			string path = "F:\\LogSHIV\\" + lbdSoThuTuSanPham.Value + ".csv";
			string[] lines = new string[28];
			lines[0] = $"Người kiểm tra,{lbdNguoiVanHanh.Value},STT Sản phẩm,{lbdSoThuTuSanPham.Value},Mã Order,{lbdMaOrder.Value}";
			lines[1] = $"PID,{lbdPID.Value},Mô tả sản phẩm,Giảm tốc,";
			lines[2] = $"";
			lines[3] = $"Điện áp tiêu chuẩn,Điện áp thực tế,Tần số tiêu chuẩn,Tần số thực tế";
			lines[4] = $"{lbTcDienap.Value},,{lbTcTanso.Value},,";
			lines[5] = $"";
			lines[6] = $"Thông số kiểm tra,Giá trị tiêu chuẩn,Chiều thuận,Chiều nghịch,Độ lệch,Đánh giá";
			lines[7] = $"Giá trị vòng quay,{lbTcVongquay.Value}," + dtVongquay.GetString();
			lines[8] = $"Hướng quay trục xuất lực,,,,,,";
			lines[9] = $"Giá trị dòng điẹn,{lbTcDongdien.Value}," + dtDongdien.GetString();
			lines[10] = $"Giá trị nhập lực,{lbTcNhapluc.Value}," + dtNhapluc.GetString();
			lines[11] = $"Giá trị độ rung,{lbTcDorung.Value}," + dtDorung.GetString();
			lines[12] = $"Giá trị tiếng ồn,{lbTcTiengon.Value}," + dtTiengon.GetString();
			lines[13] = $"Âm sắc,,,,,,";
			lines[14] = $",,,,,,,,";
			// Array Data Noise, Current
			lines[15] = $",,,,,,,,";
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				lines[16] += dlTiengon.thuan[i].ToString("0.00") + ",";
			}
			lines[17] = $",,,,,,,,";
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				lines[18] += dlTiengon.nghich[i].ToString("0.00") + ",";
			}
			//
			lines[19] = $",,,,,,,,";
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				lines[20] += dlDorung.thuan[i].ToString("0.00") + ",";
			}
			lines[21] = $",,,,,,,,";
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				lines[22] += dlDorung.nghich[i].ToString("0.00") + ",";
			}
			// Âm sắc thuận
			if (dtAmsac.giatriThuan.Value == 5) lines[23] = $"Đánh giá âm sắc :,OK,";
			else lines[23] = $"Đánh giá âm sắc :,NG,";
			//tempRange.Value2 = dtAmsac.giatriThuan.Value;
			if (dtAmsac.giatriNghich.Value == 5) lines[23] += "OK";
			else lines[23] += "NG";
			// Hướng quay
			if (dtHuongquay.giatriDanhgia.Value == 1) lines[24] = $"Đánh giá chiều quay :,OK,";
			else lines[24] = $"Đánh giá chiều quay :,OK,";
			if (lstNghich.Count > 0 && lstThuan.Count > 0)
			{
				lines[25] = $",,,,,,,,";
				lines[26] = "Tiếng ồn ngoại lai chiều thuân: " + $"{dlTiengon.thuan.Max().ToString("0.00")}";
				lines[27] = "Tiếng ồn ngoại lai chiều nghịch: " + $"{dlTiengon.nghich.Max().ToString("0.00")}";
			}
			lstNghich = new List<float>();
			lstThuan = new List<float>();
			// Ghi tất cả thông tin ra csv
			string errLogPath = $"F:\\ERRLog\\ERR_Ecel_{DateTime.Now.ToString("yyMMdd")}.txt";
			try
			{
				log.Info("Ghi ra file csv");
				File.WriteAllLines(path, lines, Encoding.UTF8);
				#region đẩy data file csv lên server
				//Update file csv lên ftp 
				DocUtils.InitFTPQLSX();
				string PathServer = @"PCA_Data\PCAHYP\CSV";
				DocUtils.UploadFile(path, PathServer);
				#endregion
			}
			catch (Exception ex)
			{
				if (File.Exists(errLogPath))
				{
					File.AppendAllText(errLogPath, $"ERR_Excel - Cannot write CSV - {DateTime.Now.ToString()} + {ex}" + "\r\n");
				}
				else
				{
					File.WriteAllText(errLogPath, $"ERR_Excel - Cannot write CSV - {DateTime.Now.ToString()} + {ex}" + "\r\n");
				}
			}




			//if (myDataTemplateWorksheet != null)
			//{
			//countDatainTemplate += 1;
			//var tempRange = (Excel.Range)myDataTemplateWorksheet.Cells[countDatainTemplate, 1];
			//	try
			//	{
			//		log.Info("Ghi ra file Excel");
			//	ExcelTemplateInput(tempRange);
			//	}
			//	catch (Exception ex)
			//	{
			//		if (File.Exists(errLogPath))
			//		{
			//			File.AppendAllText(errLogPath, $"ERR_Excel - Cannot write Excel - {DateTime.Now.ToString()} + {ex}" + "\r\n");
			//		}
			//		else
			//		{
			//			File.WriteAllText(errLogPath, $"ERR_Excel - Cannot write Excel - {DateTime.Now.ToString()} + {ex}" + "\r\n");
			//		}
			//	}
			//}


			log.Info("Upload du lieu am thanh len server");
			string filename = "PCA\\HYPONIC\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_fwd.wav";
			string fullname = "F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_fwd.wav";
			string filenameR = "PCA\\HYPONIC\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_rwd.wav";
			string fullnameR = "F:\\RecordSoundDataMotor\\" + lbdMaOrder.Value + "_" + lbdSoThuTuSanPham.Value + "_rwd.wav";
			try
			{
				FtpUploadFile(filename, fullname, uri, user, pass);
				FtpUploadFile(filenameR, fullnameR, uri, user, pass);
			}
			catch (System.Exception ex)
			{
				log.Error($"Loi upload du lieu am thanh - {ex}");
				//MessageBox.Show("Can't find FTP Server", "Missing");
			}

			/*
            * Cất kết quả công đoạn 9 vào trong database
            */
			int productID = 0;
			List<ProductCheckHistoryDetailModel> lstListDetail = new List<ProductCheckHistoryDetailModel>();
			AndonDetailModel andonDetail = new AndonDetailModel();

			ProductCheckHistoryDetailPCAModel _pca = new ProductCheckHistoryDetailPCAModel();
			// Ghi ra file Excel
			try
			{
				Dispatcher.Invoke(() =>
				{
					_pca.DateLR = DateTime.Now; // Ngày tháng năm
					_pca.STT = _qrCode.Split(' ')[0];      //lblSTTSanpham.Content == null ? "" : lblSTTSanpham.Content.ToString().Trim(); //STT sản phẩm
					_pca.OrderCode = lblMaOrder.Content == null ? "" : lblMaOrder.Content.ToString();
					if (_dtData.Rows.Count <= 0)
					{
						_pca.ProductID = 0;
					}
					else
						_pca.ProductID = TextUtils.ToInt(_dtData.Rows[0]["ProductID"]);               //ProductID
					_pca.PID = lblPID.Content == null ? "" : lblPID.Content.ToString().Trim();    //PID
					_pca.QRCode = _qrCode;                                                        //QRCode
					_pca.NguoiVanHanh = lblNguoiVanhanh.Content == null ? "" : lblNguoiVanhanh.Content.ToString().Trim();//Người vận hành
					_pca.MotaSanPham = lblMotaSanpham.Content == null ? "" : lblMotaSanpham.Content.ToString().Trim();//Mô tả sản phẩm
					_pca.GiamToc = lblGiamtoc.Content == null ? "" : lblGiamtoc.Content.ToString().Trim();// Giảm tốc
					_pca.DienApTieuChuan = lblDienapChuan.Content == null ? "" : lblDienapChuan.Content.ToString().Trim();//Điện áp tiêu chuẩn
					_pca.TanSoTieuChuan = lblTansoChuan.Content == null ? "" : lblTansoChuan.Content.ToString().Trim();// Tần số tiêu chuẩn	

					_pca.GiaTriVongQuayChuan = lblTcVongquay.Content == null ? "" : lblTcVongquay.Content.ToString().Trim();//Giá trị vong quay chuẩn
																															//_pca.GiaTriVongQuayChuan = TextUtils.ToString(dtVongquay.GiatriNghich.Value);


					_pca.GiaTriDongDienChuan = lblTcDongdien.Content == null ? "" : lblTcDongdien.Content.ToString().Trim();// Giá trị dòng điện chuẩn	
					_pca.GiaTriNhapLucChuan = lblTCNhapluc.Content == null ? "" : lblTCNhapluc.Content.ToString().Trim();//Giá trị nhập lực chuẩn
					_pca.GiaTriDoRungChuan = lblTcDorung.Content == null ? "" : lblTcDorung.Content.ToString().Trim();//Giá trị độ rung chuẩn
					_pca.GiaTriTiengOnChuan = lblTcTiengon.Content == null ? "" : lblTcTiengon.Content.ToString().Trim();//Giá trị tiếng ồn chuẩn
					_pca.DienApThucTe = lblDienapThucte.Content == null ? "" : lblDienapThucte.Content.ToString().Trim();//Điện áp thực tế
					_pca.TanSoThucTe = lblTansoThucte.Content == null ? "" : lblTansoThucte.Content.ToString().Trim();// Tần số thực tế


					//_pca.VongQuayThuan = lblVongquayFwdMax.Content == null ? "" : lblVongquayFwdMax.Content.ToString().Trim();//Vòng quay thuận
					//_pca.VongQuayNghich = lblVongquayBwdMax.Content == null ? "" : lblVongquayBwdMax.Content.ToString().Trim();//Vòng quay nghịch

					_pca.VongQuayThuan = TextUtils.ToString(dtVongquay.GiatriThuan.Value);//Vòng quay thuận
					_pca.VongQuayNghich = TextUtils.ToString(dtVongquay.GiatriNghich.Value);//Vòng quay nghịch


					_pca.DongDienThuan = lblDongdienFwdMax.Content == null ? "" : lblDongdienFwdMax.Content.ToString().Trim();// Dòng điện thuận
					_pca.DongDienNghich = lblDongdienBwdMax.Content == null ? "" : lblDongdienBwdMax.Content.ToString().Trim();//Dòng điện nghịch
					_pca.NhapLucThuan = lblNhaplucFwdMax.Content == null ? "" : lblNhaplucFwdMax.Content.ToString().Trim(); // Nhập lực thuận	
					_pca.NhapLucNghich = lblNhaplucBwdMax.Content == null ? "" : lblNhaplucBwdMax.Content.ToString().Trim(); //Nhập lực nghịch
					_pca.DoRungThuan = lblDorungFwdMax.Content == null ? "" : lblDorungFwdMax.Content.ToString().Trim();// Độ rung thuận
					_pca.DoRungNghich = lblDorungBwdMax.Content == null ? "" : lblDorungBwdMax.Content.ToString().Trim();// Độ rung nghịch


					//_pca.TiengOnThuan = lblTiengonFwdMax.Content == null ? "" : lblTiengonFwdMax.Content.ToString().Trim();// Tiếng ồn thuận
					//_pca.TiengOnNghich = lblTiengonBwdMax.Content == null ? "" : lblTiengonBwdMax.Content.ToString().Trim();//Tiếng ồn nghịch
					_pca.TiengOnThuan = TextUtils.ToString(dtTiengon.GiatriThuan.Value);
					_pca.TiengOnNghich = TextUtils.ToString(dtTiengon.GiatriNghich.Value);


					if (dtAmsac.giatriThuan.Value == 5) _pca.AmSacThuan = "OK";//Âm sắc thuận
					else _pca.AmSacThuan = "NG";
					if (dtAmsac.giatriNghich.Value == 5) _pca.AmSacNghich = "OK";//Âm sắc nghịch
					else _pca.AmSacNghich = "NG";
					if (dtHuongquay.giatriDanhgia.Value == 1) _pca.HuongQuay = "OK";//Hướng quay
					else _pca.HuongQuay = "NG";

					//_pca.XuatDacBiet = TextUtils.ToString(endRangeCollum);//Vị trí điền xuất đặc biệt
				});
			}
			catch
			{
			}

			try
			{

				int count = _dtData.Rows.Count;
				productID = TextUtils.ToInt(_dtData.Rows[0]["ProductID"]);

				for (int j = 0; j < count; j++)
				{
					Dispatcher.Invoke(() =>
					{
						try
						{
							ProductCheckHistoryDetailModel cModel = new ProductCheckHistoryDetailModel();
							cModel.ProductStepID = _stepID;
							cModel.ProductStepCode = "CD14";
							cModel.ProductStepName = _stepName;
							cModel.SSortOrder = TextUtils.ToInt(_dtData.Rows[j]["SSortOrder"]);

							cModel.ProductWorkingID = TextUtils.ToInt(_dtData.Rows[j]["WorkingID"]);
							cModel.ProductWorkingName = TextUtils.ToString(_dtData.Rows[j]["WorkingName"]);
							cModel.WSortOrder = TextUtils.ToInt(_dtData.Rows[j]["SortOrder"]);

							cModel.WorkerCode = lblNguoiVanhanh.Content == null ? "" : lblNguoiVanhanh.Content.ToString().Trim();
							cModel.StandardValue = TextUtils.ToString(_dtData.Rows[j]["StandardValue"]);
							cModel.ValueType = TextUtils.ToInt(_dtData.Rows[j]["ValueType"]);
							int stt = cModel.WSortOrder;
							string realValue = "";
							int result = 1;
							switch (stt)
							{
								case 10://Điện áp vận hành -- check mark
									realValue = lblDienapThucte.Content == null ? "" : lblDienapThucte.Content.ToString();
									break;
								case 20://Tần số dòng điện Hz -- check mark
									realValue = lblTansoThucte.Content == null ? "" : lblTansoThucte.Content.ToString();
									//if (lblOKXuatluc.Content.ToString() == "NG") result = 0;
									break;
								case 30://Dòng điện kiểm tra vận hành
									realValue = lblDongdienFwdMax.Content == null ? "" : lblDongdienFwdMax.Content.ToString();
									if (dtDongdien.GiatriDanhgia.Value.ToString() == "0") result = 0;
									break;
								case 40://Dung lượng nhập lực không tải
									realValue = lblNhaplucFwdMax.Content == null ? "" : lblNhaplucFwdMax.Content.ToString();
									if (dtNhapluc.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
									break;
								case 50://Kiểm tra độ rung chiều F
									realValue = lblDorungFwdMax.Content == null ? "" : lblDorungFwdMax.Content.ToString();
									if (dtDorung.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
									break;
								case 60://Kiểm tra độ rung chiều R
									realValue = lblDorungBwdMax.Content == null ? "" : lblDorungBwdMax.Content.ToString();
									if (dtDorung.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
									break;
								case 70://Hướng quay của trục xuất lực-- check mark
									realValue = dtHuongquay.giatriDanhgia.Value == 1 ? "OK" : "NG";
									if (dtHuongquay.giatriDanhgia.Value != 1) result = 0;
									break;
								case 80://Số vòng quay trục xuất lực
										//realValue = lblVongquayFwdMax.Content == null ? "" : lblVongquayFwdMax.Content.ToString();
									realValue = TextUtils.ToString(dtVongquay.GiatriNghich.Value);
									if (dtVongquay.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
									break;


								case 90://Kiểm tra tiếng ồn không tải chiều F
										//realValue = lblTiengonFwdMax.Content == null ? "" : lblTiengonFwdMax.Content.ToString();
									realValue = TextUtils.ToString(dtTiengon.GiatriThuan.Value);
									if (dtTiengon.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
									break;
								case 100://Kiểm tra tiếng ồn không tải chiều R
										 //realValue = lblTiengonBwdMax.Content == null ? "" : lblTiengonBwdMax.Content.ToString();
									realValue = TextUtils.ToString(dtTiengon.GiatriNghich.Value);
									if (dtTiengon.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
									break;



								//case 90://Kiểm tra tiếng ồn không tải chiều F
								//	realValue = lblTiengonFwdMax.Content == null ? "" : lblTiengonFwdMax.Content.ToString();
								//	if (dtTiengon.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
								//	break;
								//case 100://Kiểm tra tiếng ồn không tải chiều R
								//	realValue = lblTiengonBwdMax.Content == null ? "" : lblTiengonBwdMax.Content.ToString();
								//	if (dtTiengon.GiatriDanhgia.Value.ToString().ToUpper() == "0") result = 0;
								//	break;
								case 1://Xác nhận số đóng giảm tốc hoặc mác dán giảm tốc
									realValue = lbdGiamToc.Value.ToString();// lblGiamtoc.Content == null ? "" : lblGiamtoc.Content.ToString();
																			//if (dt.Content.ToString() == "0") result = 0;
									break;
								case 45://Kiểm tra âm sắc-- check mark
									realValue = dtAmsac.giatriDanhgia.Value == 1 ? "OK" : "NG";// lblAmsacThuan.Content == null ? "" : lblAmsacThuan.Content.ToString();
									if (dtAmsac.giatriDanhgia.Value != 1) result = 0;
									break;
								default:
									break;
							}
							cModel.RealValue = TextUtils.ToString(realValue);
							cModel.StatusResult = result;

							cModel.ValueTypeName = cModel.ValueType == 1 ? "Giá trị\n数値" : "Check mark";
							cModel.EditValue1 = "";
							cModel.EditValue2 = "";

							cModel.ProductID = productID;
							cModel.QRCode = _qrCode;// lblSTTSanpham.Content + " " + lblPID.Content;
							cModel.OrderCode = lblMaOrder.Content == null ? "" : lblMaOrder.Content.ToString();
							cModel.PackageNumber = _tienTo.Contains("-") ? _tienTo.Split('-')[1] : "";
							cModel.QtyInPackage = _stt;
							cModel.Approved = "";
							cModel.Monitor = "";
							cModel.DateLR = DateTime.Now;
							cModel.EditContent = "";
							cModel.EditDate = DateTime.Now;
							cModel.ProductCode = _productCode;

							cModel.ProductOrder = _order;
							ComboBoxItem item = (ComboBoxItem)cboSub.SelectedItem;
							cModel.Line = item.Content.ToString().Trim();
							lstListDetail.Add(cModel);
							//ProductCheckHistoryDetailBO.Instance.Insert(cModel);
						}
						catch
						{
						}
					});
				}
			}
			catch (Exception ex)
			{
				File.AppendAllText($"F:\\SaveLog\\ErrorLog_{DateTime.Now.ToString("yyyy-MM-dd")}.txt"
				   , DateTime.Now + ": Loi cat ket qua check.\n" + ex.ToString() + Environment.NewLine);
			}

			try
			{
				Dispatcher.Invoke(() =>
				{
					//Cất vào bảng AndonDetail
					//AndonDetailModel andonDetail = new AndonDetailModel();
					andonDetail.ProductCode = _productCode;
					andonDetail.ProductID = productID;
					andonDetail.ProductStepID = _stepID;
					andonDetail.QrCode = (lblSTTSanpham.Content == null ? "" : lblSTTSanpham.Content) + " " + (lblPID.Content == null ? "" : lblPID.Content);
					andonDetail.OrderCode = lblMaOrder.Content == null ? "" : lblMaOrder.Content.ToString();
					andonDetail.ProductStepCode = "CD14";
					//andonDetail.PeriodTime = 0;
					if (_PeriodTime > 0 && _PeriodTime < 200)
					{
						andonDetail.Type = 1;
						andonDetail.PeriodTime = _PeriodTime;
					}
					else
					{
						andonDetail.Type = 3;
						andonDetail.PeriodTime = _PeriodTime;
					}
					andonDetail.StartTime = _startMakeTime;
					andonDetail.EndTime = DateTime.Now;
					andonDetail.MakeTime = TextUtils.ToInt(Math.Round((DateTime.Now - _startMakeTime).TotalSeconds, 0));
					andonDetail.Type = 3;
					andonDetail.WorkerCode = lblNguoiVanhanh.Content == null ? "" : lblNguoiVanhanh.Content.ToString().Trim();

					//AndonDetailBO.Instance.Insert(andonDetail);
				});
			}
			catch (Exception ex)
			{
				//File.AppendAllText("F:\\ErrorLog.txt"
				//		, DateTime.Now + ": Loi cat vao bang andondetail.\n" + ex.ToString() + Environment.NewLine);
			}

			saveData(lstListDetail, andonDetail, _pca);
			try
			{
				TextUtils.ExcuteProcedure("spInsertMasterPCA",
											new string[] { "@QrderCode", "@CreatedBy", "@CreatedDate", "@DateLR", "@OrderCode", "@ProductCode", "@ProductID", "@UpdatedBy", "@UpdatedDate" },
											new object[] { _pca.QRCode, _pca.NguoiVanHanh, DateTime.Now, DateTime.Now, _productCode, productID, _pca.NguoiVanHanh, DateTime.Now });
			}
			catch { }
		}

		async void saveData(List<ProductCheckHistoryDetailModel> lstListDetail, AndonDetailModel andonDetail, ProductCheckHistoryDetailPCAModel _productCheckHistoryDetailPCAModel)
		{
			Task task1 = Task.Factory.StartNew(() =>
			{
				foreach (ProductCheckHistoryDetailModel item in lstListDetail)
				{
					ProductCheckHistoryDetailBO.Instance.Insert(item);
				}
			}
			);

			Task task2 = Task.Factory.StartNew(() =>
			{
				AndonDetailBO.Instance.Insert(andonDetail);
			}
			);

			Task task3 = Task.Factory.StartNew(() =>
			{
				ProductCheckHistoryDetailPCABO.Instance.Insert(_productCheckHistoryDetailPCAModel);
			}
			);

			await Task.WhenAll(task1, task2, task3);
		}

		string _order;
		string _productCode;
		string _tienTo = "";
		string _stt = "";
		int _stepID;
		string _stepCode;
		string _stepName;
		/// <summary>
		/// Ghi giá trị xuất đặc biệt 
		/// </summary>
		//private void ExcelTemplateInputSpecial()
		//{
		//	var tempRange = (Excel.Range)myDataTemplateWorksheet.Cells[countDatainTemplate, endRangeCollum];
		//	// Xuất đặc biệt
		//	tempRange.Value2 = specialOutputObject.Info;
		//	tempRange = tempRange.Offset[0, 1];
		//	tempRange.Value2 = specialOutputObject.UserName;
		//	tempRange = tempRange.Offset[0, 1];
		//	// Ghi thêm vào CSV
		//	string path = "F:\\LogSHIV\\" + lbdSoThuTuSanPham.Value + ".csv";
		//	string[] Temps = File.ReadAllLines(path);
		//	string[] tempWrites = new string[50];
		//	Array.Copy(Temps, tempWrites, Temps.Length);
		//	tempWrites[26] = "Special Output," + specialOutputObject.Info + ",By," + specialOutputObject.UserName;
		//	File.WriteAllLines(path, tempWrites, Encoding.UTF8);
		//}

		/// <summary>
		/// Ghi dữ liệu ra file Excel tổng, lần lượt từ trái sang phải theo Template Excel cho sẵn
		/// </summary>
		/// <param name="tempRange"></param>
		//private void ExcelTemplateInput(Excel.Range tempRange)
		//{
		//	Dispatcher.Invoke(() =>
		//	{
		//		// Ngày tháng năm
		//		tempRange.Value2 = DateTime.Now.ToString("MM/dd/yy");
		//		tempRange = tempRange.Offset[0, 1];
		//		// STT Sản phẩm
		//		tempRange.Value2 = lblSTTSanpham.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Order
		//		tempRange.Value2 = lblMaOrder.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// PID
		//		tempRange.Value2 = lblPID.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Người KT vận hành
		//		tempRange.Value2 = lblNguoiVanhanh.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Mô tả SP
		//		tempRange.Value2 = lblMotaSanpham.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Giảm tốc
		//		tempRange.Value2 = lblGiamtoc.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Điện áp tiêu chuẩn
		//		tempRange.Value2 = lblDienapChuan.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Tần số tiêu chuẩn
		//		tempRange.Value2 = lblTansoChuan.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Giá trị vòng quay chuẩn
		//		tempRange.Value2 = lblTcVongquay.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Giá trị dòng điện chuẩn
		//		tempRange.Value2 = lblTcDongdien.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Giá trị nhập lực chuẩn
		//		tempRange.Value2 = lblTCNhapluc.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Giá trị độ rung chuẩn
		//		tempRange.Value2 = lblTcDorung.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Giá trị tiếng ồn chuẩn
		//		tempRange.Value2 = lblTcTiengon.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Điện áp thực tế
		//		tempRange.Value2 = lblDienapThucte.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Tần số thực tế
		//		tempRange.Value2 = lblTansoThucte.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Vòng quay thuận
		//		tempRange.Value2 = lblVongquayFwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Vòng quay nghịch
		//		tempRange.Value2 = lblVongquayBwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Dòng điện thuận
		//		tempRange.Value2 = lblDongdienFwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Dòng điện nghịch
		//		tempRange.Value2 = lblDongdienBwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Nhập lực thuận
		//		tempRange.Value2 = lblNhaplucFwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Nhập lực nghịch
		//		tempRange.Value2 = lblNhaplucBwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Độ rung thuận
		//		tempRange.Value2 = lblDorungFwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Độ rung nghịch
		//		tempRange.Value2 = lblDorungBwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Tiếng ồn thuận
		//		tempRange.Value2 = lblTiengonFwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Tiếng ồn nghịch
		//		tempRange.Value2 = lblTiengonBwdMax.Content;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Âm sắc thuận
		//		if (dtAmsac.giatriThuan.Value == 5) tempRange.Value2 = "OK";
		//		else tempRange.Value2 = "NG";
		//		//tempRange.Value2 = dtAmsac.giatriThuan.Value;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Âm sắc nghịch
		//		if (dtAmsac.giatriNghich.Value == 5) tempRange.Value2 = "OK";
		//		else tempRange.Value2 = "NG";
		//		//tempRange.Value2 = dtAmsac.giatriNghich.Value;
		//		tempRange = tempRange.Offset[0, 1];
		//		// Hướng quay
		//		if (dtHuongquay.giatriDanhgia.Value == 1) tempRange.Value2 = "OK";
		//		else tempRange.Value2 = "NG";
		//		tempRange = tempRange.Offset[0, 1];
		//		// Vị trí điền Xuất đặc biệt
		//		endRangeCollum = tempRange.Column;
		//	});
		//}

		/// <summary>
		/// Nhấn nút F1 tương đương click chuột F1
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EventF1Push_Process(object sender, ExecutedRoutedEventArgs e)
		{
			if (!chartBusy) btnF1_PreviewMouseDown(null, null);
		}
		private void EventSpacePush_Process(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
				if (!chartBusy) btnF1_PreviewMouseDown(null, null);
		}
		/// <summary> Nhấn nút S tương ứng click chuột nhập STT sản phẩm
		/// </summary>
		private void EventSPush_Process(object sender, ExecutedRoutedEventArgs e)
		{
			lblSTTSanpham_MouseDown(null, null);
		}

		/// <summary>
		/// Nhấn F8 hiển thị cửa sổ nhập STT sản phẩm - Đổ ngược dữ liệu
		/// Sau khi lấy STT, kiểm tra để load lại dữ liệu theo STT sản phẩm
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EventF8Push_Process(object sender, ExecutedRoutedEventArgs e)
		{
			SHIV_PhongCachAm.PopupWindows.inputBarcode temp = new PopupWindows.inputBarcode("Barcode load lại dữ liệu:");
			temp.STTSanphamChange += KiemtravsLoadlaidulieu;
			temp.ShowDialog();
		}

		private void EventF7Push_Process(object sender, ExecutedRoutedEventArgs e)
		{
			try
			{
				string subStringOfMediaToFind = "*" + lbdMaOrder.Value + "*" + lbdSoThuTuSanPham.Value + "*" + "_bwd.wav";
				if (mediaPlayerFwdFile) subStringOfMediaToFind = "*" + lbdMaOrder.Value + "*" + lbdSoThuTuSanPham.Value + "*" + "_fwd.wav";
				// Tim kiem file am thanh theo ma san pham
				string[] listFileAudio = Directory.GetFiles("F:\\RecordSoundDataMotor\\", subStringOfMediaToFind);
				if (listFileAudio.Length == 0) return;
				// Lay duong dan file
				string mediaFileUrl = listFileAudio[0];
				if (File.Exists(mediaFileUrl))
					Process.Start("wmplayer.exe", mediaFileUrl);
				mediaPlayerFwdFile = !mediaPlayerFwdFile;
			}
			catch { }
		}

		/// <summary> Kiểm tra định dạng STT sản phẩm, load lại dữ liệu
		/// </summary>
		private void KiemtravsLoadlaidulieu(string bCode)
		{
			if ((bCode.IndexOf(" ") > 0) && (currentStageRun <= 1))
			{
				FindvsLoadData(bCode.Substring(0, bCode.IndexOf(" ")));
			}
		}

		/// <summary>
		/// Tìm file dữ liệu trong folder lưu dữ liệu, nếu có thì Load dữ liệu ra hiển thị trên giao diện
		/// </summary>
		/// <param name="bCode"></param>
		private void FindvsLoadData(string bCode)
		{
			// Tìm kiếm file trong thư mục Csv
			string folderUrl = "F:\\LogSHIV\\";
			string fileUrl = FindFileInFolder(bCode, folderUrl);
			// Kiểm tra nếu tìm được file thì load dữ liệu
			if (File.Exists(fileUrl))
			{
				LoadOldDataFromFile(fileUrl);
			}
			else
			{
				MessageBox.Show("Không tìm được file dữ liệu theo SST sản phẩm vừa nhập!");
			}
		}

		/// <summary>
		/// Chuyển đổi dữ liệu theo đường dẫn file, hiển thị lại vào phần mềm
		/// Tác dụng để kiểm tra lại dữ liệu hàng cũ
		/// </summary>
		/// <param name="fileUrl"></param>
		private void LoadOldDataFromFile(string fileUrl)
		{
			// Khởi tạo lại giá trị
			ResetValueData();

			// Đọc All line
			string[] tempLines = File.ReadAllLines(fileUrl);
			string[] temps = null;
			// Check độ dài
			if (tempLines.Length < 10)
			{
				MessageBox.Show("File thiếu dữ liệu!");
				return;
			}
			// Lấy dữ liệu 
			//lines[0] = $"Người kiểm tra,{lbdNguoiVanHanh.Value},STT Sản phẩm,{lbdSoThuTuSanPham.Value},Mã Order,{lbdMaOrder.Value}";
			temps = tempLines[0].Split(',');
			lbdNguoiVanHanh.Value = temps[1];
			lbdSoThuTuSanPham.Value = temps[3];
			lbdMaOrder.Value = temps[5];
			//lines[1] = $"PID,{lbdPID.Value},Mô tả sản phẩm,Giảm tốc,";
			temps = tempLines[1].Split(',');
			lbdPID.Value = temps[1];
			//lines[2] = $"";
			//lines[3] = $"Điện áp tiêu chuẩn,Điện áp thực tế,Tần số tiêu chuẩn,Tần số thực tế";
			//lines[4] = $"{lbTcDienap.Value},,{lbTcTanso.Value},,";
			temps = tempLines[4].Split(',');
			//lines[5] = $"";
			//lines[6] = $"Thông số kiểm tra,Giá trị tiêu chuẩn,Chiều thuận,Chiều nghịch,Độ lệch,Đánh giá";
			/////
			//string temp = "";
			//temp += GiatriThuan.Value + "," + GiatriNghich.Value + "," + _doLech + ",";
			//if (GiatriDanhgia.Value == 1) temp += "OK,";
			//else temp += "NG,";
			//return temp;
			// Tính toán lại giá trị tiêu chuẩn
			lbTcDienap.Value = temps[0];
			lbTcTanso.Value = temps[2];
			lbTcVongquay.Value = tempLines[7].Split(',')[1];
			lbTcDongdien.Value = tempLines[9].Split(',')[1];
			lbTcNhapluc.Value = tempLines[10].Split(',')[1];
			lbTcDorung.Value = tempLines[11].Split(',')[1];
			lbTcTiengon.Value = tempLines[12].Split(',')[1];
			calculateMaxMinValue();
			//lines[7] = $"Giá trị vòng quay,{lbTcVongquay.Value}," + dtVongquay.GetString();
			temps = tempLines[7].Split(',');
			dtVongquay.GiatriThuan.Value = float.Parse(temps[2]);
			dtVongquay.GiatriNghich.Value = float.Parse(temps[3]);
			//lines[8] = $"Hướng quay trục xuất lực,,,,,,";
			//lines[9] = $"Giá trị dòng điẹn,{lbTcDongdien.Value}," + dtDongdien.GetString();
			temps = tempLines[9].Split(',');
			dtDongdien.GiatriThuan.Value = float.Parse(temps[2]);
			dtDongdien.GiatriNghich.Value = float.Parse(temps[3]);
			//lines[10] = $"Giá trị nhập lực,{lbTcNhapluc.Value}," + dtNhapluc.GetString();
			temps = tempLines[10].Split(',');
			dtNhapluc.GiatriThuan.Value = float.Parse(temps[2]);
			dtNhapluc.GiatriNghich.Value = float.Parse(temps[3]);
			//lines[11] = $"Giá trị độ rung,{lbTcDorung.Value}," + dtDorung.GetString();
			temps = tempLines[11].Split(',');
			dtDorung.GiatriThuan.Value = float.Parse(temps[2]);
			dtDorung.GiatriNghich.Value = float.Parse(temps[3]);
			//lines[12] = $"Giá trị tiếng ồn,{lbTcTiengon.Value}," + dtTiengon.GetString();
			temps = tempLines[12].Split(',');
			dtTiengon.GiatriThuan.Value = float.Parse(temps[2]);
			dtTiengon.GiatriNghich.Value = float.Parse(temps[3]);
			//lines[13] = $"Âm sắc,,,,,,";
			//lines[14] = $",,,,,,,,";
			// Array Data Noise, Current
			//lines[15] = $",,,,,,,,";
			temps = tempLines[16].Split(',');
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				dlTiengon.thuan[i] = (float.Parse(temps[i]));
			}
			//lines[17] = $",,,,,,,,";
			temps = tempLines[18].Split(',');
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				dlTiengon.nghich[i] = (float.Parse(temps[i]));
			}
			//
			//lines[19] = $",,,,,,,,";
			temps = tempLines[20].Split(',');
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				dlDorung.thuan[i] = (float.Parse(temps[i]));
			}
			//lines[21] = $",,,,,,,,";
			temps = tempLines[22].Split(',');
			for (int i = 0; i < numberDataPerTurn; i++)
			{
				dlDorung.nghich[i] = (float.Parse(temps[i]));
			}
			//// Line 23 Lấy giá trị âm sắc
			//temps = tempLines[23].Split(',');
			//if (temps[1] == "OK") dtAmsac.giatriThuan.Value = 5;
			//else dtAmsac.giatriThuan.Value = 15;
			//if (temps[2] == "OK") dtAmsac.giatriNghich.Value = 5;
			//else dtAmsac.giatriNghich.Value = 15;
			//// Line 24 Lấy giá trị hướng quay
			//temps = tempLines[24].Split(',');
			//if (temps[1] == "OK") dtHuongquay.giatriDanhgia.Value = 1;
			//else dtHuongquay.giatriDanhgia.Value = 2;
			// Load lại đồ thị
			try
			{
				PlotChart(0);
			}
			catch { }

		}

		/// <summary>
		/// Tìm File có tên chứa STT sản phẩm - nếu có thì trả về đường dẫn file, nếu không trả về ""
		/// </summary>
		/// <param name="bCode"></param>
		/// <param name="folderUrl"></param>
		/// <returns></returns>
		private string FindFileInFolder(string bCode, string folderUrl)
		{
			string[] files = Directory.GetFiles(folderUrl, bCode + ".csv", SearchOption.AllDirectories);
			if ((files == null) || (files.Count() < 1)) return "";
			else return files[0];
		}

		/// <summary>
		/// Nhấn phím F10 - Xuất đặc biệt, hiển thị Form xuất đặc biệt
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EventF10Push_Process(object sender, ExecutedRoutedEventArgs e)
		{

			//checkSpecialOutput tempSO = new checkSpecialOutput();
			//tempSO.EventConfirmButton += ProcessSpecialOutput;
			//tempSO.ShowDialog();
		}

		/// <summary>
		/// Xử lý lựa chọn xuất đặc biệt - (đầu ra từ form xuất đặc biệt)
		/// </summary>
		/// <param name="OutputInfo"></param>
		/// <param name="LeaderConfirm"></param>
		//private void ProcessSpecialOutput(string OutputInfo, string LeaderConfirm)
		//{
		//	specialOutputObject.UserName = LeaderConfirm;
		//	specialOutputObject.Info = OutputInfo;
		//	ExcelTemplateInputSpecial();
		//}

		/// <summary>
		/// Click chuột F10 - tương đương nhấn phím
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EventF10Push_Process_Mouse(object sender, MouseButtonEventArgs e)
		{
			//EventF10Push_Process(null, null);
		}

		private void EventF8Push_Process(object sender, MouseButtonEventArgs e)
		{
			SHIV_PhongCachAm.PopupWindows.inputBarcode temp = new PopupWindows.inputBarcode("Barcode load lại dữ liệu:");
			temp.STTSanphamChange += KiemtravsLoadlaidulieu;
			temp.ShowDialog();
		}

		/// <summary>
		/// Nhấn phím O tương đương click nhập Order
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EventOPush_Process(object sender, ExecutedRoutedEventArgs e)
		{
			lblMaOrder_PreviewMouseDown(null, null);
		}

		private void lblSTTSanpham_MouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				SHIV_PhongCachAm.PopupWindows.inputSTT temp = new PopupWindows.inputSTT("Barcode số thứ tự sản phẩm:", "OrderCodeSample");
				//temp.LabelText = "Barcode số thứ tự sản phẩm:";
				temp.STTSanphamChange += CapnhatGiatriSTTSpham;
				temp.ShowDialog();
			}
			catch { }
		}

		private void BtnUpdateData_Click(object sender, RoutedEventArgs e)
		{
			return;

			//((Button)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
			//// Them dieu kien cho phep update du lieu - leanh.tu
			//if (currentStageRun <= 1)
			//{
			//	//Đóng ứng dụng
			//	try
			//	{
			//		var temp = myExcel.Workbooks.Count;
			//		myExcel.ActiveWorkbook.Save();
			//		switch (temp)
			//		{
			//			case 1:
			//				myExcel.Workbooks[1].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//				break;
			//			case 2:
			//				myExcel.Workbooks[1].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//				myExcel.ActiveWorkbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//				break;
			//			default:
			//				myExcel.ActiveWorkbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//				myExcel.Workbooks[2].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//				myExcel.Workbooks[1].Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
			//				myExcel.Quit();
			//				break;
			//		}
			//	}
			//	catch
			//	{
			//	}
			//	killAppExcel();
			//	//myExcel = new Excel.Application();
			//	// Copy DB File	DB và KH từ Server
			//	string DBServerStr = Settingsm.Default.DBServer;
			//	string KHServerStr = Settingsm.Default.KHServer;
			//	string DbLocalStri = Settingsm.Default.DBLocation;
			//	string KhLoalStri = DbLocalStri.Substring(0, DbLocalStri.LastIndexOf("\\") + 1) + "KHLocal.xlsm";

			//	if (File.Exists(DBServerStr)) File.Copy(DBServerStr, DbLocalStri, true);
			//	if (File.Exists(KHServerStr)) File.Copy(KHServerStr, KhLoalStri, true);

			//	// Load DB File _ Cập nhật Database khi bắt đầu chương trình
			//	if (Settingsm.Default.DBLocation != "")
			//	{
			//		if (File.Exists(Settingsm.Default.DBLocation))
			//			UpdateExcelDatabaseWhenChangeLink(Settingsm.Default.DBLocation);
			//		//OpenExcelResultFile();
			//	}
			//}
		}

		private void MainWD_Activated(object sender, EventArgs e)
		{

		}

		private void EventF7Push_Process(object sender, MouseButtonEventArgs e)
		{
			//lbdSoThuTuSanPham = new labelObject();
			//lbdSoThuTuSanPham.Value = "AVNLZ03294";
			//lbdMaOrder = new labelObject();

			try
			{
				string subStringOfMediaToFind = "*" + lbdMaOrder.Value + "*" + lbdSoThuTuSanPham.Value + "*" + "_bwd.wav";
				if (mediaPlayerFwdFile) subStringOfMediaToFind = "*" + lbdMaOrder.Value + "*" + lbdSoThuTuSanPham.Value + "*" + "_fwd.wav";
				// Tim kiem file am thanh theo ma san pham
				string[] listFileAudio = Directory.GetFiles("F:\\RecordSoundDataMotor\\", subStringOfMediaToFind);
				if (listFileAudio.Length == 0) return;
				// Lay duong dan file
				string mediaFileUrl = listFileAudio[0];
				if (File.Exists(mediaFileUrl))
					Process.Start("wmplayer.exe", mediaFileUrl);
				mediaPlayerFwdFile = !mediaPlayerFwdFile;
			}
			catch { }
		}

		private void MainWD_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
			{
				if (!chartBusy) btnF1_PreviewMouseDown(null, null);
			}
		}

		private void lblNguoiVanhanh_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			SHIV_PhongCachAm.PopupWindows.inputBarcode temp = new PopupWindows.inputBarcode("Barcode tên người vận hành:");
			//temp.LabelText = "Barcode tên người vận hành:";
			temp.OperatorChange += CapnhatNguoivanhanh;
			temp.ShowDialog();
		}

		private void CapnhatNguoivanhanh(string bCode)
		{
			if (bCode.Length > 5)
			{
				lbdNguoiVanHanh.Value = bCode;
			}
		}

		string _qrCode = "";
		string _bCodeCheckOrder = "";
		/// <summary>
		/// nvthao
		/// </summary>
		/// <param name="bCode"></param>
		private void CapnhatGiatriSTTSpham(string bCode)
		{
			//Expression exp1 = new Expression("OrderCode", lblMaOrder.Content.ToString().Trim());
			//Expression exp2 = new Expression("QRCode", bCode.Trim());
			//_bCodeCheckOrder = bCode;
			//ArrayList arr2 = ProductCheckHistoryDetailBO.Instance.FindByExpression(exp1.And(exp2));
			//if (arr2.Count <= 0)
			//{
			//	lbdMaOrder.Value = "";
			//	lbdSoThuTuSanPham.Value = "";
			//	MessageBox.Show("Nhap lai Order!");

			//}
			if (bCode.IndexOf(" ") > 0)
			{
				lbdSoThuTuSanPham.Value = bCode.Substring(0, bCode.IndexOf(" "));

				_qrCode = bCode;
				try
				{
					//if (lblPID.Content == null) return;
					_productCode = _qrCode.Split(' ')[1];
					if (_productCode.Trim() == "")
					{
						_productCode = _qrCode.Trim();
					}
					#region check công đoạn PCA đã đi qua chưa 
					//Check Công đoạn trước PCA đã thực hiện chưa
					try
					{
						DataSet dsCheckPCA = TextUtils.GetListDataFromSP("spGetCheckCDPCA", "CheckCDTruocPCA", new string[] { "@ProductCode", "@QRCode", "@OrderCode" }, new object[] { _productCode, bCode.Trim(), lblMaOrder.Content.ToString().Trim() });
						DataTable dtCheck = dsCheckPCA.Tables[0];
						DataTable dtCD = dsCheckPCA.Tables[1];
						if (dtCheck.Rows.Count <= 0)
						{
							lbdMaOrder.Value = "";
							lbdSoThuTuSanPham.Value = "";
							if (dtCD.Rows.Count > 0)
							{
								MessageBox.Show($"Sản phẩm chưa đi qua {TextUtils.ToString(dtCD.Rows[0][0])}");
							}
							else
							{
								MessageBox.Show($"Không tìm thấy sản phẩm");
							}
						}
					}
					catch
					{
					}

					#endregion
					string sql = string.Format(@" SELECT top 1 WS.ID ,
                                    WS.ProductStepCode,WS.Description
                            FROM    dbo.ProductStep WS
                                    INNER JOIN dbo.Product P ON P.ID = WS.ProductID
                            WHERE P.ProductCode = '{0}' and WS.ProductStepCode = 'CD14'", _productCode);

					DataTable dtStep = TextUtils.Select(sql);
					if (dtStep.Rows.Count == 0) return;
					_stepCode = TextUtils.ToString(dtStep.Rows[0]["ProductStepCode"]);
					_stepID = TextUtils.ToInt(dtStep.Rows[0]["ID"]);
					_stepName = TextUtils.ToString(dtStep.Rows[0]["Description"]);

					DataSet ds = ProductCheckHistoryDetailBO.Instance.GetDataSet("spGetWorkingByProduct_ForCD9",
						new string[] { "@WorkingStepID", "@WorkingStepCode", "@ProductCode" },
						new object[] { _stepID, _stepCode, _productCode });

					_dtData = ds.Tables[0];

					/*
					 * Tách chuỗi QrCode
					 */
					string orderCode = _qrCode;
					string[] arr1 = orderCode.Split(' ');
					if (arr1.Length > 0)
					{
						_order = arr1[0];
						//_productCode = arr1[1].Trim();
						string[] arr;
						if (_order.Contains("-"))
						{
							arr = _order.Split('-');
							_tienTo = (arr[0] + "-" + arr[1] + "-");
							_stt = arr[2];
						}
						else
						{
							arr = Regex.Split(_order, @"\D+");
							_stt = arr[arr.Length - 1];
							_tienTo = _order.Substring(0, _order.IndexOf(_stt));
						}
					}

				}
				catch (Exception ex)
				{
					File.AppendAllText(string.Format("F:\\SaveLog\\TachCode_{0}.txt", DateTime.Now.ToString("dd_MM_yyyy"))
						 , DateTime.Now + ": Loi tach barcode.\n" + _qrCode + Environment.NewLine + ex.ToString() + Environment.NewLine);
				}

				try
				{
					sendDataTCP("0", "4");
				}
				catch (Exception ex)
				{

				}
			}
		}

		/// <summary>
		/// nvthao 
		/// Thay đổi hàm lấy pid và giá trị tiêu chuẩn
		/// </summary>
		/// <param name="txtMaOder"></param>
		private void CapnhatGiatriOrderPID(string txtMaOder)
		{
			if (txtMaOder.Length > 5)
			{
				lbdMaOrder.Value = txtMaOder.Replace("\n", "").Trim();
				try
				{
					//LayPIDVaGiatriTieuchuan(lbdMaOrder.Value.Substring(0, lbdMaOrder.Value.Length - 1));
					LayPIDVaGiatriTieuchuanNew(lbdMaOrder.Value.Substring(0, lbdMaOrder.Value.Length - 1));
				}
				catch { }
				//lbdNguoiVanHanh.Value = "";	 
				is1Parse.Value = false;
				// Bổ xung Reset trạng thái 1pha/3pha
			}
		}

		/// <summary>
		/// Lấy theo database
		/// nvthao 04/12/2020
		/// </summary>
		/// <param name="value"></param>
		private void LayPIDVaGiatriTieuchuanNew(string value)
		{
			string productCode = TextUtils.ToString(TextUtils.ExcuteScalar($"select top 1 ProductCode from PRoductionPlan where OrderCode = '{value}'"));
			if (string.IsNullOrWhiteSpace(productCode))
			{
				MessageBox.Show($"Không tìm thấy sản phẩm: [{productCode}] với mã order: [{value}] trong kế hoạch.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			//ProductModel product = (ProductModel)ProductBO.Instance.FindByField("ProductCode", productCode);
			//if (product == null)
			//{
			//	MessageBox.Show($"Không tìm thấy sản phẩm: [{productCode}].", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			//	return;
			//}
			// Gán các thông tin của sản phẩm vào giao diện
			lbdPID.Value = productCode;
			LayGiatritieuchuanTheoPIDNew(productCode);
			lbdSoThuTuSanPham.Value = "";
		}
		private void LayGiatritieuchuanTheoPIDNew(string productCode)
		{
			try
			{

				DataSet ds = TextUtils.GetListDataFromSP("spGetWorkingByProduct_PCA", "Working_PCA", new string[] { "@ProductCode" }, new object[] { productCode });
				if (ds.Tables.Count <= 1)
				{
					MessageBox.Show($"Không tìm thấy dữ liệu sản phẩm: [{productCode}].", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				lbdMoTaSanPham.Value = TextUtils.ToString(ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["ProductName"] : "");
				//lbdGiamToc.Value = TextUtils.ToString(ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["RatioCode"] : "");

				DataRowCollection rs = ds.Tables[1].Rows;
				DataTable dtWorking = ds.Tables[1];

				DataRow[] r = dtWorking.Select("SortOrder = 1");
				lbdGiamToc.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				// điện áp
				r = dtWorking.Select("SortOrder = 10");
				lbTcDienap.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				//Tần số Dòng điện
				r = dtWorking.Select("SortOrder = 20");
				lbTcTanso.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				//Dòng điện KTVH
				r = dtWorking.Select("SortOrder = 30");
				lbTcDongdien.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				//Nhập lực
				r = dtWorking.Select("SortOrder = 40");
				lbTcNhapluc.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				////Kiểm tra Âm Sắc
				//DataRow[] r4 = dtWorking.Select("SortOrder = 45");
				//lbTcDongdien.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				//Kiểm tra độ rung chiều F, R
				r = dtWorking.Select("SortOrder = 50");
				lbTcDorung.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				//Vòng quay
				r = dtWorking.Select("SortOrder = 80");
				lbTcVongquay.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";
				//Tiếng ồn
				r = dtWorking.Select("SortOrder = 90");
				lbTcTiengon.Value = r.Length > 0 ? TextUtils.ToString(r[0]["StandardValue"]) : "0";

				//Ghi gia tri timer PLC
				decimal giamToc;
				switch (lbdGiamToc.Value)
				{
					case "A0":
						giamToc = 100;
						break;
					case "A2":
						giamToc = 120;
						break;
					case "A5":
						giamToc = 150;
						break;
					case "B0":
						giamToc = 200;
						break;
					case "B4":
						giamToc = 240;
						break;
					case "C0":
						giamToc = 300;
						break;
					case "C6":
						giamToc = 360;
						break;
					case "D8":
						giamToc = 480;
						break;
					case "F0":
						giamToc = 600;
						break;
					case "G2":
						giamToc = 720;
						break;
					case "J0":
						giamToc = 900;
						break;
					case "M0":
						giamToc = 1200;
						break;
					case "P4":
						giamToc = 1440;
						break;
					default:

						giamToc = TextUtils.ToDecimal(lbdGiamToc.Value);
						break;

				}
				#region fig cứng giá trị 
				//// Case 0~30
				//if ((giamToc >= 0) && (giamToc <= 30))
				//{
				//	TimerFwd = 130;
				//	TimerBwd = 130;
				//	numberDataPerTurn = TimerFwd - 40;
				//	// Set Timer Motor On Of PLC FX3G
				//	plcFX3G_Shiv.WriteDeviceRandom("D1000", 1, TimerFwd);
				//	plcFX3G_Shiv.WriteDeviceRandom("D2000", 1, TimerBwd);
				//}
				//// Case 31~240
				//if ((giamToc >= 31) && (giamToc <= 240))
				//{
				//	TimerFwd = 180;
				//	TimerBwd = 180;
				//	numberDataPerTurn = TimerFwd - 40;
				//	// Set Timer Motor On Of PLC FX3G
				//	plcFX3G_Shiv.WriteDeviceRandom("D1000", 1, TimerFwd);
				//	plcFX3G_Shiv.WriteDeviceRandom("D2000", 1, TimerBwd);
				//}
				//// Case 241~480
				//if ((giamToc >= 241) && (giamToc <= 480))
				//{
				//	TimerFwd = 230;
				//	TimerBwd = 230;
				//	numberDataPerTurn = TimerFwd - 40;
				//	// Set Timer Motor On Of PLC FX3G
				//	plcFX3G_Shiv.WriteDeviceRandom("D1000", 1, TimerFwd);
				//	plcFX3G_Shiv.WriteDeviceRandom("D2000", 1, TimerBwd);
				//}
				//// Case 481~1440
				//if ((giamToc >= 481) && (giamToc <= 1440))
				//{
				//	TimerFwd = 630;
				//	TimerBwd = 630;
				//	numberDataPerTurn = TimerFwd - 40;
				//	// Set Timer Motor On Of PLC FX3G
				//	plcFX3G_Shiv.WriteDeviceRandom("D1000", 1, TimerFwd);
				//	plcFX3G_Shiv.WriteDeviceRandom("D2000", 1, TimerBwd);
				//}
				#endregion
				#region lấy giá trị trên PM để hiển thị giảm tốc
				DataTable dt = TextUtils.Select($"SELECT TOP 1 * FROM [SumitomoHyp].[dbo].[SpeedReducer] WHERE Min <= {giamToc} AND Max >= {giamToc}");
				if (dt == null || dt.Rows.Count <= 0)
				{
					MessageBox.Show("Không tìm thấy điều kiện trên dữ liệu", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
					return;
				}
				TimerFwd = TextUtils.ToInt(dt.Rows[0]["TimeRunF"]) * 10; //VD 15 giây chạy 1 chiều = 15*10 = 150 
				TimerBwd = TextUtils.ToInt(dt.Rows[0]["TimeRunF"]) * 10; //VD 15 giây chạy 1 chiều = 15*10 = 150 
				numberDataPerTurn = TimerBwd - (TextUtils.ToInt(dt.Rows[0]["TimeTeaching"])) * 10; //biểu đồ = thời gian 1 chiều - thời gian teaching sensor VD: 150-(8)*10=70   (hiện tại đang là trừ 40)
																								   //TimerSleep = TextUtils.ToInt(dt.Rows[0]["TimeGetVongQuay"]) * 1000;    // 6S THU THAP DU LIEU 1 CHIEU QUAY
																								   //plcFX5U.SetDevice("D50", TimerSleep); // Cai dat thoi gian lay mau toc do vong quay
				plcFX3G_Shiv.WriteDeviceRandom("D1000", 1, TimerFwd + 20);
				plcFX3G_Shiv.WriteDeviceRandom("D2000", 1, TimerBwd + 20);
				//Value_Sleep_TeachSensor = TextUtils.ToInt(dt.Rows[0]["TimeTeaching"]) * 1000; //Thời gian teaching dừng 8s để sensor teaching 8*1000 
				#endregion
				// Lấy Max/Min từ giá trị tiêu chuẩn
				calculateMaxMinValue();

				// Kết thúc chu trình, chạy lại
				currentStageRun = 0;
			}
			catch
			{
				MessageBox.Show("Lỗi không thể lấy giá trị tiêu chuẩn của sản phẩm", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void calculateMaxMinValue()
		{
			string tempS = "";

			try
			{
				tempS = lbTcDongdien.Value;
				lbTcDongdien.Value = "";
				dtDongdien.Min = float.Parse(tempS.Substring(0, tempS.IndexOf('~')));
				dtDongdien.Max = float.Parse(tempS.Substring(tempS.IndexOf('~') + 1));
				lbTcDongdien.Value = tempS;
			}
			catch
			{
				MessageBox.Show("Database Error!!!" + tempS);
			}

			try
			{
				tempS = lbTcNhapluc.Value;
				lbTcNhapluc.Value = "";
				dtNhapluc.Min = 0;
				dtNhapluc.Max = float.Parse(tempS.Substring(tempS.IndexOf("~") + 1)); // Xử lý chuỗi "<= 5.555"
				lbTcNhapluc.Value = tempS;
			}
			catch
			{
				MessageBox.Show("Database Error!!!" + tempS);
			}

			try
			{
				tempS = lbTcDienap.Value;
				if (tempS.IndexOf("V") >= 0) tempS = tempS.Substring(0, tempS.IndexOf("V"));
				lbTcDienap.Value = "";
				dtDienap.Max = dtDienap.Min = float.Parse(tempS.Substring(0)); // Xử lý chuỗi "220V"
				lbTcDienap.Value = tempS + "V";
			}
			catch
			{
				MessageBox.Show("Database Error!!!" + tempS);
			}

			try
			{
				tempS = lbTcDorung.Value;
				lbTcDorung.Value = "";
				dtDorung.Min = 0;
				dtDorung.Max = float.Parse(tempS.Substring(tempS.IndexOf("~") + 1));
				lbTcDorung.Value = tempS;
			}
			catch
			{
				MessageBox.Show("Database Error!!!" + tempS);
			}

			try
			{
				tempS = lbTcTiengon.Value;
				lbTcTiengon.Value = "";
				dtTiengon.Min = 0;
				dtTiengon.Max = float.Parse(tempS.Substring(tempS.IndexOf("~") + 1)); // Xử lý chuỗi "<= 61"
				lbTcTiengon.Value = tempS;
			}
			catch
			{
				MessageBox.Show("Database Error!!!" + tempS);
			}

			try
			{
				tempS = lbTcVongquay.Value;
				lbTcVongquay.Value = "";
				dtVongquay.Min = float.Parse(tempS.Substring(0, tempS.IndexOf('~')));
				dtVongquay.Max = float.Parse(tempS.Substring(tempS.IndexOf('~') + 1));
				lbTcVongquay.Value = tempS;
			}
			catch
			{
				MessageBox.Show("Database Error!!!" + tempS);
			}
		}

		private void killAppExcel()
		{
			foreach (var process in Process.GetProcessesByName("EXCEL"))
			{
				process.Kill();
			}
		}

		private void btnF3_MouseDown(object sender, MouseButtonEventArgs e)
		{
			//excelLink = "";
			//PopupWindows.settingExcel temp = new PopupWindows.settingExcel();
			//temp.ExcelLinkChange += UpdateExcelDatabaseWhenChangeLink;
			//temp.ShowDialog();
		}

		private void lblIsUse_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (lblIsUse.Content.ToString() == "Khong Su Dung")
			{
				this.sendDataTCP("10", "10");
				lblIsUse.Content = "Su Dung";
			}
			else
			{
				this.sendDataTCP("11", "10");
				lblIsUse.Content = "Khong Su Dung";
			}
		}

		//private void UpdateExcelDatabaseWhenChangeLink(string path)
		//{
		//	DatabasePath = path;
		//	if (DatabasePath.Length > 10)
		//	{
		//		if (myExcel.Workbooks.Count > 0) myExcel.ActiveWorkbook.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
		//		UpdateDataBasePathtoExcelApplication();
		//	}
		//}

		/// <summary>
		/// Mở file Excel kế hoạch và Database, hiển thị trên ứng dụng Excel đã mở
		/// </summary>
		//private void UpdateDataBasePathtoExcelApplication()
		//{
		//	string KhLoalStri = DatabasePath.Substring(0, DatabasePath.LastIndexOf("\\") + 1) + "KHLocal.xlsm";
		//	try
		//	{
		//		myExcel.Workbooks.Open(@KhLoalStri);
		//		workSheetKehoach = myExcel.ActiveWorkbook.Worksheets["THUONG"];
		//	}
		//	catch (Exception e)
		//	{
		//		MessageBox.Show("Fail to Update Database file!" + e.ToString());
		//	}

		//	try
		//	{
		//		myExcel.Workbooks.Open(@DatabasePath);
		//		workSheetDatabase = myExcel.ActiveWorkbook.Worksheets["PID"];
		//		//workSheetKehoach = myExcel.ActiveWorkbook.Worksheets["KE HOACH"];
		//		workSheetDatabase.Activate();
		//		myExcel.DisplayFullScreen = true;
		//		myExcel.Visible = true;
		//	}
		//	catch (Exception e)
		//	{
		//		MessageBox.Show("Fail to Update Database file!" + e.ToString());
		//	}
		//}

		/// <summary>
		/// Cập nhật và phân tích dữ liệu từng chiều quay
		/// </summary>
		/// <param name="Option"></param>
		/// <param name="checkDonetemp"></param>
		private void UpdateDulieu(string Option, ref checkDone checkDonetemp)
		{
			// OLD 198
			log.Info($"  Lay du lieu - {Option}");
			int compareDataCountToFinish = numberDataPerTurn - 1;
			switch (Option)
			{
				case "Forward":

					//if (!checkDonetemp.vongQuay)
					//{
					//dtVongquay.giatriThuan.Value = htVongquay;
					//    //dtVongquay.giatriThuan.Value = (float)(DateTime.Now.Second + 1.11);
					checkDonetemp.vongQuay = true;
					//}

					log.Info("      Lay du lieu dong dien");
					if (!checkDonetemp.dongDien && htDongdien != 0)
					{
						dtDongdien.GiatriThuan.Value = htDongdien;
						//dtDongdien.giatriThuan.Value = (float)(DateTime.Now.Second + 1.11);
						checkDonetemp.dongDien = true;
						lbdDienap.Value = htDienap.ToString("0.00V");
						lbdTanso.Value = htTanso.ToString("0.00Hz");
					}

					log.Info("      Lay du lieu nhap luc");
					if (!checkDonetemp.nhapLuc && htNhapluc != 0)
					{
						dtNhapluc.GiatriThuan.Value = htNhapluc;
						//dtNhapluc.giatriThuan.Value = (float)(DateTime.Now.Second + 1.11);
						checkDonetemp.nhapLuc = true;
					}

					log.Info("      Lay du lieu do rung");
					if (!checkDonetemp.doRung)
					{
						//System.Console.WriteLine("Gia tri count do rung : " + checkDonetemp.countDorung.ToString());
						dlDorung.thuan[checkDonetemp.countDorung] = htDorung;
						dtDorung.GiatriThuan.Value = dlDorung.thuan.Max();
						checkDonetemp.countDorung += 1;
						if (checkDonetemp.countDorung > compareDataCountToFinish)
						{
							checkDonetemp.doRung = true;
							checkDonetemp.dongDien = true;
							checkDonetemp.nhapLuc = true;
						}
					}

					log.Info("      Lay du lieu tieng on");
					if (!checkDonetemp.tiengOn)
					{
						dlTiengon.thuan[checkDonetemp.countTiengon] = htTiengon;
						//dtTiengon.GiatriThuan.Value = dlTiengon.thuan.Max();
						checkDonetemp.countTiengon += 1;
						if (checkDonetemp.countTiengon > compareDataCountToFinish)
						{
							checkDonetemp.tiengOn = true;
							//Tính Độ lệch chuẩn
							STDEVTiengOnThuan = standardDeviation(dlTiengon.thuan);
							if (STDEVTiengOnThuan >= 1.3)
							{
								IsNGTiengOnThuan = 1;
								//Tính trung bình
								AVGTiengOn = dlTiengon.thuan.Average();
								GTThuan = AVGTiengOn + STDEVTiengOnThuan;
							}
							else
							{
								IsNGTiengOnThuan = 0;
							}
						}
					}

					if (((checkDonetemp.countDorung + 1) % 10 == 0) || (checkDonetemp.countDorung == 1))
					{
						try
						{
							log.Info("      Ve do thi du lieu");
							PlotChart(currentChart);
						}
						catch (Exception ex)
						{
							log.Error($"Loi ve do thi du lieu - {ex}");
							chartBusy = false;
						}

					}

					break;
				case "Backward":
					//if (!checkDonetemp.vongQuay)
					//{
					//    dtVongquay.giatriNghich.Value = htVongquay;
					//    //dtVongquay.giatriNghich.Value = (float)(DateTime.Now.Second + 1.11);
					checkDonetemp.vongQuay = true;
					//}

					log.Info("      Lay du lieu dong dien");
					if (!checkDonetemp.dongDien && htDongdien != 0)
					{
						dtDongdien.GiatriNghich.Value = htDongdien;
						//dtDongdien.giatriNghich.Value = (float)(DateTime.Now.Second + 1.11);
						checkDonetemp.dongDien = true;
					}

					log.Info("      Lay du lieu nhap luc");
					if (!checkDonetemp.nhapLuc && htNhapluc != 0)
					{
						dtNhapluc.GiatriNghich.Value = htNhapluc;
						//dtNhapluc.giatriNghich.Value = (float)(DateTime.Now.Second + 1.11);
						checkDonetemp.nhapLuc = true;
					}

					log.Info("      Lay du lieu do rung");
					if (!checkDonetemp.doRung)
					{
						//System.Console.WriteLine("Gia tri count do rung : " + checkDonetemp.countDorung.ToString());
						dlDorung.nghich[checkDonetemp.countDorung] = htDorung;
						dtDorung.GiatriNghich.Value = dlDorung.nghich.Max();
						checkDonetemp.countDorung += 1;
						if (checkDonetemp.countDorung > compareDataCountToFinish)
						{
							checkDonetemp.doRung = true;
							checkDonetemp.dongDien = true;
							checkDonetemp.nhapLuc = true;

						}
					}

					log.Info("      Lay du lieu tieng on");
					if (!checkDonetemp.tiengOn)
					{
						dlTiengon.nghich[checkDonetemp.countTiengon] = htTiengon;
						//	dtTiengon.GiatriNghich.Value = dlTiengon.nghich.Max();
						checkDonetemp.countTiengon += 1;
						if (checkDonetemp.countTiengon > compareDataCountToFinish)
						{
							checkDonetemp.tiengOn = true;
							//Tính Độ lệch chuẩn
							STDEVTiengOnNghich = standardDeviation(dlTiengon.nghich);
							if (STDEVTiengOnNghich >= 1.3)
							{
								IsNGTiengOnNghich = 1;
								//Tính trung bình
								AVGTiengOn = dlTiengon.nghich.Average();
								GTNghich = AVGTiengOn + STDEVTiengOnNghich;
							}
							else
							{
								IsNGTiengOnNghich = 0;
							}
						}
					}

					if (((checkDonetemp.countDorung + 1) % 10 == 0) | (checkDonetemp.countDorung == 1))
					{
						try
						{
							log.Info("      Ve do thi du lieu");
							PlotChart(currentChart);
						}
						catch (Exception ex)
						{
							log.Error($"Loi ve do thi du lieu - {ex}");
							chartBusy = false;
						}
					}

					break;
				default:
					break;
			}
		}
		static double standardDeviation(IEnumerable<float> sequence)
		{
			double result = 0;

			if (sequence.Any())
			{
				double average = sequence.Average();
				double sum = sequence.Sum(d => Math.Pow(d - average, 2));
				result = Math.Sqrt((sum) / (sequence.Count() - 1));
			}
			return result;
		}
		/// <summary>
		/// Vẽ đồ thị dữ liệu
		/// </summary>
		private async void PlotChart(int options)
		{
			//01/04 Doi ve do thi thanh async
			Task task = Task.Factory.StartNew(() =>
			{
				if (!chartBusy)
				{
					chartBusy = true;
					//LineChartChild.PolylineStyle = GetDashedLineStyle();
					LineChart1.Dispatcher.Invoke(new Action(() =>
					{
						if (valueSettingMaxRange.Value > 0)
							valueSettingYRange.DataContext = valueSettingMaxRange;
					}));
					switch (options)
					{
						case 0:
							if (true)
							{
								MyValue = new ObservableCollection<ChartViewItem>();
								MyValue_TempTiengon = new ObservableCollection<ChartViewItem>();
								MyMax = new ObservableCollection<ChartViewItem>();
							}
							else
							{
								//LineChart1.Dispatcher.Invoke(new Action(() =>
								//{
								//    MyValue.Clear();
								//    MyValue_TempTiengon.Clear();
								//    MyMax.Clear();
								//}));
							}

							for (int i = 0; i < numberDataPerTurn; i++)
							{
								MyValue.Add(new ChartViewItem { Key = i / (float)10.0, Value = dlDorung.thuan[i] });
							}
							MyMax.Add(new ChartViewItem { Key = 0 / (float)10.0, Value = dtDorung.Max });
							MyMax.Add(new ChartViewItem { Key = (numberDataPerTurn - 1) / (float)10.0, Value = dtDorung.Max });

							valueSettingMaxRange.Value = (float)((dtDorung.Max) * 1.5);
							LineChart1.Dispatcher.Invoke(new Action(() =>
							{
								//LineChartChild.DataPointStyle = styleDorung;
								LineChartChild.Title = "Độ rung thuận";
								LineChartChild.DataContext = MyValue;

								LineChartChild_TempTiengon.Title = "Tiếng ồn thuận";
								LineChartChild_TempTiengon.DataContext = MyValue_TempTiengon;

								LineChartMax.DataContext = MyMax;
							}));
							break;
						case 1:
							if (true)
							{
								MyValue = new ObservableCollection<ChartViewItem>();
								MyValue_TempTiengon = new ObservableCollection<ChartViewItem>();
								MyMax = new ObservableCollection<ChartViewItem>();
							}
							else
							{
								//LineChart1.Dispatcher.Invoke(new Action(() =>
								//{
								//    MyValue.Clear();
								//    MyValue_TempTiengon.Clear();
								//    MyMax.Clear();
								//}));
							}

							for (int i = 0; i < numberDataPerTurn; i++)
							{
								MyValue.Add(new ChartViewItem { Key = i / (float)10.0, Value = dlDorung.nghich[i] });
							}
							MyMax.Add(new ChartViewItem { Key = 0 / (float)10.0, Value = dtDorung.Max });
							MyMax.Add(new ChartViewItem { Key = (numberDataPerTurn - 1) / (float)10.0, Value = dtDorung.Max });

							valueSettingMaxRange.Value = (float)((dtDorung.Max) * 1.5);
							LineChart1.Dispatcher.Invoke(new Action(() =>
							{
								//LineChartChild.DataPointStyle = styleDorung;
								LineChartChild.Title = "Độ rung nghịch";
								LineChartChild.DataContext = MyValue;

								LineChartChild_TempTiengon.Title = "Tiếng ồn nghịch";
								LineChartChild_TempTiengon.DataContext = MyValue_TempTiengon;

								LineChartMax.DataContext = MyMax;
							}));
							break;
						case 2:
							if (true)
							{
								MyValue = new ObservableCollection<ChartViewItem>();
								MyValue_TempTiengon = new ObservableCollection<ChartViewItem>();
								MyMax = new ObservableCollection<ChartViewItem>();
							}
							else
							{
								//LineChart1.Dispatcher.Invoke(new Action(() =>
								//{
								//    MyValue.Clear();
								//    MyValue_TempTiengon.Clear();
								//    MyMax.Clear();
								//}));
							}
							for (int i = 0; i < numberDataPerTurn; i++)
							{
								MyValue_TempTiengon.Add(new ChartViewItem { Key = i / (float)10.0, Value = dlTiengon.thuan[i] });
							}
							MyMax.Add(new ChartViewItem { Key = 0 / (float)10.0, Value = dtTiengon.Max });
							MyMax.Add(new ChartViewItem { Key = (numberDataPerTurn - 1) / (float)10.0, Value = dtTiengon.Max });

							valueSettingMaxRange.Value = (float)((dtTiengon.Max) * 1.5);

							LineChart1.Dispatcher.Invoke(new Action(() =>
							{
								//LineChartChild.DataPointStyle = styleTiengon;
								LineChartChild.Title = "Độ rung thuận";
								LineChartChild.DataContext = MyValue;

								LineChartChild_TempTiengon.Title = "Tiếng ồn thuận";
								LineChartChild_TempTiengon.DataContext = MyValue_TempTiengon;

								LineChartMax.DataContext = MyMax;
							}));
							break;
						case 3:
							if (true)
							{
								MyValue = new ObservableCollection<ChartViewItem>();
								MyValue_TempTiengon = new ObservableCollection<ChartViewItem>();
								MyMax = new ObservableCollection<ChartViewItem>();
							}
							else
							{
								//LineChart1.Dispatcher.Invoke(new Action(() =>
								//{
								//    MyValue.Clear();
								//    MyValue_TempTiengon.Clear();
								//    MyMax.Clear();
								//}));
							}
							for (int i = 0; i < numberDataPerTurn; i++)
							{
								MyValue_TempTiengon.Add(new ChartViewItem { Key = i / (float)10.0, Value = dlTiengon.nghich[i] });
							}
							MyMax.Add(new ChartViewItem { Key = 0 / (float)10.0, Value = dtTiengon.Max });
							MyMax.Add(new ChartViewItem { Key = (numberDataPerTurn - 1) / (float)10.0, Value = dtTiengon.Max });
							valueSettingMaxRange.Value = (float)((dtTiengon.Max) * 1.5);
							LineChart1.Dispatcher.Invoke(new Action(() =>
							{

								//LineChartChild.DataPointStyle = styleTiengon;
								LineChartChild.Title = "Độ rung nghịch";
								LineChartChild.DataContext = MyValue;

								LineChartChild_TempTiengon.Title = "Tiếng ồn nghịch";
								LineChartChild_TempTiengon.DataContext = MyValue_TempTiengon;

								LineChartMax.DataContext = MyMax;
							}));
							break;
						default:
							break;
					}
					chartBusy = false;
				}
			});
			await task;
		}

		private Style GetDashedLineStyle()
		{
			var style = new Style(typeof(Polyline));
			style.Setters.Add(new Setter(Shape.StrokeDashArrayProperty,
							  new DoubleCollection(new[] { 5.0 })));
			return style;
		}

		/// <summary>
		/// Kiểm tra âm sắc theo từng chiều lựa chọn
		/// </summary>
		/// <param name="v"></param>
		private void CheckAmsac(string v)
		{
			switch (v)
			{
				case "Forward":
					Application.Current.Dispatcher.Invoke(
						(Action)delegate
						{
							PopupWindows.checkAmsacWD temp = new PopupWindows.checkAmsacWD("thuận");
							temp.isCheckedEvent += checkAmsacThuan;
							temp.ShowDialog();
						});
					break;
				case "Backward":
					Application.Current.Dispatcher.Invoke(
						(Action)delegate
						{
							PopupWindows.checkAmsacWD temp = new PopupWindows.checkAmsacWD("nghịch");
							temp.isCheckedEvent += checkAmsacNghich;
							temp.ShowDialog();
						});
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Kiểm tra phán định âm sắc và update hiển thị
		/// </summary>
		/// <param name="value"></param>
		private void checkAmsacThuan(string value)
		{
			if (value == "OK") dtAmsac.giatriThuan.Value = 5;
			else dtAmsac.giatriThuan.Value = 15;
		}
		/// <summary>
		/// Kiểm tra phán định âm sắc và update hiển thị
		/// </summary>
		/// <param name="value"></param>
		private void checkAmsacNghich(string value)
		{
			if (value == "OK") dtAmsac.giatriNghich.Value = 5;
			else dtAmsac.giatriNghich.Value = 15;
		}

		/// <summary>
		/// Kiểm tra hướng quay trục xuất lực tổng
		/// </summary>
		private void checkRotaryDirection()
		{
			Application.Current.Dispatcher.Invoke(
						(Action)delegate
						{
							PopupWindows.checkRotary temp = new PopupWindows.checkRotary("");
							temp.isCheckedEvent += checkHuongquayTong;
							temp.ShowDialog();
						});
		}

		/// <summary>
		/// Kiểm tra phán định hướng quay, sau đó Update hiển thị phán định
		/// </summary>
		/// <param name="value"></param>
		private void checkHuongquayTong(string value)
		{
			if (value == "OK")
			{
				dtHuongquay.giatriThuan.Value = dtHuongquay.giatriNghich.Value = 5;
			}
			else
			{
				dtHuongquay.giatriThuan.Value = dtHuongquay.giatriNghich.Value = 15;
			}


		}

		[DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
		private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
		private void RecordStart()
		{
			string errLogPath = $"F:\\ERRLog\\ERR_Record_{DateTime.Now.ToString("yyMMdd")}.txt";
			try
			{
				record("open new Type waveaudio Alias recsound", "", 0, 0);
				record("record recsound", "", 0, 0);
			}
			catch (Exception ex)
			{
				if (File.Exists(errLogPath))
				{
					File.AppendAllText(errLogPath, $"ERR_Record - Cannot Record - {DateTime.Now.ToString()} + {ex}" + "\r\n");
				}
				else
				{
					File.WriteAllText(errLogPath, $"ERR_Record - Cannot Record - {DateTime.Now.ToString()} + {ex}" + "\r\n");
				}

			}

		}

		private void RecordStopAndSave(string fileName)
		{
			string errLogPath = $"F:\\ERRLog\\ERR_Record_{DateTime.Now.ToString("yyMMdd")}.txt";
			try
			{

				record("save recsound " + @fileName + ".wav", "", 0, 0);
				record("close recsound", "", 0, 0);
				//System.IO.FileInfo fi = new System.IO.FileInfo(fileName + ".wav");
				//if (TextUtils.ToDouble(fi) <= 44)
				//{
				//	MessageBox.Show("Không lấy được dữ liệu file âm thanh");
				//}
			}
			catch (Exception ex)
			{
				//System.IO.FileInfo fi = new System.IO.FileInfo(fileName + ".wav");
				//if (TextUtils.ToDouble(fi) <= 44)
				//{
				//	MessageBox.Show("Không lấy được dữ liệu file âm thanh");
				//}
				if (File.Exists(errLogPath))
				{
					File.AppendAllText(errLogPath, $"ERR_Record - Cannot Record - {DateTime.Now.ToString()} + {ex}" + "\r\n");
				}
				else
				{
					File.WriteAllText(errLogPath, $"ERR_Record - Cannot Record - {DateTime.Now.ToString()} + {ex}" + "\r\n");
				}
			}
		}

		private async void FtpUploadFile(string filename, string fullname, string to_uri, string user_name, string password)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				// Get the object used to communicate with the server.
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", to_uri, filename)));
				// Method will be upload to server
				request.Method = WebRequestMethods.Ftp.UploadFile;

				// Get network credentials.
				request.Credentials = new NetworkCredential(user_name, password);

				byte[] bytes = System.IO.File.ReadAllBytes(fullname);

				// Write the bytes into the request stream.
				request.ContentLength = bytes.Length;
				using (Stream request_stream = request.GetRequestStream())
				{
					request_stream.Write(bytes, 0, bytes.Length);
					request_stream.Close();
				}
			});

			await task;
		}

	}
}
