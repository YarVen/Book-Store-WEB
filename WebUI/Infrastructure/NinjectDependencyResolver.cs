using Domain.Abstract;
using Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<EFBookRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
        }

        /// <summary>
        /// Mock using
        /// </summary>
        //private void AddBindings()
        //{
        //    Mock<IBookRepository> mock = new Mock<IBookRepository>();
        //    mock.Setup(m => m.Books).Returns(new List<Book>
        //    {
        //        new Book{Name = "Коти-Вояки. Нове пророцтво", Author = "Эрин Хантер", Price = 109},
        //        new Book{Name = "Бартімеус", Author = "Джонатан Страуд", Price = 126},
        //        new Book{Name = "Танец с драконами: Искры над пеплом", Author = "Джордж Мартин", Price = 239}
        //    });
        //    kernel.Bind<IBookRepository>().ToConstant(mock.Object);
        //}

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}