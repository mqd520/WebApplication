using System.Reflection;

namespace WebApplication16.Tools
{
    public static class CommonTool
    {
        public static bool IsAsyncMethod(MethodInfo mi)
        {
            return (mi.ReturnType == typeof(Task)
                    || (mi.ReturnType.IsGenericType && mi.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            );
        }
    }
}
