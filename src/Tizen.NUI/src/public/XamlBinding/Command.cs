/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Reflection;
using System.Windows.Input;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Command<T> : Command
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Command(Action<T> execute)
            : base(o =>
            {
                if (IsValidParameter(o))
                {
                    execute((T)o);
                }
            })
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Command(Action<T> execute, Func<T, bool> canExecute)
            : base(o =>
            {
                if (IsValidParameter(o))
                {
                    execute((T)o);
                }
            }, o => IsValidParameter(o) && canExecute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        static bool IsValidParameter(object o)
        {
            if (o != null)
            {
                // The parameter isn't null, so we don't have to worry whether null is a valid option
                return o is T;
            }

            var t = typeof(T);

            // The parameter is null. Is T Nullable?
            if (Nullable.GetUnderlyingType(t) != null)
            {
                return true;
            }

            // Not a Nullable, if it's a value type then null is not valid
            return !t.GetTypeInfo().IsValueType;
        }
    }

    /// <summary>
    /// Defines an ICommand implementation that wraps a Action.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Command : ICommand
    {
        readonly Func<object, bool> _canExecute;
        readonly Action<object> _execute;

        /// <summary>
        /// Initializes a new instance of the Command class.
        /// </summary>
        /// <param name="execute">An instance to execute when the Command is executed.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Command(Action<object> execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
        }

        /// <summary>
        /// Initializes a new instance of the Command class.
        /// </summary>
        /// <param name="execute">An Action to execute when the Command is executed.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Command(Action execute) : this(o => execute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        /// <summary>
        /// Initializes a new instance of the Command class.
        /// </summary>
        /// <param name="execute">An Action to execute when the Command is executed.</param>
        /// <param name="canExecute">A instance indicating if the Command can be executed.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Command(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));

            _canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the Command class.
        /// </summary>
        /// <param name="execute">An Action to execute when the Command is executed.</param>
        /// <param name="canExecute">A instance indicating if the Command can be executed.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Command(Action execute, Func<bool> canExecute) : this(o => execute(), o => canExecute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }

        /// <summary>
        /// Returns a Boolean indicating if the Command can be executed with the given parameter.
        /// </summary>
        /// <param name="parameter">An Object used as parameter to determine if the Command can be executed.</param>
        /// <returns>true if the Command can be executed, false otherwise.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        /// <summary>
        /// Occurs when the target of the Command should reevaluate whether or not the Command can be executed.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Invokes the execute Action.
        /// </summary>
        /// <param name="parameter">An Object used as parameter for the execute Action.</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Send a CanExecuteChanged.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ChangeCanExecute()
        {
            EventHandler changed = CanExecuteChanged;
            changed?.Invoke(this, EventArgs.Empty);
        }
    }
}
