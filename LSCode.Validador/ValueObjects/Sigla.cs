﻿using LSCode.Validador.ValidacoesNotificacoes;
using System;

namespace LSCode.Validador.ValueObjects
{
    /// <summary>Auxilia na utilização e validação de siglas.</summary>
    public class Sigla : Notificadora
    {
        /// <value>Sigla.</value>
        public string Valor { get; private set; }

        /// <summary>Construtor da classe Sigla.</summary>
        /// <remarks>Deve conter no máximo três caracteres.</remarks>
        /// <param name="valor">Sigla.</param>
        /// <returns>Cria uma instância da classe Sigla.</returns>
        public Sigla(string valor)
        {
            try
            {
                Valor = valor;

                if (!string.IsNullOrWhiteSpace(Valor))
                    AddNotificacao(new ContratoValidacao().TamanhoMaximo(valor, 3, "Sigla", "Sigla superior à 3 caracteres"));
                else
                    AddNotificacao("Sigla", "Sigla não pode ser nula ou vazia");
            }
            catch (Exception ex)
            {
                AddNotificacao("Sigla", $"Erro: {ex.Message}");
            }
        }

        /// <summary>Retorna a sigla.</summary>
        public override string ToString() => Valor;
    }
}