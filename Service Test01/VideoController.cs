using System.Collections.Generic;
using System.Web.Http;

namespace Service_Test01
{
    public class VideoController : ApiController
    {
        // GET api
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return ("some get" + id);
        }

        // POST to api/video
        public void Post([FromBody]string value)
        {
            // do some stuff
        }
    }
}
