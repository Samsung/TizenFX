using System;
using TestFramework;
using Tizen.Applications;
using Tizen.Applications.Notifications;

namespace TizenTest.Applications.Notifications
{
    [TestFixture]
    [Description("NotificationManager Api Test")]
    public class TSNotificationManager
    {
        [SetUp]
        public static void Init() {
        }

        [TearDown]
        public static void Destroy() {
        }

        [Test]
        [Category("P1")]
        [Description("Post a Notification.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Post M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Post_RETURN_VALUE() {
            /* TEST CODE */
            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            try
            {
                NotificationManager.Post(noti);
            }
            catch(Exception)
            {
                Assert.True(false, "Post method should not throw an exception");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Update a posted Notification.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Update M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Update_RETURN_VALUE() {
            /* TEST CODE */
            string title = "title";
            string newTitle = "newTitle";

            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            noti.Title = title;
            try
            {
                NotificationManager.Post(noti);
            }
            catch(Exception)
            {
                Assert.True(false, "Post method should not throw an exception");
            }

            noti.Title = newTitle;
            try
            {
                NotificationManager.Update(noti);
            }
            catch(Exception)
            {
                Assert.True(false, "Update method should not throw an exception");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Deletes a posted Notification.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Delete M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Delete_RETURN_VALUE() {
            /* TEST CODE */
            EventNotification noti = new EventNotification();
            Assert.IsNotNull(noti, "Event Notification should not be null after init");

            try
            {
                NotificationManager.Post(noti);
            }
            catch(Exception)
            {
                Assert.True(false, "Post method should not throw an exception");
            }

            try
            {
                NotificationManager.Delete(noti);
            }
            catch(Exception)
            {
                Assert.True(false, "Delete method should not throw an exception");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Deletes a type of posted Notifications.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.DeleteAll M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void DeleteAll_RETURN_VALUE() {
            /* TEST CODE */
            EventNotification notiT = new EventNotification();
            Assert.IsNotNull(notiT, "Event Notification should not be null after init");

            ProgressNotification notiP = new ProgressNotification();
            Assert.IsNotNull(notiP, "Progress Notification should not be null after init");

            try
            {
                NotificationManager.Post(notiT);
                NotificationManager.Post(notiP);
            }
            catch(Exception)
            {
                Assert.True(false, "Post method should not throw an exception");
            }

            try
            {
                NotificationManager.DeleteAll(NotificationType.Event);
                NotificationManager.DeleteAll(NotificationType.Progress);
            }
            catch(Exception)
            {
                Assert.True(false, "Delete all method should not throw an exception");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Deletes all posted Notifications.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.DeleteAll M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void DeleteAllTypes_RETURN_VALUE() {
            /* TEST CODE */
            EventNotification notiT = new EventNotification();
            Assert.IsNotNull(notiT, "Event Notification should not be null after init");

            ProgressNotification notiP = new ProgressNotification();
            Assert.IsNotNull(notiP, "Progress Notification should not be null after init");

            try
            {
                NotificationManager.Post(notiT);
                NotificationManager.Post(notiP);
            }
            catch(Exception)
            {
                Assert.True(false, "Post method should not throw an exception");
            }

            try
            {
                NotificationManager.DeleteAll();
            }
            catch(Exception)
            {
                Assert.True(false, "Delete all method should not throw an exception");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Posts a toast message")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.PostToastMessage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void PostToastMessage_RETURN_VALUE() {
            /* TEST CODE */
            string message = "Message";

            try
            {
                NotificationManager.PostToastMessage(message);
            }
            catch(Exception)
            {
                Assert.True(false, "Post toast message method should not throw an exception");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Loads a posted notification")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Load M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Load_RETURN_VALUE() {
            /* TEST CODE */
            string titleP = "ProgressTitle";
            string titleE = "EventTitle";
            string tagP = "progress";
            string tagE = "event";
            ProgressNotification notiPCopy;
            EventNotification notiECopy;
            Notification notiCopy;

            ProgressNotification notiP = new ProgressNotification();
            Assert.IsNotNull(notiP, "Progress Notification should not be null after init");

            notiP.Title = titleP;
            notiP.Tag = tagP;

            EventNotification notiE = new EventNotification();
            Assert.IsNotNull(notiE, "Event Notification should not be null after init");

            notiE.Title = titleE;
            notiE.Tag = tagE;
            try
            {
                NotificationManager.Post(notiP);
                NotificationManager.Post(notiE);
            }
            catch(Exception)
            {
                Assert.True(false, "Post method should not throw an exception");
            }

            try
            {
                notiPCopy = NotificationManager.Load<ProgressNotification>(tagP);
                Assert.IsNotNull(notiPCopy, "Progress Notification copy cannot be null");

                notiECopy = NotificationManager.Load<EventNotification>(tagE);
                Assert.IsNotNull(notiECopy, "Event Notification copy cannot be null");

                notiCopy = NotificationManager.Load<Notification>(tagE);
                Assert.IsNotNull(notiCopy, "Notification copy cannot be null");

                Assert.AreEqual(titleP, notiPCopy.Title, "Title values should match for ProgressNotification");

                Assert.AreEqual(titleE, notiECopy.Title, "Title values should match for EventNotification");
            }
            catch(Exception)
            {
                Assert.True(false, "Load method should  not throw an exception");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check post method for null argument.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Post M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Post_CHECK_FOR_NULL_INPUT() {
            /* TEST CODE */
            try
            {
                NotificationManager.Post(null);
                Assert.True(false, "Post method should throw an exception");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check update method for null argument.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Update M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Update_CHECK_FOR_NULL_INPUT() {
            /* TEST CODE */
            try
            {
                NotificationManager.Update(null);
                Assert.True(false, "Update method should throw an exception");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check delete method for null argument.")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Delete M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Delete_CHECK_FOR_NULL_INPUT() {
            /* TEST CODE */
            try
            {
                NotificationManager.Delete(null);
                Assert.True(false, "Delete method should throw an exception");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check post toast method for null argument")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.PostToastMessage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void PostToastMessage_CHECK_FOR_NULL_INPUT() {
            /* TEST CODE */
            try
            {
                NotificationManager.PostToastMessage(null);
                Assert.True(false, "Post toast message method should throw an exception");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check load method for null argument")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Load M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Load_CHECK_FOR_NULL_INPUT() {
            /* TEST CODE */
            try
            {
                NotificationManager.Load<Notification>(null);
                Assert.True(false, "Load method should throw an exception");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        [Category("P2")]
        [Description("Check load method for not finding a Notification object")]
        [Property("SPEC", "Tizen.Applications.NotificationManager.Load M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Randeep Ahlawat, randeep.ah@samsung.com")]
        public static void Load_CHECK_FOR_INCORRECT_TAG() {
            /* TEST CODE */
            string tag = "test";

            try
            {
                NotificationManager.DeleteAll();
            }
            catch(Exception)
            {
                Assert.True(false, "Load method should not throw an exception");
            }

            try
            {
                NotificationManager.Load<Notification>(tag);
                Assert.True(false, "Load method should throw an exception");
            }
            catch(Exception)
            {
                Assert.Pass();
            }
        }
    }



}
