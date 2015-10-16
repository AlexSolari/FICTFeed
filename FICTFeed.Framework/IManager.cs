using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Framework
{
    public interface IManager<TType>
    {
        TType GetById(string id);

        void Create(TType model);
    }
}
