//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Gerenciador_de_Bancos
{
    public abstract class Conta
    {
        public Conta (Cliente t)
        {
            Titular = t;
        }

        public decimal Saldo
        {
            get; set;
        }

        public Cliente Titular
        {
            get; set;
        }

        public abstract string  Id
        {
            get;
        }

        public virtual void Depositar(decimal v)
        {
            Saldo += v;
        }

        public virtual void Sacar(decimal v)
        {
            if (v <= Saldo) Saldo -= v;
            else WriteLine("Valor não disponível.. Consulte seu saldo!");
        }
    }
}

//By Renato Alves de Oliveira