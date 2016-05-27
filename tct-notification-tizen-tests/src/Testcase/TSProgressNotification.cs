using System;
using TestFramework;
using Tizen.Applications;
using Tizen.Applications.Notifications;

namespace TizenTest.Applications.Notifications
{
    [TestFixture]
    [Description("Progress Notification Api Test")]
    public class TSProgressNotification
    {
        [SetUp]
        public static void Init() {
        }

        [TearDown]
        public static void Destroy() {
        }

        [Test]
        [Category("P1")]
        [Description("Progress Notification constructor.")]
        [Property("SPEC", "Tizen.Applications.ProgressNotification C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void ProgressNotification_INIT() {
            /* TEST CODE */
            ProgressNotification noti = new ProgressNotification();
            Assert.IsNotNull(noti, "Progress Notification should not be null after init");
        }

        [Test]
        [Category("P1")]
        [Description("Test : ProgressNotification's Properties")]
        [Property("SPEC", " Tizen.Applications.ProgressNotification A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void ProgressNotification_PROPERTIES_SET_GET() {
            /* TEST CODE */
            double progressSize = 80;
            double progressValue = 50;
            double defaultSize = 100;
            double defaultValue = 0;

            ProgressNotification noti = new ProgressNotification();
            Assert.IsNotNull(noti, "Progress notification should not be null after init");

            Assert.AreEqual(defaultSize, noti.Maximum);
            noti.Maximum = progressSize;
            Assert.AreEqual(progressSize, noti.Maximum);

            Assert.AreEqual(defaultValue, noti.ProgressValue);
            noti.ProgressValue = progressValue;
            Assert.AreEqual(progressValue, noti.ProgressValue);
        }

        [Test]
        [Category("P2")]
        [Description("Test : Check ProgressNotification Maximum for negative value")]
        [Property("SPEC", " Tizen.Applications.ProgressNotification.Maximum A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Maximum_CHECK_MAXIMUM_FOR_NEGATIVE_VALUE() {
            /* TEST CODE */
            double negativeSize = -100;

            ProgressNotification noti = new ProgressNotification();
            Assert.IsNotNull(noti, "Progress notification should not be null after init");

            try
            {
                noti.Maximum = negativeSize;
                Assert.True(false, "Maximum cannot be set to negative values");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        [Category("P2")]
        [Description("Test : Check ProgressNotification Progress value for negative value")]
        [Property("SPEC", " Tizen.Applications.ProgressNotification.ProgressValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void ProgressValue_CHECK_PROGRESS_VALUE_FOR_NEGATIVE_VALUE() {
            /* TEST CODE */
            double negativeValue = -10;

            ProgressNotification noti = new ProgressNotification();
            Assert.IsNotNull(noti, "Progress notification should not be null after init");

            try
            {
                noti.ProgressValue = negativeValue;
                Assert.True(false, "ProgressValue cannot be set to negative values");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        [Category("P2")]
        [Description("Test : Check ProgressNotification Progress value for negative value")]
        [Property("SPEC", " Tizen.Applications.ProgressNotification.ProgressValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void ProgressValue_CHECK_PROGRESS_VALUE_FOR_INVALID_VALUE() {
            /* TEST CODE */
            double value = 120;
            double max = 100;

            ProgressNotification noti = new ProgressNotification();
            Assert.IsNotNull(noti, "Progress notification should not be null after init");

            noti.Maximum = max;
            try
            {
                noti.ProgressValue = value;
                Assert.True(false, "ProgressValue cannot be greater than max");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }
    }
}
