using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Api
{
    public class TimeSlot
    {
        public TimeSlot(GroupEvent groupEvent)
        {
            Events = new List<GroupEvent> { groupEvent };
        }

        public List<GroupEvent> Events
        {
            get;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var groupEvent in Events)
            {
                sb.AppendLine(groupEvent.ToString());
            }

            return WebUtility.HtmlEncode(sb.ToString()).Replace(Environment.NewLine, "<br />");
        }
    }
}