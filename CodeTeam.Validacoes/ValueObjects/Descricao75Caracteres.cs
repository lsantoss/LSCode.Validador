﻿using CodeTeam.Validacoes.ValidacoesNotificacoes;

namespace CodeTeam.Validacoes.ValueObjects
{
    class Descricao75Caracteres : Notificadora
    {
        public string Valor { get; private set; }

        public Descricao75Caracteres(string valor, string descritivo)
        {
            Valor = valor;

            AddNotificacao(new ContratoValidacao().TamanhoMaximo(valor, 75, descritivo, "Conteúdo superior à 75 caracteres"));
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}