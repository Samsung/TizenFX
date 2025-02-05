using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class AlertDialog
    {
        /// <summary>
        /// TitleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleProperty = null;
        internal static void SetInternalTitleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalTitle = newValue as string;
            }
        }
        internal static object GetInternalTitleProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalTitle;
        }

        /// <summary>
        /// TitleContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleContentProperty = null;
        internal static void SetInternalTitleContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalTitleContent = newValue as View;
            }
        }
        internal static object GetInternalTitleContentProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalTitleContent;
        }

        /// <summary>
        /// MessageProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MessageProperty = null;
        internal static void SetInternalMessageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalMessage = newValue as string;
            }
        }
        internal static object GetInternalMessageProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalMessage;
        }

        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = null;
        internal static void SetInternalContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalContent = newValue as View;
            }
        }
        internal static object GetInternalContentProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalContent;
        }

        /// <summary>
        /// ActionsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ActionsProperty = null;
        internal static void SetInternalActionsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalActions = newValue as IEnumerable<View>;
            }
        }
        internal static object GetInternalActionsProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalActions;
        }

        /// <summary>
        /// ActionContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ActionContentProperty = null;
        internal static void SetInternalActionContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalActionContent = newValue as View;
            }
        }
        internal static object GetInternalActionContentProperty(BindableObject bindable)
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalActionContent;
        }
    }
}
