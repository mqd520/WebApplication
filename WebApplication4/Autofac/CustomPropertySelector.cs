using System.Reflection;

using Autofac.Core;

namespace WebApplication4.Autofac
{
    public sealed class CustomPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.IsDefined(typeof(CustomPropertySelectorAttribute), false);
        }
    }
}
