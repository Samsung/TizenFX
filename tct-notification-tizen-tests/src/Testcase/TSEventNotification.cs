using System;
using TestFramework;
using Tizen.Applications;
using Tizen.Applications.Notifications;

namespace TizenTest.Applications.Notifications
{
    [TestFixture]
    [Description("Event Notification Api Test")]
    public class TSEventNotification
    {
        [SetUp]
        public static void Init() {
        }

        [TearDown]
        public static void Destroy() {
        }

        [Test]
        [Category("P1")]
        [Description("EventNotification constructor.")]
        [Property("SPEC", "Tizen.Applications.EventNotification C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void EventNotification_INIT() {
            /* TEST CODE */
            EventNotification firstNoti = new EventNotification();
            Assert.IsNotNull(firstNoti, "Event Notification should not be null after init");
        }

        [Test]
        [Category("P1")]
        [Description("Test : EventNotification's Properties")]
        [Property("SPEC", " Tizen.Applications.EventNotification A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void EventNotification_PROPERTIES_SET_GET() {
            /* TEST CODE */
            int eventCount = 2;
            DateTime testDate = new DateTime(2002, 10, 15);
            int defaultEventCount = 0;
            DateTime defaultDate = new DateTime(1970, 1, 1, 9, 0, 0);

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event notification should not be null after init");

            Assert.AreEqual(defaultEventCount, noti.EventCount, "Default Event count for EventCount property should match value from getter");
            noti.EventCount = eventCount;
            Assert.AreEqual(eventCount, noti.EventCount, "Event count set for EventCount property should match value from getter");

            Assert.AreEqual(0, DateTime.Compare(defaultDate, noti.Timestamp));
            noti.Timestamp = testDate;
            Assert.AreEqual(0, DateTime.Compare(testDate, noti.Timestamp));
        }

        [Test]
        [Category("P1")]
        [Description("Add a button to a notificaiton.")]
        [Property("SPEC", "Tizen.Applications.EventNotification.AddButton M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void AddButton_RETURN_VALUE() {
            /* TEST CODE */
            string buttonText = "AAA";
            string buttonImage = "BBB";
            AppControl app = new AppControl();

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            foreach(ButtonIndex t in Enum.GetValues(typeof(ButtonIndex)))
            {
                try
                {
                    noti.AddButton(t, buttonImage, buttonText, app);
                }
                catch(Exception)
                {
                    Assert.True(false, "Add button should not throw an exception");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("Remove a added button from a notificaiton.")]
        [Property("SPEC", "Tizen.Applications.EventNotification.RemoveButton M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void RemoveButton_RETURN_VALUE() {
            /* TEST CODE */
            string buttonText = "AAA";
            string buttonImage = "BBB";
            AppControl app = new AppControl();

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            foreach(ButtonIndex t in Enum.GetValues(typeof(ButtonIndex)))
            {
                try
                {
                    noti.AddButton(t, buttonImage, buttonText, app);
                }
                catch(Exception)
                {
                    Assert.True(false, "Add button should not throw an exception");
                }

                try
                {
                    noti.RemoveButton(t);
                }
                catch(Exception)
                {
                    Assert.True(false, "Remove button should not throw an exception");
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("Test : Check for negative value set for event count")]
        [Property("SPEC", " Tizen.Applications.EventNotification.EventCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void EventCount_CHECK_FOR_NEGATIVE_VALUE() {
            /* TEST CODE */
            int eventCount = -2;

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event notification should not be null after init");

            try
            {
                noti.EventCount = eventCount;
                Assert.True(false, "Event count cannot be set to negative values");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }
    }
}
