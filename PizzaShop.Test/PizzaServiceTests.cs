using Moq;
using PizzaShop.Domain.Interfaces;
using PizzaShop.Domain.Services;
using PizzaShop.Domain.Entities;
using PizzaShop.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace PizzaShop.Test
{
    public class PizzaServiceTests
    {
        private readonly Mock<IAppDbContext> _mockDbContext;
        private readonly IPizzaService _pizzaService;

        public PizzaServiceTests()
        {
            _mockDbContext = new Mock<IAppDbContext>();
            _pizzaService = new PizzaService(_mockDbContext.Object);
        }

        [Fact]
        public void GetPizzas_ReturnsPizzas()
        {
            // Arrange
            var pizzas = new List<Pizza>()
            {
                new Pizza { Id = 1, Name = "Margherita", Category = Category.Vegetable },
                new Pizza { Id = 2, Name = "Pepperoni", Category = Category.Meat }
            };
            var mockDbSet = new Mock<DbSet<Pizza>>();
            mockDbSet.As<IQueryable<Pizza>>().Setup(m => m.Provider).Returns(pizzas.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Pizza>>().Setup(m => m.Expression).Returns(pizzas.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Pizza>>().Setup(m => m.ElementType).Returns(pizzas.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Pizza>>().Setup(m => m.GetEnumerator()).Returns(pizzas.AsQueryable().GetEnumerator());
            _mockDbContext.Setup(c => c.Pizzas).Returns(mockDbSet.Object);

            // Act
            var result = _pizzaService.GetPizzas();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreatePizzaAsync_AddsPizzaToDatabase()
        {
            // Arrange
            var pizza = new Pizza { Id = 1, Name = "Pepperoni", Category = Category.Meat };
            _mockDbContext.Setup(c => c.Pizzas.AddAsync(pizza, default)).Verifiable();

            // Act
            await _pizzaService.CreatePizzaAsync(pizza);

            // Assert
            _mockDbContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
        [Fact]
        public async Task DeletePizzaAsync_RemovesPizzaFromDatabase()
        {
            // Arrange
            var pizza = new Pizza { Id = 1, Name = "Pepperoni", Category = Category.Meat };
            _mockDbContext.Setup(c => c.Pizzas.FindAsync(pizza.Id)).ReturnsAsync(pizza);
            _mockDbContext.Setup(c => c.Pizzas.Remove(pizza)).Verifiable();

            // Act
            await _pizzaService.DeletePizzaAsync(pizza.Id);

            // Assert
            _mockDbContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task UpdatePizzaAsync_UpdatesPizzaInDatabase()
        {
            // Arrange
            var pizza = new Pizza { Id = 1, Name = "Pepperoni", Category = Category.Meat };
            _mockDbContext.Setup(c => c.Pizzas.Update(pizza)).Verifiable();

            // Act
            await _pizzaService.UpdatePizzaAsync(pizza);

            // Assert
            _mockDbContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
