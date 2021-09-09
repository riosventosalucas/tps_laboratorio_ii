using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        private string ultimoResultado;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            var cerrar = MessageBox.Show("Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            e.Cancel = (cerrar == DialogResult.No);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.txtNumero1.Text != "" && this.txtNumero2.Text != "")
            {
                string num1 = this.txtNumero1.Text;
                string num2 = this.txtNumero2.Text;
                string oper = this.cmbOperador.Text;
                double resultado;

                Operando n1 = new Operando(num1);
                Operando n2 = new Operando(num2);
                char operador = char.Parse(oper);
               
                resultado = Calculadora.Operar(n1, n2, operador);

                this.lblREsultado.Text = string.Format("{0:.##}", resultado);
                this.lstOperaciones.Items.Add(string.Format("{0} {1} {2} = {3:.##}", num1, operador, num2, resultado));
                this.ultimoResultado = resultado.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text   = "";
            this.txtNumero2.Text   = "";
            this.cmbOperador.Text  = "";
            this.lblREsultado.Text = "";
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!(this.ultimoResultado is null))
            {
                Operando op = new Operando();

                double aux = double.Parse(this.ultimoResultado);
                string numeroBinario = op.DecimalBinario(this.ultimoResultado);

                this.lstOperaciones.Items.Add(string.Format("{0:.##} a binario: {1}", aux, numeroBinario));

                this.ultimoResultado = numeroBinario;

            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando op = new Operando();

            string numeroDecimal = op.BinarioDecimal(this.ultimoResultado);

            this.lstOperaciones.Items.Add(string.Format("{0:.##} a decimal es: {1}", this.ultimoResultado, numeroDecimal));

            this.ultimoResultado = numeroDecimal;
        }
    }
}
