using System;
using System.Collections.Generic;

namespace DIO.BANK
{
	class Program
	{
		/* Alguns testes da aula
		// Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "dddd");
        // Console.WriteLine(minhaConta.ToString());// - aqui força a escrever a conta em que parece o nome da Classe Conta
        // Eu quero sobrescrever o método, criando um método ToString na Classe Conta, que já existe na Classe Mãe*/
		static List<Conta> listContas = new List<Conta>(); 
		/* Lista as contas  - para armazenar, clica no balão para pegar a Collections
		OBS: Como exemplo da aula quando saimos perdemos todos os dados que estão em memóra RAM, por isso a importância de ter Banco de Dados*/
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();// clica com o botão direito, em generate método
						break;
					case "3":
						//TODO - 
						Transferir();
						break;
					case "4":
						//TODO - Saque da conta
						Sacar();
						break;
					case "5":
						//TODOD - Depósito da Conta
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito); // pegar uma conta de determinado índice, chamando o método Depositar do Objeto Conta
		}

		private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque); // pegar uma conta de determinado índice, chamando o método Sacar do Objeto Conta
			
		}

		private static void Transferir()// Método Transferir
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
			//Pegar o objeto da conta que irá transferir (indice) e faz o Depósito da Conta Destino
		}

		private static void InserirConta()
		{
			Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine()); //Int.Parse converter o que usuário digitou para Inteiro.

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();// Não precisa converter, o ReadLine já retorna uma string

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());//Double.Parse converter o que usuário digitou para Double

			Console.Write("Digite o crédito: "); //item Acima
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, //Convertendo entradaTipoConta para o enum
										saldo: entradaSaldo,//o parâmetro saldo recebendo entradaSaldo
										credito: entradaCredito,
										nome: entradaNome);
										//obs: fica seguro passsar os nomes dos parâmetros, do que só digitar os valores	

			listContas.Add(novaConta);//recebe como parâmetro uma Conta - e insere na listContas
		}

		private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];//pega a posição do Vetor e joga no ponto
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta); //mostrar os dados da conta no formato toString
			}
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
