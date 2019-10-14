using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Constant
{
    class ApiUrl
    {
        public const string REGISTER_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/members";
        public const string LOGIN_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/authentication";
        public const string GET_INFORMATION_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/information";
        public const string GET_FREE_SONG_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";
        public const string UPLOAD_SONG_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs";
        public const string MY_SONG_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-mine";
        public const string UPLOAD_IMAGE_URL = "https://2-dot-backup-server-003.appspot.com/get-upload-token";
    }
}
