using Arquimedes.MDL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arquimedes.BLL.Tests
{
    [TestClass()]
    public class MesTests
    {
        [TestMethod()]
        public void MostrarTotalDeDiasEmUmMes()
        {
            Assert.AreEqual(21, Mes.TotalDiasMes(), "Deu merda");
        }

        [TestMethod()]
        public void MostrarTotalDeFimDeSemanaEmUmMes()
        {
            Assert.AreEqual(9, Mes.FimDeSemana(true), "Deu merda");
        }

        [TestMethod()]
        public void Mostrar_Fins_De_Semana_Ate_O_Fim_Do_Mes()
        {
            Assert.AreEqual(4, Mes.FimDeSemana(false), "Deu merda");
        }

        [TestMethod()]
        public void Mostrar_Total_De_Feriados_No_Mes()
        {
            Assert.AreEqual(0, Mes.TotalFeriados(), "Deu merda");
        }

        [TestMethod()]
        public void Mostra_Dias_Faltando_Para_Terminar_O_Mes_Contando_De_Agora()
        {
            Options option = new Options();
            option.Limite = "182";
            option.Atual = "180";
            option.Agora = "180";

            var bla = Mes.DiasFaltando(option);
            Assert.AreEqual(6, bla, "Deu merda");
        }

        [TestMethod()]
        public void Mostra_Dias_Faltando_Para_Terminar_O_Mes_Contando_De_Ontem()
        {
            Options option = new Options();
            option.Limite = "182";
            option.Atual = "180";

            var bla = Mes.DiasFaltando(option);
            Assert.AreEqual(7, bla, "Deu merda");
        }
    }
}