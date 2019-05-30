using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Threading;

namespace Tizen.NUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPerformanceProvider
	{
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Stop(string reference, string tag, string path, string member);

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        void Start(string reference, string tag, string path, string member);
	}

    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
	public class Performance
	{
		static long Reference;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IPerformanceProvider Provider { get; private set; }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetProvider(IPerformanceProvider instance)
		{
			Provider = instance;
		}

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Start(out string reference, string tag = null, [CallerFilePath] string path = null, [CallerMemberName] string member = null)
		{
			if (Provider == null)
			{
				reference = String.Empty;
				return;
			}

			reference = Interlocked.Increment(ref Reference).ToString();
			Provider.Start(reference, tag, path, member);
		}

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Start(string reference, string tag = null, [CallerFilePath] string path = null,
			[CallerMemberName] string member = null)
		{
			Provider?.Start(reference, tag, path, member);
		}

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Stop(string reference, string tag = null, [CallerFilePath] string path = null, [CallerMemberName] string member = null)
		{
			Provider?.Stop(reference, tag, path, member);
		}

		internal static IDisposable StartNew(string tag = null, [CallerFilePath] string path = null, [CallerMemberName] string member = null)
		{
			return new DisposablePerformanceReference(tag, path, member);
		}

		class DisposablePerformanceReference : IDisposable
		{
			string _reference;
			string _tag;
			string _path;
			string _member;

			public DisposablePerformanceReference(string tag, string path, string member)
			{
				_tag = tag;
				_path = path;
				_member = member;
				Start(out string reference, _tag, _path, _member);
				_reference = reference;
			}

			public void Dispose()
			{
				Stop(_reference, _tag, _path, _member);
			}
		}
	}
}
