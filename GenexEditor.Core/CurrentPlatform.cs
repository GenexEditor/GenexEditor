using System;

namespace GenexEditor.Core
{
    public static class CurrentPlatform
    {
        public static bool IsWindows { get; set; }

        public static bool IsLinux { get; set; }

        public static bool IsMac { get; set; }

        public static bool IsUnix { get; set; }
    }
}
