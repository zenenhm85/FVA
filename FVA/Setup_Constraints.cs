using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hydra;
using System.Globalization;
namespace FVA
{
    public partial class Setup_Constraints : Plantilla
    {
        public Setup_Constraints()
        {
            InitializeComponent();
        }

        Sbml sbml;
        string valuee = "";
        string objetive = "";

        private void Setup_Constraints_Load(object sender, EventArgs e)
        {
            valuee = "";
            objetive = FVA.objetive;

            sbml = Principal.mysbml;

            dataGridView1.Rows.Clear();

            for (int i = 0; i < sbml.ListReaction.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = sbml.ListReaction[i].Id;
                dataGridView1.Rows[i].Cells[1].Value = sbml.ListReaction[i].Reversible;
                dataGridView1.Rows[i].Cells[2].Value = sbml.ListReaction[i].LowerBound;
                dataGridView1.Rows[i].Cells[3].Value = sbml.ListReaction[i].UpperBound;

            }
        }
        public bool EsNumero(string cadena)
        {

            for (int i = 0; i < cadena.Length; i++)
            {
                if (!char.IsDigit(cadena[i]) && cadena[i] != '.')
                {
                    return false;
                }
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Principal.yaabriconstraint = false;
            FVA fba = new FVA();
            fba.MdiParent = Principal.ActiveForm;
            fba.Show();

            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            Read red = new Read();

            foreach (Reaction item in sbml.ListReaction)
            {
                item.LowerBound = double.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                item.UpperBound = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                if (!Principal.txt)
                {

                    red.ActualizarRestricciones(Principal.doc, item.Id, dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
                }

                i++;

            }

            Principal.mysbml = sbml;


            MessageBox.Show("Update!!!!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView1[0, e.RowIndex].Value.ToString() == objetive)
            {
                e.Cancel = true;
                MessageBox.Show("The objective function must be not configured", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                valuee = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
            {
                if (e.ColumnIndex == 2)
                {
                    char aux = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()[0];

                    if (aux == '-')
                    {
                        if (!EsNumero(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(1)))
                        {
                            dataGridView1[e.ColumnIndex, e.RowIndex].Value = valuee;

                        }
                    }
                    else
                    {
                        if (!EsNumero(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()))
                        {
                            dataGridView1[e.ColumnIndex, e.RowIndex].Value = valuee;

                        }
                    }

                }
                else
                {
                    if (!EsNumero(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()))
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = valuee;

                    }
                }
            }
            else
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = valuee;
            }
        }
    }
}
