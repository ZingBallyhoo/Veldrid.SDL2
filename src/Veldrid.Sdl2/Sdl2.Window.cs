using System;

namespace Veldrid.Sdl2
{
    public static unsafe partial class Sdl2Native
    {
        private delegate IntPtr SDL_CreateWindow_t(string title, int x, int y, int w, int h, SDL_WindowFlags flags);
        private static SDL_CreateWindow_t s_sdl_createWindow = LoadFunction<SDL_CreateWindow_t>("SDL_CreateWindow");
        public static IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, SDL_WindowFlags flags) => s_sdl_createWindow(title, x, y, w, h, flags);

        private delegate IntPtr SDL_DestroyWindow_t(SDL_Window window);
        private static SDL_DestroyWindow_t s_sdl_destroyWindow = LoadFunction<SDL_DestroyWindow_t>("SDL_DestroyWindow");
        public static IntPtr SDL_DestroyWindow(SDL_Window window) => s_sdl_destroyWindow(window);

        private delegate void SDL_GetWindowSize_t(SDL_Window window, int* w, int* h);
        private static SDL_GetWindowSize_t s_getWindowSize = LoadFunction<SDL_GetWindowSize_t>("SDL_GetWindowSize");
        public static void SDL_GetWindowSize(SDL_Window window, int* w, int* h) => s_getWindowSize(window, w, h);

        private delegate void SDL_SetWindowSize_t(SDL_Window window, int w, int h);
        private static SDL_SetWindowSize_t s_setWindowSize = LoadFunction<SDL_SetWindowSize_t>("SDL_SetWindowSize");
        public static void SDL_SetWindowSize(SDL_Window window, int w, int h) => s_setWindowSize(window, w, h);

        private delegate string SDL_GetWindowTitle_t(SDL_Window window);
        private static SDL_GetWindowTitle_t s_getWindowTitle = LoadFunction<SDL_GetWindowTitle_t>("SDL_GetWindowTitle");
        public static string SDL_GetWindowTitle(SDL_Window window) => s_getWindowTitle(window);

        private delegate void SDL_SetWindowTitle_t(SDL_Window window, string title);
        private static SDL_SetWindowTitle_t s_setWindowTitle = LoadFunction<SDL_SetWindowTitle_t>("SDL_SetWindowTitle");
        public static void SDL_SetWindowTitle(SDL_Window window, string title) => s_setWindowTitle(window, title);

        private delegate SDL_WindowFlags SDL_GetWindowFlags_t(SDL_Window window);
        private static SDL_GetWindowFlags_t s_getWindowFlags = LoadFunction<SDL_GetWindowFlags_t>("SDL_GetWindowFlags");
        public static SDL_WindowFlags SDL_GetWindowFlags(SDL_Window window) => s_getWindowFlags(window);

        private delegate void SDL_SetWindowBordered_t(SDL_Window window, uint bordered);
        private static SDL_SetWindowBordered_t s_setWindowBordered = LoadFunction<SDL_SetWindowBordered_t>("SDL_SetWindowBordered");
        public static void SDL_SetWindowBordered(SDL_Window window, uint bordered) => s_setWindowBordered(window, bordered);

        private delegate void SDL_MaximizeWindow_t(SDL_Window window);
        private static SDL_MaximizeWindow_t s_maximizeWindow = LoadFunction<SDL_MaximizeWindow_t>("SDL_MaximizeWindow");
        public static void SDL_MaximizeWindow(SDL_Window window) => s_maximizeWindow(window);

        private delegate void SDL_MinimizeWindow_t(SDL_Window window);
        private static SDL_MinimizeWindow_t s_minimizeWindow = LoadFunction<SDL_MinimizeWindow_t>("SDL_MinimizeWindow");
        public static void SDL_MinimizeWindow(SDL_Window window) => s_minimizeWindow(window);

        private delegate int SDL_SetWindowFullscreen_t(SDL_Window window, SDL_FullscreenMode mode);
        private static SDL_SetWindowFullscreen_t s_setWindowFullscreen = LoadFunction<SDL_SetWindowFullscreen_t>("SDL_SetWindowFullscreen");
        public static int SDL_SetWindowFullscreen(SDL_Window window, SDL_FullscreenMode mode) => s_setWindowFullscreen(window, mode);
    }

    [Flags]
    public enum SDL_WindowFlags : uint
    {
        Fullscreen = 0x00000001,         /**< fullscreen window */
        OpenGL = 0x00000002,             /**< window usable with OpenGL context */
        Shown = 0x00000004,              /**< window is visible */
        Hidden = 0x00000008,             /**< window is not visible */
        Borderless = 0x00000010,         /**< no window decoration */
        Resizable = 0x00000020,          /**< window can be resized */
        Minimized = 0x00000040,          /**< window is minimized */
        Maximized = 0x00000080,          /**< window is maximized */
        InputGrabbed = 0x00000100,      /**< window has grabbed input focus */
        InputFocus = 0x00000200,        /**< window has input focus */
        MouseFocus = 0x00000400,        /**< window has mouse focus */
        FullScreenDesktop = (Fullscreen | 0x00001000),
        Foreign = 0x00000800,            /**< window not created by SDL */
        AllowHighDpi = 0x00002000,      /**< window should be created in high-DPI mode if supported */
        MouseCapture = 0x00004000,      /**< window has mouse captured (unrelated to INPUT_GRABBED) */
        AlwaysOnTop = 0x00008000,      /**< window should always be above others */
        SkipTaskbar = 0x00010000,      /**< window should not be added to the taskbar */
        Utility = 0x00020000,      /**< window should be treated as a utility window */
        Tooltip = 0x00040000,      /**< window should be treated as a tooltip */
        PopupMenu = 0x00080000       /**< window should be treated as a popup menu */
    }

    public enum SDL_FullscreenMode : uint
    {
        Windowed = 0,
        Fullscreen = 0x00000001,
        FullScreenDesktop = (Fullscreen | 0x00001000),
    }
}
