namespace CsharpCICD;
using System;
using System.Globalization;

    public static class CurrencyFormatter
    {
/// <summary>
    /// Converte um valor numérico em uma string formatada como moeda local ou estrangeira.
    /// </summary>
    /// <param name="amount">O valor numérico decimal a ser formatado. Exemplo: <c>1000.50m</c>.</param>
    /// <param name="currencyCode">O código da moeda (ex: "BRL", "USD").</param>
    /// <param name="cultureName">O local da formatação (ex: "pt-BR", "en-US").</param>
    /// <returns>O valor formatado.</returns>
        public static string FormatCurrency(decimal amount, string currencyCode = "BRL", string cultureName = "pt-BR")
        {
            try
            {
                // Instancia a cultura desejada
                var culture = new CultureInfo(cultureName);
                
                // Força o símbolo da moeda correto caso seja diferente do padrão da cultura
                var regionInfo = new RegionInfo(culture.Name);
                if (regionInfo.ISOCurrencySymbol != currencyCode)
                {
                    culture = (CultureInfo)culture.Clone();
                    culture.NumberFormat.CurrencySymbol = currencyCode == "USD" ? "$" : currencyCode; 
                }

                // Remove espaços inseparáveis (equivalente ao regex do seu teste em JS)
                string result = amount.ToString("C", culture);
                return result.Replace("\u00A0", " ").Trim();
            }
            catch (CultureNotFoundException)
            {
                throw new ArgumentException("Cultura ou moeda inválida.");
            }
        }
    }


