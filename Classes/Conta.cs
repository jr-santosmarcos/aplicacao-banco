using System;
namespace Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Saque(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("O saldo atual da conta de {0} é {1} R$", this.Nome, this.Saldo);

            return true;
        }

        public void Deposito(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("A conta de {0} recebeu um depósito de {1} R$", this.Nome, valorDeposito);
            Console.WriteLine("O saldo atual da conta de {0} é {1} R$", this.Nome, this.Saldo);
        }

        public void Transferencia(double valorTransferencia, Conta contaDestino)
        {
            if (this.Saque(valorTransferencia))
            {
                contaDestino.Deposito(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }

    }
}