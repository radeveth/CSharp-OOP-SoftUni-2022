using System;

namespace Demo03.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
