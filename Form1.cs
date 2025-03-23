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

namespace TpCalculette
{
    public partial class frmCalculette : Form
    {
        private double value = 0;
        private string op = "";
        private bool operation = true;
        private readonly Label lblOperation = new Label();
        private bool isNewOperation = true;
        private string op1 = "";   
        private string historique = "";

        public frmCalculette()
        {
            InitializeComponent();
            this.KeyPress += FrmCalculette_KeyPress;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(265,452); // hada hua ligne dial size d fenetre 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;// hada bach katfixer
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtAffichage.TextAlign = HorizontalAlignment.Right;
            lblOperation.TextAlign = ContentAlignment.TopRight;

            this.Controls.Add(lblOperation);

            this.KeyPreview = true;

            lblOperation.Location = new Point(txtAffichage.Right - lblOperation.Width, txtAffichage.Top - lblOperation.Height - 5);
        }
        private void AjouterChiffre(string chiffre)
        {
            if (operation || isNewOperation)
            {
                txtAffichage.Text = chiffre;
                operation = false;
                isNewOperation = false;
                value = double.Parse(txtAffichage.Text);
            }
            else
            {
                if (txtAffichage.Text == "0" && chiffre != "0")
                {
                    txtAffichage.Text = chiffre;
                }
                else
                {
                    txtAffichage.Text += chiffre;
                }
                value = double.Parse(txtAffichage.Text);
            }
        }
        private void PerformOperation(string newOperator)
        {
            try
            {
                if (!string.IsNullOrEmpty(op1))
                {
                    string expression = op1 + op + txtAffichage.Text;
                    expression = expression.Replace("~", "-");
                    double result = EvaluerExpression(expression, CultureInfo.GetCultureInfo("fr-FR"));
                    txtAffichage.Text = result.ToString();
                    historique += result ;
                    lblOperation.Text =expression;

                    op = newOperator;
                    op1 = txtAffichage.Text;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private double EvaluerExpression(string expression, CultureInfo culture)
        {
            expression = expression.Replace(",", ".");

            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(double), expression);

            DataRow row = table.NewRow();
            table.Rows.Add(row);

            double result = (double)row["expression"];
            return result;
        }
        private void Égale_Click(object sender, EventArgs e)
        {
            PerformOperation("");
       
            op1 = "";
            historique = "";
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            op1 = txtAffichage.Text;
            op = "+";
            operation = true;
        }
        private void soustraction_Click(object sender, EventArgs e)
        {
            op1 = txtAffichage.Text;
            op = "-";
            operation = true;
        }
        private void multiplication_Click(object sender, EventArgs e)
        {
            op1 = txtAffichage.Text;
            op = "*";
            operation = true;
        }
        private void division_Click(object sender, EventArgs e)
        {
            op1 = txtAffichage.Text;
            op = "/";
            operation = true;
        }

        private string op5 = "";
        private void modulo_Click(object sender, EventArgs e)
        {
            try
            {
                op5 = txtAffichage.Text;
                lblOperation.Text = txtAffichage.Text + "/100";
                double percentage = value *0.01;
                txtAffichage.Text = percentage.ToString("F2");
                operation = true;
                isNewOperation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }


        private void frmCalculette_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void btnCalculer_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn0.Text);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn1.Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn2.Text);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn3.Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn4.Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn5.Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn6.Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn7.Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn8.Text);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AjouterChiffre(btn9.Text);
        }


        private void txtAffichage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string c = e.KeyChar.ToString();
            //txtAffichage.Text += c;
        }

        private void txtAffichage_TextChanged(object sender, EventArgs e)
        {

        }

        private void symbole_Click(object sender, EventArgs e)
        {
            try
            {
                double currentValue = double.Parse(txtAffichage.Text);
                double newValue = -currentValue;
                txtAffichage.Text = newValue.ToString();

                operation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void virgule_Click(object sender, EventArgs e)
        {
            txtAffichage.Text += virgule.Text;
        }



        private void égale_Click(object sender, EventArgs e)
        {
            PerformOperation("");
            op1 = "";
            historique = "";
            
        }
        private void racinecarr_Click(object sender, EventArgs e)
        {
            try
            {
                double op1 = double.Parse(txtAffichage.Text);
                if (op1 < 0)
                {
                    MessageBox.Show("Impossible de calculer la racine carrée d'un nombre négatif.");
                    return;
                }

                double result = Math.Sqrt(op1);
                txtAffichage.Text = result.ToString();
                operation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void carrée_Click(object sender, EventArgs e)
        {
            try
            {
                txtAffichage.Text = (Math.Pow(double.Parse(txtAffichage.Text), 2)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void inverse_Click(object sender, EventArgs e)
        {
            try
            {
                double op1 = double.Parse(txtAffichage.Text);

                if (op1 != 0)
                {
                    double inverse = 1 / op1;
                    txtAffichage.Text = inverse.ToString();
                    operation = true;
                }
                else
                {
                    MessageBox.Show("L'inverse de zéro n'est pas défini.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {

            txtAffichage.Text = "0";
            value = 0;
            op = "";
            operation = true;
            isNewOperation = true;
            lblOperation.Text = "";
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            txtAffichage.Text = "0";
            value = 0;
            op = "";
            operation = true;
            isNewOperation = true;
            lblOperation.Text = "";
        }
        private void btnCE_Click_1(object sender, EventArgs e)
        {
            txtAffichage.Text = "0";
            operation = true;
            isNewOperation = true;
            lblOperation.Text = "";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void FrmCalculette_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                AjouterChiffre(e.KeyChar.ToString());
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                PerformOperation("");
                op1 = "";
                historique = "";
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                // Supprimez le dernier chiffre
                if (txtAffichage.Text.Length > 0)
                {
                    txtAffichage.Text = txtAffichage.Text.Substring(0, txtAffichage.Text.Length - 1);
                    value = double.Parse(txtAffichage.Text);
                }

                // Gérez le cas où tout le texte est effacé
                if (string.IsNullOrEmpty(txtAffichage.Text))
                {
                    txtAffichage.Text = "0";
                    value = 0;
                }
            }
            else if (e.KeyChar == '-')
            {
                op1 = txtAffichage.Text;
                op = "-";
                operation = true;
            }
            else if (e.KeyChar == '*')
            {
                op1 = txtAffichage.Text;
                op = "*";
                operation = true;
            }
            else if (e.KeyChar == '/')
            {
                op1 = txtAffichage.Text;
                op = "/";
                operation = true;
            }
            else if (e.KeyChar == '+')
            {
                op1 = txtAffichage.Text;
                op = "+";
                operation = true;
            }
        }


    }
}
   