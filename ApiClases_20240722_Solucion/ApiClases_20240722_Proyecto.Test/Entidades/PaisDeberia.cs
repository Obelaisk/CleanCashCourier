using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiClases_20270722_Proyecto.Entidades;

namespace ApiClases_20240722_Proyecto.Test.Entidades
{
    public class PaisDeberia
    {
        private ValidationContext ObtenerContextoValidacion(object objeto)
        {
            return new ValidationContext(objeto, serviceProvider: null, items: null);
        }

        private IList<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            Validator.TryValidateObject(modelo, ObtenerContextoValidacion(modelo), resultados, true);
            return resultados;
        }

        [Theory]
        [InlineData(null)] // Nombre nulo
        [InlineData("")]   // Nombre vacío
        [InlineData("A very long name that exceeds the maximum allowed length of 100 characters.....................................................................")] // Nombre demasiado largo
        public void DeberiaRetornarErrorParaNombreInvalido(string nombre)
        {
            // Arrange
            var pais = new Pais { Nombre = nombre, Divisa = "USD", Iso3Pais = "USA", Iso3Divisa = "USD" };

            // Act
            var resultados = ValidarModelo(pais);

            // Assert
            Assert.Contains(resultados, r => r.MemberNames.Contains(nameof(Pais.Nombre)));
        }

        [Theory]
        [InlineData(null)] // Divisa nula
        [InlineData("")]   // Divisa vacía
        [InlineData("A very long currency name that exceeds the maximum allowed length of 50 characters....")] // Divisa demasiado larga
        public void DeberiaRetornarErrorParaDivisaInvalida(string divisa)
        {
            // Arrange
            var pais = new Pais { Nombre = "Estados Unidos", Divisa = divisa, Iso3Pais = "USA", Iso3Divisa = "USD" };

            // Act
            var resultados = ValidarModelo(pais);

            // Assert
            Assert.Contains(resultados, r => r.MemberNames.Contains(nameof(Pais.Divisa)));
        }

        [Theory]
        [InlineData(null)]  // Iso3Pais nulo
        [InlineData("")]    // Iso3Pais vacío
        [InlineData("US")]  // Iso3Pais demasiado corto
        [InlineData("USA1")] // Iso3Pais demasiado largo
        public void DeberiaRetornarErrorParaIso3PaisInvalido(string iso3Pais)
        {
            // Arrange
            var pais = new Pais { Nombre = "Estados Unidos", Divisa = "USD", Iso3Pais = iso3Pais, Iso3Divisa = "USD" };

            // Act
            var resultados = ValidarModelo(pais);

            // Assert
            Assert.Contains(resultados, r => r.MemberNames.Contains(nameof(Pais.Iso3Pais)));
        }

        [Theory]
        [InlineData(null)]  // Iso3Divisa nulo
        [InlineData("")]    // Iso3Divisa vacío
        [InlineData("US")]  // Iso3Divisa demasiado corto
        [InlineData("USD1")] // Iso3Divisa demasiado largo
        public void DeberiaRetornarErrorParaIso3DivisaInvalido(string iso3Divisa)
        {
            // Arrange
            var pais = new Pais { Nombre = "Estados Unidos", Divisa = "USD", Iso3Pais = "USA", Iso3Divisa = iso3Divisa };

            // Act
            var resultados = ValidarModelo(pais);

            // Assert
            Assert.Contains(resultados, r => r.MemberNames.Contains(nameof(Pais.Iso3Divisa)));
        }

        [Fact]
        public void DeberiaSerValidoCuandoPropiedadesSonCorrectas()
        {
            // Arrange
            var pais = new Pais { Nombre = "Estados Unidos", Divisa = "USD", Iso3Pais = "USA", Iso3Divisa = "USD" };

            // Act
            var resultados = ValidarModelo(pais);

            // Assert
            Assert.Empty(resultados); // Si no hay errores, la lista de resultados debe estar vacía
        }
    }
}

