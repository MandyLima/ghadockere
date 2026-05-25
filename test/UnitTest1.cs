namespace CsharpCICD.Test;

public class UnitTest1
{
    [Fact]
   public void Deve_Formatar_Um_Valor_Positivo_Para_BRL_Por_Padrao()
        {
            var result = CurrencyFormatter.FormatCurrency(1000.50m);
            Assert.Contains("R$ 1.000,50", result);
        }

        [Fact]
        public void Deve_Formatar_Corretamente_Para_Outra_Moeda_USD()
        {
            // Em C#, a cultura pt-BR formatando USD costuma resultar em $ 100,00 ou USD 100,00 dependendo do ambiente
            var result = CurrencyFormatter.FormatCurrency(100m, "USD", "pt-BR");
            Assert.Contains("100,00", result);
        }

        [Fact]
        public void Deve_Formatar_Zero_Corretamente()
        {
            var result = CurrencyFormatter.FormatCurrency(0m);
            Assert.Contains("R$ 0,00", result);
        }

        [Fact]
        public void Deve_Formatar_Valores_Negativos()
        {
            var result = CurrencyFormatter.FormatCurrency(-50m);
            Assert.Contains("-R$ 50,00", result); // Ou "-R$ 50,00" dependendo da versão do .NET
        }

        // === Testes de Exceção ===

        [Fact]
        public void Deve_Lancar_ArgumentException_Se_A_Moeda_Ou_Cultura_For_Invalida()
        {
            Assert.Throws<ArgumentException>(() => 
                CurrencyFormatter.FormatCurrency(100m, "123", "invalid-culture")
            );
        }
    }
