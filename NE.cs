using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Disservice
{
    [Serializable]
    class SlotPort
    {
        string slotPort;
        Tunnel[] tunnels;
        Service[] services;

        public SlotPort()
        {
            slotPort = "";
            tunnels = null;
            services = null;
        }

        public string Slot_Port
        {
            get { return slotPort; }
            set { slotPort = value; }
        }

        public override string ToString()
        {
            return slotPort;
        }

        public Tunnel[] Tunnels
        {
            get { return tunnels; }
            set { tunnels = value; }
        }

        public Service[] Services
        {
            get { return services; }
            set { services = value; }
        }

        public void AddTunnel(Tunnel _t)
        {
            if (_t == null) return;
            int count = 0;
            int i = 0;
            if (tunnels != null) count = tunnels.Count();
            for (i = 0; i < count; i++)
                if (tunnels[i].Name == _t.Name) return;

            Tunnel[] tmp = new Tunnel[count + 1];
            for (i = 0; i < count; i++)
                tmp[i] = tunnels[i];
            tmp[count] = new Tunnel();
            tmp[count] = _t;
            tunnels = tmp;
        }

        public void AddService(Service _s)
        {
            if (_s == null) return;
            int count = 0;
            if (services != null) count = services.Count();
            int i;
            for (i = 0; i < count; i++)
                if (services[i].Name == _s.Name) return;

            Service[] tmp = new Service[count + 1];
            for (i = 0; i < count; i++)
                tmp[i] = services[i];
            tmp[count] = new Service();
            tmp[count] = _s;
            services = tmp;
        }

        public string ShowSlotPort()
        {
            string str = "\t\tSlot-Port - " + slotPort + "\n";
            if (services != null)
            {
                str += "\t\t\tServices:\n";
                foreach (Service srv in services)
                {
                    str += "\t\t\t\t" + srv.Name + "\n";
                }
            }
            if (tunnels != null)
            {
                str += "\t\t\tTunnels:\n";
                foreach (Tunnel tnl in tunnels)
                {
                    str += "\t\t\t\t" + tnl.Name + "\n";
                }
            }

            return str;
        }


    }

    [Serializable]
    class NE
    {
        string neName;
        SlotPort[] slotPorts;
        NE next;

        public NE()
        {
            neName = "";
            slotPorts = null;
            next = null;
        }

        public SlotPort AddSlotPort(string _sp)
        {
            int count = 0;
            if ((_sp == "") || (_sp == null)) return null;
            if (slotPorts != null) count = slotPorts.Count();
            int i;
            for (i = 0; i < count; i++)
                if (slotPorts[i].Slot_Port == _sp) return slotPorts[i];
            
            SlotPort[] tmp = new SlotPort[count + 1];
            for (i = 0; i < count; i++)
                tmp[i] = slotPorts[i];
            tmp[count] = new SlotPort();
            tmp[count].Slot_Port = _sp;
            slotPorts = tmp;
            return slotPorts[count];
        }

        public string NEName
        {
            set { neName = value; }
            get { return neName; }
        }

        public SlotPort SlotPort
        {
            set { SlotPort = value; }
            get { return SlotPort; }
        }

        public NE Next
        {
            set { next = value; }
            get { return next; }
        }

        public SlotPort[] SlotPorts
        {
            set { slotPorts = value; }
            get { return slotPorts; }
        }

        public string ShowNE()
        {
            string str = "NEName - " + neName + "\n";
            foreach (SlotPort _sp in slotPorts)
            {
                str += _sp.ShowSlotPort() + "\n";
            }
            return str;
        }

        override public string ToString()
        {
            return neName;
        }

        public void RemoveSlotPort(string sp)
        {
            int i;
            for (i = 0; i < slotPorts.Count(); i++)
            {
                if (slotPorts[i].Slot_Port == sp)
                {
                    SlotPort[] tmpSP = new SlotPort[slotPorts.Count() - 1];
                    int ii;
                    for (ii = 0; ii < tmpSP.Count(); ii++)
                    {
                        if (ii < i)
                            tmpSP[ii] = slotPorts[ii];
                        else tmpSP[ii] = slotPorts[ii + 1];
                    }
                    slotPorts = tmpSP;
                    return;
                }
            }

        }


    }
    [Serializable]
    class NEList
    {
        uint count;
        NE head, tail;

        public NEList()
        {
            count = 0;
            head = null;
            tail = null;
        }

        public NE Head
        {
            set { head = value; }
            get { return head; }
        }

        public NE Tail
        {
            set { tail = value; }
            get { return tail; }
        }


        public NE AddNE(string neName)
        {
            if (neName == "")  return null;
            NE cursor = head;
            while (cursor != null)
            {
                if (cursor.NEName == neName) return cursor;
                cursor = cursor.Next;
            }

            NE newNE = new NE();
            newNE.NEName = neName;
            if (head == null)
            {
                head = newNE;
                tail = newNE;
            }
            else
            {
                tail.Next = newNE;
                tail = newNE;
            }
            return newNE;
        }

        public void RemoveNE(string remNE)
        {
            if (remNE == "") return;
            NE cursor = head;
            while (cursor.Next.NEName  != remNE)
            {
                cursor = cursor.Next;
            }
            if (cursor == null) return;
            cursor.Next = cursor.Next.Next;
        }

        public void RemoveSlotPort(string remNE, string sp)
        {
            if ((remNE == "") || (sp == "")) return;
            NE cursor = head;
            while ((cursor.NEName != remNE) && (cursor != null))
            {
                cursor = cursor.Next;
            }
            if (cursor == null) return;
            cursor.RemoveSlotPort(sp);
            if (cursor.SlotPorts == null) RemoveNE(remNE);
        }

        public void AddService(Service _s)
        {
            if (_s == null) return;
            NE tmpNE = null;
            SlotPort tmpSP = null;
            if ((_s.SrcInterfaceWork != null) && (_s.SrcInterfaceWork.NEName != ""))
            {
                tmpNE = AddNE(_s.SrcInterfaceWork.NEName);
                if (tmpNE != null)
                {
                    if (_s.SrcInterfaceWork.SlotPort != null) tmpSP = tmpNE.AddSlotPort(_s.SrcInterfaceWork.SlotPort);
                    if (tmpSP != null)
                    {
                        tmpSP.AddService(_s);
                    }
                }
            }
            if ((_s.SrcInterfaceProt != null) && (_s.SrcInterfaceProt.NEName != ""))
            {
                tmpNE = AddNE(_s.SrcInterfaceProt.NEName);
                if (tmpNE != null)
                {
                    if (_s.SrcInterfaceProt.SlotPort != null) tmpSP = tmpNE.AddSlotPort(_s.SrcInterfaceProt.SlotPort);
                    if (tmpSP != null)
                    {
                        tmpSP.AddService(_s);
                    }
                }
            }
            if ((_s.SnkInterfaceWork != null) && (_s.SnkInterfaceWork.NEName != ""))
            {
                tmpNE = AddNE(_s.SnkInterfaceWork.NEName);
                if (tmpNE != null)
                {
                    if (_s.SnkInterfaceWork.SlotPort != null) tmpSP = tmpNE.AddSlotPort(_s.SnkInterfaceWork.SlotPort);
                    if (tmpSP != null)
                    {
                        tmpSP.AddService(_s);
                    }
                }
            }
            if ((_s.SnkInterfaceProt != null) && (_s.SnkInterfaceProt.NEName != ""))
            {
                tmpNE = AddNE(_s.SnkInterfaceProt.NEName);
                if (tmpNE != null)
                {
                    if (_s.SnkInterfaceProt.SlotPort != null) tmpSP = tmpNE.AddSlotPort(_s.SnkInterfaceProt.SlotPort);
                    if (tmpSP != null)
                    {
                        tmpSP.AddService(_s);
                    }
                }
            }




        } //AddService

        public void AddTunnel(Tunnel _t)
        {
            if (_t == null) return;
            NE tmpNE = null;
            SlotPort tmpSP = null;
            if ((_t.SnkInterface != null) && (_t.SnkInterface.NEName != ""))
            {
                tmpNE = AddNE(_t.SnkInterface.NEName);
                if (tmpNE != null)
                {
                    if (_t.SnkInterface.SlotPort != null) tmpSP = tmpNE.AddSlotPort(_t.SnkInterface.SlotPort);
                    if (tmpSP != null)
                    {
                        tmpSP.AddTunnel(_t);
                    }
                }
            }
            if ((_t.SrcInterface != null) && (_t.SrcInterface.NEName != ""))
            {
                tmpNE = AddNE(_t.SrcInterface.NEName);
                if (tmpNE != null)
                {
                    if (_t.SrcInterface.SlotPort != null) tmpSP = tmpNE.AddSlotPort(_t.SrcInterface.SlotPort);
                    if (tmpSP != null)
                    {
                        tmpSP.AddTunnel(_t);
                    }
                }
            }
            if (_t.TransitNE != null)
            {
                foreach (TransitNE tmpTrNE in _t.TransitNE)
                {
                    if ((tmpTrNE.NEName != null) && (tmpTrNE.NEName != ""))
                    {
                        tmpNE = AddNE(tmpTrNE.NEName);
                        if (tmpNE != null)
                        {
                            if (tmpTrNE.InSlotPort != null) tmpSP = tmpNE.AddSlotPort(tmpTrNE.InSlotPort);
                            if (tmpSP != null)
                            {
                                tmpSP.AddTunnel(_t);
                            }
                            if (tmpTrNE.OutSlotPort != null) tmpSP = tmpNE.AddSlotPort(tmpTrNE.OutSlotPort);
                            if (tmpSP != null)
                            {
                                tmpSP.AddTunnel(_t);
                            }
                        }
                    }

                } //forech
            }
        }


    } // class NEList

    [Serializable]
    class DB
    {
        public ServiceList LService;
        public TunnelList LTunnel;

        public DB()
        {
            LService = new ServiceList();
            LTunnel = new TunnelList();
        }

        public void SaveDB(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream
                (filename, FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void LoadDB(string filename, ref DB lDB)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream
                (filename, FileMode.Open, FileAccess.Read);
            lDB = (DB)bf.Deserialize(fs);
            fs.Close();
        }

    }

}
