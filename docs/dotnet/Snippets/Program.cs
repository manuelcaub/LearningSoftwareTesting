using System;
using FluentAssertions;
using Xunit;

namespace Snippets
{
    public class Program
    {
        static void Main(
            string region = null,
            string session = null,
            string package = null,
            string project = null,
            string[] args = null)
        {
#region Main
            switch (region)
            {
                case "XunitVsFluentAssertions":
                    XunitVsFluentAssertions();
                    break;
            }
        }
#endregion

        public static void XunitVsFluentAssertions()
        {
            try
            {
                #region XunitVsFluentAssertions
                Assert.Equal(1, 2);
                #endregion
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
}