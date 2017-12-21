using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disservice
{
    [Serializable]
    class Port
    {
        Byte slot;
        Byte port;

        public Port()
        {
            slot = 0;
            port = 0;
        }

        public Port(Byte _slot, Byte _port)
        {
            slot = 0;
            port = 0;
            if ((_slot > 0) && (_port >= 0))
            {
                slot = (Byte)_slot;
                port = (Byte)_port;
            }
        }

        public Port(Int64 _slot, Int64 _port)
        {
            slot = 0;
            port = 0;
            if ((_slot > 0) && (_port >= 0) && (_slot < 256) && (_port < 256))
            {
                slot = (Byte)_slot;
                port = (Byte)_port;
            }
        }

        public Port(String SlotPort)
        {
            slot = 0;
            port = 0;
            String[] _slotport;
            Int64 _slot = 0, _port = 0;
            Int32 count = 0;
            _slotport = SlotPort.Split('-');
            count = _slotport.Count();
            if ((count > 3) || (count < 2)) return;
            try
            {
                _slot = Int64.Parse(_slotport[0]);
            }
            catch (FormatException)
            {
                return;
            }
            catch (OverflowException)
            {
                return;
            }

            if (count == 2)
            {
                try
                {
                    _port = Int64.Parse(_slotport[1]);
                }
                catch (FormatException)
                {
                    return;
                }
                catch (OverflowException)
                {
                    return;
                }
            }//if

            if (count == 3)
            {
                try
                {
                    _port = Int64.Parse(_slotport[2]);
                }
                catch (FormatException)
                {
                    return;
                }
                catch (OverflowException)
                {
                    return;
                }
            }//if
            slot = (Byte)_slot;
            port = (Byte)_port;

        }//constructor

        public Boolean Compare(Port a1, Port a2)
        {
            if ((a1.port == a2.port) && (a1.slot == a2.slot)) return true;
            else return false;
        }

        public Byte GetPort()
        {
            return port;
        }

        public Byte GetSlot()
        {
            return slot;
        }

        public String ShowSlotPort()
        {
            return String.Format("slot - {0}\tport - {1}", this.slot, this.port);
        }
    }
}
