using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace BomGroupper
{
    public partial class BomGroupperRibon
    {
        private void BomGroupperRibon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet asheet = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            ClearOutline(asheet);
            Excel.Range rng = asheet.Range["A2"];
            while (rng.Value2 != null && rng.Value2.Length > 0)
            {

                Excel.Range rng2 = rng.Offset[1, 0];
                int len = rng.Value2.Length;

                int i = 0;
                while (rng2.Value2 != null && len < rng2.Value2.Length) 
                {
                    i++;
                    rng2 = rng2.Offset[1, 0];
                }

                if(i > 0)
                {
                    Excel.Range groupArea = rng.Offset[1, 0].Resize[i, 1];
                    Debug.Print($"Making {groupArea.Address} a group.");
                    groupArea.EntireRow.Group();
                }
                rng = rng.Offset[1, 0];
            }
        }

        private void ClearOutline(Excel.Worksheet sheet)
        {
            Excel.Range usedRng = sheet.UsedRange;
            //string addr = usedRng.Address;
            //Excel.Range ungroupArea = sheet.Range[addr];
            usedRng.EntireRow.ClearOutline();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet asheet = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            ClearOutline(asheet);


        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            DialogResult r = MessageBox.Show
                ("本次操作将会覆盖当前工作表表内所有字体样式，请谨慎操作。依然要继续吗？", 
                "不可逆操作，请确认", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning);

            if (r == DialogResult.Cancel)
            {
                return;
            }
            
            Excel.Worksheet sheet = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            Excel.Range UsedArea = sheet.UsedRange;

            int rows = UsedArea.Rows.Count;



            for (int i = 1; i <= rows; i++)
            {
                Excel.Range targetRow = UsedArea.Rows[i];
                string levelStr = targetRow.Cells[1, 1].Value2 as string;
                if(LevelGenerator.TryParseLevel(levelStr, out int level))
                {
                    double fontSize = 30 - 3 * level;
                    targetRow.Font.Size = fontSize;
                }

            }

        }
    }
}
