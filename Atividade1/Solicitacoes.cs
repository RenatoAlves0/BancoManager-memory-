//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Gerenciador_de_Bancos
{
    public class Solicitacoes
{
        List<Banco> bancos = new List<Banco>();
        List<Cliente> clientes = new List<Cliente>();

        public Cliente Eu
        {
            get; set;
        }

        public Cliente Logar()
        {
            Cliente cliente = new Cliente();

            WriteLine("Para começar informe seu CPF: ");
            WriteLine("Coloque apenas números -> 00000000000 ");
            Write("_");
            cliente.Cpf = ReadLine();

            if (SearchCliente(cliente.Cpf) == null)
            {
                WriteLine("\nPercebemos que você ainda não está cadastrad#!");
                WriteLine("Informe seu nome, para poder-mos lhe cadastrar ");
                Write("_");
                cliente.Nome = ReadLine();

                AddCliente(cliente);
                Eu = cliente;
                WriteLine("\nBem vind# " + cliente.Nome + " !\n");
                return Eu;
            }
            else
            {
                Eu = cliente;
                WriteLine("\nBem vind# " + SearchCliente(cliente.Cpf).Nome + " !");
                return Eu;
            }
        }

        public Cliente TrocarUsuario()
        {
            string op = "";
            WriteLine("Deseja continuar como " + Eu.Nome + " ? S/N");
            Write("_");
            op = ReadLine();

            if (op.ToLower().Equals("s")) return Eu;
            else return Logar();
        }

        public Cliente SearchCliente(string cpf)
        {
            foreach(var cliente in clientes)
            {
                if (cpf.Equals(cliente.Cpf)) return cliente;
            }

            return null;
        }

        public void AddCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void AddBanco()
        {
            WriteLine("\n*** Novo Banco ***\n");
            Banco b = new Banco();
            Write("Nome: ");
            b.Nome = ReadLine();
            Write("Identificador: ");
            b.Id = ReadLine();

            bancos.Add(b);
        }

        public void ListBancos()
        {
            WriteLine("\n*** Bancos ***\n");
            int i = 1;
            foreach (var b in bancos)
            {
                WriteLine(i + ".\nNome: " + b.Nome + "\nId: " + b.Id + "\n");
                i++;
            }
        }

        public int SearchBanco(string id)
        {
            foreach (var b in bancos)
            {
                if (id.Equals(b.Id))
                {
                    return bancos.IndexOf(b);
                }
            }
            WriteLine("\n!!! Banco não cadastrado !!!\n");

            return -1;
        }

        public void AddAgencia()
        {
            WriteLine("\n*** Dados do Banco ***\n");
            int banco;
            string opcao = "";
            Agencia agencia = new Agencia();

            Write("Identificador: ");
            banco = SearchBanco(ReadLine());
            if (banco == -1) return;
            else
            {

                WriteLine("\n*** Nova Agência do " + bancos[banco].Nome + " ***\n");

                Write("Nome: ");
                agencia.Nome = ReadLine();
                Write("Identificador: ");
                agencia.Id = ReadLine();

                bancos[banco].AddAgencia(agencia);
                
            }

            Write("\nCadastrar nova Agência? S/N :");
            opcao = ReadLine();

            if (opcao.ToLower().Equals("s")) {
                WriteLine("\n");
                AddAgencia();
            }
            else return;


        }

        public void ListAgencias()
        {
            WriteLine("\n*** Dados do Banco ***\n");
            int banco;
            Write("Identificador: ");
            banco = SearchBanco(ReadLine());
            if (banco != -1) bancos[banco].ListAgencias();
        }

        // Poupança

        public void AddContaPoupanca()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;
            else
            {
                Cliente cliente = new Cliente();
                cliente = TrocarUsuario();

                WriteLine("\n*** Dados da Conta ***\n");
                Write("Taxa de juros: ");
                decimal juros = Convert.ToDecimal(ReadLine());

                agencia.AddCp(juros, DateTime.Now, cliente);
                agencia.ExibirCp(cliente.Cpf);
            }
        }

        public void ListContasPoupanca()
        {
            IdentificarAgencia().ListarCps();
        }

        public void ConsultarContaPoupanca()
        {
            IdentificarAgencia().ExibirCp(Eu.Cpf);
        }

        public void DepositarContaPoupanca()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do depósito: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.DepositarPoupanca(Eu.Cpf, valor);
        }

        public void SacarContaPoupanca()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do saque: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.SacarPoupanca(Eu.Cpf, valor);
        }

        // Corrente

        public void AddContaCorrente()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;
            else
            {
                Cliente cliente = new Cliente();
                cliente = TrocarUsuario();

                agencia.AddCc(cliente);
                agencia.ExibirCc(cliente.Cpf);
            }
        }

        public void ListContasCorrente()
        {
            IdentificarAgencia().ListarCcs();
        }

        public void ConsultarContaCorrente()
        {
            IdentificarAgencia().ExibirCc(Eu.Cpf);
        }

        public void DepositarContaCorrente()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do depósito: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.DepositarCorrente(Eu.Cpf, valor);
        }

        public void SacarContaCorrente()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do saque: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.SacarCorrente(Eu.Cpf, valor);
        }

        //Generic

        public Agencia IdentificarAgencia()
        {
            WriteLine("\n*** Dados do Banco ***\n");
            string banco = "", agencia = "";
            int idBanco, idAgencia;

            Write("Idenditifcador: ");
            banco = ReadLine();
            idBanco = SearchBanco(banco);
            if (idBanco.Equals("-1"))
            {
                WriteLine("\n!!! Banco não cadastrado !!!\n");
                WriteLine("\n!!! É necessário cadastrar um Banco antes de realizar esta operação !!!\n");
                return null;
            }
            else
            {
                WriteLine("\n*** Dados da Agência ***\n");
                Write("Identificador: ");
                agencia = ReadLine();
                idAgencia = bancos[idBanco].BuscarAgencia(agencia);
                if (idAgencia.Equals("-1"))
                {
                    WriteLine("\n!!! Agência não cadastrada !!!\n");
                    WriteLine("\n!!! É necessário cadastrar uma Agência antes de realizar esta operação !!!\n");
                    return null;
                }
                else return bancos[idBanco].agencias[idAgencia];
                
            }
        }
    }
}

//By Renato Alves de Oliveira