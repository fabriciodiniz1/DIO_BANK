using System;

namespace DIO.BANK
{
	public class Conta
	{
		// Atributos
		// O motivo do private (encapsulamento) é para proteger após a criação do objeto que ninguém altere diretamente as informações.
		// Se eu precisar mudar o saldo, eu crio um método. Ai tem um controle de onde está vindo a alteração.
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }

		// Métodos
		
		// Método Construtor - momento que é criado o objeto
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta; //This informa para alterar somente a instância que foi passada.
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque) // Cheque o Saldo, antes de Sacar
		{
            // Validação de saldo insuficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
			// Você você pode fazer de outra forma: this.Saldo=this.Saldo-valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
			//Onde esta {0},{1} (parecendo vetor de dados) é a formatação composta da string
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;//retorno da realização do saque
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{ 
			if (this.Sacar(valorTransferencia)){// Aqui está sendo reusado o método Sacar e o método Depositar
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString() //Sobrescrevendo da classe mãe
		{
            string retorno = ""; // Criado uma string para escrever na tela de forma concatenada
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}
	}
}