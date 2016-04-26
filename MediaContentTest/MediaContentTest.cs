using System;
using Tizen.Content.MediaContent;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MediaContentTest
{
    public class NativeGlib
    {
        [DllImport("libglib-2.0.so.0", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr g_main_loop_new(IntPtr context, bool isRunning);

        [DllImport("libglib-2.0.so.0", CallingConvention = CallingConvention.Cdecl)]
        public static extern void g_main_loop_run(IntPtr loop);
    }
    internal class MainClass
    {
        public static async void Method()
        {
            Task<IEnumerable<MediaFolder>> getFoldersTask = ContentManager.GetContentCollectionAsync<MediaFolder>(new ContentFilter());
            IEnumerable<MediaFolder> foldersList = await getFoldersTask;
            foreach (MediaFolder fol in foldersList)
            {
                Console.WriteLine("Folder Path: " + fol.Path);
            }
        }
        public static void Main(string[] args)
        {
            //Get all media count in the media database
            ContentFilter filter = new ContentFilter();
            Console.WriteLine("All Media count: " + ContentManager.GetMediaInformationCount(filter));

            // Get different ContentCollections count
            Console.WriteLine("Album Count: " + ContentManager.GetContentCollectionCount(ContentCollectionType.Album, filter));
            Console.WriteLine("Folder Count: " + ContentManager.GetContentCollectionCount(ContentCollectionType.Folder, filter));
            Console.WriteLine("Storage Count: " + ContentManager.GetContentCollectionCount(ContentCollectionType.Storage, filter));
            Console.WriteLine("Tag Count: " + ContentManager.GetContentCollectionCount(ContentCollectionType.Tag, filter));
            Console.WriteLine("PlayList Count: " + ContentManager.GetContentCollectionCount(ContentCollectionType.PlayList, filter));

            //Get Bookmark count
            Console.WriteLine("Book mark Count: " + ContentManager.GetBookmarkCount(filter));
            Method();

            ContentCollection tag = new Tag("cool");
            Console.WriteLine(tag.GetType());
            IntPtr loop = NativeGlib.g_main_loop_new((IntPtr)0, false);
            NativeGlib.g_main_loop_run(loop);
        }
    }
}