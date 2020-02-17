﻿using CodeTeam.Validacoes.ValidacoesNotificacoes;

namespace CodeTeam.Validacoes.ValueObjects
{
    public class Descricao300Caracteres : Notificadora
    {
        public string Valor { get; private set; }

        public Descricao300Caracteres(string valor, string descritivo)
        {
            Valor = valor;

            AddNotificacao(new ContratoValidacao().TamanhoMaximo(valor, 300, descritivo, "Conteúdo superior à 300 caracteres"));
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}