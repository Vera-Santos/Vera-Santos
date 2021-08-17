using System;

namespace Store
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class PathAttribute : Attribute
    {
        public string Path { get; private set; }
        public PathAttribute(string value)
        {
            Path = value;
        }
    }
}