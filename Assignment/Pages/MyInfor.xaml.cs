using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Assignment.Entity;
using Assignment.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyInfor : Page
    {
        private MemberService memberService;
        public MyInfor()
        {
            this.InitializeComponent();
            this.memberService = new MemberServiceApi();

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("token.txt").GetAwaiter().GetResult();
            string text = Windows.Storage.FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();

            var memberInfor = memberService.GetInformation(text);
            avatar.Source = new BitmapImage(new Uri(memberInfor.avatar));
            firstName.Text = memberInfor.firstName;
            lastName.Text = memberInfor.lastName;
            gender.Text = (memberInfor.gender).ToString();
            introduction.Text = memberInfor.introduction;
        }
    }
}
