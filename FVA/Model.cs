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
    public partial class Model : Plantilla
    {
        public Model()
        {
            InitializeComponent();
        }
        Sbml mysbml;
        private void Model_Load(object sender, EventArgs e)
        {
            Read read = new Read();


            mysbml = Principal.mysbml;

            foreach (Reaction aux in mysbml.ListReaction)
            {
                string[] row = new string[4] { aux.Name, aux.LowerBound.ToString(), aux.UpperBound.ToString(), aux.IsExchange().ToString() };

                ListViewItem list = new ListViewItem(row);

                listView2.Items.Add(list);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Index)
            {
                case 0:
                    {
                        listView1.Size = new System.Drawing.Size(366, 330);
                        groupBox2.Visible = false;
                        textBox1.Visible = false;
                        label10.Visible = false;
                        textBox1.Clear();
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        label1.Text = mysbml.IdModel;
                        label2.Text = mysbml.NameModel;
                        label3.Text = mysbml.Compartiment.Length.ToString();
                        label4.Text = mysbml.ListSpecie.Length.ToString();
                        label5.Text = mysbml.ListReaction.Length.ToString();
                        label6.Text = mysbml.CountReactionExchange().ToString();
                        label7.Text = mysbml.StoichiometryNonZero().ToString() + " Non Zero";
                        label8.Text = mysbml.SbmlLevel;
                        label9.Text = mysbml.SbmlVersion;
                        listView1.Visible = false;
                        groupBox4.Text = "";
                        break;
                    }
                case 1:
                    {
                        listView1.Size = new System.Drawing.Size(366, 330);
                        groupBox2.Visible = false;
                        label10.Visible = true;
                        textBox1.Visible = true;
                        textBox1.Clear();
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        listView1.Visible = true;
                        listView1.Columns.Add("Id", 350);

                        foreach (string aux in mysbml.Compartiment)
                        {
                            string[] row = new string[1] { aux };

                            ListViewItem list = new ListViewItem(row);

                            listView1.Items.Add(list);
                        }
                        groupBox4.Text = "Compartiments ids";
                        break;
                    }
                case 2:
                    {
                        listView1.Size = new System.Drawing.Size(366, 330);
                        groupBox2.Visible = false;
                        label10.Visible = true;
                        textBox1.Visible = true;
                        textBox1.Clear();
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        listView1.Visible = true;
                        listView1.Columns.Add("Id", 100);
                        listView1.Columns.Add("Name", 200);

                        foreach (Specie aux in mysbml.ListSpecie)
                        {
                            string[] row = new string[2] { aux.Id, aux.Name };

                            ListViewItem list = new ListViewItem(row);

                            listView1.Items.Add(list);
                        }

                        groupBox4.Text = "Species Id and Name";
                        break;
                    }
                case 3:
                    {
                        listView1.Size = new System.Drawing.Size(366, 232);
                        groupBox2.Visible = true;
                        label10.Visible = true;
                        textBox1.Visible = true;
                        textBox1.Clear();
                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        listView1.Visible = true;
                        listView1.Columns.Add("Id", 100);
                        listView1.Columns.Add("Name", 220);

                        foreach (Reaction aux in mysbml.ListReaction)
                        {
                            string[] row = new string[2] { aux.Id, aux.Name };

                            ListViewItem list = new ListViewItem(row);

                            listView1.Items.Add(list);
                        }

                        groupBox4.Text = "Reactions Id and Name";
                        break;
                    }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string aux2 = textBox1.Text;

            if (!char.IsControl(e.KeyChar))
            {
                aux2 += e.KeyChar;
            }
            else
            {
                if (textBox1.Text.Length >= 1)
                {
                    aux2 = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }

            }

            switch (treeView1.SelectedNode.Index)
            {

                case 1:
                    {


                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        listView1.Visible = true;
                        listView1.Columns.Add("Id", 350);

                        foreach (string aux in mysbml.Compartiment)
                        {
                            if (Coinciden(aux2, aux))
                            {
                                string[] row = new string[1] { aux };

                                ListViewItem list = new ListViewItem(row);

                                listView1.Items.Add(list);
                            }

                        }
                        break;
                    }
                case 2:
                    {

                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        listView1.Visible = true;
                        listView1.Columns.Add("Id", 100);
                        listView1.Columns.Add("Name", 200);

                        foreach (Specie aux in mysbml.ListSpecie)
                        {
                            if (Coinciden(aux2, aux.Id))
                            {
                                string[] row = new string[2] { aux.Id, aux.Name };

                                ListViewItem list = new ListViewItem(row);

                                listView1.Items.Add(list);
                            }
                        }
                        break;
                    }
                case 3:
                    {

                        listView1.Columns.Clear();
                        listView1.Items.Clear();
                        listView1.Visible = true;
                        listView1.Columns.Add("Id", 100);
                        listView1.Columns.Add("Name", 220);

                        foreach (Reaction aux in mysbml.ListReaction)
                        {
                            if (Coinciden(aux2, aux.Id))
                            {
                                string[] row = new string[2] { aux.Id, aux.Name };

                                ListViewItem list = new ListViewItem(row);

                                listView1.Items.Add(list);
                            }
                        }


                        break;
                    }
            }
        }
        public bool Coinciden(string a, string b)
        {
            if (a.Length <= b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {


                    if (a[i] != b[i])
                    {
                        return false;
                    }

                }
                return true;
            }
            else
            {
                return false;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            listView2.Items.Clear();
            string aux2 = textBox2.Text;

            if (!char.IsControl(e.KeyChar))
            {
                aux2 += e.KeyChar;
            }
            else
            {
                if (textBox2.Text.Length >= 1)
                {
                    aux2 = textBox2.Text.Remove(textBox2.Text.Length - 1);
                }

            }
            foreach (Reaction aux in mysbml.ListReaction)
            {
                if (Coinciden(aux2, aux.Name))
                {
                    string[] row = new string[4] { aux.Name, aux.LowerBound.ToString(), aux.UpperBound.ToString(), aux.IsExchange().ToString() };

                    ListViewItem list = new ListViewItem(row);

                    listView2.Items.Add(list);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void lbtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-' || char.IsControl(e.KeyChar) || e.KeyChar == '.')
            {

                if (e.KeyChar == '-')
                {
                    if (revtext.Text == "False")
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ubtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-' || char.IsControl(e.KeyChar) || e.KeyChar == '.')
            {

                if (e.KeyChar == '-')
                {
                    if (revtext.Text == "False")
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string aux = "";

            if (listView1.SelectedIndices.Count > 0)
            {
                aux = listView1.Items[listView1.SelectedIndices[0]].Text;
            }
            if (aux != "")
            {
                foreach (Reaction reaction in mysbml.ListReaction)
                {
                    if (reaction.Id.ToLower() == aux)
                    {
                        reaction.LowerBound = double.Parse(lbtext.Text, CultureInfo.InvariantCulture.NumberFormat);
                        reaction.UpperBound = double.Parse(ubtext.Text, CultureInfo.InvariantCulture.NumberFormat);
                        if (!Principal.txt)
                        {
                            Read read = new Read();
                            read.ActualizarRestricciones(Principal.doc, aux, lbtext.Text, ubtext.Text);
                        }
                        Principal.mysbml = mysbml;
                        MessageBox.Show("Update!!!!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select the reaction to be configured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Model_FormClosing(object sender, FormClosingEventArgs e)
        {
            Principal.abierto = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            revtext.Text = "";
            lbtext.Text = "";
            ubtext.Text = "";

            string aux = "";

            if (listView1.SelectedIndices.Count > 0)
            {
                aux = listView1.Items[listView1.SelectedIndices[0]].Text;
            }
            if (aux != "")
            {
                foreach (Reaction reaction in mysbml.ListReaction)
                {
                    if (reaction.Id.ToLower() == aux)
                    {
                        revtext.Text = reaction.Reversible.ToString();
                        lbtext.Text = reaction.LowerBound.ToString();
                        ubtext.Text = reaction.UpperBound.ToString();
                    }
                }
            }
        }
    }
}
