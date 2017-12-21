using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disservice
{
    [Serializable]
    class TransitNE
    {
        String nEName;
        String inSlotPort;
        String outSlotPort;

        public TransitNE()
        {
            nEName = "";
            inSlotPort = "";
            outSlotPort = "";
        }

        public TransitNE(String _NEName, String _InPort, String _OutPort)
        {
            nEName = _NEName;
            inSlotPort = _InPort;
            outSlotPort = _OutPort;
        }

        public String NEName
        {
            set { if (value != "") nEName = value; }
            get { return nEName; }
        }

        public String InSlotPort
        {
            set { if (value != "") inSlotPort = value; }
            get { return inSlotPort; }
        }

        public String OutSlotPort
        {
            set { if (value != "") outSlotPort = value; }
            get { return outSlotPort; }
        }


        public String ShowTransitNE()
        {
            return String.Format("Transit NEName - {0}\tInPort - {1}\tOutPort - {2}", this.nEName, this.inSlotPort, this.outSlotPort);
        }
    }


}
