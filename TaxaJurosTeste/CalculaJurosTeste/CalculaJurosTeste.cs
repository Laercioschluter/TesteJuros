using Calculo.Interface;
using Calculo.Service;
using Moq;
using Xunit;

namespace CalculaJurosTeste
{
    public class CalculaJurosTeste
    {
        [Theory(DisplayName = "Calcula Juros")]
        [InlineData(100, 5, 105.10)]
        [InlineData(200, 5, 210.20)]
        [InlineData(300, 5, 315.30)]
        [InlineData(400, 5, 420.40)]
        public async void Calcular_Juros_Test(double valorInicial, int tempo, double esperado)
        {
            //Arrange     
            var mockITaxaJuros = new Mock<ICalculaJuros>();
            var mockIBuscaTaxa = new Mock<IBuscaTaxa>();
            var mockCalcularJurosService = new CalculaJuros(mockIBuscaTaxa.Object);

            //Act
            var result = await mockCalcularJurosService.CalcularJuros(valorInicial, tempo);

            //Assert
            Assert.Equal(esperado, result);
        }

        [Theory(DisplayName = "Taxa Juros")]
        [InlineData(0.01)]
        public async void Obter_Taxa_Juros_Test(double taxa)
        {
            //Arrange
            var juros = 0.01;
            var mockITaxaJuros = new Mock<IBuscaTaxa>();
            mockITaxaJuros.Setup(s => s.PegaTaxa()).ReturnsAsync(juros);

            //Act
            var result = await mockITaxaJuros.Object.PegaTaxa();

            //Assert
            Assert.Equal(taxa, result);
        }
    }
}
