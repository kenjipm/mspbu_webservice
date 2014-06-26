using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
//using OCR_Terminal.WebService;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OCR_Terminal
{
    public partial class mspbuTerminalForm : Form
    {
        //ServiceClient client = new ServiceClient();

        public mspbuTerminalForm()
        {
            InitializeComponent();
        }

        struct SppForm
		{
            public string Name;
            public string Address;
            public string Police;
            public string Shipment;
            public string Volume;
            public string Quality;
            public string Buyer;
            public string Product;
		};

        private void tabDashboard_Click(object sender, EventArgs e)
        {

        }        

        private void loginBtn_Click(object sender, EventArgs e)
        {
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            openSppFileDialog.ShowDialog(this);
            pathTextBox.Text = openSppFileDialog.FileName;
            scanPictureBox.ImageLocation = openSppFileDialog.FileName;
            using (var engine = new TesseractEngine("./tessdata", "ind", EngineMode.Default))
            {
                Image original_img = new Bitmap(openSppFileDialog.FileName);
                Point crop_point = new Point(300,0);
                Size crop_size = new Size(original_img.Width - 300, original_img.Height);
                Rectangle crop_area = new Rectangle(crop_point, crop_size);
                Image cropped_img = cropImage(original_img, crop_area);
                cropped_img.Save("./cropped_img.png", System.Drawing.Imaging.ImageFormat.Png);
                using (var img = Pix.LoadFromFile("./cropped_img.png"))
                {
                    using (Page page = engine.Process(img))
                    {
                        string spp_str = page.GetText();
                        int parse_state = 0; // 0,2,4,6,8,10,12,14,16=none, 1=nama, 3=alamat, 5=nmrpolisi, 7=nmrshipment, 9=tujuan, 
                                             // 11=pemesanan, 13=denstemp, 15=pembeli, 17=produk
                        var i = 0;
                        SppForm spp = new SppForm();
                        Console.WriteLine(spp_str);
                        for(i=0; i<spp_str.Length; i++) {
                            if (spp_str[i] == ':') {
                                parse_state++;
                            }
                            else {
                                if (parse_state == 1)
                                { // name
                                    spp.Name = spp.Name + spp_str[i];
                                }
                                else if (parse_state == 2)
                                {
                                    spp.Address = spp.Address + spp_str[i];
                                }
                                else if (parse_state == 3)
                                {// nmrpolisi
                                    spp.Police = spp.Police + spp_str[i];
                                }
                                else if (parse_state == 4)
                                {// nmrshipment
                                    spp.Shipment = spp.Shipment + spp_str[i];
                                }
                                else if (parse_state == 6)
                                {// pemesanan
                                    spp.Volume = spp.Volume + spp_str[i];
                                }
                                else if (parse_state == 7)
                                {// denstemp
                                    spp.Quality = spp.Quality + spp_str[i];
                                }
                                else if (parse_state == 8)
                                {// pembeli
                                    spp.Buyer = spp.Buyer + spp_str[i];
                                }
                                else if (parse_state == 9)
                                {// produk
                                    spp.Product = spp.Product + spp_str[i];
                                }
                            }					
                        }

                        setSppTextBox(false);
                        sppNameTextbox.Text = spp.Name;
                        sppAddressTextbox.Text = spp.Address;
                        sppPoliceTextbox.Text = spp.Police;
                        sppShipmentTextbox.Text = spp.Shipment;
                        sppVolumeTextbox.Text = spp.Volume;
                        sppQualityTextbox.Text = spp.Quality;
                        sppBuyerTextbox.Text = spp.Buyer;
                        sppProductTextbox.Text = spp.Product;
                    }
                }
            }
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        private void setSppTextBox(bool isEnabled) {
            sppNameTextbox.Enabled = isEnabled;
            sppAddressTextbox.Enabled = isEnabled;
            sppPoliceTextbox.Enabled = isEnabled;
            sppShipmentTextbox.Enabled = isEnabled;
            sppVolumeTextbox.Enabled = isEnabled;
            sppQualityTextbox.Enabled = isEnabled;
            sppBuyerTextbox.Enabled = isEnabled;
            sppProductTextbox.Enabled = isEnabled;
        }

        private void saveSppBtn_Click(object sender, EventArgs e)
        {
			/****************** GET *****************/
			string functionName = "sppGet";
			string data = JsonConvert.SerializeObject(new
			{
				sppId = 10 //id get
			});

			/**************** GET ALL ***************/
			//string functionName = "sppGetAll";
			//string data = JsonConvert.SerializeObject(null);

			/*************** GET PAGE ***************/
			//string functionName = "sppGetPage";
			//string data = JsonConvert.SerializeObject(new
			//{
			//	username = "kenjipm",
			//	pageNum = 2,
			//	jmlRecord = 3
			//});

			/*************** GET WHERE **************/
			//string functionName = "sppGetWhere";
            //string data = JsonConvert.SerializeObject(new
            //{
            //    sppAttributes = new
            //    {
            //        police_no = "B8321AA"
            //        //another attributes here
            //    }
            //});

			/**************** INSERT ****************/
			//string functionName = "sppInsert";
			//string data = JsonConvert.SerializeObject(new
			//{
			//	sppData = new
			//	{
			//		address = sppAddressTextbox.Text,
			//		buyer = sppBuyerTextbox.Text,
			//		name = sppNameTextbox.Text,
			//		police_no = sppPoliceTextbox.Text,
			//		product = sppProductTextbox.Text,
			//		shipment_no = sppShipmentTextbox.Text,
			//		volume = sppVolumeTextbox.Text,
			//		dens_temp = sppQualityTextbox.Text
			//		//verification_date = DateTime.Now.ToString()
			//		//another attributes here
			//	}
			//});

			/************* INSERT BATCH *************/
			//string functionName = "sppInsertBatch";
            //string data = JsonConvert.SerializeObject(new
            //{
            //    sppList = new object[]
            //    {
            //        new
            //        {
            //            name        = sppNameTextbox.Text + " - new 1",
            //            address     = sppAddressTextbox.Text,
            //            police_no   = sppPoliceTextbox.Text,
            //            shipment_no = sppShipmentTextbox.Text,
            //            volume      = sppVolumeTextbox.Text
            //            //another attributes here
            //        },
            //        new
            //        {
            //            name        = sppNameTextbox.Text+" - new 2",
            //            address     = sppAddressTextbox.Text + " - 2",
            //            police_no   = sppPoliceTextbox.Text,
            //            shipment_no = sppShipmentTextbox.Text,
            //            volume      = sppVolumeTextbox.Text
            //            //another attributes here
            //        },
            //        new
            //        {
            //            name        = sppNameTextbox.Text + " - new 3",
            //            address     = sppAddressTextbox.Text + " - 3",
            //            police_no   = sppPoliceTextbox.Text,
            //            shipment_no = sppShipmentTextbox.Text,
            //            volume      = sppVolumeTextbox.Text
            //            //another attributes here
            //        }
            //        //another objects here
            //    }
            //});

            /**************** UPDATE ****************/
			//string functionName = "sppUpdate";
            //string data = JsonConvert.SerializeObject(new
            //{
            //    sppData = new
            //    {
            //        Id = 10,
            //        name = "Updated using sppUpdate",
            //        volume = 8.8
            //        //another attributes here, don't put attributes you didn't wish to change
            //    }
            //});

			/************* UPDATE BATCH *************/
			//string functionName = "sppUpdateBatch";
            //string data = JsonConvert.SerializeObject(new
            //{
            //    sppList = new object[]
            //    {
            //        new
            //        {
            //            Id          = 10,
            //            name        = "Updated using sppUpdateBatch - 1",
            //            volume      = 15.3
            //            //another attributes here, don't put attributes you didn't wish to change
            //        },
            //        new
            //        {
            //            Id          = 11,
            //            name        = "Updated using sppUpdateBatch - 2",
            //            volume      = 16.3
            //            //another attributes here, don't put attributes you didn't wish to change
            //        },
            //        new
            //        {
            //            Id          = 12,
            //            name        = "Updated using sppUpdateBatch - 3",
            //            volume      = 22.3
            //            //another attributes here, don't put attributes you didn't wish to change
            //        }
            //        //another objects here
            //    }
            //});

			/**************** DELETE ****************/
			//string functionName = "sppDelete";
            //string data = JsonConvert.SerializeObject(new
            //{
            //    sppId = 6 //id delete
            //});

            /************* DELETE BATCH *************/
			//string functionName = "sppDeleteBatch";
            //string data = JsonConvert.SerializeObject(new
            //{
            //    sppIdList = new int[]
            //    {
            //        1, 11
            //    }
            //});

			/*************** SAVE PDF **************/
			//string functionName = "sppSavePDF";
			////StreamWriter dataWriter = new StreamWriter("X:\\tesaja.png");
			//string filePath = "X:\\Temp\\Gambar Pohon Spesies Bumi.pdf";
			//FileStream data = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			//int length = (int)data.Length;
			//byte[] fileArray = new byte[length];
			//data.Read(fileArray, 0, length);

			/************** WEB REQUEST *************/
			//string url = "http://localhost:2424/Service.svc/" + functionName;
			string url = "http://180.250.242.107/Service.svc/" + functionName;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			/************ WEB REQUEST JSON **********/
			request.ContentType = "text/json";
			request.Method = "POST";
			Console.WriteLine(data);
			StreamWriter writer = new StreamWriter(request.GetRequestStream());
			writer.Write(data);
			writer.Flush();
			writer.Close();

			/************ WEB REQUEST FILE **********/
			//request.Method = "POST";
			//request.AllowWriteStreamBuffering = true;
			//request.ContentLength = length;
			//Stream stream = request.GetRequestStream();
			//stream.Write(fileArray, 0, fileArray.Length);
			//stream.Flush();
			//stream.Close();
			//data.Close();
			//Console.WriteLine(data);

			/************ WEB RESPONSE **********/
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream responseStream = response.GetResponseStream();
			StreamReader sr = new StreamReader(responseStream);

			Console.WriteLine(sr.ReadToEnd());
			sr.Close();
			responseStream.Close();

			/************* PRINT HASIL LIST *************/
			//dynamic listResult = JsonConvert.DeserializeObject<dynamic>(sr.ReadToEnd());
			////harus Using Newtonsoft.Json.Linq;
			//JArray arrayResult = listResult[functionName + "Result"];
			//foreach (object result in arrayResult)
			//{
			//	Console.WriteLine("\n" + result + "\n");
			//}
			
            setSppTextBox(false);
        }

        private void editSppBtn_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:2424/Service.svc/sppDelete";
            string data = JsonConvert.SerializeObject(new
                {
                    id = 1
                });
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/json";
            request.Method = "POST";
            Console.WriteLine(data);
            //request.ContentType = "application/json; charset=utf-8";
            //DataContractJsonSerializer ser = new datacontractjsonserializer(data.gettype());
            //memorystream ms = new memorystream();
            //ser.writeobject(ms, data);
            //string json = encoding.utf8.getstring(ms.toarray());
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(data);
            writer.Flush();
            writer.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            Console.WriteLine(sr.ReadToEnd());
            setSppTextBox(true);
        }

        private void stockPremiumOrderBtn_Click(object sender, EventArgs e)
        {
            OrderForm newOrderForm = new OrderForm();
            newOrderForm.ShowDialog(this);
        }

        private void stockPertamaxOrderBtn_Click(object sender, EventArgs e)
        {
            OrderForm newOrderForm = new OrderForm();
            newOrderForm.ShowDialog(this);
        }

        private void stockSolarOrderBtn_Click(object sender, EventArgs e)
        {
            OrderForm newOrderForm = new OrderForm();
            newOrderForm.ShowDialog(this);
        }

        private void stockPremiumUpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateForm newUpdateForm = new UpdateForm();
            newUpdateForm.ShowDialog(this);
        }

        private void stockPertamaxUpdateBtn_Click(object sender, EventArgs e)
        {
            OrderForm newOrderForm = new OrderForm();
            newOrderForm.ShowDialog(this);
        }

        private void stockSolarUpdateBtn_Click(object sender, EventArgs e)
        {
            OrderForm newOrderForm = new OrderForm();
            newOrderForm.ShowDialog(this);
        }

    }

    [DataContractAttribute]
    class Json
    {
        [DataMemberAttribute]
        public string content { get; set; }
    }
}
