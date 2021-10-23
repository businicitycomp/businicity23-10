using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnicityApp.InterFaces
{
   public interface AddAdmin<TEntity>
    {
        void Add(TEntity entity);

    }
}
