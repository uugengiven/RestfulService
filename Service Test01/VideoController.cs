using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Diagnostics;

namespace Service_Test01
{
    public class VideoController : ApiController
    {
        // GET api
        public IEnumerable<string> Get()
        {
            // do some stuff
            Process proc = new Process();

            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.WorkingDirectory = "c:\\OBS";
            proc.StartInfo.FileName = "c:\\OBS\\obs.exe";
            proc.StartInfo.Arguments = @"-start -multi -portable";
            proc.StartInfo.UseShellExecute = true;

            proc.Start();

            return new string[] { "value1", "value2", proc.Id.ToString() };
        }

        public string Get(int id)
        {
            return ("some get" + id);
        }

        // POST to api/video
        public string Post([FromBody]string value)
        {
            // do some stuff
            Process proc = new Process();
            
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.WorkingDirectory = "c:\\OBS";
            proc.StartInfo.FileName = "c:\\OBS\\obs.exe";
            proc.StartInfo.Arguments = @"-start -multi -portable";
            proc.StartInfo.UseShellExecute = true;

            proc.Start();


            return proc.Id.ToString();
        }
    }
}
