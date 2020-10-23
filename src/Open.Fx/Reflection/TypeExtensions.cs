using System.Linq;

namespace System.Reflection
{
    public static class TypeExtensions
    {
        public static bool HasAttribute<T>(
            this Type source)
        {
            var attributeType = typeof(T);

            var attributes =
                source
                    .GetCustomAttributes(true)
                    .Concat(
                        source
                            .GetInterfaces()
                            .SelectMany(i => i.GetCustomAttributes(true)));

            var returnValue =
                attributes.Any(x => x.GetType() == attributeType);

            return returnValue;
        }

        public static bool Implements<T>(
            this Type sourceType,
            bool isClass = true)
        {
            return sourceType.Implements(typeof(T), isClass);
        }

        public static bool Implements(
            this Type sourceType,
            Type scanType,
            bool isClass = true)
        {
            var isAssignable =
                scanType.IsAssignableFrom(sourceType) ||
                sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == scanType;

            if (isAssignable && isClass && !sourceType.IsInterface && !sourceType.IsAbstract)
            {
                return true;
            }

            return isAssignable;
        }

        public static void SetProperty(
            this Type type,
            object target,
            string name,
            object value)
        {
            var bindingFlags =
                BindingFlags.SetProperty |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.FlattenHierarchy |
                BindingFlags.Instance;

            type
                .InvokeMember(
                    name,
                    bindingFlags,
                    null,
                    target,
                    new[] { value });
        }

        public static bool TrySetPropertyValue(
            this object @object,
            string propertyName,
            object value)
        {
            var field =
                @object
                    .GetType()
                    .GetField(
                        $"<{propertyName}>k__BackingField",
                        BindingFlags.NonPublic |
                        BindingFlags.Instance |
                        BindingFlags.FlattenHierarchy);

            if (field != default)
            {
                field.SetValue(@object, value);
            }

            return field?.GetValue(@object) == value;
        }
    }
}