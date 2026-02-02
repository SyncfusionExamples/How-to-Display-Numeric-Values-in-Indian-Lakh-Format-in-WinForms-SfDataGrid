using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;

            // Define columns
            var column1 = new GridNumericColumn
            {
                MappingName = nameof(OrderRow.QtyCheck),
                HeaderText = "QtyCheck (Default)",
                FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Numeric
            };

            var column2 = new GridNumericColumn
            {
                MappingName = nameof(OrderRow.OrdrValChk),
                HeaderText = "OrdrValChk (Lakh Format)",
                FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Numeric
            };

            var plainFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            plainFormat.NumberDecimalDigits = 0;
            plainFormat.NumberGroupSeparator = "";
            plainFormat.NumberGroupSizes = new int[] { };
            column1.NumberFormatInfo = plainFormat;

            //Lakh formatting
            var inrFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            inrFormat.NumberDecimalDigits = 0;
            inrFormat.NumberGroupSeparator = ",";
            inrFormat.NumberGroupSizes = new[] { 3, 2 };
            column2.NumberFormatInfo = inrFormat;

            sfDataGrid1.Columns.Add(column1);
            sfDataGrid1.Columns.Add(column2);

            // Bind sample data
            sfDataGrid1.DataSource = GetSampleData();
        }
        private BindingList<OrderRow> GetSampleData()
        {
            return new BindingList<OrderRow>(new List<OrderRow>
            {
                new OrderRow { QtyCheck = 1200000, OrdrValChk = 1200000 },
                new OrderRow { QtyCheck = 9876543, OrdrValChk = 9876543 },
                new OrderRow { QtyCheck = 10000000, OrdrValChk = 10000000 },
                new OrderRow { QtyCheck = 123456789, OrdrValChk = 123456789 },
            });
        }

    }
    public class OrderRow
    {
        public long QtyCheck { get; set; }
        public long OrdrValChk { get; set; }
    }

}
