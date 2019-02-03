//By Renato Alves de Oliveira

using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciador_de_Bancos
{
    public class ContaPoupanca : Conta
    {
        public decimal Juros
        {
            get; set;
        }

        public DateTime Aniversario
        {
            get; set;
        }

        public ContaPoupanca(decimal j, DateTime a, Cliente t): base(t)
        {
            Juros = j;
            Aniversario = a;
        }

        public void AddRendimento()
        {
            if(DateTime.Now.Equals(Aniversario))
            {
                Depositar(Saldo * Juros);
            }
        }

        public override string Id
        {
            get { return Titular.Cpf + "(CP)"; }
        }

    }
}

//By Renato Alves de Oliveira
