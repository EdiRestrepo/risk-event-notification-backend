using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Presentation.DTOs
{
    public class SiataAlertDto
    {
        public String Event_id { get; set; }

        public Int16 Event_type { get; set; }

        public Int16 Risk_type { get; set; }

        public String Severity { get; set; }

        public String AlertName { get; set; }

        public String Place { get; set; }

        public String Description { get; set; }

        public DateTime TimestampAlert { get; set; }

        public List<String> Recommendations { get; set; }

        public Boolean isBasic { get; set; }

        public String Origen { get; set; }

        public List<Int16> NotificationChannels { get; set; }


        public override string ToString()
        {
            return $"{Event_id},{Event_type},{Risk_type},{Severity},{AlertName},{Place},{Description},{TimestampAlert},{Recommendations},{isBasic},{Origen},{NotificationChannels}";
        }

    }
}
