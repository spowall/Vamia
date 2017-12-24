using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Vamia.Tests.Infrastructure
{
    [TestClass]
    public class NinjectTest
    {
        [TestMethod]
        public void TestBindings()
        {
            //Create Kernel and Load Assembly EduPortal.Web
            var kernel = new StandardKernel();
            kernel.Load(new Assembly[] { Assembly.Load("Vamia.Web") });


            var query = from types in Assembly.Load("Vamia.Domain").GetExportedTypes()
                        where types.IsInterface
                        where types.Namespace.StartsWith("Vamia.Domain.Interface")
                        select types;

            foreach (var i in query)
            {
                kernel.Get(i);
            }
        }
    }
}
