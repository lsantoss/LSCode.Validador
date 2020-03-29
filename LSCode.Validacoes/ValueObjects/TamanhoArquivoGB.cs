﻿using LSCode.Validacoes.ValidacoesNotificacoes;

namespace LSCode.Validacoes.ValueObjects
{
    public class TamanhoArquivoGB : Notificadora
    {
        public string Tamanho { get; private set; }

        public TamanhoArquivoGB(string tamanhoEmBytes)
        {
            double tamanhoDouble = double.Parse(tamanhoEmBytes);

            // Bytes para KBytes
            tamanhoDouble = tamanhoDouble / 1024;

            // KBytes para MBytes
            tamanhoDouble = tamanhoDouble / 1024;

            // MBytes para GBytes
            tamanhoDouble = tamanhoDouble / 1024;

            this.Tamanho = tamanhoDouble.ToString("N1") + " GB";
        }

        public override string ToString()
        {
            return this.Tamanho;
        }
    }
}