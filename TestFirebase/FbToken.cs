using System.Collections.Generic;

namespace TestFirebase
{
    public class FbToken
    {
        public List<string> registrationsIds { get; set; }
        public NotificationModel NotificationModel { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
