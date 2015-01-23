using System;

namespace CodeGolem
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class MarkupControlEventAttribute : Attribute
    {
        public string EventName;
        public string EventHandler;

        public MarkupControlEventAttribute(string eventName, string eventHandler)
        {
            EventName = eventName;
            EventHandler = eventHandler;
        }
    }
}
