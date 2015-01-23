using System;

namespace NSCC.Web.Awards.Classes
{
    [Serializable]
    public class AwardAttachment
    {
        public string AttachmentType { get; set; }
        public string Filename { get; set; }
    }
}