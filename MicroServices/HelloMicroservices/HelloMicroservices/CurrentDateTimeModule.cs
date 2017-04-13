using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMicroservices
{
    using Nancy;

    public class CurrentDateTimeModule: NancyModule 
    {
        public CurrentDateTimeModule()
        {
            Get("/", _ => DateTime.UtcNow);
        }
    }
}
