using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Disservice
{
    public partial class Form1 : Form
    {
        DB pDB = new DB();
        NEList LNE = new NEList();
        NEList LBrokenPorts = new NEList();
        TunnelList LDamagedTunnels = new TunnelList();
        TunnelList LBrokenTunnels = new TunnelList();
        ServiceList LDamagedService = new ServiceList();
        ServiceList LBrokenService = new ServiceList();
        int countETH = 0, countCES = 0, countTunnels = 0, countPG = 0, count = 0, c2gBroken = 0, c3GBroken = 0, c4GBroken = 0,
            c2gDamaged = 0, c3GDamaged = 0, c4GDamaged = 0;

        public void PostToForm2(string str)
        {
            richTextBox2.AppendText(String.Format(str + "\n"));
            richTextBox2.ScrollToCaret();

        }


        void ParseXsls(Excel.Sheets sheets)
        {
            Excel.Worksheet workSheet;
            Excel.Range cells;
            String[] strArr1 = new String[4], strArr2 = new String[4], strArr3 = new String[4];
            Tunnel tmpTunnel = new Tunnel();
            TransitNE[] tmpTransitNE;
            string str;
            int _parse = 0;
            int rowsCount = 0, columnsCount = 0;
            DateTime curTime;
            int numSheet = 2; //set sheet "Static CR Tunnel"
            String UsedRange = "";
            {
                int i = 0;
                workSheet = (Excel.Worksheet)sheets.Item[numSheet];
                rowsCount = workSheet.UsedRange.Rows.Count;
                columnsCount = workSheet.UsedRange.Columns.Count;
                dataGridView.ColumnCount = columnsCount;
/*                DataGridViewColumn[] dataGridColumns = new DataGridViewColumn[columnsCount];
                for (i = 0; i < columnsCount; i++)
                {
                    DataGridViewColumn _tmpColumn = new DataGridViewColumn();
                    _tmpColumn.CellType.
                        = DataGridTextBoxColumn;
                    dataGridColumns[i] = new DataGridViewColumn();
                }
               dataGridColumns[1].Name = "FirstColumn";
                dataGridView.Columns.AddRange(dataGridColumns);
*/
               dataGridView.Columns[1].Name = "FirstColumn";
                return;
                cells = workSheet.Range["A1", UsedRange];
                str = "";
                if (pDB.LTunnel.Tail != null) pDB.LTunnel.SetCurrentToTail();
                int ii = 9;
                while ((cells[ii, 5].Value2 != null) && (cells[ii, 5].Value2 != "")) 
                {
                    str = "";
                    {
                        if (cells[ii, 4].Value2 != null) tmpTunnel.Name = cells[ii, 4].Value2; 
                        try
                        {
                            _parse = Int32.Parse(cells[ii, 5].Value2); 
                        }
                        catch (FormatException)
                        {
                            str = "TunnelID FormatException" + cells[ii, 5].Value2 + '\n'; 
                            richTextBox2.AppendText(str);
                        }
                        catch (OverflowException)
                        {
                            str = "TunnelID OverflowException" + cells[ii, 5].Value2 + '\n';
                            richTextBox2.AppendText(str);
                        }
                        if (cells[ii, 5].Value2 != null) tmpTunnel.ID = (uint)_parse; 
                        if ((cells[ii, 9].Value2 != null) && (cells[ii, 10].Value2 != null))
                        {
                            tmpTunnel.SrcInterface = new Interface(cells[ii, 9].Value2, cells[ii, 10].Value2); 
                        }
                        if ((cells[ii, 15].Value2 != null) && (cells[ii, 16].Value2 != null))
                        {
                            tmpTunnel.SnkInterface = new Interface(cells[ii, 15].Value2, cells[ii, 16].Value2);
                        }
                        if (cells[ii, 24].Value2 != null) strArr1 = cells[ii, 24].Value2.ToString().Split('\n');
                        if (cells[ii, 25].Value2 != null) strArr2 = cells[ii, 25].Value2.ToString().Split('\n');
                        if (cells[ii, 27].Value2 != null) strArr3 = cells[ii, 27].Value2.ToString().Split('\n');
                        int strCount = strArr1.Count();
                        if ((strArr1[0] != null))
                        {
                            tmpTransitNE = new TransitNE[strCount];
                            for (i = 0; i < (strCount); i++)
                            {
                                tmpTransitNE[i] = new TransitNE();
                                tmpTransitNE[i].NEName = strArr1[i];
                                tmpTransitNE[i].InSlotPort = strArr2[i];
                                tmpTransitNE[i].OutSlotPort = strArr3[i];
                            }
                            tmpTunnel.TransitNE = tmpTransitNE;
                        }

                        pDB.LTunnel.Add(tmpTunnel);

                    }// get tunnel
//                    str += LTunnel.Tail.ShowTunnel() + "\n";
//                    richTextBox1.AppendText(String.Format("{0}{1}", str1, str));
//                    richTextBox1.ScrollToCaret();
//                    str = "";

                    ii += 1;
                    count++;
                    countTunnels++;
                    label1.Text = String.Format("Tunnels: {0} PG: {1} ETH: {2} CES: {3} SUM: {4}", countTunnels, countPG, countETH, countCES, count);
                }// while tunnel exist //Load Tunnel

                    richTextBox2.ScrollToCaret();


            }// end read tunnels //load Tunnels

            numSheet = 3; // set sheet "Tunnel Protection Group"
            strArr3 = new String[4];
            {
                workSheet = (Excel.Worksheet)sheets.Item[numSheet];
                UsedRange = "I" + workSheet.UsedRange.Rows.Count.ToString();
                cells = workSheet.Range["A1", UsedRange];
                str = "";
                int ii = 9;
                while ((cells[ii, 2].Value2 != null) && (cells[ii, 2].Value2 != ""))
                {
                    str = "";
                    {
                        if (cells[ii, 8].Value2 != null) strArr1 = cells[ii, 8].Value2.ToString().Split('\n');
                        if (cells[ii, 9].Value2 != null) strArr2 = cells[ii, 9].Value2.ToString().Split('\n');
                        int strCount = strArr1.Count();
                        if ((strArr1[0] != null))
                        {
                            int i = 0;
                            for (i = 0; i < strCount; i++)
                                switch (strArr1[i])
                                {
                                    case "Working":
                                        strArr3[0] = strArr2[i];
                                        strArr3[1] = null;
                                        break;
                                    case "Forward Working":
                                        strArr3[0] = strArr2[i];
                                        break;
                                    case "Backward Working":
                                        strArr3[1] = strArr2[i];
                                        break;
                                    case "Protecting":
                                        strArr3[2] = strArr2[i];
                                        strArr3[3] = null;
                                        break;
                                    case "Forward Protecting":
                                        strArr3[2] = strArr2[i];
                                        break;
                                    case "Backward Protecting":
                                        strArr3[3] = strArr2[i];
                                        break;
                                    default:
                                        richTextBox2.AppendText(string.Format("\t\t\t\tPG ERROR - {0}\n", strArr2[0]));
                                        break;
                                }
                        }

                    }// get PG

                    if (!(pDB.LTunnel.SetRole(strArr3)))
                    {
                        richTextBox2.AppendText(String.Format("\nError - " + strArr3[0] + "\n\n"));
                        richTextBox2.ScrollToCaret();
                    }


                    ii += 1;
                    count++;
                    countPG++;
                    label1.Text = String.Format("Tunnels: {0} PG: {1} ETH: {2} CES: {3} SUM: {4}", countTunnels, countPG, countETH, countCES, count);
                }// while PG exist

                richTextBox2.ScrollToCaret();


            } //load Protection Group

            numSheet = 4; // set sheet "PWE3 ETH"
            {
                workSheet = (Excel.Worksheet)sheets.Item[numSheet];
                UsedRange = "I" + workSheet.UsedRange.Rows.Count.ToString();
                cells = workSheet.Range["A1", UsedRange];
                int ii = 9;
                while ((cells[ii, 1].Value2 != null) && (cells[ii, 1].Value2 != ""))
                {
                    Service tmpService = new Service();
                    if (cells[ii, 4].Value2 != null) tmpService.Name = cells[ii, 4].Value2;
                    try
                    {
                        _parse = Int32.Parse(cells[ii, 5].Value2);
                    }
                    catch (FormatException)
                    {
                        str = "PWE3 ETH ID FormatException" + cells[ii, 5].Value2 + '\n';
                        richTextBox2.AppendText(str);
                    }
                    catch (OverflowException)
                    {
                        str = "PWE3 ETH ID OverflowException" + cells[ii, 5].Value2 + '\n';
                        richTextBox2.AppendText(str);
                    }
                    if (cells[ii, 5].Value2 != null) tmpService.ID = (uint)_parse;
                    if (cells[ii, 9].Value2 != null) tmpService.ProtectType = cells[ii, 9].Value2;
                    if (cells[ii, 12].Value2 != null) tmpService.SrcInterfaceWork.NEName = cells[ii, 12].Value2;

                    if (cells[ii, 13].Value2 != null) tmpService.SrcInterfaceWork.SlotPort = cells[ii, 13].Value2;
                    if (cells[ii, 21].Value2 != null) tmpService.SnkInterfaceWork.NEName = cells[ii, 21].Value2;
                    if (cells[ii, 22].Value2 != null) tmpService.SnkInterfaceWork.SlotPort = cells[ii, 22].Value2;

                    if (cells[ii, 35].Value2 != null) strArr1 = cells[ii, 35].Value2.ToString().Split('\n');
                    tmpService.WorkTunnels = strArr1;


                    if (tmpService.ProtectType != "Protection-Free")
                    {
                        if (cells[ii + 1, 12].Value2 != null) tmpService.SrcInterfaceProt.NEName = cells[ii + 1, 12].Value2;
                        if (cells[ii + 1, 13].Value2 != null) tmpService.SrcInterfaceProt.SlotPort = cells[ii + 1, 13].Value2;
                        if (cells[ii+1, 21].Value2 != null) tmpService.SnkInterfaceProt.NEName = cells[ii+1, 21].Value2;
                        if (cells[ii+1, 22].Value2 != null) tmpService.SnkInterfaceProt.SlotPort = cells[ii+1, 22].Value2;

                        if (cells[ii, 35].Value2 != null) strArr1 = cells[ii+1, 35].Value2.ToString().Split('\n');
                        tmpService.ProtTunnels = strArr1;

                    }

                    tmpService.ServiceType = "PWE3 ETH";
                    pDB.LService.Add(tmpService);
                    ii += 2;
                    count++;
                    countETH++;
                    label1.Text = String.Format("Tunnels: {0} PG: {1} ETH: {2} CES: {3} SUM: {4}", countTunnels, countPG, countETH, countCES, count);
//                    richTextBox1.AppendText(String.Format(tmpService.Show() + "\n"));
//                    richTextBox1.ScrollToCaret();


                }

                richTextBox2.ScrollToCaret();
            }  //load PWE3 ETH

            numSheet = 5; // set sheet "PWE3 ETH"
            {
                workSheet = (Excel.Worksheet)sheets.Item[numSheet];
                UsedRange = "I" + workSheet.UsedRange.Rows.Count.ToString();
                cells = workSheet.Range["A1", UsedRange];
                int ii = 9;
                while ((cells[ii, 1].Value2 != null) && (cells[ii, 1].Value2 != ""))
                {
                    Service tmpService = new Service();
                    if (cells[ii, 4].Value2 != null) tmpService.Name = cells[ii, 4].Value2;
                    try
                    {
                        _parse = Int32.Parse(cells[ii, 5].Value2);
                    }
                    catch (FormatException)
                    {
                        str = "PWE3 CES ID FormatException" + cells[ii, 5].Value2 + '\n';
                        richTextBox2.AppendText(str);
                    }
                    catch (OverflowException)
                    {
                        str = "PWE3 CES ID OverflowException" + cells[ii, 5].Value2 + '\n';
                        richTextBox2.AppendText(str);
                    }
                    if (cells[ii, 5].Value2 != null) tmpService.ID = (uint)_parse;
                    if (cells[ii, 9].Value2 != null) tmpService.ProtectType = cells[ii, 9].Value2;
                    if (cells[ii, 12].Value2 != null) tmpService.SrcInterfaceWork.NEName = cells[ii, 12].Value2;

                    if (cells[ii, 13].Value2 != null) tmpService.SrcInterfaceWork.SlotPort = cells[ii, 13].Value2;
                    if (cells[ii, 21].Value2 != null) tmpService.SnkInterfaceWork.NEName = cells[ii, 20].Value2;
                    if (cells[ii, 22].Value2 != null) tmpService.SnkInterfaceWork.SlotPort = cells[ii, 21].Value2;

                    if (cells[ii, 33].Value2 != null) strArr1 = cells[ii, 33].Value2.ToString().Split('\n');
                    tmpService.WorkTunnels = strArr1;


                    if (tmpService.ProtectType != "Protection-Free")
                    {
                        if (cells[ii + 1, 12].Value2 != null) tmpService.SrcInterfaceProt.NEName = cells[ii + 1, 12].Value2;
                        if (cells[ii + 1, 13].Value2 != null) tmpService.SrcInterfaceProt.SlotPort = cells[ii + 1, 13].Value2;
                        if (cells[ii + 1, 21].Value2 != null) tmpService.SnkInterfaceProt.NEName = cells[ii + 1, 20].Value2;
                        if (cells[ii + 1, 22].Value2 != null) tmpService.SnkInterfaceProt.SlotPort = cells[ii + 1, 21].Value2;

                        if (cells[ii, 33].Value2 != null) strArr1 = cells[ii+1, 33].Value2.ToString().Split('\n');
                        tmpService.ProtTunnels = strArr1;

                    }

                    tmpService.ServiceType = "PWE3 CES";
                    pDB.LService.Add(tmpService);
                    ii += 2;
                    count++;
                    countCES++;
                    label1.Text = String.Format("Tunnels: {0} PG: {1} ETH: {2} CES: {3} SUM: {4}", countTunnels, countPG, countETH, countCES, count);
 //                   richTextBox1.AppendText(String.Format(tmpService.Show() + "\n"));
 //                   richTextBox1.ScrollToCaret();


                }

                curTime = DateTime.Now;
                richTextBox2.AppendText(String.Format(curTime.ToLocalTime().ToString() + "\n"));
                richTextBox2.ScrollToCaret();
            }  // load PWE3 CES
        } // ParseXsls

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp;
            Excel.Sheets sheets;
//            openFileDialog1.InitialDirectory = @"D:\code\Data\";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                excelApp = new Excel.Application();
                DateTime curTime;
                string str;
                curTime = DateTime.Now;
                str = curTime.ToLocalTime().ToString() + "\n";
                richTextBox2.AppendText(str);
                foreach (String fileName in openFileDialog1.FileNames)
                {
                    excelApp.Workbooks.Open(fileName);
                    str = fileName + "\n";
                    richTextBox2.AppendText(str);
                    richTextBox2.ScrollToCaret();
                    sheets = excelApp.Worksheets;
                    ParseXsls(sheets);
                    excelApp.Workbooks.Close();

                }// foreach обход файлов

                excelApp.Quit();
                sheets = null;
                excelApp = null;
                FillNEList();
                FillComboBoxNEName();

            }// if OpenDialog1
        }//button1_Click

        void ShowTunnel()
        {
            string str;
            pDB.LTunnel.Current = pDB.LTunnel.Head;
            if (pDB.LTunnel == null)
            {
                richTextBox2.AppendText("\t\t\tNo Tunnels");
                return;
            }
            str = pDB.LTunnel.ShowNextTunnel();
            while (str != "")
            {
                richTextBox2.AppendText(str);
                str = pDB.LTunnel.ShowNextTunnel();
            }
            richTextBox2.ScrollToCaret();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NE cursor = LNE.Head;
            while (cursor != null)
            {
                if (cursor.NEName == comboBoxNEName.SelectedItem.ToString())
                {
                    if (cursor.SlotPorts != null)
                    {
                        listBoxSlotPort.Items.Clear();
                        foreach (SlotPort _sp in cursor.SlotPorts)
                        {
                            listBoxSlotPort.Items.Add(_sp.Slot_Port);
                        }
                        listBoxSlotPort.Sorted = true;
                    }
                }
                cursor = cursor.Next;
            }

        }

        private void buttonAddPort_Click(object sender, EventArgs e)
        {
            if((listBoxSlotPort.SelectedItem != null) && (comboBoxNEName.SelectedItem != null))
            AddBrokenPort(comboBoxNEName.SelectedItem.ToString(), listBoxSlotPort.SelectedItem.ToString());
        }

        private void buttonAddAllPorts_Click(object sender, EventArgs e)
        {
            foreach (object item in listBoxSlotPort.Items)
            {
                    AddBrokenPort(comboBoxNEName.SelectedItem.ToString(), item.ToString());
            }
        }

        private void buttonRemovePort_Click(object sender, EventArgs e)
        {
            if (listBoxBrokenPorts.SelectedItem == null) return;
            string[] groups = new string[2];
            groups[0] = "NEName";
            groups[1] = "SlotPort";
            string[] arrStr = TextParse(listBoxBrokenPorts.SelectedItem.ToString(), @"(?<NEName>.*)(\-){1}(?<SlotPort>(\d{1,2}|VEth)(\-){1}\d{1,2})", groups);

//            richTextBox2.AppendText("NEName: \"" + arrStr[0] + "\" SlotPort: \"" + arrStr[1] + "\"\n");
            LBrokenPorts.RemoveSlotPort(arrStr[0], arrStr[1]);
            ShowBrokenPorts();
        }

        private void buttonRemoveAllPorts_Click(object sender, EventArgs e)
        {
            LBrokenPorts.Head = null;
            LBrokenPorts.Tail = null;
            ShowBrokenPorts();
        }

        void ShowService()
        {
            if (pDB.LService == null)
            {
                richTextBox2.AppendText("\t\t\tNo Service");
                return;
            }
            String str;
            Service srv;
            srv = pDB.LService.Head;
            while (srv != null)
            {
                str = srv.Show() + "\n";
                richTextBox2.AppendText(str);
                srv = srv.Next;
            }
            richTextBox2.ScrollToCaret();

        }

        void FillNEList()
        {
            LNE = new NEList();
            Service cursor = pDB.LService.Head;
            while (cursor != null)
            {
                LNE.AddService(cursor);
                cursor = cursor.Next;
            }

            Tunnel cursor1 = pDB.LTunnel.Head;
            while (cursor1 != null)
            {
                LNE.AddTunnel(cursor1);
                cursor1 = cursor1.Next;
            }
        }

        void ShowNEList()
        {
            NE cursor = LNE.Head;
            string str = "";
            while (cursor != null)
            {
                richTextBox2.AppendText(cursor.ShowNE());
                cursor = cursor.Next;
            }
            richTextBox2.ScrollToCaret();
        }

        private void buttonSaveDB_Click(object sender, EventArgs e)
        {
            string filename = "";
//            saveFileDialog1.InitialDirectory = @"D:\code\Data\";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                pDB.SaveDB(Path.GetDirectoryName(saveFileDialog1.FileName) + "\\" + filename + ".dsv");

            }

        }

        private void buttonLoadDB_Click(object sender, EventArgs e)
        {
            DateTime curTime;
            string str;
            openFileDialog1.InitialDirectory = @"D:\code\Data\";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                curTime = DateTime.Now;
                str = curTime.ToLocalTime().ToString() + "\n";
                richTextBox2.AppendText("Start load DB file: " + str);
                richTextBox2.ScrollToCaret();

                if (Path.GetExtension(openFileDialog1.FileName) == ".dsv")
                    pDB.LoadDB(openFileDialog1.FileName, ref pDB);
            }
            curTime = DateTime.Now;
            str = curTime.ToLocalTime().ToString() + "\n";
            richTextBox2.AppendText("Start fill NE list: " + str);
            richTextBox2.ScrollToCaret();

            FillNEList();
            curTime = DateTime.Now;
            str = curTime.ToLocalTime().ToString() + "\n";
            richTextBox2.AppendText("Start show NE list : " + str);
            richTextBox2.ScrollToCaret();

            FillComboBoxNEName();

            curTime = DateTime.Now;
            str = curTime.ToLocalTime().ToString() + "\n";
            richTextBox2.AppendText("End load DB: " + str);
            richTextBox2.ScrollToCaret();
            //ShowNEList();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            string[] groups = new string[2];
            groups[0] = "NEName";
            groups[1] = "SlotPort";
            NE curNE;
            Tunnel curT1, curT2;
            DateTime curTime;
            string str;
            LDamagedTunnels = new TunnelList();
            LBrokenTunnels = new TunnelList();
            LDamagedService = new ServiceList();
            LBrokenService = new ServiceList();
            bool BrokenWorkTunnel = false, BrokenProtTunnel = false;
            listBoxBrokenFix.Items.Clear();
            listBoxBrokenBS.Items.Clear();
            listBoxBrokenInter.Items.Clear();
            listBoxBrokenService.Items.Clear();
            listBoxDamagedFix.Items.Clear();
            listBoxDamagedBS.Items.Clear();
            listBoxDamagedInter.Items.Clear();
            listBoxDamagedService.Items.Clear();
            c2gBroken = 0;
            c3GBroken = 0;
            c4GBroken = 0;
            c2gDamaged = 0;
            c3GDamaged = 0;
            c4GDamaged = 0;

            richTextBox2.Clear();
            curTime = DateTime.Now;
            str = curTime.ToLocalTime().ToString() + "\n";
            richTextBox2.AppendText("Start calculate tunnels: " + str);
            richTextBox2.ScrollToCaret();

            foreach (object item in listBoxBrokenPorts.Items)
            {
                string[] arrStr = TextParse(item.ToString(), @"(?<NEName>.*)(\-){1}(?<SlotPort>(\d{1,2}|VEth)(\-){1}\d{1,2})", groups);
                curNE = LNE.Head;
                while ((curNE != null) && (curNE.NEName != arrStr[0]))
                    curNE = curNE.Next;
                if (curNE != null)
                {
                    if (curNE.SlotPorts != null)
                        foreach (SlotPort curSP in curNE.SlotPorts)
                        {
                            if (curSP.Slot_Port == arrStr[1])
                            {
                                if (curSP.Tunnels != null)
                                    foreach (Tunnel curT in curSP.Tunnels) //если туннель поврежден, добавляем в поврежденные реверсный туннель
                                    {
                                        if (curT != null) LDamagedTunnels.Add(curT);
                                        if (curT.RVSTunnel != null) LDamagedTunnels.Add(curT.RVSTunnel);
                                    }
                                break;
                            }
                        }
                }
            } //find Damaged tunnels

/*            curT1 = LDamagedTunnels.Head;
            richTextBox2.AppendText("-----------------------------------1. Damaged tunnels:\n");
            while (curT1 != null)
            {
                richTextBox2.AppendText(curT1.ShowTunnel());
                curT1 = curT1.Next;
            }
            richTextBox2.AppendText("\nDamaged tail: " + LDamagedTunnels.Tail.Name + "\n");
            curT1 = LBrokenTunnels.Head;
            richTextBox2.AppendText("-----------------------------------1. Broken tunnels:\n");
            while (curT1 != null)
            {
                richTextBox2.AppendText(curT1.ShowTunnel());
                curT1 = curT1.Next;
            }
            richTextBox2.AppendText("\n");*/
            curT1 = LDamagedTunnels.Head;
            while (curT1 != null)
            {
                if (curT1 == null) continue;
                if (curT1.PRTTunnel == null)
                {
                    LDamagedTunnels.Delete(curT1);
                    LBrokenTunnels.Add(curT1);
                    richTextBox2.AppendText("- Damaged + Broken prt free: " + curT1.Name + "\n");
                   if (curT1.RVSTunnel != null)
                    {
                        LDamagedTunnels.Delete(curT1.RVSTunnel);
                        LBrokenTunnels.Add(curT1.RVSTunnel);
                    }
//                    richTextBox2.AppendText("\nDamaged tail: " + LDamagedTunnels.Tail.Name + "\n");
                }
                else
                {
                    if (((curT1.PRTTunnel != null) && (LDamagedTunnels.SearchTunnel(curT1.PRTTunnel.Name) != null))
                        ||((curT1.PRTTunnel.RVSTunnel != null) && (LDamagedTunnels.SearchTunnel(curT1.PRTTunnel.RVSTunnel.Name) != null)))
                    {
                        LDamagedTunnels.Delete(curT1);
                        LBrokenTunnels.Add(curT1);
                        richTextBox2.AppendText("- Damaged + Broken both: " + curT1.Name + "\n");
                        if (curT1.RVSTunnel != null)
                        {
                            LDamagedTunnels.Delete(curT1.RVSTunnel);
                            LBrokenTunnels.Add(curT1.RVSTunnel);
                            richTextBox2.AppendText("- Damaged + Broken both: " + curT1.RVSTunnel.Name + "\n");
                        }
                        if (curT1.PRTTunnel != null)
                        {
                            LDamagedTunnels.Delete(curT1.PRTTunnel);
                            LBrokenTunnels.Add(curT1.PRTTunnel);
                            richTextBox2.AppendText("- Damaged + Broken both: " + curT1.PRTTunnel.Name + "\n");
                        }
                        if (curT1.PRTTunnel.RVSTunnel != null)
                        {
                            LDamagedTunnels.Delete(curT1.PRTTunnel.RVSTunnel);
                            LBrokenTunnels.Add(curT1.PRTTunnel.RVSTunnel);
                        }
//                        richTextBox2.AppendText("\nDamaged tail: " + LDamagedTunnels.Tail.Name + "\n");
                    }
                }
                curT1 = curT1.Next;
            } //find Broken tunnels

            curT1 = LDamagedTunnels.Head;
            richTextBox2.AppendText("-----------------------------------2. Damaged tunnels:\n");
            while (curT1 != null)
            {
                richTextBox2.AppendText(curT1.ShowTunnel());
                curT1 = curT1.Next;
            }
//            richTextBox2.AppendText("\nDamaged tail: " + LDamagedTunnels.Tail.Name + "\n");

            curT1 = LBrokenTunnels.Head;
            richTextBox2.AppendText("-----------------------------------2. Broken tunnels:\n");
            while (curT1 != null)
            {
                richTextBox2.AppendText(curT1.ShowTunnel());
                curT1 = curT1.Next;
            }

            curT1 = LDamagedTunnels.Head;
            while (curT1 != null)
            {
                if (curT1.RVSTunnel != null)
                    LDamagedTunnels.Add(curT1.RVSTunnel);

                if (curT1.PRTTunnel != null)
                {
                    LDamagedTunnels.Add(curT1.PRTTunnel);
                    richTextBox2.AppendText("Added PRT Tunnel:-------" + curT1.PRTTunnel.Name + "\n");
                }

                if (curT1.PRTTunnel.RVSTunnel != null)
                    LDamagedTunnels.Add(curT1.PRTTunnel.RVSTunnel);
                curT1 = curT1.Next;


/*                curT2 = LDamagedTunnels.Head;
                richTextBox2.AppendText("----------------Damaged tunnels:\n");
                while (curT2 != null)
                {
                    richTextBox2.AppendText(curT2.ShowTunnel());
                    curT2 = curT2.Next;
                }
                richTextBox2.AppendText("\nDamaged tail: " + LDamagedTunnels.Tail.Name + "\n");*/
            }



            curT1 = LDamagedTunnels.Head;
            richTextBox2.AppendText("-----------------------------------Damaged tunnels: " + LDamagedTunnels.Count + "\n");
            while (curT1 != null)
            {
                richTextBox2.AppendText(curT1.ShowTunnel());
                curT1 = curT1.Next;
            }
//            richTextBox2.AppendText("\nDamaged tail: " + LDamagedTunnels.Tail.Name + "\n");

            curT1 = LBrokenTunnels.Head;
            richTextBox2.AppendText("-----------------------------------Broken tunnels: " + LDamagedTunnels.Count + "\n");
            while (curT1 != null)
            {
                richTextBox2.AppendText(curT1.ShowTunnel());
                curT1 = curT1.Next;
            }

            richTextBox2.ScrollToCaret(); //Show finded tunnels

            //------------------------------------------------------------------------------

            Service curPWE = pDB.LService.Head;
            Tunnel SearchTunnel;
            int i=0;
            curTime = DateTime.Now;
            str = curTime.ToLocalTime().ToString() + "\n";
            richTextBox2.AppendText("Start calculate service: " + str);
            richTextBox2.ScrollToCaret();

            while (curPWE != null)
            {
                string SnkInterfaceWork = "", SnkInterfaceProt = "", SrsInterfaceWork = "", SrsInterfaceProt = "";
                switch (curPWE.ProtectType)
                {
                    case "Protection-Free":
                        SrsInterfaceWork = curPWE.SrcInterfaceWork.NEName + "-" + curPWE.SrcInterfaceWork.SlotPort;
                        SnkInterfaceWork = curPWE.SnkInterfaceWork.NEName + "-" + curPWE.SnkInterfaceWork.SlotPort;
                        foreach (object item in listBoxBrokenPorts.Items)
                        {
                            if (SrsInterfaceWork == item.ToString())
                            {
                                if (LBrokenService.SearchService(curPWE.Name) == null)
                                {
                                    LBrokenService.Add(curPWE);
                                    richTextBox2.AppendText(curPWE.Name +" - Broken Source port: " + SrsInterfaceWork + "\n");
                                }
                            }
                            if (SnkInterfaceWork == item.ToString())
                            {
                                if (LBrokenService.SearchService(curPWE.Name) == null)
                                {
                                    LBrokenService.Add(curPWE);
                                    richTextBox2.AppendText(curPWE.Name + " - Broken Sink   port: " + SnkInterfaceWork + "\n");
                                }
                            }

                            foreach (string tnl in curPWE.WorkTunnels)
                            {
                                SearchTunnel = LBrokenTunnels.SearchTunnel(tnl); 
                                if (SearchTunnel != null)
                                {
                                    {
                                        if (LBrokenService.SearchService(curPWE.Name) == null)
                                        {
                                            LBrokenService.Add(curPWE);
                                            if (LDamagedService.SearchService(curPWE.Name) != null) LDamagedService.Delete(curPWE);
                                            richTextBox2.AppendText("\t\t\t" + curPWE.Name + " - Broken tunnel: " + tnl + "\n");
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    // если туннель поврежден
                                    SearchTunnel = LDamagedTunnels.SearchTunnel(tnl);
                                    if ((SearchTunnel != null) ) 
                                    {
                                        {
                                            if ((LBrokenService.SearchService(curPWE.Name) == null) && (LDamagedService.SearchService(curPWE.Name) == null))
                                            {
                                                LDamagedService.Add(curPWE);
                                                richTextBox2.AppendText(curPWE.Name + " - Damaged tunnel: " + tnl + "\n");
                                            }
                                        }
                                    }
                                }
                            }
                        } // проверка PRT Free сервисов
                        break;

                    case "PW APS (dual source and single sink)":
//                        richTextBox2.AppendText("PW APS (dual source and single sink)\n");
                        SrsInterfaceWork = curPWE.SrcInterfaceWork.NEName + "-" + curPWE.SrcInterfaceWork.SlotPort;
                        SrsInterfaceProt = curPWE.SrcInterfaceProt.NEName + "-" + curPWE.SrcInterfaceProt.SlotPort;
                        SnkInterfaceWork = curPWE.SnkInterfaceWork.NEName + "-" + curPWE.SnkInterfaceWork.SlotPort;
                        foreach (object item in listBoxBrokenPorts.Items)
                        {
                            if ((SrsInterfaceWork == item.ToString()) && (SrsInterfaceProt == item.ToString()))
                            {
                                if ((LBrokenService.SearchService(curPWE.Name) == null))
                                {
                                    if (LBrokenService.SearchService(curPWE.Name) == null) LBrokenService.Add(curPWE);
                                    if (LDamagedService.SearchService(curPWE.Name) != null) LDamagedService.Delete(curPWE);
                                    richTextBox2.AppendText(curPWE.Name + " - Broken both source ports: " + SrsInterfaceWork + "\n");
                                }
                            }
                            else
                            if ((SrsInterfaceWork == item.ToString()) || (SrsInterfaceProt == item.ToString()))
                            {
                                if (LBrokenService.SearchService(curPWE.Name) == null)
                                {
                                    {
                                        LDamagedService.Add(curPWE);
                                        richTextBox2.AppendText(curPWE.Name + " - Broken one of source ports: " + SrsInterfaceWork + "\n");
                                    }
                                }
                            }


                            if (SnkInterfaceWork == item.ToString())
                            {
                                {
                                    LBrokenService.Add(curPWE);
                                    LDamagedService.Delete(curPWE);
                                    richTextBox2.AppendText(curPWE.Name + " - Broken sink   port: " + SnkInterfaceWork + "\n");
                                }
                            }
                            foreach (string tnl in curPWE.WorkTunnels)
                            {
                                SearchTunnel = LBrokenTunnels.SearchTunnel(tnl);
                                if (SearchTunnel != null)
                                {
                                    BrokenWorkTunnel = true;
                                    richTextBox2.AppendText("\t\t\t" + curPWE.Name + " - Broken work tunnel: " + tnl + "\n");
                                }
                            }
                            foreach (string tnl in curPWE.ProtTunnels)
                            {
                                SearchTunnel = LBrokenTunnels.SearchTunnel(tnl);
                                if (SearchTunnel != null)
                                {
                                    BrokenProtTunnel = true;
                                    richTextBox2.AppendText("\t\t\t" + curPWE.Name + " - Broken prot tunnel: " + tnl + "\n");
                                }
                            }
                            if (BrokenWorkTunnel && BrokenProtTunnel)
                                {
//                                if (LBrokenService.SearchService(curPWE.Name) == null)
                                    LBrokenService.Add(curPWE);
//                                if (LDamagedService.SearchService(curPWE.Name) != null)
                                    LDamagedService.Delete(curPWE);
                                    richTextBox2.AppendText(curPWE.Name + " - Both ways the tunnels are broken\n");
                            }
                            else
                            {
                                if (BrokenWorkTunnel || BrokenProtTunnel)
                                {
                                    if (LBrokenService.SearchService(curPWE.Name) == null)
                                    {
//                                        if (LDamagedService.SearchService(curPWE.Name) == null)
                                            LDamagedService.Add(curPWE);
                                        richTextBox2.AppendText(curPWE.Name + " - One way tunnels are broken\n");
                                    }
                                }

                            }
                            BrokenWorkTunnel = false;
                            BrokenProtTunnel = false;

                        }
                        break;

                    case "PW APS (single source and dual sink)":
//                        richTextBox2.AppendText("PW APS (single source and dual sink)\n");
                        SrsInterfaceWork = curPWE.SrcInterfaceWork.NEName + "-" + curPWE.SrcInterfaceWork.SlotPort;
                        SnkInterfaceWork = curPWE.SnkInterfaceWork.NEName + "-" + curPWE.SnkInterfaceWork.SlotPort;
                        SnkInterfaceProt = curPWE.SnkInterfaceProt.NEName + "-" + curPWE.SnkInterfaceProt.SlotPort;
                        foreach (object item in listBoxBrokenPorts.Items)
                        {
                            if ((SnkInterfaceWork == item.ToString()) && (SnkInterfaceProt == item.ToString()))
                            {
                                if ((LBrokenService.SearchService(curPWE.Name) == null))
                                {
                                    LBrokenService.Add(curPWE);
                                    LDamagedService.Delete(curPWE);
                                    richTextBox2.AppendText(curPWE.Name + " - Broken both sink ports: " + SnkInterfaceWork + "\n");
                                }
                            }
                            else
                            if ((SnkInterfaceWork == item.ToString()) || (SnkInterfaceProt == item.ToString()))
                            {
                                if (LBrokenService.SearchService(curPWE.Name) == null)
                                {
                                    if (LDamagedService.SearchService(curPWE.Name) == null)
                                    {
                                        LDamagedService.Add(curPWE);
                                        richTextBox2.AppendText(curPWE.Name + " - Broken one of sink ports: " + SnkInterfaceWork + "\n");
                                    }
                                }
                            }


                            if (SrsInterfaceWork == item.ToString())
                            {
                                if (LBrokenService.SearchService(curPWE.Name) == null)
                                {
                                    LBrokenService.Add(curPWE);
                                    LDamagedService.Delete(curPWE);
                                    richTextBox2.AppendText(curPWE.Name + " - Broken source  port: " + SrsInterfaceWork + "\n");
                                }
                            }
                            foreach (string tnl in curPWE.WorkTunnels)
                            {
                                SearchTunnel = LBrokenTunnels.SearchTunnel(tnl);
                                if (SearchTunnel != null)
                                {
                                    BrokenWorkTunnel = true;
                                    richTextBox2.AppendText("\t\t\t" + curPWE.Name + " - Broken work tunnel: " + tnl + "\n");
                                }
                            }
                            foreach (string tnl in curPWE.ProtTunnels)
                            {
                                SearchTunnel = LBrokenTunnels.SearchTunnel(tnl);
                                if (SearchTunnel != null)
                                {
                                    BrokenProtTunnel = true;
                                    richTextBox2.AppendText("\t\t\t" + curPWE.Name + " - Broken prot tunnel: " + tnl + "\n");
                                }
                            }
                            if (BrokenWorkTunnel && BrokenProtTunnel)
                            {
                                LBrokenService.Add(curPWE);
                                LDamagedService.Delete(curPWE);
                                richTextBox2.AppendText(curPWE.Name + " - Both ways the tunnels are broken\n");
                            }
                            else
                            {
                                if (BrokenWorkTunnel || BrokenProtTunnel)
                                {
                                    if (LBrokenService.SearchService(curPWE.Name) == null)
                                    {
                                        LDamagedService.Add(curPWE);
                                        richTextBox2.AppendText(curPWE.Name + " - One way tunnels are broken\n");
                                    }
                                }

                            }

                            BrokenWorkTunnel = false;
                            BrokenProtTunnel = false;
                        }
                        break;
                    default:
                        richTextBox2.AppendText("\t\t\t\tPW APS ERROR - " + curPWE.ServiceType + "\n");
                        break;

                }
                curPWE = curPWE.Next;
                i++;
                label1.Text = i.ToString();

            }// while Service

            curTime = DateTime.Now;
            str = curTime.ToLocalTime().ToString() + "\n";
            richTextBox2.AppendText("End calculate: " + str);
            richTextBox2.ScrollToCaret();

            listBoxDamagedService.Items.Clear();
            listBoxBrokenService.Items.Clear();
            curPWE = LDamagedService.Head;
            while (curPWE != null)
            {
                listBoxDamagedService.Items.Add(curPWE.Name);
                curPWE = curPWE.Next;
            }
            curPWE = LBrokenService.Head;
            while (curPWE != null)
            {
                listBoxBrokenService.Items.Add(curPWE.Name);
                curPWE = curPWE.Next;
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxDamagedService.SelectedItems.Count)
            {
                item = listBoxDamagedService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxDamagedFix.Items.Add(item.ToString());
                    listBoxDamagedService.Items.Remove(item);
                }
                else i++;
            }
            labelDamagedFix.Text = "Fix: " + listBoxDamagedFix.Items.Count.ToString();
        }

        private void buttonAddFixSrv_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while(i < listBoxBrokenService.SelectedItems.Count)
            {
                item = listBoxBrokenService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxBrokenFix.Items.Add(item.ToString());
                    listBoxBrokenService.Items.Remove(item);
                }
                else i++;
            }
            labelBrokenFix.Text = "Fix: " + listBoxBrokenFix.Items.Count.ToString();
        }

        private void buttonAddService2G_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxBrokenService.SelectedItems.Count)
            {
                item = listBoxBrokenService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxBrokenBS.Items.Add(item.ToString());
                    c2gBroken++;
                    listBoxBrokenService.Items.Remove(item);
                }
                else i++;
            }
            labelBrokenMobile.Text = "2G - " + c2gBroken.ToString() + ",\t 3G - " + c3GBroken.ToString() + ",\t LTE - " + c4GBroken.ToString();

        }

        private void buttonAddService2GDamaged_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxDamagedService.SelectedItems.Count)
            {
                item = listBoxDamagedService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxDamagedBS.Items.Add(item.ToString());
                    c2gDamaged++;
                    listBoxDamagedService.Items.Remove(item);
                }
                else i++;
            }
            labelDamagedMobile.Text = "2G - " + c2gDamaged.ToString() + ",\t 3G - " + c3GDamaged.ToString() + ",\t LTE - " + c4GDamaged.ToString();

        }

        private void buttonAddService3GDamaged_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxDamagedService.SelectedItems.Count)
            {
                item = listBoxDamagedService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxDamagedBS.Items.Add(item.ToString());
                    c3GDamaged++;
                    listBoxDamagedService.Items.Remove(item);
                }
                else i++;
            }
            labelDamagedMobile.Text = "2G - " + c2gDamaged.ToString() + ",\t 3G - " + c3GDamaged.ToString() + ",\t LTE - " + c4GDamaged.ToString();

        }

        private void buttonAddService4GDamaged_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxDamagedService.SelectedItems.Count)
            {
                item = listBoxDamagedService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxDamagedBS.Items.Add(item.ToString());
                    c4GDamaged++;
                    listBoxDamagedService.Items.Remove(item);
                }
                else i++;
            }
            labelDamagedMobile.Text = "2G - " + c2gDamaged.ToString() + ",\t 3G - " + c3GDamaged.ToString() + ",\t LTE - " + c4GDamaged.ToString();

        }

        private void buttonAddServiceInterDamaged_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxDamagedService.SelectedItems.Count)
            {
                item = listBoxDamagedService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxDamagedInter.Items.Add(item.ToString());
                    listBoxDamagedService.Items.Remove(item);
                }
                else i++;
            }
            labelDamagedInter.Text = "Fix: " + listBoxDamagedInter.Items.Count.ToString();

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp;
            Excel.Sheets sheet;
            Excel.Range cell;
            int i = 0, ii = 0, numSheets = 0, curSheet = 1;

            excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Can not open MS Excel");
                return;
            }
            excelApp.Visible = true;
            if ((listBoxBrokenBS.Items.Count > 0) || (listBoxDamagedBS.Items.Count > 0)) numSheets++;
            if (listBoxBrokenFix.Items.Count > 0) numSheets++;
            if (listBoxDamagedFix.Items.Count > 0) numSheets++;
            if ((listBoxBrokenInter.Items.Count > 0) || (listBoxDamagedInter.Items.Count > 0)) numSheets++;
            if ((listBoxDamagedVPLS.Items.Count > 0) || (listBoxBrokenVPLS.Items.Count > 0)) numSheets++;


            excelApp.SheetsInNewWorkbook = numSheets;
            excelApp.Workbooks.Add();

            /*            excelApp.Worksheets[1].Name = "Гарантированный ущерб БС";
                        excelApp.Worksheets[2].Name = "Гарантированный ущерб ШПД";
                        excelApp.Worksheets[3].Name = "Гарантированный ущерб внутр";
                        excelApp.Worksheets[4].Name = "Потенциальный ущерб БС";
                        excelApp.Worksheets[5].Name = "Потенциальный ущерб ШПД";
                        excelApp.Worksheets[6].Name = "Потенциальный ущерб внутр";
            */
            if ((listBoxBrokenBS.Items.Count > 0) || (listBoxDamagedBS.Items.Count > 0))
            {
                excelApp.Worksheets[curSheet].Name = "Ущерб БС";
                if (listBoxBrokenBS.Items.Count > 0)
                {
                    excelApp.Worksheets[curSheet].Cells[1, 2] = "Гарантированный ущерб";
                    excelApp.Worksheets[curSheet].Cells[2, 2] = "2G - " + c2gBroken.ToString() + ", 3G - " + c3GBroken.ToString() + ", LTE - " + c4GBroken.ToString();

                    for (i = 0; i < listBoxBrokenBS.Items.Count; i++)
                    {
                        excelApp.Worksheets[1].Cells[i + 4, 2] = listBoxBrokenBS.Items[i].ToString();
                    }
                    ii = i + 5;
                }

                if (listBoxDamagedBS.Items.Count > 0)
                {
                    excelApp.Worksheets[curSheet].Cells[ii + 1, 2] = "Потенциальный ущерб";
                    excelApp.Worksheets[curSheet].Cells[ii + 2, 2] = "2G - " + c2gDamaged.ToString() + ", 3G - " + c3GDamaged.ToString() + ", LTE - " + c4GDamaged.ToString();
                    for (i = 0; i < listBoxDamagedBS.Items.Count; i++)
                    {
                        excelApp.Worksheets[curSheet].Cells[ii + i + 4, 2] = listBoxDamagedBS.Items[i].ToString();
                    }
                }
                curSheet++;
            }
            ii = 0;

            if (listBoxBrokenFix.Items.Count > 0)
            {
                excelApp.Worksheets[curSheet].Name = "Ущерб ШПД гарант";

                for (i = 0; i < listBoxBrokenFix.Items.Count; i++)
                {
                    excelApp.Worksheets[curSheet].Cells[i + 3, 2] = listBoxBrokenFix.Items[i].ToString();
                }
            curSheet++;
            }

            if (listBoxDamagedFix.Items.Count > 0)
            {
                excelApp.Worksheets[curSheet].Name = "Ущерб ШПД потенц";
                for (i = 0; i < listBoxDamagedFix.Items.Count; i++)
                {
                    excelApp.Worksheets[curSheet].Cells[i + 3, 2] = listBoxDamagedFix.Items[i].ToString();
                }
            curSheet++;
            }

            if ((listBoxBrokenInter.Items.Count > 0) || (listBoxDamagedInter.Items.Count > 0))
            {
                excelApp.Worksheets[curSheet].Name = "Ущерб внутренний";
                if (listBoxBrokenInter.Items.Count > 0)
                {
                    excelApp.Worksheets[curSheet].Cells[1, 2] = "Гарантированный ущерб";

                    for (i = 0; i < listBoxBrokenInter.Items.Count; i++)
                    {
                        excelApp.Worksheets[curSheet].Cells[i + 3, 2] = listBoxBrokenInter.Items[i].ToString();
                    }
                    ii = i + 4;
                }

                if (listBoxDamagedInter.Items.Count > 0)
                {
                    excelApp.Worksheets[curSheet].Cells[ii + 1, 2] = "Потенциальный ущерб";
                    for (i = 0; i < listBoxDamagedInter.Items.Count; i++)
                    {
                        excelApp.Worksheets[curSheet].Cells[ii + i + 3, 2] = listBoxDamagedInter.Items[i].ToString();
                    }
                }
                curSheet++;
            }
            ii = 0;
            if ((listBoxBrokenVPLS.Items.Count > 0) || (listBoxDamagedVPLS.Items.Count > 0))
            {
                excelApp.Worksheets[curSheet].Name = "Ущерб VPLS";
                if (listBoxBrokenVPLS.Items.Count > 0)
                {
                    excelApp.Worksheets[curSheet].Cells[1, 2] = "Гарантированный ущерб";

                    for (i = 0; i < listBoxBrokenVPLS.Items.Count; i++)
                    {
                        excelApp.Worksheets[curSheet].Cells[i + 3, 2] = listBoxBrokenVPLS.Items[i].ToString();
                    }
                    ii = i + 4;
                }

                if (listBoxDamagedVPLS.Items.Count > 0)
                {
                    excelApp.Worksheets[curSheet].Cells[ii + 1, 2] = "Потенциальный ущерб";
                    for (i = 0; i < listBoxDamagedVPLS.Items.Count; i++)
                    {
                        excelApp.Worksheets[curSheet].Cells[ii + i + 3, 2] = listBoxDamagedVPLS.Items[i].ToString();
                    }
                }
            }






        }

        private void buttonSaveFilter_Click(object sender, EventArgs e)
        {
            string filename = "";
            //            saveFileDialog1.InitialDirectory = @"D:\code\Data\";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                filename = Path.GetDirectoryName(saveFileDialog1.FileName) + "\\" + filename + ".ftr";
                using (StreamWriter strWr = new StreamWriter(filename))
                {
                    strWr.WriteLine(textBoxBrokenFix.Text.ToString());
                    strWr.WriteLine(textBoxBrokenBS.Text);
                    strWr.WriteLine(textBoxBrokenInter.Text);
                }
            }


        }

        private void buttonLoadFilter_Click(object sender, EventArgs e)
        {
            string filename = "";
            //            saveFileDialog1.InitialDirectory = @"D:\code\Data\";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                filename = Path.GetDirectoryName(openFileDialog1.FileName) + "\\" + filename + ".ftr";
                using (StreamReader strRead = new StreamReader(filename))
                {
                    textBoxBrokenFix.Text = strRead.ReadLine();
                    textBoxBrokenBS.Text = strRead.ReadLine();
                    textBoxBrokenInter.Text = strRead.ReadLine();
                }
            }

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void buttonCalculateVPLS_Click(object sender, EventArgs e)
        {
            int i = 1, tabs;
            string[] strArr;
            string nameVPLS = "";
            foreach (string str in richTextBoxVPLS.Lines)
            {
                tabs = 0;
                strArr = str.Split('\t');
                foreach (string splitStr in strArr)
                    if (splitStr != "") tabs++;
                if (tabs == 7) nameVPLS = strArr[0];
                else if ((tabs == 17) || (tabs == 21))
                {
                    if (LBrokenTunnels.SearchTunnel(strArr[14]) != null)
                    {
                        listBoxBrokenVPLS.Items.Add(nameVPLS + " in direction " + strArr[4] + " --- " + strArr[5]);

                    }
                    if (LDamagedTunnels.SearchTunnel(strArr[14]) != null)
                    {
                        listBoxDamagedVPLS.Items.Add(nameVPLS + " in direction " + strArr[4] + " --- " + strArr[5]);

                    }
                }
                else if (tabs != 0) richTextBox2.AppendText("Error! In VPLS line " + str + " are " + tabs + "Tabs");




                i++;

            }
        }

        private void buttonAddService3G_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxBrokenService.SelectedItems.Count)
            {
                item = listBoxBrokenService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxBrokenBS.Items.Add(item.ToString());
                    c3GBroken++;
                    listBoxBrokenService.Items.Remove(item);
                }
                else i++;
            }
            labelBrokenMobile.Text = "2G - " + c2gBroken.ToString() + ",\t 3G - " + c3GBroken.ToString() + ",\t LTE - " + c4GBroken.ToString();
        }

        private void buttonAddService4G_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxBrokenService.SelectedItems.Count)
            {
                item = listBoxBrokenService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxBrokenBS.Items.Add(item.ToString());
                    c4GBroken++;
                    listBoxBrokenService.Items.Remove(item);
                }
                else i++;
            }
            labelBrokenMobile.Text = "2G - " + c2gBroken.ToString() + ",\t 3G - " + c3GBroken.ToString() + ",\t LTE - " + c4GBroken.ToString();
        }

        private void buttonAddServiceInter_Click(object sender, EventArgs e)
        {
            int i = 0;
            object item;
            while (i < listBoxBrokenService.SelectedItems.Count)
            {
                item = listBoxBrokenService.SelectedItems[i];
                if (item.ToString() != "")
                {
                    listBoxBrokenInter.Items.Add(item.ToString());
                    listBoxBrokenService.Items.Remove(item);
                }
                else i++;
            }
            labelBrokenInter.Text = "Fix: " + listBoxBrokenInter.Items.Count.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            int i = 0;
            string tmpStr = "";
            Service curPWE;
            string[] groups = new string[1];
            groups[0] = "GRP";
            listBoxBrokenFix.Items.Clear();
            listBoxBrokenBS.Items.Clear();
            listBoxBrokenInter.Items.Clear();
            listBoxBrokenService.Items.Clear();
            listBoxDamagedFix.Items.Clear();
            listBoxDamagedBS.Items.Clear();
            listBoxDamagedInter.Items.Clear();
            listBoxDamagedService.Items.Clear();
            c2gBroken = 0;
            c3GBroken = 0;
            c4GBroken = 0;
            c2gDamaged = 0;
            c3GDamaged = 0;
            c4GDamaged = 0;

            curPWE = LDamagedService.Head;
            while (curPWE != null)
            {
                listBoxDamagedService.Items.Add(curPWE.Name);
                curPWE = curPWE.Next;
            }
            curPWE = LBrokenService.Head;
            while (curPWE != null)
            {
                listBoxBrokenService.Items.Add(curPWE.Name);
                curPWE = curPWE.Next;
            }

            foreach (object line in richTextBoxBrokenExternal.Lines)
            {
                if (line.ToString() != "")
                    listBoxBrokenService.Items.Add(line.ToString());
            }

            foreach (object line in richTextBoxDamagedExternal.Lines)
            {
                if (line.ToString() != "")
                    listBoxDamagedService.Items.Add(line.ToString());
            }

            object item;
            while (i < listBoxBrokenService.Items.Count)
            {
                item = listBoxBrokenService.Items[i];
                string[] result = TextParse(item.ToString(), textBoxBrokenFix.Text, groups);
                if ((result[0] != null) && (result[0] != ""))
                {
                    listBoxBrokenFix.Items.Add(result[0]);
                    listBoxBrokenService.Items.Remove(item);
                }
                else i++;
                if (result[0] == "Regular error") break;
            }
            labelBrokenFix.Text = "Fix: " + listBoxBrokenFix.Items.Count.ToString();

            i = 0;
            while (i < listBoxDamagedService.Items.Count)
            {
                item = listBoxDamagedService.Items[i];
                string[] result = TextParse(item.ToString(), textBoxBrokenFix.Text, groups);
                if ((result[0] != null) && (result[0] != ""))
                {
                    listBoxDamagedFix.Items.Add(result[0]);
                    listBoxDamagedService.Items.Remove(item);
                }
                else i++;
                if (result[0] == "Regular error") break;
            }
            labelDamagedFix.Text = "Fix: " + listBoxDamagedFix.Items.Count.ToString();

            i = 0;
            string[] groupsBS = new string[3];
            bool added = false;
            groupsBS[0] = "g2G";
            groupsBS[1] = "g3G";
            groupsBS[2] = "g4G";
            while (i < listBoxBrokenService.Items.Count)
            {
                item = listBoxBrokenService.Items[i];
                string[] result = TextParse(item.ToString(), textBoxBrokenBS.Text, groupsBS);
                if ((result[0] != null) && (result[0] != ""))
                {
                    listBoxBrokenBS.Items.Add(result[0]);
                    c2gBroken++;
                    listBoxBrokenService.Items.Remove(item);
                    added = true;
                }
                if ((result[1] != null) && (result[1] != ""))
                {
                    listBoxBrokenBS.Items.Add(result[1]);
                    c3GBroken++;
                    listBoxBrokenService.Items.Remove(item);
                    added = true;
                }
                if ((result[2] != null) && (result[2] != ""))
                {
                    listBoxBrokenBS.Items.Add(result[2]);
                    listBoxBrokenService.Items.Remove(item);
                    added = true;
                    c4GBroken++;
                }
                labelBrokenMobile.Text = "2G - " + c2gBroken.ToString() +",\t 3G - " + c3GBroken.ToString() + ",\t LTE - " + c4GBroken.ToString();
                if (!added)
                {
                    i++;
                }
                added = false;

                if (result[0] == "Regular error") break;
            }
            i = 0;

            while (i < listBoxDamagedService.Items.Count)
            {
                item = listBoxDamagedService.Items[i];
                string[] result = TextParse(item.ToString(), textBoxBrokenBS.Text, groupsBS);
                if ((result[0] != null) && (result[0] != ""))
                {
                    listBoxDamagedBS.Items.Add(result[0]);
                    c2gDamaged++;
                    listBoxDamagedService.Items.Remove(item);
                    added = true;
                }
                if ((result[1] != null) && (result[1] != ""))
                {
                    listBoxDamagedBS.Items.Add(result[1]);
                    c3GDamaged++;
                    listBoxDamagedService.Items.Remove(item);
                    added = true;
                }
                if ((result[2] != null) && (result[2] != ""))
                {
                    listBoxDamagedBS.Items.Add(result[2]);
                    listBoxDamagedService.Items.Remove(item);
                    added = true;
                    c4GDamaged++;
                }
                labelDamagedMobile.Text = "2G - " + c2gDamaged.ToString() + ",\t 3G - " + c3GDamaged.ToString() + ",\t LTE - " + c4GDamaged.ToString();
                if (!added)
                {
                    i++;
                }
                added = false;

                if (result[0] == "Regular error") break;
            }
            i = 0;



            while (i < listBoxBrokenService.Items.Count)
            {
                item = listBoxBrokenService.Items[i];
                string[] result = TextParse(item.ToString(), textBoxBrokenInter.Text, groups);
                if ((result[0] != null) && (result[0] != ""))
                {
                    listBoxBrokenInter.Items.Add(result[0]);
                    listBoxBrokenService.Items.Remove(item);
                }
                else i++;
                if (result[0] == "Regular error") break;
            }
            labelBrokenInter.Text = "Inter: " + listBoxBrokenInter.Items.Count.ToString();

            while (i < listBoxDamagedService.Items.Count)
            {
                item = listBoxDamagedService.Items[i];
                string[] result = TextParse(item.ToString(), textBoxBrokenInter.Text, groups);
                if ((result[0] != null) && (result[0] != ""))
                {
                    listBoxDamagedInter.Items.Add(result[0]);
                    listBoxDamagedService.Items.Remove(item);
                }
                else i++;
                if (result[0] == "Regular error") break;
            }
            labelDamagedInter.Text = "Inter: " + listBoxDamagedInter.Items.Count.ToString();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        void FillComboBoxNEName()
        {
            NE cursor = LNE.Head;
            comboBoxNEName.Items.Clear();
            while (cursor != null)
            {
                comboBoxNEName.Items.Add(cursor.NEName);
                cursor = cursor.Next;
            }
            comboBoxNEName.Sorted = true;
            richTextBox2.AppendText("Number of loaded NEs - " + comboBoxNEName.Items.Count.ToString() + "\n");
            richTextBox2.ScrollToCaret();


        }

        void AddBrokenPort(string _nE, string _sp)
        {
            NE cursor = LBrokenPorts.AddNE(_nE);
            if (cursor != null)
            {
                cursor.AddSlotPort(_sp);
            }
            ShowBrokenPorts();
        }

        void ShowBrokenPorts()
        {
            NE cursor = LBrokenPorts.Head;
            listBoxBrokenPorts.Sorted = true;
            if (cursor == null)
            {
                listBoxBrokenPorts.Items.Clear();
                return;
            }
            listBoxBrokenPorts.Items.Clear();
            while (cursor != null)
            {
                if (cursor.SlotPorts != null)
                {
                    foreach (SlotPort sp in cursor.SlotPorts)
                    {
                        listBoxBrokenPorts.Items.Add(cursor.NEName + "-" + sp.Slot_Port);
                    }
                    cursor = cursor.Next;
                }
            }
        }

        string[] TextParse(string str, string pat, string[] groups)
        {
            string[] found = new string[groups.Count()];
            try
            {
                Regex reg1 = new Regex(pat);
                Match match1 = reg1.Match(str);


                int i;
                for (i = 0; i < groups.Count(); i++)
                {
                    found[i] = match1.Groups[groups[i]].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Regular error: " + ex.Message);
                found[0] = "Regular error";
            }
            return found;
        }


    }
}
