using Bogus;
using Bogus.Extensions.Brazil;
using DFe.Classes.Entidades;
using NFe.Classes.Informacoes;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao;

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
                    emit = ObterEmitente()
                }
            };
        }

        private static ide ObterIdentificacao()
        {
            var identificacao = new ide
            {
                
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
    }
}
