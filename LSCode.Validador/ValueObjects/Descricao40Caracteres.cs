﻿using LSCode.Validador.ValidacoesNotificacoes;

namespace LSCode.Validador.ValueObjects
{
    public class Descricao40Caracteres : Notificadora
    {
        public string Valor { get; private set; }

        public Descricao40Caracteres(string valor, string descritivo)
        {
            Valor = valor;

            AddNotificacao(new ContratoValidacao().TamanhoMaximo(valor, 40, descritivo, "Conteúdo superior à 40 caracteres"));
        }

        public override string ToString() => Valor;
    }
}