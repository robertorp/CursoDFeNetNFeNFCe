using System;
using System.Net;
using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Servicos;
using NFe.Utils;
using UtilsDFeNFe.NFeNfceExtensions;

namespace Aula2ConsultaStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuracaoServico = new ConfiguracaoServico
            {
                Certificado = new ConfiguracaoCertificado
                {
                    TipoCertificado = TipoCertificado.A1Repositorio,
                    //Arquivo = @"C:\Arquivo.pfx"
                    //ArrayBytesArquivo = certificado em bytes
                    CacheId = "b2543ace-2708-4660-8ea8-89ca845d10bf",
                    ManterDadosEmCache = true,
                    //Senha = "minhasenha do certificado digital",
                    Serial = "7CF486CADF6F2C54"
                },
                DefineVersaoServicosAutomaticamente = true,
                VersaoLayout = VersaoServico.Versao400,
                cUF = Estado.MT,
                DiretorioSalvarXml = @"C:\MeuSistema\Xmls",
                SalvarXmlServicos = true,
                DiretorioSchemas = @"C:\MeuSistema\Schemas",
                ModeloDocumento = ModeloDocumento.NFe,
                ProtocoloDeSeguranca = SecurityProtocolType.Tls12,
                RemoverAcentos = true,
                TimeOut = 30000,
                ValidarCertificadoDoServidor = false,
                tpAmb = TipoAmbiente.Homologacao,
                tpEmis = TipoEmissao.teNormal
            };

            var servicos = new ServicosNFe(configuracaoServico);

            var retorno = servicos.NfeStatusServico();

            var retornoStatusSucesso = retorno.ServicoEmOperacao();

            Console.WriteLine(retorno.EnvioStr);
        }
    }
}
