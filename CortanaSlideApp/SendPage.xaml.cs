using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkID=390556 を参照してください

namespace CortanaSlideApp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class SendPage : Page
    {
        private StreamSocket chatSocket;
        private DataWriter chatWriter;

        public SendPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// このページがフレームに表示されるときに呼び出されます。
        /// </summary>
        /// <param name="e">このページにどのように到達したかを説明するイベント データ。
        /// このプロパティは、通常、ページを構成するために使用します。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var ip = ApplicationData.Current.LocalSettings.Values["address"].ToString();
                using (chatSocket = new StreamSocket())
                {
                    await chatSocket.ConnectAsync(new HostName(ip), "5000");
                    var stream = chatSocket.OutputStream;
                    chatWriter = new DataWriter(stream);
                    chatWriter.WriteByte(1);
                    await chatWriter.StoreAsync();
                }
            }
            catch(Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                await dialog.ShowAsync();
            }
            
        }
    }
}
