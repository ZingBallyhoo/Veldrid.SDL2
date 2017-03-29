using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Veldrid.Sdl2
{
    public static unsafe partial class Sdl2Native
    {
        private delegate void SDL_PumpEvents_t();
        private static SDL_PumpEvents_t s_sdl_pumpEvents = LoadFunction<SDL_PumpEvents_t>("SDL_PumpEvents");
        public static void SDL_PumpEvents() => s_sdl_pumpEvents();

        private delegate int SDL_PollEvent_t(SDL_Event* @event);
        private static SDL_PollEvent_t s_sdl_pollEvent = LoadFunction<SDL_PollEvent_t>("SDL_PollEvent");
        public static int SDL_PollEvent(SDL_Event* @event) => s_sdl_pollEvent(@event);
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_Event
    {
        [FieldOffset(0)]
        public SDL_EventType type;

        [FieldOffset(0)]
        private Bytex56 __padding;
        private unsafe struct Bytex56 { private fixed byte bytes[56]; }
    }

    public struct SDL_WindowEvent
    {
        public SDL_EventType type;        /**< ::SDL_WINDOWEVENT */
        public uint timestamp;
        public uint windowID;    /**< The associated window */
        public SDL_WindowEventID @event;        /**< ::SDL_WindowEventID */
        public byte padding1;
        public byte padding2;
        public byte padding3;
        public int data1;       /**< event dependent data */
        public int data2;       /**< event dependent data */
    }

    public enum SDL_WindowEventID : byte
    {
        None,           /**< Never used */
        Shown,          /**< Window has been shown */
        Hidden,         /**< Window has been hidden */
        Exposed,        /**< Window has been exposed and should be
                                             redrawn */
        Moved,          /**< Window has been moved to data1, data2
                                         */
        Resized,        /**< Window has been resized to data1xdata2 */
        SizeChanged,   /**< The window size has changed, either as
                                             a result of an API call or through the
                                             system or user changing the window size. */
        Minimized,      /**< Window has been minimized */
        Maximized,      /**< Window has been maximized */
        Restored,       /**< Window has been restored to normal size
                                             and position */
        Enter,          /**< Window has gained mouse focus */
        Leave,          /**< Window has lost mouse focus */
        FocusGained,   /**< Window has gained keyboard focus */
        FocusLost,     /**< Window has lost keyboard focus */
        Close,          /**< The window manager requests that the window be closed */
        TakeFocus,     /**< Window is being offered a focus (should SetWindowInputFocus() on itself or a subwindow, or ignore) */
        HitTest        /**< Window had a hit test that wasn't SDL_HITTEST_NORMAL. */
    }

    /// <summary>
    /// The types of events that can be delivered.
    /// </summary>
    public enum SDL_EventType
    {
        SDL_FIRSTEVENT = 0,     /**< Unused (do not remove) */

        /* Application events */
        SDL_QUIT = 0x100, /**< User-requested quit */

        /* These application events have special meaning on iOS, see README-ios.md for details */
        SDL_APP_TERMINATING,        /**< The application is being terminated by the OS
                                          Called on iOS in applicationWillTerminate()
                                          Called on Android in onDestroy()
                                     */
        SDL_APP_LOWMEMORY,          /**< The application is low on memory, free memory if possible.
                                          Called on iOS in applicationDidReceiveMemoryWarning()
                                          Called on Android in onLowMemory()
                                     */
        SDL_APP_WILLENTERBACKGROUND, /**< The application is about to enter the background
                                          Called on iOS in applicationWillResignActive()
                                          Called on Android in onPause()
                                     */
        SDL_APP_DIDENTERBACKGROUND, /**< The application did enter the background and may not get CPU for some time
                                          Called on iOS in applicationDidEnterBackground()
                                          Called on Android in onPause()
                                     */
        SDL_APP_WILLENTERFOREGROUND, /**< The application is about to enter the foreground
                                          Called on iOS in applicationWillEnterForeground()
                                          Called on Android in onResume()
                                     */
        SDL_APP_DIDENTERFOREGROUND, /**< The application is now interactive
                                          Called on iOS in applicationDidBecomeActive()
                                          Called on Android in onResume()
                                     */

        /* Window events */
        SDL_WINDOWEVENT = 0x200, /**< Window state change */
        SDL_SYSWMEVENT,             /**< System specific event */

        /* Keyboard events */
        SDL_KEYDOWN = 0x300, /**< Key pressed */
        SDL_KEYUP,                  /**< Key released */
        SDL_TEXTEDITING,            /**< Keyboard text editing (composition) */
        SDL_TEXTINPUT,              /**< Keyboard text input */
        SDL_KEYMAPCHANGED,          /**< Keymap changed due to a system event such as an
                                          input language or keyboard layout change.
                                     */

        /* Mouse events */
        SDL_MOUSEMOTION = 0x400, /**< Mouse moved */
        SDL_MOUSEBUTTONDOWN,        /**< Mouse button pressed */
        SDL_MOUSEBUTTONUP,          /**< Mouse button released */
        SDL_MOUSEWHEEL,             /**< Mouse wheel motion */

        /* Joystick events */
        SDL_JOYAXISMOTION = 0x600, /**< Joystick axis motion */
        SDL_JOYBALLMOTION,          /**< Joystick trackball motion */
        SDL_JOYHATMOTION,           /**< Joystick hat position change */
        SDL_JOYBUTTONDOWN,          /**< Joystick button pressed */
        SDL_JOYBUTTONUP,            /**< Joystick button released */
        SDL_JOYDEVICEADDED,         /**< A new joystick has been inserted into the system */
        SDL_JOYDEVICEREMOVED,       /**< An opened joystick has been removed */

        /* Game controller events */
        SDL_CONTROLLERAXISMOTION = 0x650, /**< Game controller axis motion */
        SDL_CONTROLLERBUTTONDOWN,          /**< Game controller button pressed */
        SDL_CONTROLLERBUTTONUP,            /**< Game controller button released */
        SDL_CONTROLLERDEVICEADDED,         /**< A new Game controller has been inserted into the system */
        SDL_CONTROLLERDEVICEREMOVED,       /**< An opened Game controller has been removed */
        SDL_CONTROLLERDEVICEREMAPPED,      /**< The controller mapping was updated */

        /* Touch events */
        SDL_FINGERDOWN = 0x700,
        SDL_FINGERUP,
        SDL_FINGERMOTION,

        /* Gesture events */
        SDL_DOLLARGESTURE = 0x800,
        SDL_DOLLARRECORD,
        SDL_MULTIGESTURE,

        /* Clipboard events */
        SDL_CLIPBOARDUPDATE = 0x900, /**< The clipboard changed */

        /* Drag and drop events */
        SDL_DROPFILE = 0x1000, /**< The system requests a file open */
        SDL_DROPTEXT,                 /**< text/plain drag-and-drop event */
        SDL_DROPBEGIN,                /**< A new set of drops is beginning (NULL filename) */
        SDL_DROPCOMPLETE,             /**< Current set of drops is now complete (NULL filename) */

        /* Audio hotplug events */
        SDL_AUDIODEVICEADDED = 0x1100, /**< A new audio device is available */
        SDL_AUDIODEVICEREMOVED,        /**< An audio device has been removed. */

        /* Render events */
        SDL_RENDER_TARGETS_RESET = 0x2000, /**< The render targets have been reset and their contents need to be updated */
        SDL_RENDER_DEVICE_RESET, /**< The device has been reset and all textures need to be recreated */

        /** Events ::SDL_USEREVENT through ::SDL_LASTEVENT are for your use,
         *  and should be allocated with SDL_RegisterEvents()
         */
        SDL_USEREVENT = 0x8000,

        /**
         *  This last event is only for bounding internal arrays
         */
        SDL_LASTEVENT = 0xFFFF
    }

    /// <summary>
    /// Mouse motion event structure (event.motion.*)
    /// </summary>
    public struct SDL_MouseMotionEvent
    {
        public SDL_EventType type;        /**< :: SDL_MOUSEMOTION */
        public uint timestamp;
        public uint windowID;    /**< The window with mouse focus, if any */
        public uint which;       /**< The mouse instance id, or SDL_TOUCH_MOUSEID */
        public ButtonState state;       /**< The current button state */
        public int x;           /**< X coordinate, relative to window */
        public int y;           /**< Y coordinate, relative to window */
        public int xrel;        /**< The relative motion in the X direction */
        public int yrel;        /**< The relative motion in the Y direction */
    }

    [Flags]
    public enum ButtonState : uint
    {
        Left = 1 << 0,
        Middle = 1 << 1,
        Right = 1 << 2,
        X1 = 1 << 3,
        X2 = 1 << 4,
    }
}
