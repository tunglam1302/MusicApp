
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Assignment.Constant;
using Assignment.Entity;
using Assignment.Service;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private StorageFile photo;
        private int gender = 0;
        private ValidateService validateService;
        private MemberService memberService;
        public Register()
        {
            this.InitializeComponent();
            this.memberService = new MemberServiceApi();
            this.validateService = new ValidateService();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var member = new Member
            {
                firstName = this.Firstname.Text,
                lastName = this.Lastname.Text,
                avatar = this.AvatarUrl.Text,
                phone = this.Phone.Text,
                address = this.Address.Text,
                introduction = this.Introduction.Text,
                gender = gender,
                birthday = this.Birthday.Date.ToString("yyyy-MM-dd"),
                email = this.Email.Text,
                password = this.Password.Password
            };
            Dictionary<String, String> errors = member.Validate();
            if (errors.Count == 0)
            {
                try
                {
                    memberService.Register(member);
                    validateService.ValidateTrue();
                    this.NavigationCacheMode = NavigationCacheMode.Disabled;
                }
                catch (Exception exception)
                {
                    MessageDialog dialog = new MessageDialog(exception.Message);
                    await dialog.ShowAsync();
                }
            }
            else
            {
                validateService.ValidateFalse(FirstNameMessage, errors, "firstName");
                validateService.ValidateFalse(LastNameMessage, errors, "lastName");
                validateService.ValidateFalse(EmailMessage, errors, "email");
                validateService.ValidateFalse(PasswordMessage, errors, "password");
                validateService.ValidateFalse(PhoneMessage, errors, "phone");
                validateService.ValidateFalse(AddressMessage, errors, "address");

            }

        }

        private async void ButtonBase_Photo(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            var uploadUrl = client.GetAsync(ApiUrl.UPLOAD_IMAGE_URL).Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Upload url: " + uploadUrl);

            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            this.photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (this.photo == null)
            {
                // User cancelled photo capture
                return;
            }

            UploadFile(uploadUrl, "myFile", "image/png");
        }

        public async void UploadFile(string url, string paramName, string contentType)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            Stream rs = await wr.GetRequestStreamAsync();
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, "path_file", contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            // write file.
            Stream fileStream = await photo.OpenStreamForReadAsync();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);

            WebResponse wresp = null;
            try
            {
                wresp = await wr.GetResponseAsync();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string imageUrl = reader2.ReadToEnd();
                Avatar.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
                AvatarUrl.Text = imageUrl;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error uploading file", ex.StackTrace);
                Debug.WriteLine("Error uploading file", ex.InnerException);
                if (wresp != null)
                {
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        private void Gender_check(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                string colorName = rb.Tag.ToString();
                switch (colorName)
                {
                    case "Male":
                        gender = 0;
                        break;
                    case "Female":
                        gender = 1;
                        break;
                }
            }
        }
    }
}
