using NFe.Servicos.Retorno;

namespace UtilsDFeNFe.NFeNfceExtensions
{
    public static class RetornoNFeStatusServicoExtension
    {
        public static bool ServicoEmOperacao(this RetornoNfeStatusServico retornoNfeStatusServico)
        {
            if (retornoNfeStatusServico == null) return false;

            if (retornoNfeStatusServico.Retorno.cStat == 107) return true;

            return false;
        }

        public static bool ParalisadoTemporariamente(this RetornoNfeStatusServico retornoNfeStatusServico)
        {
            if (retornoNfeStatusServico == null) return false;

            if (retornoNfeStatusServico.Retorno.cStat == 108) return true;

            return false;
        }

        public static bool ParalisadoSemPrevisaoDeRetorno(this RetornoNfeStatusServico retornoNfeStatusServico)
        {
            if (retornoNfeStatusServico == null) return false;

            if (retornoNfeStatusServico.Retorno.cStat == 109) return true;

            return false;
        }

    }
}