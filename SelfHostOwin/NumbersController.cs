using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostOwin
{
    public class NumbersController : ApiController
    {
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(0, 10);
        }
    }
}
