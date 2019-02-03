//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Gerenciador_de_Bancos
{
    public class Agencia
    {

        public List<ContaCorrente> contasCorrentes = new List<ContaCorrente>();
        public List<ContaPoupanca> contasPoupancas = new List<ContaPoupanca>();

        public string Nome
        {
            get; set;
        }

        public string Id
        {
            get; set;
        }

        // Poupança

        public void AddCp(decimal juros, DateTime aniversario, Cliente cliente)
        {
            ContaPoupanca cp = new ContaPoupanca(juros, aniversario, cliente);
            contasPoupancas.Add(cp);

            WriteLine("\nConta cadastrada com sucesso !\n");
        }

        public void ListarCps()
        {
            Write("\n");
            int i = 1;
            foreach (var c in contasPoupancas)
            {
                WriteLine(i + "\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id + "\n Aniversário: " + c.Aniversario);
                i++;
            }
            Write("\n");
        }

        public ContaPoupanca SearchCP(string cpf)
        {
            string idConta = cpf + "(CP)";
            foreach (var c in contasPoupancas)
            {
                if (idConta.Equals(c.Id))
                {
                    return c;
                }
            }

            Write("!!! Conta não encontrada !!!");
            return null;
        }

        public void ExibirCp(ContaPoupanca c)
        {
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id + "\n Aniversário: " + c.Aniversario);
        }

        public void ExibirCp(string cpf)
        {
            ContaPoupanca c = SearchCP(cpf);
            if (c == null) return;
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id + "\n Aniversário: " + c.Aniversario);
        }

        public void DepositarPoupanca(string cpf, decimal valor)
        {
            ContaPoupanca conta = SearchCP(cpf);
            if (conta == null) return;

            conta.Depositar(valor);
            ExibirCp(conta);
        }

        public void SacarPoupanca(string cpf, decimal valor)
        {
            ContaPoupanca conta = SearchCP(cpf);
            if (conta == null) return;

            conta.Sacar(valor);
            ExibirCp(conta);
        }

        // Corrente

        public void AddCc(Cliente cliente)
        {
            ContaCorrente cc = new ContaCorrente(cliente);
            contasCorrentes.Add(cc);
            WriteLine("\nConta cadastrada com sucesso !\n");
        }

        public void ListarCcs()
        {
            Write("\n");
            int i = 1;
            foreach (var c in contasCorrentes)
            {
                WriteLine(i + "\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id);
                i++;
            }
            Write("\n");
        }

        public ContaCorrente SearchCC (string cpf)
        {
            string idConta = cpf + "(CC)";
            foreach (var c in contasCorrentes)
            {
                if (idConta.Equals(c.Id))
                {
                    return c;
                }
            }

            Write("!!! Conta não encontrada !!!");
            return null;
        }

        public void ExibirCc(ContaCorrente c)
        {
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id);
        }

        public void ExibirCc(string cpf)
        {
            ContaCorrente c = SearchCC(cpf);
            if (c == null) return;
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id);
        }

        public void DepositarCorrente(string cpf, decimal valor)
        {
            ContaCorrente conta = SearchCC(cpf);
            if (conta == null) return;

            conta.Depositar(valor);
            ExibirCc(conta);
        }

        public void SacarCorrente(string cpf, decimal valor)
        {
            ContaCorrente conta = SearchCC(cpf);
            if (conta == null) return;

            conta.Sacar(valor);
            ExibirCc(conta);
        }
    }
}

//By Renato Alves de Oliveira
