namespace DescompressDataInventario
{
    [Serializable]
    public record ResultadoXML
    {
        public int CD_RESULTADO { get; set; }
        public int CD_MEDICAO { get; set; }
        public int CD_MEDICAO_PLANTIO { get; set; }
        public int CD_MEDICAO_PARCELA { get; set; }
        public int CD_PLANTIO { get; set; }
        public string ID_REGIAO { get; set; }
        public string ID_PROJETO { get; set; }
        public string CD_TALHAO { get; set; }
        public int CD_PARCELA { get; set; }
        public string NRO_PARCELA { get; set; }
        public double COORD_X { get; set; }
        public double COORD_Y { get; set; }
        public DateTime DATA_MEDICAO { get; set; }
        public int CD_NIVEL { get; set; }
        public int NUM_FILA { get; set; }
        public int NUM_ARVORE { get; set; }
        public int NUM_FUSTE { get; set; }
        public int NUM_SECAO { get; set; }
        public string FLAG_ORIGEM_ITEM_MEDICAO { get; set; }
        public string FLAG_DUPLICIDADE { get; set; }
        public int CD_CHAVE { get; set; }
        public double? VLR_VARIAVEL { get; set; }
        public string TXT_VARIAVEL { get; set; }
        public int CD_GRUPO_ATRIBUTO { get; set; }
        public int CD_USUARIO { get; set; }
        public int CD_OPERACAO { get; set; }
        public double QTD_TEMPO_COLETA { get; set; }
        public double NUM_TAMANHO_PARCELA { get; set; }
        public int CD_OBJETIVO_MEDICAO { get; set; }
        public int CD_TAMANHO_PARCELA { get; set; }
        public int CD_ORDEM_SERVICO { get; set; }
        public double VLR_TEMPO_COLETA { get; set; }
        public string REF_BOLETIM_SILV_DISPOSITIVO { get; set; }
        public string ManagementUnit { get; set; }
        public string CD_FORNECEDOR { get; set; }
        public string DCR_OBSERVACAO { get; set; }
        public string DEVICE_NAME { get; set; }
        public string DEVICE_SERIAL { get; set; }
        public string NOME_DISPOSITIVO { get; set; }
        public string DATA_HORA_INICIO { get; set; }
        public string DATA_HORA_FIM { get; set; }
    }
}