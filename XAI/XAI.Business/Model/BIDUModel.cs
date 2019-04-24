using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAI.Business.Model
{
    public class BIDURequest
    {
        public List<BIDUImageInfo> image_list { get; set; }
        public string image { get; set; }
        public string image_type { get; set; }
        public string group_id_list { get; set; }
        public string quality_control { get; set; }
        public string liveness_control { get; set; }
        public string user_id { get; set; }
        public string max_user_num { get; set; }
        public string group_id { get; set; }
        public string user_info { get; set; }
        public string face_token { get; set; }
    }
    public class BIDUImageInfo
    {
        public string image { get; set; }
        public string image_type { get; set; }
        public string face_type { get; set; }
        public string quality_control { get; set; }
        public string liveness_control { get; set; }
    }
    public class BIDUResponse
    {
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public string log_id { get; set; }
        public string timestamp { get; set; }
        public BIDUResult result { get; set; }
    }
    public class FaceInfo
    {
        public string face_token { get; set; }
    }
    public class UserInfo
    {
        public string group_id { get; set; }
        public string user_id { get; set; }
        public string user_info { get; set; }
        public float score { get; set; }
    }
    public class LocationInfo
    {
        public double left { get; set; }
        public double top { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public long rotation { get; set; }
    }
    public class BIDUResult
    {

        public float score { get; set; }
        public List<FaceInfo> face_list { get; set; }
        public string face_token { get; set; }
        public List<UserInfo> user_list { get; set; }
        public LocationInfo location { get; set; }
        public List<string> user_id_list { get; set; }
    }
}
