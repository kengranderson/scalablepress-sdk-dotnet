using System;

namespace ScalablePress.API.Models.MockupApi
{
    internal class MockupTemplateAttribute : Attribute
    {
        public MockupTemplateAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
