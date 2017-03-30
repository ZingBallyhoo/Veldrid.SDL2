using System;

namespace Veldrid.Sdl2
{
    public static unsafe partial class Sdl2Native
    {
        private delegate IntPtr SDL_GL_CreateContext_t(SDL_Window window);
        private static SDL_GL_CreateContext_t s_gl_createContext = LoadFunction<SDL_GL_CreateContext_t>("SDL_GL_CreateContext");
        public static IntPtr SDL_GL_CreateContext(SDL_Window window) => s_gl_createContext(window);

        private delegate IntPtr SDL_GL_GetProcAddress_t(string proc);
        private static SDL_GL_GetProcAddress_t s_getProcAddress = LoadFunction<SDL_GL_GetProcAddress_t>("SDL_GL_GetProcAddress");
        public static IntPtr SDL_GL_GetProcAddress(string proc)
        {
            return s_getProcAddress(proc);
        }

        private delegate IntPtr SDL_GL_GetCurrentContext_t();
        private static SDL_GL_GetCurrentContext_t s_gl_getCurrentContext = LoadFunction<SDL_GL_GetCurrentContext_t>("SDL_GL_GetCurrentContext");
        public static IntPtr SDL_GL_GetCurrentContext()
        {
            var ret = s_gl_getCurrentContext();
            return ret;
        }

        private delegate void SDL_GL_SwapWindow_t(SDL_Window window);
        private static SDL_GL_SwapWindow_t s_gl_swapWindow = LoadFunction<SDL_GL_SwapWindow_t>("SDL_GL_SwapWindow");
        public static void SDL_GL_SwapWindow(SDL_Window window) => s_gl_swapWindow(window);
    }
}
