using System;
using System.Drawing;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria {
        private int Numero { get; set; }
        private string Titular { get; set; }
        private Double Valor { get; set;}

        public ContaBancaria(int Numero, string Titular, Double DepositoInicial = 0)
        {
            this.Numero = Numero;
            this.Titular = Titular;
            this.Valor = DepositoInicial;
        }

        public void Saque(Double ValorSaque)
        {
            Valor -= ValorSaque;
            Valor -= TaxaSaque();
        }
        public void Deposito(Double ValorDeposito)
        {
            Valor += ValorDeposito;
        }
        NumberFormatInfo mNumberFormatInfo = new CultureInfo("en-US", false).NumberFormat;

        public string ExibirContaSaldo()
        {
            return string.Concat("Conta ", Numero
                , ", Titular: ", Titular
                , ", Saldo: ", Valor.ToString("C", mNumberFormatInfo));
        }

        public Double TaxaSaque()
        {
            return 3.5;
        }

        public void AlterarNome(string NomeTitular)
        {
            Titular = NomeTitular;
        }
    }
}
