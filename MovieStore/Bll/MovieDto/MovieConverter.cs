﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreDAL;

namespace Bll.MovieDto
{
    public class MovieConverter : AbstractDtoConverter<Movie, MovieDto>
    {
        public override MovieDto Convert(Movie item)
        {
            var dto = new MovieDto()
            {
               dto.id
                

            };
            return null;
        }
    }
}

