using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disservice
{
    [Serializable]
    class Interface
    {
        String nEName;
        String slotPort;

        public Interface()
        {
            nEName = "";
            slotPort = "";
        }

        public Interface(String _NEName, String _slotPort)
        {
            nEName = _NEName;
            slotPort = _slotPort;

        }

        public Boolean Compare(Interface a1, Interface a2)
        {
            if ((a1.slotPort == a2.slotPort) && (a1.nEName == a2.nEName)) return true;
            else return false;
        }

        public String SlotPort
        {
            set { if (value != "") slotPort = value; }
            get { return slotPort; }
        }

        public String NEName
        {
            set { if (value != "") nEName = value; }
            get { return nEName; }
        }

        public String ShowInterface()
        {
            return String.Format("NEName - {0}\tSlotPort - {1}",this.nEName, this.slotPort);
        }
    }
}
