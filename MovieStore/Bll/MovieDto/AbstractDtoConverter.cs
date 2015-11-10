using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.MovieDto
{
    public abstract class AbstractDtoConverter<T,TD>
    {

       public IEnumerable<TD> Convert(IEnumerable<T> toConvert)
       {
           return toConvert.Select(item => Convert(item)).ToList();
       }

        public abstract TD Convert(T item);
    }

    }

