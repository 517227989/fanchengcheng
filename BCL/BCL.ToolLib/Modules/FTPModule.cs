using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BCL.ToolLib.Modules
{
    public class FTPModule : IDisposable
    {
        protected FtpWebRequest _Req { get; set; }
        protected string User { get; set; }
        protected string Password { get; set; }
        protected string Root { get; set; }
        protected bool Passive { get; set; }
        public FTPModule(string _IP, string _User, string _Password, bool _Passive = false)
        {
            User = _User;
            Password = _Password;
            Root = String.Format("ftp://{0}/", _IP);
            Passive = _Passive;
        }
        public FtpWebRequest CreateInstance(string _Url)
        {
            _Req = WebRequest.Create(new Uri(_Url)) as FtpWebRequest;
            _Req.Credentials = new NetworkCredential(User, Password);
            _Req.KeepAlive = false;
            _Req.UsePassive = Passive;
            return _Req;
        }
        public string FileDelete(string _Path, string _Name)
        {
            _Req = CreateInstance(Root + _Path + _Name);
            _Req.Method = WebRequestMethods.Ftp.DeleteFile;

            using (var _Res = _Req.GetResponse() as FtpWebResponse)
            {
                using (var _Sr = new StreamReader(_Res.GetResponseStream()))
                {
                    _Sr.ReadToEnd();
                }
                return _Req.RequestUri.AbsolutePath;
            }
        }
        public string FileDownload(string _LPath, string _LName, string _Path, string _Name)
        {
            _Req = CreateInstance(Root + _Path + _Name);
            _Req.Method = WebRequestMethods.Ftp.DownloadFile;
            _Req.UseBinary = true;
            if (!Directory.Exists(_LPath))
                Directory.CreateDirectory(_LPath);

            using (var _Res = _Req.GetResponse() as FtpWebResponse)
            {
                using (var _Fs = new FileStream(_LPath + _LName, FileMode.Create))
                {
                    var s = _Res.GetResponseStream();
                    int size = 2048;
                    byte[] buffer = new byte[size];
                    int rc = s.Read(buffer, 0, size);
                    while (rc > 0)
                    {
                        _Fs.Write(buffer, 0, rc);
                        rc = s.Read(buffer, 0, size);
                    }
                }
                return _Req.RequestUri.AbsolutePath;
            }
        }
        public string FileExist(string _Path, string _Name)
        {
            _Req = CreateInstance(Root + _Path);
            _Req.Method = WebRequestMethods.Ftp.ListDirectory;
            using (var _Res = _Req.GetResponse() as FtpWebResponse)
            {
                using (var _Sr = new StreamReader(_Res.GetResponseStream()))
                {
                    if (_Sr.ReadToEnd().Contains(_Name))
                        return _Req.RequestUri.AbsolutePath;
                }
                return null;
            }
        }
        public string FileRename()
        {
            throw new NotImplementedException();
        }
        public string FileUpLoad(string _FullName, string _Path, string _Name)
        {
            var _FI = new FileInfo(_FullName);
            _Req = CreateInstance(Root + _Path + _Name);
            _Req.Method = WebRequestMethods.Ftp.UploadFile;
            _Req.UseBinary = true;
            _Req.ContentLength = _FI.Length;

            using (var _Res = _Req.GetResponse() as FtpWebResponse)
            {
                using (var _Fs = _FI.OpenRead())
                {
                    var s = _Res.GetResponseStream();
                    int size = 2048;
                    byte[] buffer = new byte[size];
                    int rc = s.Read(buffer, 0, size);
                    while (rc > 0)
                    {
                        _Fs.Write(buffer, 0, rc);
                        rc = s.Read(buffer, 0, size);
                    }
                }
                return _Req.RequestUri.AbsolutePath;
            }
        }
        public void Dispose()
        {
            GC.Collect();
        }
    }
}
