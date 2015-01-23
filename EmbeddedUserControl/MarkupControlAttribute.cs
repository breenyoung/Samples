using System;

namespace CodeGolem
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public class MarkupControlAttribute : Attribute
    {
        public string ID;

        public MarkupControlAttribute()
        {
        }

        public MarkupControlAttribute(string id)
        {
            ID = id;
        }
    }
}
