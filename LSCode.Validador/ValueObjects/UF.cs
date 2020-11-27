﻿using LSCode.Validador.ValidacoesNotificacoes;
using System;

namespace LSCode.Validador.ValueObjects
{
    /// <summary>Auxilia na utilização e validação de UF.</summary>
    public class UF : Notificadora
    {
        /// <value>UF.</value>
        public string Valor { get; private set; }

        /// <summary>Construtor da classe UF.</summary>
        /// <remarks> Deve conter sigla de um dos estados brasileiros.</remarks>
        /// <param name="valor">UF.</param>
        /// <returns> Cria uma instância da classe UF.</returns>
        public UF(string valor)
        {
            try
            {
                Valor = valor;

                if (Valor == null)
                {
                    AddNotificacao("Celular", "Celular não pode ser nulo");
                }
                else
                {
                    AddNotificacao(new ContratoValidacao().EhVerdadeiro(Validar(Valor), "UF", "UF não é válido"));

                    AddNotificacao(new ContratoValidacao().TamanhoMaximo(valor, 2, "UF", "UF superior à 2 caracteres"));
                }
            }
            catch (Exception ex)
            {
                AddNotificacao("UF", $@"Erro: {ex.Message}");
            }
        }

        /// <summary>Efetua validação do UF.</summary>
        /// <param name="valor">UF. Deve conter sigla de um dos estados brasileiros.</param>
        /// <returns>True caso válido ou False caso inválido.</returns>
        /// <exception cref="Exception">Erro ao validar UF.</exception>
        private bool Validar(string valor)
        {
            Valor = valor.Trim().ToUpper();

            return Valor == "RO" || Valor == "AC" || Valor == "AM" || Valor == "RR" || Valor == "PA" || Valor == "AP" || Valor == "TO" || Valor == "MA" || Valor == "PI" ||
                   Valor == "CE" || Valor == "RN" || Valor == "PB" || Valor == "PE" || Valor == "AL" || Valor == "SE" || Valor == "BA" || Valor == "MG" || Valor == "ES" ||
                   Valor == "RJ" || Valor == "SP" || Valor == "PR" || Valor == "SC" || Valor == "RS" || Valor == "MS" || Valor == "MT" || Valor == "GO" || Valor == "DF";
        }

        /// <summary>Retorna número do celular.</summary>
        public override string ToString() => Valor;
    }
}