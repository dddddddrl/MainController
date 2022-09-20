using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MainController
{
    //È«¾Ö¿ì½Ý¼ü 
    public delegate void HotkeyEventHandler(int HotKeyID);
    public class Hotkey : System.Windows.Forms.IMessageFilter
    {
        Hashtable keyIDs = new Hashtable();
        IntPtr hWnd;

        static public int Hotkey1;
        static public int Hotkey2;
        static public int Hotkey3;

        public event HotkeyEventHandler OnHotkey;

        public enum KeyFlags
        {
            MOD_NONE = 0,
            MOD_ALT = 1,
            MOD_CONTROL = 2,
            MOD_SHIFT = 4,
            MOD_WIN = 8
        }
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

        public Hotkey(IntPtr hWnd)
        {
            this.hWnd = hWnd;
            Application.AddMessageFilter(this);
        }

        public int RegisterHotkey(Keys Key, KeyFlags keyflags)
        {
            UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());
            RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyflags, (UInt32)Key);
            keyIDs.Add(hotkeyid, hotkeyid);
            return (int)hotkeyid;
        }

        public void UnregisterHotkeys()
        {
            Application.RemoveMessageFilter(this);
            foreach (UInt32 key in keyIDs.Values)
            {
                UnregisterHotKey(hWnd, key);
                GlobalDeleteAtom(key);
            }
        }

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x312)
            {
                if (OnHotkey != null)
                {
                    foreach (UInt32 key in keyIDs.Values)
                    {
                        if ((UInt32)m.WParam == key)
                        {
                            OnHotkey((int)m.WParam);
                            return true;
                        }
                    }
                }
            }
            return false;
        }


    }


}
