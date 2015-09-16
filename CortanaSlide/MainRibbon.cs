using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.PowerPoint;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace CortanaSlide
{
    public partial class MainRibbon
    {
        public static Microsoft.Office.Interop.PowerPoint.Application application;
        TcpListener listner;
        TcpClient client;
        NetworkStream stream;

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        

        private void ShowLastSlide()
        {
            var setting = application.ActivePresentation.SlideShowSettings;
            var window = setting.Run();
            var lastIndex = application.ActivePresentation.Slides.Count;
            window.View.GotoSlide(lastIndex);

            
        }
        private async void buttonConnect_Click(object sender, RibbonControlEventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxIp.Text))
            {
                try {
                    if (listner != null)
                    {
                        listner.Stop();
                        listner = null;
                    }
                    listner = new TcpListener(IPAddress.Parse(comboBoxIp.Text), 5000);
                    listner.Start();
                    labelStatus.Label = "データ待機中";
                    client = await listner.AcceptTcpClientAsync();
                    stream = client.GetStream();
                    byte[] buff = new byte[1];
                    var read = await stream.ReadAsync(buff, 0, buff.Length);
                    ShowLastSlide();
                    labelStatus.Label = "接続待機中";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("IPを選択してください");
            }

        }

        private void buttonClose_Click(object sender, RibbonControlEventArgs e)
        {
            listner.Stop();
            stream.Close();
            client.Close();
        }

        private void buttonReflesh_Click(object sender, RibbonControlEventArgs e)
        {
            comboBoxIp.Items.Clear();
            var ip = Dns.GetHostAddresses(Dns.GetHostName());
            ip.ToList().ForEach(q =>
            {
                var item = Factory.CreateRibbonDropDownItem();
                item.Label = q.ToString();
                comboBoxIp.Items.Add(item);
            });
        }
    }
}
