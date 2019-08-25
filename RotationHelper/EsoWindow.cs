using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RotationHelper
{
    class EsoWindow
    {
        //Import the FindWindow API to find our window
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindowNative(string className, string windowName);

        //Import the SetForeground API to activate it
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern IntPtr SetForegroundWindowNative(IntPtr hWnd);

        [DllImport("user32", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageNative(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
        private static extern IntPtr OpenProcessNative(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        private static extern Int32 ReadProcessMemoryNative(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
        private static extern bool CloseHandleNative(IntPtr hObject);

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        private static extern int GetWindowThreadProcessIdNative(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPosNative(int X, int Y);

        [DllImport("user32.dll", EntryPoint = "GetCursorPos")]
        private static extern bool GetCursorPosNative(out Point lpPoint);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "SetThreadExecutionState")]
        private static extern EXECUTION_STATE SetThreadExecutionStateNative(EXECUTION_STATE esFlags);

        [Flags]
        public enum WindowMessages : uint
        {
            WM_MOUSEMOVE = 0x200,
            WM_LBUTTONDOWN = 0x201,
            WM_RBUTTONDOWN = 0x204,
            WM_MBUTTONDOWN = 0x207,
            WM_LBUTTONUP = 0x202,
            WM_RBUTTONUP = 0x205,
            WM_MBUTTONUP = 0x208,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDBLCLK = 0x206,
            WM_MBUTTONDBLCLK = 0x209,
            WM_MOUSEWHEEL = 0x020A,
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105,
        }

        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
        }

        public EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags)
        {
            return SetThreadExecutionStateNative(esFlags);
        }

        public IntPtr FindWindow(string className, string windowName)
        {
            return FindWindowNative(className, windowName);
        }

        public IntPtr SetForegroundWindow(IntPtr hWnd)
        {
            return SetForegroundWindowNative(hWnd);
        }

        public IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam)
        {
            return SendMessageNative(hWnd, Msg, wParam, lParam);
        }

        public IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId)
        {
            return OpenProcessNative(dwDesiredAccess, bInheritHandle, dwProcessId);
        }

        public Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead)
        {
            return ReadProcessMemoryNative(hProcess, lpBaseAddress, buffer, size, out lpNumberOfBytesRead);
        }

        public bool CloseHandle(IntPtr hObject)
        {
            return CloseHandleNative(hObject);
        }

        public int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId)
        {
            return GetWindowThreadProcessIdNative(hWnd, out lpdwProcessId);
        }

        public bool SetCursorPos(int X, int Y)
        {
            return SetCursorPosNative(X, Y);
        }

        public bool GetCursorPos(out Point lpPoint)
        {
            return GetCursorPosNative(out lpPoint);
        }
    }
}
