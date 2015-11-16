namespace MovieStoreDAL.Bll.MovieDto
{
    public class MovieConverter : AbstractDtoConverter<Movie, MovieDto>
    {
        private decimal USDDKKKurs = 5.8M;
        public override MovieDto Convert(Movie item)
        {
            var dto = new MovieDto()
            {
               Id = item.Id,
               Title = item.Title,
               Genre = item.Genre,
               ImageUrl = item.ImageUrl,
               TrailerUrl = item.TrailerUrl,
               Year = item.Year,
               Price = item.Price,
               USDPrice = item.Price/USDDKKKurs
            };
            return dto;
        }

        
    }
}

