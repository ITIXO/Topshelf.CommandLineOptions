using System;

namespace Topshelf.CommandLineOptions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class OptionAttribute : Attribute
    {
        public string OptionName { get; set; }

        public OptionAttribute(string optionName)
        {
            OptionName = optionName;
        }
    }
}
