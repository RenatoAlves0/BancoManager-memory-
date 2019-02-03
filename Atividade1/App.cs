//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;

namespace Gerenciador_de_Bancos
{
    public class App
    {
        static void Main(string[] args)
        {
            Solicitacoes solicitacoes = new Solicitacoes();

            solicitacoes.Logar();

            string op = "";

            while(!op.Equals("0"))
            {
                WriteLine("\n\nBem vind# ao BancoManager");
                WriteLine("0. Sair\n");

                WriteLine("Banco");
                WriteLine("1.1 Cadastrar");
                WriteLine("1.2 Listar\n");

                WriteLine("Agência");
                WriteLine("2.1 Adicionar");
                WriteLine("2.2 Listar\n");

                WriteLine("Conta Poupança");
                WriteLine("3.1 Cadastrar");
                WriteLine("3.2 Listar");
                WriteLine("3.3 Saldo");
                WriteLine("3.4 Depositar");
                WriteLine("3.5 Sacar\n");

                WriteLine("Conta Corrente");
                WriteLine("4.1 Cadastrar");
                WriteLine("4.2 Listar");
                WriteLine("4.3 Saldo");
                WriteLine("4.4 Depositar");
                WriteLine("4.5 Sacar");
                Write("_");

                op = ReadLine();

                switch (op)
                {
                    case "1.1":
                        solicitacoes.AddBanco();
                        break;
                    case "1.2":
                        solicitacoes.ListBancos();
                        break;

                    case "2.1":
                        solicitacoes.AddAgencia();
                        break;
                    case "2.2":
                        solicitacoes.ListAgencias();
                        break;

                    case "3.1":
                        solicitacoes.AddContaPoupanca();
                        break;
                    case "3.2":
                        solicitacoes.ListContasPoupanca();
                        break;
                    case "3.3":
                        solicitacoes.ConsultarContaPoupanca();
                        break;
                    case "3.4":
                        solicitacoes.DepositarContaPoupanca();
                        break;
                    case "3.5":
                        solicitacoes.SacarContaPoupanca();
                        break;

                    case "4.1":
                        solicitacoes.AddContaCorrente();
                        break;
                    case "4.2":
                        solicitacoes.ListContasCorrente();
                        break;
                    case "4.3":
                        solicitacoes.ConsultarContaCorrente();
                        break;
                    case "4.4":
                        solicitacoes.DepositarContaCorrente();
                        break;
                    case "4.5":
                        solicitacoes.SacarContaCorrente();
                        break;
                }
            }

        

        }
    }
}

//By Renato Alves de Oliveira