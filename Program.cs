using System.Data;
using System.IO.Compression;
using System.Text.Json;
using DescompressDataInventario;

internal partial class Program
{
    static void Main(string[] args)
    {

        var path = "data.txt";

        var data = Descompress(FromBase64ToByte());
        var table = data.Tables[0];

        var list = new List<ResultadoXML>();

        var xmls = table.AsEnumerable().Select(row =>
            new ResultadoXML
            {
                CD_ORDEM_SERVICO = row.Field<int>("CD_ORDEM_SERVICO"),
                CD_FORNECEDOR = row.Field<string>("CD_FORNECEDOR"),
                ManagementUnit = row.Field<string>("ManagementUnit"),
                CD_MEDICAO = row.Field<int>("CD_MEDICAO"),
                CD_CHAVE = row.Field<int>("CD_CHAVE"),
                CD_MEDICAO_PLANTIO = 0,
                CD_MEDICAO_PARCELA = 0,
                CD_PARCELA = 0,
                CD_PLANTIO = row.Field<int>("CD_PLANTIO"),
                ID_REGIAO = row.Field<string>("ID_REGIAO"),
                ID_PROJETO = row.Field<string>("ID_PROJETO"),
                CD_TALHAO = row.Field<string>("CD_TALHAO"),
                NRO_PARCELA = row.Field<string>("NRO_PARCELA"),
                COORD_X = row.Field<double>("COORD_X"),
                COORD_Y = row.Field<double>("COORD_Y"),
                DATA_MEDICAO = row.Field<DateTime>("DATA_MEDICAO"),
                CD_NIVEL = row.Field<int>("CD_NIVEL"),
                NUM_FILA = row.Field<int>("NUM_FILA"),
                NUM_ARVORE = row.Field<int>("NUM_ARVORE"),
                NUM_FUSTE = row.Field<int>("NUM_FUSTE"),
                NUM_SECAO = row.Field<int>("NUM_SECAO"),
                CD_OBJETIVO_MEDICAO = row.Field<int>("CD_OBJETIVO_MEDICAO"),
                FLAG_ORIGEM_ITEM_MEDICAO = row.Field<string>("FLAG_ORIGEM_ITEM_MEDICAO"),
                VLR_VARIAVEL = row.Field<double>("VLR_VARIAVEL"),
                TXT_VARIAVEL = row.Field<string>("TXT_VARIAVEL"),
                CD_GRUPO_ATRIBUTO = row.Field<int>("CD_GRUPO_ATRIBUTO"),
                CD_USUARIO = row.Field<int>("CD_USUARIO"),
                CD_OPERACAO = row.Field<int>("CD_OPERACAO"),
                VLR_TEMPO_COLETA = row.Field<double>("VLR_TEMPO_COLETA"),
                NUM_TAMANHO_PARCELA = row.Field<double>("NUM_TAMANHO_PARCELA"),
                REF_BOLETIM_SILV_DISPOSITIVO = row.Field<string>("REF_BOLETIM_SILV_DISPOSITIVO"),
                CD_TAMANHO_PARCELA = row.Field<int>("CD_TAMANHO_PARCELA"),
                DEVICE_NAME = row.Field<string>("DEVICE_NAME"),
                DEVICE_SERIAL = row.Field<string>("DEVICE_SERIAL"),
                NOME_DISPOSITIVO = row.Field<string>("NOME_DISPOSITIVO"),
                DATA_HORA_INICIO = row.Field<string>("DATA_HORA_INICIO"),
                DATA_HORA_FIM = row.Field<string>("DATA_HORA_FIM"),
                DCR_OBSERVACAO = row.Field<string>("DCR_OBSERVACAO"),
                CD_RESULTADO = row.Field<int>("CD_RESULTADO"),
                FLAG_DUPLICIDADE = row.Field<string>("FLAG_DUPLICIDADE"),
                QTD_TEMPO_COLETA = row.Field<double>("QTD_TEMPO_COLETA"),
            }
        ).GroupBy(xml => xml.CD_TALHAO).ToList();

        File.WriteAllText(path, JsonSerializer.Serialize(xmls));
    }

    static DataSet Descompress(byte[] data)
    {
        var mem = new MemoryStream(data);
        GZipStream gZip = new(mem, CompressionMode.Decompress);
        DataSet dataset = new();
        dataset.ReadXml(gZip, XmlReadMode.ReadSchema);
        gZip.Close();
        mem.Close();

        return dataset;
    }


    /// <summary>
    /// Aqui deve ser salvo o arquivo dentro da pasta do projeto, com o nome dataHub.txt
    /// </summary>
    /// <returns>Esse método converte a string recebida do HUB para um byte array.</returns>
    static byte[] FromBase64ToByte()
    {
        var base64 = File.ReadAllText("dataHub.txt");
        return Convert.FromBase64String(base64);
    }
}