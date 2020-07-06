﻿using LSCode.Validador.ValidacoesNotificacoes;

namespace LSCode.Validador.ValueObjects
{
    public class TamanhoArquivoKB : Notificadora
    {
        public string Tamanho { get; private set; }

        public TamanhoArquivoKB(string tamanhoEmBytes)
        {
            double tamanhoDouble = double.Parse(tamanhoEmBytes);

            // Bytes para KBytes
            tamanhoDouble = tamanhoDouble / 1024;

            Tamanho = tamanhoDouble.ToString("N0") + " KB";
        }

        public override string ToString()
        {
            return Tamanho;
        }
    }
}