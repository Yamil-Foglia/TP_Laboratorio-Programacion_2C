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
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numero numeroUno = new Numero(textNumero1.Text);
            Numero numeroDos = new Numero(textNumero2.Text);
            lblResultado.Text = Convert.ToString(Calculadora.Operar(numeroUno, numeroDos, cmbOperador.Text));
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultado.Text = Numero.DecimalBinario(Convert.ToDouble(lblResultado.Text));
            }
            catch
            {
                lblResultado.Text = "Valor invalido";
            }
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        private void Limpiar()
        {
            textNumero1.Text = "";
            textNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = -1;
            
        }
    }
}
