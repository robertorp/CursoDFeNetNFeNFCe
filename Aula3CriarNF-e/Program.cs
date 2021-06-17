using System;
using System.Collections.Generic;
using Bogus;
using Bogus.Extensions.Brazil;
using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using NFe.Classes.Informacoes;
using NFe.Classes.Informacoes.Destinatario;
using NFe.Classes.Informacoes.Detalhe;
using NFe.Classes.Informacoes.Detalhe.Tributacao;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual;
using NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao;
using NFe.Classes.Informacoes.Identificacao.Tipos;

namespace Aula3CriarNF_e
{
    class Program
    {
        private static Faker _faker;

        static void Main(string[] args)
        {
            _faker = new Faker(locale: "pt_BR");

            var nfe = new NFe.Classes.NFe
            {
                infNFe = new infNFe
                {
                    ide = ObterIdentificacao(),
                    emit = ObterEmitente(),
                    dest = ObterDestinatario(),
                    det = ObterDetalhesProdutos()
                }
            };
        }

        private static ide ObterIdentificacao()
        {
            var identificacao = new ide
            {
                dhEmi = DateTimeOffset.Now,
                cUF = Estado.GO,
                serie = 1,
                nNF = 1,
                cNF = _faker.Random.Number(8, 8).ToString(),
                tpEmis = TipoEmissao.teNormal,
                mod = ModeloDocumento.NFe,
                dSaiEnt = DateTime.Now,
                cMunFG = 5208707,
                idDest = DestinoOperacao.doInterna,
                finNFe = FinalidadeNFe.fnNormal,
                indFinal = ConsumidorFinal.cfConsumidorFinal,
                indPres = PresencaComprador.pcPresencial,
                natOp = "Vendas de Mercadorias",
                procEmi = ProcessoEmissao.peAplicativoContribuinte,
                tpAmb = TipoAmbiente.Homologacao,
                tpImp = TipoImpressao.tiRetrato,
                tpNF = TipoNFe.tnSaida,
                verProc = "Meu Sistema V1.0"
            };

            return identificacao;
        }

        private static emit ObterEmitente()
        {
            var emitente = new emit
            {
                CNPJ = _faker.Company.Cnpj(includeFormatSymbols:false),
                CRT = CRT.SimplesNacional,
                IE = _faker.Company.Random.Number(10, 14).ToString(),
                xFant = _faker.Company.CompanyName(),
                xNome = _faker.Company.CompanyName(),
                enderEmit = new enderEmit
                {
                    CEP = _faker.Address.ZipCode("########"),
                    UF = Estado.GO,
                    cMun = 5208707,
                    fone = long.Parse(_faker.Phone.PhoneNumber("###########")),
                    nro = _faker.Address.BuildingNumber(),
                    xBairro = _faker.Address.CityPrefix(),
                    xLgr = _faker.Address.StreetAddress(),
                    xMun = _faker.Address.City(),
                    xCpl = _faker.Address.Direction()
                }
            };

            return emitente;
        }

        private static dest ObterDestinatario()
        {
            var destinatario = new dest(VersaoServico.Versao400)
            {
                CPF = _faker.Person.Cpf(includeFormatSymbols:false),
                email = _faker.Person.Email,
                xNome = $"{_faker.Person.FullName}",
                indIEDest = indIEDest.NaoContribuinte,
                enderDest = new enderDest
                {
                    CEP = _faker.Address.ZipCode("########"),
                    UF = "GO",
                    cMun = 5208707,
                    fone = long.Parse(_faker.Phone.PhoneNumber("###########")),
                    nro = _faker.Address.BuildingNumber(),
                    xBairro = _faker.Address.CityPrefix(),
                    xLgr = _faker.Address.StreetAddress(),
                    xMun = _faker.Address.City(),
                    xCpl = _faker.Address.Direction()
                }
            };

            return destinatario;
        }

        private static List<det> ObterDetalhesProdutos()
        {
            var quantidadeDetalhesProdutos = 5;
            var detalhesProdutos = new List<det>();

            for (var i = 0; i < quantidadeDetalhesProdutos; i++)
            {
                var valorProduto = decimal.Parse(_faker.Commerce.Price(1.00m, 200m, 2));


                detalhesProdutos.Add(new det
                {
                    nItem = i+1,
                    prod = new prod
                    {
                        vOutro = 0.0m,
                        vSeg = 0.0m,
                        vFrete = 0.0m,
                        cProd = _faker.Random.String2(10),
                        vDesc = 0.0m,
                        vProd = valorProduto,
                        qTrib = 1.0m,
                        uTrib = "UN",
                        vUnTrib = valorProduto,
                        qCom = 1.0m,
                        uCom = "UN",
                        vUnCom = valorProduto,
                        xProd = _faker.Commerce.ProductName(),
                        CFOP = 5102,
                        indTot = IndicadorTotal.ValorDoItemCompoeTotalNF,
                        NCM = "83833333"
                    },
                    infAdProd = _faker.Commerce.ProductDescription(),
                    imposto = new imposto
                    {
                        ICMS = new ICMS
                        {
                            TipoICMS = new ICMSSN102
                            {
                                CSOSN = Csosnicms.Csosn102,
                                orig = OrigemMercadoria.OmNacional
                            }
                        }
                    }
                });
            }


            return detalhesProdutos;
        }
    }
}
