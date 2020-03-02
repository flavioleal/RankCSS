using RankCSS.Business.Dominio;
using System;
using Xunit;

namespace RankCSS.Test
{
    public class UnitTest1
    {
        [Fact]
        public void LerArquivoLogTxt()
        {
            var log = new Log();
            log.LerAquivoLogTxt();
        }
    }
}
