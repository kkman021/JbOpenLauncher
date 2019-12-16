using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;

namespace me.joshbennett
{
    public class OpenLauncher
    {
        private bool DevicePresent;

        //Bytes used in command
        private byte[] UP;
        private byte[] RIGHT;
        private byte[] LEFT;
        private byte[] DOWN;

        private byte[] FIRE;
        private byte[] STOP;
        private byte[] LED_OFF;
        private byte[] LED_ON;

        IEnumerable<HidDevice> deviceList;
        HidDevice dev1;

        public OpenLauncher()
        {
            initCommands();

            // Enumerate the devices
            deviceList = HidDevices.Enumerate(0x2123, 0x1010);

            if (deviceList.Count() < 1)
            {
                throw new Exception("Could not find device");
            }
            
            DevicePresent = true;

            dev1 = deviceList.FirstOrDefault();
            dev1.OpenDevice();
            dev1.Inserted += DeviceAttachedHandler;
            dev1.Removed += DeviceRemovedHandler;
            dev1.MonitorDeviceEvents = true;

            //dev1.CloseDevice();
        }

        private void initCommands()
        {
            this.UP = new byte[10];
            this.UP[1] = 2;
            this.UP[2] = 2;

            this.DOWN = new byte[10];
            this.DOWN[1] = 2;
            this.DOWN[2] = 1;

            this.LEFT = new byte[10];
            this.LEFT[1] = 2;
            this.LEFT[2] = 4;

            this.RIGHT = new byte[10];
            this.RIGHT[1] = 2;
            this.RIGHT[2] = 8;

            this.FIRE = new byte[10];
            this.FIRE[1] = 2;
            this.FIRE[2] = 0x10;

            this.STOP = new byte[10];
            this.STOP[1] = 2;
            this.STOP[2] = 0x20;

            this.LED_ON = new byte[9];
            this.LED_ON[1] = 3;
            this.LED_ON[2] = 0;

            this.LED_OFF = new byte[9];
            this.LED_OFF[1] = 3;
            this.LED_OFF[1] = 1;
        }

        #region commands
        public void commandStop()
        {
            dev1.Write(this.STOP);
        }

        public void commandLeft()
        {
            dev1.Write(this.LEFT);
        }

        public void commandRight()
        {
            dev1.Write(this.RIGHT);
        }

        public void commandUp()
        {
            dev1.Write(this.UP);
        }

        public void commandDown()
        {
            dev1.Write(this.DOWN);
        }

        public void commandFire()
        {
            dev1.Write(this.FIRE);
        }

        public void commandLedOn()
        {
            dev1.Write(this.LED_ON);
        }

        public void commandLedOff()
        {
            dev1.Write(this.LED_OFF);
        }

        #endregion

        #region event handlers
        
        private void OnReport(HidReport report)
        {
            if (!dev1.IsConnected) { return; }

            dev1.ReadReport(OnReport);
        }

        private static void DeviceAttachedHandler()
        {
            var test = "test";
        }

        private static void DeviceRemovedHandler()
        {
            var test = "test";
        }
        
        #endregion
    }
}
