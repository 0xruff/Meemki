using System.Runtime.InteropServices;

namespace Meemki.Keyboard
{
    public static class FasterKeyboard
    {
        /* https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeystate
           The return value specifies the status of the specified virtual key, as follows:
            •If the high-order bit is 1, the key is down; otherwise, it is up.
            •If the low-order bit is 1, the key is toggled. A key, such as the CAPS LOCK key, is toggled if it is turned on. The key is off and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
         */
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
        
        private const int KeyDownBitMask = 0x8000;

        public static bool IsKeyDown(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyDownBitMask) != 0;
        }
    }

    // Key code documentation: http://msdn.microsoft.com/en-us/library/dd375731%28v=VS.85%29.aspx
    public enum KeyCode
    {
        Left = 0x25,
        Up = 0x26,
        Right = 0x27,
        Down = 0x28
    }
}
