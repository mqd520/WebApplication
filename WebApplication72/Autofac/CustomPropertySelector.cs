using Autofac.Core;
using System.Reflection;

namespace WebApplication72.Autofac
{
    public class CustomPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.IsDefined(typeof(CustomPropertySelectorAttribute), false);
        }
    }
}
