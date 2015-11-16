using System.Collections.Generic;
using System.Linq;

namespace MovieStoreDAL.Bll.MovieDto
{
    public abstract class AbstractDtoConverter<T,TD>
    {

       public IEnumerable<TD> Convert(IEnumerable<T> toConvert)
       {
           return toConvert.Select(item => Convert((T) item)).ToList();
       }

        public abstract TD Convert(T item);
    }

    }

