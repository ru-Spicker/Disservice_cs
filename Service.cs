using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Disservice
{
    [Serializable]
    class Service
    {

        uint iD;
        string name;
        Interface srcInterfaceWork;
        Interface srcInterfaceProt;
        Interface snkInterfaceWork;
        Interface snkInterfaceProt;
        string serviceType;
        string[] workTunnels;
        string[] protTunnels;
        string protectType;
        Service next;

        //constructors
        public Service()
        {
            iD = 0;
            name = "";
            srcInterfaceProt = new Interface();
            srcInterfaceWork = new Interface();
            snkInterfaceProt = new Interface();
            snkInterfaceWork = new Interface();
            serviceType = "";
            protectType = "";
            workTunnels = null;
            protTunnels = null;
            next = null;
        }

        public Service (Service _srv)
        {
            iD = _srv.iD;
            name = _srv.name;
            srcInterfaceProt = _srv.srcInterfaceProt;
            srcInterfaceWork = _srv.srcInterfaceWork;
            snkInterfaceProt = _srv.snkInterfaceProt;
            snkInterfaceWork = _srv.snkInterfaceWork;
            serviceType = _srv.serviceType;
            protectType = _srv.protectType;
            workTunnels = _srv.workTunnels;
            protTunnels = _srv.protTunnels;
            next = null;
        }
        //properties
        public uint ID
        {
            set { iD = value; }
            get { return iD; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public Interface SrcInterfaceProt
        {
            set { srcInterfaceProt = value; }
            get { return srcInterfaceProt; }
        }

        public Interface SrcInterfaceWork
        {
            set { srcInterfaceWork = value; }
            get { return srcInterfaceWork; }
        }

        public Interface SnkInterfaceProt
        {
            set { snkInterfaceProt = value; }
            get { return snkInterfaceProt; }
        }

        public Interface SnkInterfaceWork
        {
            set { snkInterfaceWork = value; }
            get { return snkInterfaceWork; }
        }

        public string[] WorkTunnels
        {
            set {
                int count = DeleteDublicat(value);
                workTunnels = new string[count];
                int i;
                for (i = 0; i < count; i++)
                    workTunnels[i] = value[i];
                }
            get { return workTunnels; }
        }

        public string[] ProtTunnels
        {
            set
            {
                int count = DeleteDublicat(value);
                protTunnels = new string[count];
                int i;
                for (i = 0; i < count; i++)
                    protTunnels[i] = value[i];
            }
            get { return protTunnels; }
        }

        public Service Next
        {
            set { next = value; }
            get { return next; }
        }

        public string ProtectType
        {
            set { protectType = value; }
            get { return protectType; }
        }

        public string ServiceType
        {
            set { serviceType = value; }
            get { return serviceType; }
        }

        public string Show()
        {
            string str = "";
            if (name != "") str += "ServiceName - " + name;
            if (iD > 0) str += "\tID - " + iD.ToString();
            if (protectType != "") str += "\tProtectionType - " + protectType;
            if (serviceType != "") str += "\tServiceType - " + serviceType;
            str += "\n";
            if ((srcInterfaceWork != null) && (srcInterfaceWork.NEName != "")) str += "SourceWorkInt:\t" + srcInterfaceWork.ShowInterface() + "\n";
            if ((srcInterfaceProt != null) && (srcInterfaceProt.NEName != "")) str += "SourceProtInt:\t" + srcInterfaceProt.ShowInterface() + "\n";
            if ((snkInterfaceWork != null) && (snkInterfaceWork.NEName != "")) str += "SinkWorkInt:\t" + snkInterfaceWork.ShowInterface() + "\n";
            if ((snkInterfaceProt != null) && (snkInterfaceProt.NEName != "")) str += "SinkeProtInt:\t" + snkInterfaceProt.ShowInterface() + "\n";
            int i;
            if (workTunnels != null)
            {
                str += "WorkTunnels:\n";
                for (i = 0; i < workTunnels.Count(); i++)
                {
                    if (workTunnels[i] != "") str += "\t" + workTunnels[i] + "\n";
                }
            }
            if (protTunnels != null)
            {
                str += "ProtTunnels:\n";
                for (i = 0; i < protTunnels.Count(); i++)
                {
                    if (protTunnels[i] != "") str += "\t" + protTunnels[i] + "\n";
                }
            }
            return str;
        }

        int DeleteDublicat(string[] strArr)
        {
            if (strArr == null) return 0;
            int i, ii, count = strArr.Count();
            if ((strArr[0] == "") || (count < 2))
                return 0;
            for (i = 0; i < count-1; i++)
            {
                if (strArr[i] == strArr[i+1])
                {
                    for (ii = i; ii < count-1; ii++)
                    {
                        strArr[ii] = strArr[ii + 1];
                    }
                    count--;
                    strArr[count] = "";
                }

            }


            return count;
        }

        override public String ToString()
        {
            return name;
        }
    }


    [Serializable]
    class ServiceList
    {
        uint count;
        Service head, tail;

        public ServiceList()
        {
            count = 0;
            head = null;
            tail = null;
        }

        public Service Head
        {
            set { head = value; }
            get { return head; }
        }

        public bool Add(Service _srv)
        {
            Service cursor = head;
            Service preCursor = head;
            if ((_srv.Name != "") && (_srv.ID > 0))
            {
                while (cursor != null)
                {
                    if ((cursor.Name == _srv.Name) && (cursor.ID == _srv.ID))
                        break;
                    preCursor = cursor;
                    cursor = cursor.Next;
                }
                Service newService = new Service(_srv);
                if (cursor == null)
                {
                    if (head == null)
                    {
                        head = newService;
                        tail = newService;
                    }
                    else
                    {
                        tail.Next = newService;
                        tail = newService;
                    }
                    count++;
                    return true;
                }
                else
                {
                    if (cursor == tail) tail = newService;
                    if (cursor == head) head = newService;
                    newService.Next = cursor.Next;
                    preCursor.Next = newService;
                    return true;
                }
            }
            return false;

        }

        public void Show()
        {
/*            Service cursor = head;
            while (cursor != null)
            {
                Form1.PostToForm2(cursor.Show());
                cursor = cursor.Next;
            }
*/            
        }

        public void SaveServiceList(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream
                (filename, FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void LoadServiceList(string filename, ref ServiceList lService)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream
                (filename, FileMode.Open, FileAccess.Read);
            lService = (ServiceList)bf.Deserialize(fs);
            fs.Close();
        }

        public Service SearchService(string _ServiceName)
        {
            Service cursor = head;
            while (cursor != null)
            {
                if (cursor.Name == _ServiceName) return cursor;
                cursor = cursor.Next;
            }
            return null;
        }

        public void Delete(Service _ds)
        {
            Service cursor = head;
            if (cursor == null) return;
            if (_ds == null) return;
            if (_ds.Name == "") return;
            if (cursor.Name == _ds.Name)
            {
                head = cursor.Next;
                count--;
                return;
            }
            while (cursor.Next != null)
            {
                if (cursor.Next.Name == _ds.Name)
                {
                    if (cursor.Next == tail) tail = cursor.Next;
                    cursor.Next = cursor.Next.Next;
                    count--;
                    return;
                }
                cursor = cursor.Next;
            }
        }

    }
}
