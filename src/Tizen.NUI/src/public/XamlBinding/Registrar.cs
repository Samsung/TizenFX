using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding.Internals
{
    /// <summary>
    /// For internal use.
    /// </summary>
    /// <typeparam name="TRegistrable"></typeparam>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Registrar<TRegistrable> where TRegistrable : class
    {
        readonly Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="tview">The type of the view</param>
        /// <param name="trender">The type of the render.</param>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Register(Type tview, Type trender)
        {
            //avoid caching null renderers
            if (trender == null)
                return;
            _handlers[tview] = trender;
        }

        internal TRegistrable GetHandler(Type type)
        {
            Type handlerType = GetHandlerType(type);
            if (handlerType == null)
                return null;

            object handler = DependencyResolver.ResolveOrCreate(handlerType);

            return (TRegistrable)handler;
        }

        internal TRegistrable GetHandler(Type type, params object[] args)
        {
            if (args.Length == 0)
            {
                return GetHandler(type);
            }

            Type handlerType = GetHandlerType(type);
            if (handlerType == null)
                return null;

            return (TRegistrable)DependencyResolver.ResolveOrCreate(handlerType, args);
        }

        /// <summary>
        /// For internal use. Returns handler.
        /// </summary>
        /// <typeparam name="TOut">The type of the handler</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>The handler instance.</returns>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TOut GetHandler<TOut>(Type type) where TOut : TRegistrable
        {
            return (TOut)GetHandler(type);
        }

        /// <summary>
        /// For internal use. Returns handler.
        /// </summary>
        /// <typeparam name="TOut">The type of the handler</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="args">The args of the type</param>
        /// <returns>The handler instance.</returns>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TOut GetHandler<TOut>(Type type, params object[] args) where TOut : TRegistrable
        {
            return (TOut)GetHandler(type, args);
        }

        /// <summary>
        /// For internal use. Return the handler of the object.
        /// </summary>
        /// <typeparam name="TOut">Thetype</typeparam>
        /// <param name="obj">The object instance.</param>
        /// <returns>The handle of the obj.</returns>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TOut GetHandlerForObject<TOut>(object obj) where TOut : TRegistrable
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var reflectableType = obj as IReflectableType;
            var type = reflectableType != null ? reflectableType.GetTypeInfo().AsType() : obj.GetType();

            return (TOut)GetHandler(type);
        }

        /// <summary>
        /// For inetrnal use. Return the handler of the object.
        /// </summary>
        /// <typeparam name="TOut">The type</typeparam>
        /// <param name="obj">The object instance</param>
        /// <param name="args">The args of the type</param>
        /// <returns>The handler of the object.</returns>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TOut GetHandlerForObject<TOut>(object obj, params object[] args) where TOut : TRegistrable
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var reflectableType = obj as IReflectableType;
            var type = reflectableType != null ? reflectableType.GetTypeInfo().AsType() : obj.GetType();

            return (TOut)GetHandler(type, args);
        }

        /// <summary>
        /// For internal use. Returns the handle type.
        /// </summary>
        /// <param name="viewType">The view type.</param>
        /// <returns>The type of the handle.</returns>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type GetHandlerType(Type viewType)
        {
            Type type;
            if (LookupHandlerType(viewType, out type))
                return type;

            // lazy load render-view association with RenderWithAttribute (as opposed to using ExportRenderer)
            var attribute = viewType.GetTypeInfo().GetCustomAttribute<RenderWithAttribute>();
            if (attribute == null)
            {
                Register(viewType, null); // Cache this result so we don't have to do GetCustomAttribute again
                return null;
            }

            type = attribute.Type;

            if (type.Name.StartsWith("_", StringComparison.Ordinal))
            {
                // TODO: Remove attribute2 once renderer names have been unified across all platforms
                var attribute2 = type.GetTypeInfo().GetCustomAttribute<RenderWithAttribute>();
                if (attribute2 != null)
                    type = attribute2.Type;

                if (type.Name.StartsWith("_", StringComparison.Ordinal))
                {
                    Register(viewType, null); // Cache this result so we don't work through this chain again
                    return null;
                }
            }

            Register(viewType, type); // Register this so we don't have to look for the RenderWith Attibute again in the future

            return type;
        }

        /// <summary>
        /// For internal use. Return the handle type of the object
        /// </summary>
        /// <param name="obj">The object instance.</param>
        /// <returns>The type of the handler.</returns>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Type GetHandlerTypeForObject(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var reflectableType = obj as IReflectableType;
            var type = reflectableType != null ? reflectableType.GetTypeInfo().AsType() : obj.GetType();

            return GetHandlerType(type);
        }

        bool LookupHandlerType(Type viewType, out Type handlerType)
        {
            Type type = viewType;

            while (type != null)
            {
                if (_handlers.ContainsKey(type))
                {
                    handlerType = _handlers[type];
                    return true;
                }

                type = type.GetTypeInfo().BaseType;
            }

            handlerType = null;
            return false;
        }
    }

    /// <summary>
    /// For internal use
    /// </summary>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class Registrar
    {
        static Registrar()
        {
            Registered = new Registrar<IRegisterable>();
        }

        internal static Dictionary<string, Type> Effects { get; } = new Dictionary<string, Type>();
        internal static Dictionary<string, StyleSheets.StylePropertyAttribute> StyleProperties { get; } = new Dictionary<string, StyleSheets.StylePropertyAttribute>();

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IEnumerable<Assembly> ExtraAssemblies { get; set; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Registrar<IRegisterable> Registered { get; internal set; }
    }
}
