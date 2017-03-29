using System;
using System.Runtime.CompilerServices;
using Veldrid.Sdl2;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TestApp
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IntPtr window = Sdl2Native.SDL_CreateWindow("Here is a pretty wacky title.", 50, 50, 1280, 720, SDLWindowFlags.Shown | SDLWindowFlags.Resizable | SDLWindowFlags.OpenGL);
            Sdl2WindowInfo windowInfo = new Sdl2WindowInfo(window);
            IntPtr graphicsContext = Sdl2Native.SDL_GL_CreateContext(window);

            GraphicsContext.GetAddressDelegate getAddress = Sdl2Native.SDL_GL_GetProcAddress;
            GraphicsContext.GetCurrentContextDelegate getCurrentContext = () => new ContextHandle(Sdl2Native.SDL_GL_GetCurrentContext());
            GraphicsContext gc = new GraphicsContext(new ContextHandle(graphicsContext), getAddress, getCurrentContext);
            gc.LoadAll();
            gc.MakeCurrent(windowInfo);

            while (true)
            {
                GL.ClearColor(Color.DarkBlue);
                GL.Viewport(0, 0, 1280, 720);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                Sdl2Native.SDL_PumpEvents();
                SDL_Event ev;
                while (Sdl2Native.SDL_PollEvent(&ev) != 0)
                {
                    if (ev.type == SDL_EventType.SDL_WINDOWEVENT)
                    {
                        SDL_WindowEvent windowEvent = Unsafe.Read<SDL_WindowEvent>(&ev);
                        Console.WriteLine("Window event: " + windowEvent.@event);
                    }
                    else if (ev.type == SDL_EventType.SDL_MOUSEMOTION)
                    {
                        SDL_MouseMotionEvent mme = Unsafe.Read<SDL_MouseMotionEvent>(&ev);
                        Console.WriteLine($"X: {mme.x}, Y: {mme.y}, State: {mme.state}");
                    }
                    else if (ev.type == SDL_EventType.SDL_QUIT)
                    {
                        Sdl2Native.SDL_DestroyWindow(window);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Event: " + ev.type);
                    }
                }

                Sdl2Native.SDL_GL_SwapWindow(window);
                //gc.SwapBuffers();
            }
        }
    }

    class Sdl2WindowInfo : OpenTK.Platform.IWindowInfo
    {
        private readonly IntPtr _sdl2Window;

        public Sdl2WindowInfo(IntPtr window)
        {
            _sdl2Window = window;
        }

        public IntPtr Handle
        {
            get
            {
                unsafe
                {
                    SDL_SysWMinfo info;
                    Sdl2Native.SDL_GetVersion(&info.version);
                    Sdl2Native.SDL_GetWMWindowInfo(_sdl2Window, &info);
                    if (info.subsystem == SysWMType.Windows)
                    {
                        Win32WindowInfo win32Info = Unsafe.Read<Win32WindowInfo>(&info.info);
                        return win32Info.window;
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
