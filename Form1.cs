using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace homework_04
{
    public partial class Form1 : Form
    {
        private DataGridView wordmatrix = new DataGridView();
        private char[][] matrix;
        private bool[][] isin;
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(char[][] matrix,bool[][] isin,bool ans)
        {
            this.matrix = matrix;
            this.isin = isin;
            InitializeComponent();
            //MessageBox.Show("aaa");
            SetupDataGridView();
            PopulateDataGridView();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SetupDataGridView()
        {
            this.Controls.Add(wordmatrix);
            wordmatrix.ColumnCount = matrix[0].Length;
            for (int i = 0; i < matrix[0].Length; i++)
                wordmatrix.Columns[i].Width = 20;
            wordmatrix.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            wordmatrix.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            wordmatrix.ColumnHeadersDefaultCellStyle.Font =
                new Font(wordmatrix.Font, FontStyle.Bold);

            wordmatrix.Name = "songsDataGridView";
            wordmatrix.Location = new Point(8, 8);
            wordmatrix.Size = new Size(20, 20);           
            wordmatrix.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;
            //wordmatrix.ColumnHeadersBorderStyle =
            //DataGridViewHeaderBorderStyle.Single;
            wordmatrix.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            wordmatrix.GridColor = Color.Black;
            wordmatrix.RowHeadersVisible = false;
            wordmatrix.ColumnHeadersVisible = false;


            //wordmatrix.Columns[4].DefaultCellStyle.Font =
            //new Font(wordmatrix.DefaultCellStyle.Font, FontStyle.Italic);

            //wordmatrix.SelectionMode =
            //DataGridViewSelectionMode.FullRowSelect;
            wordmatrix.MultiSelect = false;
            wordmatrix.Dock = DockStyle.Fill;
            //wordmatrix.Visible = false;
            //items[0].KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDetails_KeyPress);
            //wordmatrix.CellFormatting += new
            //    DataGridViewCellFormattingEventHandler(
            //    item_CellFormatting);
            //return items[index];
        }
        private void PopulateDataGridView()
        {
            int row = matrix.Length;
            int column = matrix[0].Length;
            string[] row0 = new string[column];
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < column; j++)
                {
                    row0[j] = matrix[i][j].ToString();
                }
                wordmatrix.Rows.Add(row0);
                for (int j = 0; j < column; j++)
                    if (isin[i][j])
                    {
                        wordmatrix.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                    }
            }
        }
    }
}
