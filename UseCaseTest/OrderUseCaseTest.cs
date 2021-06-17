using Moq;
using PFE.Domain;
using PFE.Repository;
using PFE.UseCase;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UseCaseTest
{
    public class OrderUseCaseTest
    {
        private readonly OrderUseCase useCase;
        private readonly Mock<IOrderRepository> orderRepositoryMock;
        public OrderUseCaseTest()
        {
            orderRepositoryMock = new Mock<IOrderRepository>();
            useCase = new OrderUseCase(orderRepositoryMock.Object);
        }
        [Fact]
        public void Test_GetOrderById_WhenIdPositif_CallGetOrderById_Once()
        {
            //Given
            var orderResult = new Order() 
            { 

                UserId = 1, 
                OrderId =3,
                CreditCard = new BankCard ()
            };
            orderResult.CreditCard.CreditCardId = 35; 
            orderRepositoryMock.Setup(x => x.GetOrderById(It.IsAny<int>()))
                               .Returns(orderResult);


            //When
            var order = useCase.GetOrderById(3);
            //then
            orderRepositoryMock.Verify(x => x.GetOrderById(3), Times.Once);
            Assert.Equal(1, order.UserId);
            Assert.Equal(3, order.OrderId);
            Assert.Equal(35, order.CreditCard.CreditCardId);
        }


        [Fact]
        public void Test_GetOrderById_WhenIdNegatif_ThrowException()
        {
            //then
            Assert.Throws<Exception>(() => useCase.GetOrderById(-3));
            orderRepositoryMock.Verify(x => x.GetOrderById(-3), Times.Never);

        }

    }
}
