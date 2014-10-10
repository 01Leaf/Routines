using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput;

namespace SendKey
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Count() == 0)
            {
                return;
            }
            string[] target = args[0].Split('+');

            bool CTRL = false, ALT = false, SHIFT = false;

            foreach (string key in target)
            {
                switch (System.Web.HttpUtility.UrlDecode(key))
                {
                    case "{WIN}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.LWIN);
                        break;
                    case "{TAB}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB);
                        break;
                    case "{BACKSPACE}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK);
                        break;
                    case "{ENTER}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
                        break;
                    case "{SPACE}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
                        break;
                    case "{DEL}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.DELETE);
                        break;
                    case "{HOME}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.HOME);
                        break;
                    case "{PGUP}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.PRIOR);
                        break;
                    case "{PGDOWN}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.NEXT);
                        break;
                    case "{END}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.END);
                        break;
                    case "{ESC}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.ESCAPE);
                        break;
                    case "{F1}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F1);
                        break;
                    case "{F2}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F2);
                        break;
                    case "{F3}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F3);
                        break;
                    case "{F4}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F4);
                        break;
                    case "{F5}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F5);
                        break;
                    case "{F6}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F6);
                        break;
                    case "{F7}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F7);
                        break;
                    case "{F8}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F8);
                        break;
                    case "{F9}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F9);
                        break;
                    case "{F10}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F10);
                        break;
                    case "{F11}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F1);
                        break;
                    case "{F12}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.F12);
                        break;
                    case "{INS}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.INSERT);
                        break;
                    case "{CAPS}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.CAPITAL);
                        break;
                    case "{NUM}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMLOCK);
                        break;
                    case "{UP}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.UP);
                        break;
                    case "{DOWN}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN);
                        break;
                    case "{LEFT}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
                        break;
                    case "{RIGHT}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
                        break;
                    case "{VOLUP}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP);
                        break;
                    case "{VOLDOWN}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN);
                        break;
                    case "{MUTE}":
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_MUTE);
                        break;
                    case "{CTRL}":
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
                        CTRL = true;
                        break;
                    case "{ALT}":
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.MENU);
                        ALT = true;
                        break;
                    case "{SHIFT}":
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        SHIFT = true;
                        break; 
                    default:
                        InputSimulator.SimulateTextEntry(key);
                        break;
                }

                if (CTRL)
                {
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
                }

                if (ALT)
                {
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.MENU);
                }

                if (SHIFT)
                {
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                }

                Console.Read();
               
            }
        }
    }
}
