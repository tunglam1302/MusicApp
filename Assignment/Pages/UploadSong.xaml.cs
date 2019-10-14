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
using Windows.UI.Xaml.Navigation;
using Assignment.Entity;
using Assignment.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UploadSong : Page
    {
        private ValidateService validateService;
        private SongService songService;
        public UploadSong()
        {
            this.InitializeComponent();
            this.songService = new SongService();
            this.validateService = new ValidateService();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var song = new Song
            {
                name = Name.Text,
                description = Description.Text,
                singer = Singer.Text,
                author = Author.Text,
                thumbnail = Thumbnail.Text,
                link = Link.Text,
            };
            Dictionary<String, String> errors = song.Validate();
            if (errors.Count == 0)
            {
                songService.PostSongFree(song);
                validateService.ValidateTrue();
                this.NavigationCacheMode = NavigationCacheMode.Disabled;
            }
            else
            {
                validateService.ValidateFalse(NameMessage, errors, "name");
                validateService.ValidateFalse(SingerMessage, errors, "single");
                validateService.ValidateFalse(ThumbnailMessage, errors, "thumbnail");
                validateService.ValidateFalse(LinkMessage, errors, "link");
                validateService.ValidateFalse(AuthorMessage, errors, "author");
            }
        }
    }
}
