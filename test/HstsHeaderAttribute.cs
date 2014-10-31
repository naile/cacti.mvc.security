using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cacti.Mvc.Security.Test
{
    [TestClass]
    public class HstsHeaderAttribute
    {
        [TestMethod]
        public void FlagIsSet()
        {
            var filter = new HstsHeaderAttribute();

            filter.FlagIsSet();
        }
    }
}
