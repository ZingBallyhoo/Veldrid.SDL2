using System;

namespace Veldrid.Sdl2
{
    public static unsafe partial class Sdl2Native
    {
        private delegate IntPtr SDL_CreateWindow_t(string title, int x, int y, int w, int h, SDLWindowFlags flags);
        private static SDL_CreateWindow_t s_sdl_createWindow = LoadFunction<SDL_CreateWindow_t>("SDL_CreateWindow");
        public static IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, SDLWindowFlags flags) => s_sdl_createWindow(title, x, y, w, h, flags);

        private delegate IntPtr SDL_DestroyWindow_t(IntPtr window);
        private static SDL_DestroyWindow_t s_sdl_destroyWindow = LoadFunction<SDL_DestroyWindow_t>("SDL_DestroyWindow");
        public static IntPtr SDL_DestroyWindow(IntPtr window) => s_sdl_destroyWindow(window);

    }

    [Flags]
    public enum SDLWindowFlags : uint
    {
        FullScreen = 0x00000001,         /**< fullscreen window */
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
        FullScreenDesktop = (FullScreen | 0x00001000),
        Foreign = 0x00000800,            /**< window not created by SDL */
        AllowHighDpi = 0x00002000,      /**< window should be created in high-DPI mode if supported */
        MouseCapture = 0x00004000,      /**< window has mouse captured (unrelated to INPUT_GRABBED) */
        AlwaysOnTop = 0x00008000,      /**< window should always be above others */
        SkipTaskbar = 0x00010000,      /**< window should not be added to the taskbar */
        Utility = 0x00020000,      /**< window should be treated as a utility window */
        Tooltip = 0x00040000,      /**< window should be treated as a tooltip */
        PopupMenu = 0x00080000       /**< window should be treated as a popup menu */
    }
}
