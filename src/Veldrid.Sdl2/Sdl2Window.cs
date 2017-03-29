using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

using static Veldrid.Sdl2.Sdl2Native;

namespace Veldrid.Sdl2
{
    // TODO: Move this into Veldrid itself, or a Veldrid extension library.
    public class Sdl2Window : Window
    {
        private readonly IntPtr _sdlWindow;
        private IntPtr _handle;

        private Rectangle _bounds;

        public Sdl2Window(string title, int x, int y, int width, int height, SDLWindowFlags flags)
        {
            _sdlWindow = SDL_CreateWindow(title, x, y, width, height, flags);
        }

        public int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IntPtr Handle => throw new NotImplementedException();

        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public WindowState WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Exists => throw new NotImplementedException();

        public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector2 ScaleFactor => throw new NotImplementedException();

        public Rectangle Bounds => throw new NotImplementedException();

        public bool CursorVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Focused => throw new NotImplementedException();

        public event Action Resized;
        public event Action Closing;
        public event Action Closed;
        public event Action FocusLost;
        public event Action FocusGained;

        public Point ClientToScreen(Point p)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public InputSnapshot GetInputSnapshot()
        {
            throw new NotImplementedException();
        }

        public Point ScreenToClient(Point p)
        {
            throw new NotImplementedException();
        }
    }
}
