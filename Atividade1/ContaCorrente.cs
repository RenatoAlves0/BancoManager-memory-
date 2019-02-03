//By Renato Alves de Oliveira

using System;
using System.Collections.Generic;
using System.Text;

namespace Gerenciador_de_Bancos
{
    public class ContaCorrente : Conta
    {
        public const decimal Taxa = 0.10M;

        public ContaCorrente(Cliente t) : base(t)
        {

        }

        public override string Id
        {
            get { return Titular.Cpf + "(CC)"; }
        }

        public override void Depositar(decimal v)
        {
            base.Depositar(v - (v*Taxa));
        }

        public override void Sacar(decimal v)
        {
            base.Sacar(v + (v*Taxa));
        }
    }
}

//By Renato Alves de Oliveira
