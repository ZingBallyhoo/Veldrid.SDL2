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
            IntPtr window = Sdl2Native.SDL_CreateWindow("Here is a pretty wacky title.", 50, 50, 1280, 720, SDL_WindowFlags.Shown | SDL_WindowFlags.Resizable | SDL_WindowFlags.OpenGL);
            var windowInfo = OpenTK.Platform.Utilities.CreateSdl2WindowInfo(window);
            GraphicsContext gc = new GraphicsContext(GraphicsMode.Default, windowInfo);
            gc.LoadAll();
            gc.MakeCurrent(windowInfo);

            while (true)
            {
                GL.ClearColor(0f, 0f, .75f, 1f);
                GL.Viewport(0, 0, 1280, 720);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                Sdl2Native.SDL_PumpEvents();
                SDL_Event ev;
                while (Sdl2Native.SDL_PollEvent(&ev) != 0)
                {
                    if (ev.type == SDL_EventType.WindowEvent)
                    {
                        SDL_WindowEvent windowEvent = Unsafe.Read<SDL_WindowEvent>(&ev);
                        Console.WriteLine("Window event: " + windowEvent.@event);
                    }
                    else if (ev.type == SDL_EventType.MouseMotion)
                    {
                        SDL_MouseMotionEvent mme = Unsafe.Read<SDL_MouseMotionEvent>(&ev);
                        Console.WriteLine($"X: {mme.x}, Y: {mme.y}, State: {mme.state}");
                    }
                    else if (ev.type == SDL_EventType.Quit)
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
}
