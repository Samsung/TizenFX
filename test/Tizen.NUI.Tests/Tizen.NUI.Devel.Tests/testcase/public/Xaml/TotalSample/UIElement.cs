using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    public class GenericTemple<T>
    {

    }

    public class CustomList : List<string>
    {
        public class ParamType
        {
            public static implicit operator ParamType(int i)
            {
                var ret = new ParamType();
                ret.value = i;
                return ret;
            }

            private int value;

            public override string ToString()
            {
                return value.ToString();
            }
        }

        public static implicit operator CustomList(ParamType p)
        {
            return new CustomList() { p.ToString() };
        }
    }

    [ContentProperty("VisualStateGroup")]
    public partial class UIElement : View, IResourcesProvider
    {
        public UIElement()
        {

        }

        public UIElement(int p)
        {

        }

        public UIElement(int[] p)
        {

        }

        public enum TestEnum
        {
            V1,
            V2
        }

        public UIElement(TestEnum p)
        {

        }

        public CustomList CustomList
        {
            get;
            set;
        } = new CustomList();

        public List<string> StrList
        {
            get;
            set;
        }

        public View Child
        {
            get;
            set;
        }

        private static View staticChild;
        public static View StaticChild
        {
            get
            {
                if (null == staticChild)
                {
                    staticChild = new View();
                }
                return staticChild;
            }
            set
            {
                staticChild?.Dispose();
                staticChild = value;
            }
        }

        public class TestNestType
        {
            public TestNestType(int p = 0)
            {

            }
        }

        public UIElement(TestNestType p)
        {

        }

        public UIElement(UIElement p)
        {

        }

        public UIElement([Parameter("CharP")]char c)
        {

        }

        public UIElement(List<object> p)
        {

        }

        public static UIElement FactoryMethod(int p1, string p2, float p3)
        {
            return new UIElement();
        }

        public static UIElement FactoryMethodWithoutParams()
        {
            return new UIElement();
        }

        public int IntP
        {
            get
            {
                return (int)GetValue(IntPProperty);
            }
            set
            {
                SetValue(IntPProperty, value);
            }
        }

        public BindableProperty CustomBindableProperty
        {
            get;
            set;
        }

        private string stringP;
        public string StringP
        {
            get
            {
                return (string)GetValue(StringPProperty);
            }
            set
            {
                SetValue(StringPProperty, value);
            }
        }

        private string[] stringIndexer;
        public string[] StringIndexer
        {
            get
            {
                if (null == stringIndexer)
                {
                    stringIndexer = new string[1];
                    stringIndexer[0] = "Indexer";
                }

                return stringIndexer;
            }
            set
            {
                stringIndexer = value;
            }
        }

        public float FloatP
        {
            get
            {
                return (float)GetValue(FloatPProperty);
            }
            set
            {
                SetValue(FloatPProperty, value);
            }
        }

        public event EventHandler<EventArgs> Event;

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        internal bool IsFocused { get; set; } = false;

        internal void CommandCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            ICommand cmd = Command;
            if (cmd != null)
                cmd.CanExecute(CommandParameter);
        }

        internal void OnCommandChanged()
        {
            if (Command != null)
            {
                Command.CanExecuteChanged += CommandCanExecuteChanged;
                CommandCanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
