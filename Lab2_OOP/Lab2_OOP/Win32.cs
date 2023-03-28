using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Lab2_OOP
{
    public class Win32
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);
    }
}
