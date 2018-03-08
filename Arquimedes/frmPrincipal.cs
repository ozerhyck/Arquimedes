//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Arquimedes
//{
//    public partial class frmPrincipal : Form
//    {
//        public frmPrincipal()
//        {
//            InitializeComponent();
//        }

//        private void frmPrincipal_Load(object sender, EventArgs e)
//        {

//        }

//        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
//            {
//                e.Handled = true;
//            }
//            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(':') > -1))
//            {
//                e.Handled = true;
//                MessageBox.Show("este campo aceita somente uma virgula");
//            }
//        }

//        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
//            {
//                e.Handled = true;
//                MessageBox.Show("este campo aceita somente numero e virgula");
//            }
//            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
//            {
//                e.Handled = true;
//                MessageBox.Show("este campo aceita somente uma virgula");
//            }
//        }

//        private void textBox2_TextChanged(object sender, EventArgs e)
//        {
//            if (TextBox1.Text == string.Empty)
//            {
//                return;
//            }

//            string hora1 = String.Format(@"{000:00}", TextBox1.Text);
//            decimal HoraLimite = Convert.ToDecimal(Convert.ToDecimal(hora1.Split(':')[0]) + Convert.ToDecimal(TimeSpan.Parse("00:" + hora1.Split(':')[1]).TotalHours));

//            string hora2 = String.Format(@"{000:00}", TextBox2.Text);
//            decimal HoraConcluida = Convert.ToDecimal(Convert.ToDecimal(hora2.Split(':')[0]) + Convert.ToDecimal(TimeSpan.Parse("00:" + (hora2.Split(':')[1] == null?  "0": hora2.Split(':')[1])).TotalHours));

//            decimal HoraFaltando = HoraLimite - HoraConcluida;

//            //var limite = Convert.ToDecimal(TimeSpan.Parse(textBox1.Text).TotalHours);// Convert.ToInt32(textBox1.Text);
//            //var sobra = limite - Convert.ToDecimal(TimeSpan.Parse(textBox2.Text).TotalHours);
//            //decimal dec = Convert.ToDecimal(TimeSpan.Parse(sobra.ToString()).TotalHours);

//            //var teste = TimeSpan.Parse(textBox1.Text); 

//            var hoje = DateTime.Now.Date.AddDays(-1);
//            var ultimoDiaDoMes = hoje.AddDays(-(hoje.Day - 1)).AddMonths(1).AddDays(-1);
//            var primeiroDia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

//            var diasFaltantes = ultimoDiaDoMes.AddDays(hoje.Day * -1).Day - FinsDeSemana();

//            var resultado = HoraFaltando / diasFaltantes;
            
//            textBox3.Text = "Faltam " + HoraFaltando + "h.\n Nos próximos " + diasFaltantes  + " dias, faça " + resultado + "h por dia.";
//        }

//        private void Limpar()
//        {
//            TextBox1.Text = string.Empty;
//            TextBox2.Text = string.Empty;
//            textBox3.Text = string.Empty;
//        }


//        private void button1_Click(object sender, EventArgs e)
//        {
//            Limpar();
//            TextBox1.Focus();
//        }

//        private int FinsDeSemana()
//        {
//            var _data = DateTime.Now;
//            int contador = 1;

//            DateTime PrimeiroDiadoMes = DateTime.Parse("01" + _data.ToString("/ MM / yyyy"));
//            DateTime PrimeiroDiadoProximoMes = PrimeiroDiadoMes.AddMonths(1);
//            var UltimoDiadoMes = PrimeiroDiadoProximoMes.AddDays(-1).Day;

//            for (int i = _data.Day; i < UltimoDiadoMes; i++)
//            {
//                DateTime diaCorrido = DateTime.Parse(i.ToString() + _data.ToString("/ MM / yyyy"));

//                if (diaCorrido.DayOfWeek == DayOfWeek.Saturday)
//                    contador++;
//                else if (diaCorrido.DayOfWeek == DayOfWeek.Sunday)
//                    contador++;
//            }

//            return contador;
//        }
//    }
//}
