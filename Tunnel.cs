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
    class Tunnel
    {
        uint iD;
        protected String name;
        Interface srcInterface;
        Interface snkInterface;
        TransitNE[] transitNEs;
        Tunnel next;
        Tunnel pRTTunnel;
        Tunnel rVSTunnel;

        public Tunnel()
        {
            name = "";
            iD = 0;
            srcInterface = new Interface();
            snkInterface = new Interface();
            next = null;
            pRTTunnel = null;
            rVSTunnel = null;
        }

        public Tunnel(Tunnel t)
        {
            name = t.name;
            iD = t.iD;
            srcInterface = t.srcInterface;
            snkInterface = t.snkInterface;
            transitNEs = t.transitNEs;
            next = null;
            pRTTunnel = t.PRTTunnel;
            rVSTunnel = t.RVSTunnel;
        }

        public Tunnel Next
        {
            set { next = value; }
            get { return next; }
        }

        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        public uint ID
        {
            set { iD = value; }
            get { return iD; }
        }

        public Interface SrcInterface
        {
            set { srcInterface = value; }
            get { return srcInterface; }
        }

        public Interface SnkInterface
        {
            set { snkInterface = value; }
            get { return snkInterface; }
        }

        public TransitNE[] TransitNE
        {
            set { transitNEs = value; }
            get { return transitNEs; }
        }

        public Tunnel PRTTunnel
        {
            set { pRTTunnel = value; }
            get { return pRTTunnel; }
        }

        public Tunnel RVSTunnel
        {
            set { rVSTunnel = value; }
            get { return rVSTunnel; }
        }

        public String ShowTunnel()
        {
            String str = "";
            int i = 0, strCount = 0;
            str = String.Format("TunnelName - {0}\t", name);
            //            str += String.Format("TunnelId - {0}\t\tSource - {1}\t Sink - {2}\n", iD, srcInterface.ShowInterface(), snkInterface.ShowInterface());
            //            if (pRTTunnel != null) str += "Protect - \t" + pRTTunnel.Name + "\n";
            /*            if (rVSTunnel != null) str += "RVS - \t" + rVSTunnel.Name + "\n";
                        if (transitNEs != null)
                        {
            */
            if (transitNEs != null) strCount = transitNEs.Count();
            /*                for (i = 0; i < strCount; i++)
                            {
                                str += "\n\t" + transitNEs[i].ShowTransitNE();
                            }
                            str += "\nSummary transit node - " + strCount.ToString() + "\n\n";
                        }
            */
            str = str + " Transit NEs: " + strCount.ToString() + "\n";
            return str;
        }

        override public String ToString()
        {
            return name;
        }
    }//class Tunnel


    [Serializable]
    class TunnelList
    {
        uint count;
        Tunnel head, tail, current;

        public TunnelList()
        {
            head = null;
            tail = null;
            current = null;
        }

        public bool Add(Tunnel t)
        {
            Tunnel cursor = head;
            Tunnel preCursor = head;
            if ((t.Name != "")
                && (t.ID > 0)
                && (t.SrcInterface.NEName != "")
                && (t.SrcInterface.SlotPort != "")
                && (t.SnkInterface.NEName != "")
                && (t.SnkInterface.SlotPort != ""))
            {
                while (cursor != null)
                {
                    if ((cursor.Name == t.Name) && (cursor.ID == t.ID))
                        break;
                    preCursor = cursor;
                    cursor = cursor.Next;
                }
                Tunnel newTunnel = new Tunnel(t);
                if (cursor == null)
                {
                    if (head == null)
                    {
                        head = newTunnel;
                        tail = newTunnel;
                    }
                    else
                    {

                        tail.Next = newTunnel;
                        tail = newTunnel;
                    }
                    count++;
                    return true;
                }
                else
                {
                    if (cursor == tail) tail = newTunnel;
                    if (cursor == head) head = newTunnel;
                    newTunnel.Next = cursor.Next;
                    preCursor.Next = newTunnel;
                    return true;
                }
            }
            return false;
        }// Add

        public String ShowNextTunnel()
        {
            String str = "";
            if (current == null)
            {
                current = head;
            }
            else
            {
                str = current.ShowTunnel() + "\n";
                current = current.Next;
                if (current == null) str += "\n" + count.ToString();
            }
            return str;
        }

        public void SetCurrentToTail()
        {
            current = tail;
        }

        public Tunnel SearchTunnelFromCurrent(string _TunnelName)
        {
            Tunnel cursor = current;
            while (cursor != null)
            {
                if (cursor.Name == _TunnelName) return cursor;
                cursor = cursor.Next;
            }
            return null;
        }

        public Tunnel SearchTunnel(string _TunnelName)
        {
            Tunnel cursor = head;
            if (_TunnelName == null) return null;
            if (_TunnelName == "") return null;
            while (cursor != null)
            {
                if (cursor.Name == _TunnelName) return cursor;
                cursor = cursor.Next;
            }
            return null;
        }

        public bool SetRole(string[] _role)
        {
            Tunnel work, backWork, prot, backProt;

            work = SearchTunnelFromCurrent(_role[0]);
            prot = SearchTunnelFromCurrent(_role[2]);
            if ((work == null) || (prot == null)) return false;
            work.PRTTunnel = prot;
            prot.PRTTunnel = work;

            if (_role[1] != null)
            {
                backWork = SearchTunnelFromCurrent(_role[1]);
                if (backWork == null) return false;
                work.RVSTunnel = backWork;
                backWork.RVSTunnel = work;
                backWork.PRTTunnel = prot;
            }
            if (_role[3] != null)
            {
                backProt = SearchTunnelFromCurrent(_role[3]);
                if (backProt == null) return false;
                prot.RVSTunnel = backProt;
                backProt.RVSTunnel = prot;
                backProt.PRTTunnel = work;
            }



            return true;
        }

        public Tunnel Tail
        {
            get { return tail; }
        }

        public uint Count
        {
            get { return count; }
        }

        public Tunnel Head
        {
            get { return head; }
        }

        public Tunnel Current
        {
            get { return current; }
            set { current = value; }
        }

        public void SaveTunnelList(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream
                (filename, FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void LoadTunnelList(string filename, ref TunnelList lTunnel)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream
                (filename, FileMode.Open, FileAccess.Read);
            lTunnel = (TunnelList)bf.Deserialize(fs);
            fs.Close();
        }

        public void Delete(Tunnel _dt)
        {
            if ((_dt == null) || (_dt.Name == "")) return;
            if ((head.Name == _dt.Name) && (head.ID == _dt.ID))
            {
                head = head.Next;
                count--;
                return;
            }
            Tunnel cursor = head;
            while (cursor.Next != null)
            {
                if (cursor.Next.Name == _dt.Name)
                {
                    if (cursor.Next == tail) tail = cursor;
                    cursor.Next = cursor.Next.Next;
                    count--;
                    return;
                }
                cursor = cursor.Next;
            }
        }

    }
}
