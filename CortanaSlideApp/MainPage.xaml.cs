using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechRecognition;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=391641 を参照してください

namespace CortanaSlideApp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private StreamSocket chatSocket;
        private DataWriter chatWriter;
       
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。
        /// このプロパティは、通常、ページを構成するために使用します。</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("address"))
            {
                this.textBoxIp.Text = ApplicationData.Current.LocalSettings.Values["address"].ToString();
            }
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            // Find all paired instances of the Rfcomm chat service
            try {

                using (chatSocket = new StreamSocket())
                {
                    await chatSocket.ConnectAsync(new HostName(textBoxIp.Text), "5000");
                    var stream = chatSocket.OutputStream;
                    chatWriter = new DataWriter(stream);
                    chatWriter.WriteByte(1);
                    await chatWriter.StoreAsync();
                }
                              
            }catch(Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                await dialog.ShowAsync();
            }
        }

        private async void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["address"] = textBoxIp.Text;
            var dialog = new MessageDialog("保存完了");
            await dialog.ShowAsync();
        }

        private async void buttonRegist_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///assets/Slide.xml"));
            await VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(file);
            var dialog = new MessageDialog("OK");
            await dialog.ShowAsync();

        }
    }
}
