using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieHub.Provider.Test
{
    [TestClass]
    public class ApiHelperTest
    {

        ApiHelper _apiHelper = new ApiHelper();

        [TestMethod]
        public void Request_Test()
        {
            string apiUrl = "";
            _apiHelper.Request(apiUrl, null, null, null, null);
        }
    }
}
