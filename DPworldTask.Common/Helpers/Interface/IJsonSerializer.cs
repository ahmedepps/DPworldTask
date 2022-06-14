using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPworldTask.Common.Helpers.Interface
{
    public interface IJsonSerializer
    {
        string SerializeObject(IEnumerable<object> data);

        string SerializeObject(object data);

    }
}
