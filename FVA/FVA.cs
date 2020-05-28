using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlpkSharp;
using System.Globalization;
using Hydra;

namespace FVA
{
    public partial class FVA : Plantilla
    {
        public FVA()
        {
            InitializeComponent();
        }

        public static string objetive = "";
        Read readsbml;
        static public Sbml sbml;
        public static MakeFba makefba;
        public static OptimisationDirection pd;
        public static Setup_Constraints sc;

        public static string reactionoptimize;

        static bool results;

        public static int Funcion_obj;
        public static double z;

        public static Fva fva;
        public static string reactionoptimize1;
        public static string reactionoptimize2;


        public static bool Result
        {
            get { return results; }
        }
        private void FVA_Load(object sender, EventArgs e)
        {
            fileTextBox.Text = Principal.FileAddres;

            readsbml = new Read();
            results = false;

            sbml = Principal.mysbml;

            foreach (Reaction item in sbml.ListReaction)
            {
                reactionObjetiveComboBox.Items.Add(item.Id);
                comboconstrain.Items.Add(item.Id);
                reactionObjetiveComboBox2.Items.Add(item.Id);
            }
            foreach (Specie item in sbml.ListSpecie)
            {
                combometabolites.Items.Add(item.Id);
            }
            reactionObjetiveComboBox.Text = Principal.objetivefuntion;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Principal.mod.Close();
            Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (reactionObjetiveComboBox.Text.Length > 0 && reactionObjetiveComboBox2.Text.Length > 0)
            {
                if (Sbml.There(reactionObjetiveComboBox, reactionObjetiveComboBox.Text) && Sbml.There(reactionObjetiveComboBox2, reactionObjetiveComboBox2.Text))
                {
                    makefba = new MakeFba();

                    int i = 0;
                    int j = 0;

                    int ii = 0;
                    int jj = 0;

                    int find = 0;

                    foreach (Reaction item in sbml.ListReaction)
                    {
                        if (item.Id == reactionObjetiveComboBox.Text)
                        {
                            reactionoptimize1 = reactionObjetiveComboBox.Text;

                            find++;

                            ii = i;
                        }
                        if (item.Id == reactionObjetiveComboBox2.Text)
                        {
                            reactionoptimize2 = reactionObjetiveComboBox2.Text;

                            find++;

                            jj = j;
                        }
                        if (find == 2)
                        {
                            break;
                        }

                        j++;
                        i++;
                    }
                    if (find == 2)
                    {


                        if (radiomax.Checked)
                        {
                            pd = OptimisationDirection.MAXIMISE;
                        }
                        else
                        {
                            pd = OptimisationDirection.MINIMISE;
                        }

                        fva = makefba.Fva(sbml, ii, jj, pd);

                        double z1 = fva.Lp1.GetObjectiveValue();
                        double z2 = fva.Lp2.GetObjectiveValue();


                        resultlist.Items.Clear();

                        string[] str = new string[3] { "Z1,Z2", "Z1 = " + z1.ToString(), "Z2 = " + z2.ToString() };


                        ListViewItem list = new ListViewItem(str, 0, Color.Black, Color.YellowGreen, new Font("Arial", 12));


                        resultlist.Items.Add(list);


                        for (int k = 0; k < sbml.ListReaction.Length; k++)
                        {
                            str = new string[3] { sbml.ListReaction[k].Id, fva.Lp1.GetColPrimal(k + 1).ToString(), fva.Lp2.GetColPrimal(k + 1).ToString() };

                            if (fva.Lp1.GetColPrimal(k + 1) == fva.Lp2.GetColPrimal(k + 1))
                            {
                                list = new ListViewItem(str);
                                resultlist.Items.Add(list);
                            }
                            else
                            {
                                list = new ListViewItem(str, 0, Color.Black, Color.YellowGreen, new Font("Arial", 12));
                                resultlist.Items.Add(list);
                            }


                        }
                        results = true;
                        button3.Enabled = true;

                    }
                    else
                    {
                        results = false;
                        button3.Enabled = false;

                        MessageBox.Show("This reaction not exist in the model", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    MessageBox.Show("One of the functions not exist in the model", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Select the functions to optimize", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reactionObjetiveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Reaction item in sbml.ListReaction)
            {
                if (item.Id == reactionObjetiveComboBox.Text)
                {
                    reactionTextBox.Text = item.Id;

                    break;
                }

            }
        }

        private void reactionObjetiveComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Reaction item in sbml.ListReaction)
            {
                if (item.Id == reactionObjetiveComboBox2.Text)
                {
                    textid2.Text  = item.Id;

                    break;
                }

            }
        }

        private void comboconstrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboconstrain.Text != reactionObjetiveComboBox.Text && comboconstrain.Text != reactionObjetiveComboBox2.Text)
            {
                foreach (Reaction item in sbml.ListReaction)
                {
                    if (item.Id == comboconstrain.Text)
                    {
                        lowertextBox1.Text = item.LowerBound.ToString();
                        uppertextBox2.Text = item.UpperBound.ToString();
                        isReversibleTextBox.Text = item.Reversible.ToString();
                        break;
                    }

                }
            }
            else
            {

                DialogResult dr = MessageBox.Show("The objective function not must be configured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (dr == DialogResult.OK)
                {
                    comboconstrain.ResetText();
                    comboconstrain.SelectedIndex = -1;
                }
            }
        }

        private void lowertextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-' || char.IsControl(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (comboconstrain.Text.Length > 0)
            {
                if (Sbml.There(comboconstrain, comboconstrain.Text))
                {
                    if (isReversibleTextBox.Text == "False")
                    {
                        if (double.Parse(lowertextBox1.Text, CultureInfo.InvariantCulture.NumberFormat) < 0)
                        {
                            MessageBox.Show("This reaction is irreversible, the Lower Bound must be less than zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            foreach (Reaction item in sbml.ListReaction)
                            {
                                if (item.Id == comboconstrain.Text)
                                {

                                    item.LowerBound = double.Parse(lowertextBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                                    item.UpperBound = double.Parse(uppertextBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
                                    Principal.mysbml = sbml;
                                    if (!Principal.txt)
                                    {
                                        Read red = new Read();
                                        red.ActualizarRestricciones(Principal.doc, comboconstrain.Text.ToLower(), lowertextBox1.Text, uppertextBox2.Text);
                                    }
                                    MessageBox.Show("Update!!!!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;

                                }

                            }
                        }
                    }
                    else
                    {
                        foreach (Reaction item in sbml.ListReaction)
                        {
                            if (item.Id == comboconstrain.Text)
                            {

                                item.LowerBound = double.Parse(lowertextBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                                item.UpperBound = double.Parse(uppertextBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
                                Principal.mysbml = sbml;
                                if (!Principal.txt)
                                {
                                    Read red = new Read();
                                    red.ActualizarRestricciones(Principal.doc, comboconstrain.Text.ToLower(), lowertextBox1.Text, uppertextBox2.Text);
                                }
                                MessageBox.Show("Update!!!!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not exist a reaction with this name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select the reaction to be configured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics gra = new Graphics();
            gra.MdiParent = Principal.ActiveForm;
            gra.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (combometabolites.Text.Length > 0)
            {
                if (Sbml.There(combometabolites, combometabolites.Text))
                {
                    sbml.AgregaraMetabolitosExternos(combometabolites.Text);
                    if (!Principal.txt)
                    {
                        Read read = new Read();
                        read.ActualizarBoundaryCondition(Principal.doc, combometabolites.Text.ToLower());
                    }
                    // Principal.doc.PreserveWhitespace = true;


                    combometabolites.Items.Remove(combometabolites.Text);
                    Principal.mysbml = sbml;
                    MessageBox.Show("Correctly Converted!!!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("not exist a metabolite with this name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Select the metabolite to be removed of the internal metabolites", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (reactionObjetiveComboBox.Text.Length == 0)
            {
                MessageBox.Show("Select the function to optimize", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Sbml.There(reactionObjetiveComboBox, reactionObjetiveComboBox.Text))
                {
                    Principal.objetivefuntion = reactionObjetiveComboBox.Text;
                    Principal.yaabriconstraint = true;
                    sc = new Setup_Constraints();
                    sc.MdiParent = Principal.ActiveForm;
                    objetive = reactionObjetiveComboBox.Text;
                    this.Close();
                    sc.Show();
                }
                else
                {
                    MessageBox.Show("This reaction not exist in the model", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
