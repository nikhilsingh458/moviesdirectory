using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;

namespace omdbios
{
	public class OMDBService
	{
		const string omdbUrl = "http://www.omdbapi.com/?"; // Base omdb api URL
		public string omdbKey; // A key is required for poster images.
		public Movie newMovie; // Initialize movie object
		public MovieList newMovieList; // Initialize movie list object

		public OMDBService ()
		{
		}

		public async Task<Movie> GetMovie(string query, string apiKey = "")
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(omdbUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(omdbUrl + "t=" + query);
				if (response.IsSuccessStatusCode)
				{
					newMovie = await response.Content.ReadAsAsync<Movie>();
					return newMovie;
				}
				else
				{
					return null;
				}
			}
		}


		public async Task<MovieList> GetMovieList(string query, string apiKey = "")
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(omdbUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(omdbUrl + "s=" + query);
				if (response.IsSuccessStatusCode)
				{
					newMovieList = await response.Content.ReadAsAsync<MovieList>();
					return newMovieList;
				}
				else
				{
					return null;
				}
			}
		}


		public async Task<MovieList> GetEpisodesAndSeriesList(string query,string episodeorseries, string apiKey = "")
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(omdbUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(omdbUrl + "s=" + query +"&type="+ episodeorseries);
				if (response.IsSuccessStatusCode)
				{
					newMovieList = await response.Content.ReadAsAsync<MovieList>();
					return newMovieList;
				}
				else
				{
					return null;
				}
			}
		}
	}
}

