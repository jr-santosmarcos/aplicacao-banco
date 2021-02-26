using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Saque();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();


        }

        private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());
            indiceConta = indiceConta - 1;

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Deposito(valorDeposito);
		}

        private static void Saque()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());
            indiceConta = indiceConta - 1;

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Saque(valorSaque);
		}

        private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());
            indiceContaOrigem = indiceContaOrigem - 1;

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());
            indiceContaDestino = indiceContaDestino - 1;

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferencia(valorTransferencia, listContas[indiceContaDestino]);
		}

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"#{i + 1} - ");
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome);
            listContas.Add(novaConta);  
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco .NET a seu dispor");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Depósito");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;

        }
    }
}
