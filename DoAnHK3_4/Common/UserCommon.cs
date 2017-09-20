using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.Common
{
    [Serializable]
    public class UserCommon
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool FaceBook { get; set; }
        public bool? Payment { get; set; }




    }
}