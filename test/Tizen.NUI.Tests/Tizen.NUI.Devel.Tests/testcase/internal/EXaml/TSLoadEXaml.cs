// using global::System;
// using NUnit.Framework;
// using NUnit.Framework.TUnit;
// using Tizen.NUI.Components;
// using Tizen.NUI.BaseComponents;

// namespace Tizen.NUI.Devel.Tests
// {
//     using tlog = Tizen.Log;

//     [TestFixture]
//     [Description("Internal/EXaml/LoadEXaml")]
//     public class InternalLoadEXamlTest
//     {
//         private const string tag = "NUITEST";
//         private string eXamlString = "<?xml?><?xml-stylesheet?>";

//         [SetUp]
//         public void Init()
//         {
//             tlog.Info(tag, "Init() is called!");
//         }

//         [TearDown]
//         public void Destroy()
//         {
//             tlog.Info(tag, "Destroy() is called!");
//         }

//         [Test]
//         [Category("P1")]
//         [Description("LoadEXaml GatherDataList.")]
//         [Property("SPEC", "Tizen.NUI.LoadEXaml.GatherDataList M")]
//         [Property("SPEC_URL", "-")]
//         [Property("CRITERIA", "MR")]
//         [Property("AUTHOR", "guowei.wang@samsung.com")]
//         public void LoadEXamlGatherDataList()
//         {
//             tlog.Debug(tag, $"LoadEXamlGatherDataList START");

//             try
//             {
//                 Tizen.NUI.EXaml.LoadEXaml.GatherDataList(eXamlString);
//             }
//             catch (Exception e)
//             {
//                 tlog.Debug(tag, e.Message.ToString());
//                 Assert.Fail("Caught Exception : Failed!");
//             }

//             tlog.Debug(tag, $"LoadEXamlGatherDataList END (OK)");
//         }
//     }
// }
