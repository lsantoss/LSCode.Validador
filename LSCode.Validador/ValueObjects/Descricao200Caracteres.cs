﻿using LSCode.Validador.ValidacoesNotificacoes;
using System;

namespace LSCode.Validador.ValueObjects
{
    public class Descricao200Caracteres : Notificadora
    {
        public string Valor { get; private set; }

        public Descricao200Caracteres(string valor, string descritivo)
        {
            try
            {
                Valor = valor;

                if (Valor == null)
                {
                    AddNotificacao(descritivo, "Conteúdo não pode ser nulo");
                }
                else
                {
                    AddNotificacao(new ContratoValidacao().TamanhoMaximo(Valor, 200, descritivo, "Conteúdo superior à 200 caracteres"));
                }
            }
            catch (Exception ex)
            {
                AddNotificacao(descritivo, $@"Erro: {ex.Message}");
            }
        }

        public override string ToString() => Valor;
    }
}