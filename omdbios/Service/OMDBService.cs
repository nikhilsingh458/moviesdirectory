using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Json;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using MoviesDirectory.Enums;
using System.Linq;

namespace MoviesDirectory
{
	/// <summary>
	/// OMDB service.Service class to fetch the response
	/// </summary>
	public class OMDBService
	{
		#region Members

		const string omdbUrl = "http://www.omdbapi.com/?"; // Base omdb api URL
		public string omdbKey; // A key is required for poster images.
		public Movie movie; // Initialize movie object
		public Movie movieList; // Initialize movie list object
		private bool loop = false;

		#endregion

		#region Static Methods

		/// <summary>
		/// Gets the instanse.
		/// </summary>
		/// <returns>The instanse.</returns>
		public static OMDBService GetInstanse()
		{
			return new OMDBService ();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Gets the movie details asynchronously
		/// </summary>
		/// <returns>Movie details</returns>
		/// <param name="query">search query passed from user</param>
		/// <param name="apiKey">API key(if available).</param>
		public async Task<Movie> GetMovie(string query, string apiKey = ""){
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(omdbUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(omdbUrl + "t=" + query);
				if (response.IsSuccessStatusCode)
				{
					movie = await response.Content.ReadAsAsync<Movie>();
					return movie;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Gets the movie list response asynchronously
		/// </summary>
		/// <returns>List of movies based on search parameters</returns>
		/// <param name="query">search query entered by user</param>
		/// <param name="apiKey">API key(if available).</param>
		public async Task<Movie> GetMovieList(string query, string apiKey = ""){
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(omdbUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(omdbUrl + "s=" + query);
				if (response.IsSuccessStatusCode)
				{
					movieList = await response.Content.ReadAsAsync<Movie>();
					return movieList;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Gets the episodes and series list based on type of movie and name asynchronously.
		/// </summary>
		/// <returns>The episodes and series list.</returns>
		/// <param name="query">Search text entered by user</param>
		/// <param name="episodeorseries">type - Episode or series.</param>
		/// <param name="apiKey">API key(if available).</param>
		public async Task<Movie> GetEpisodesAndSeriesList(string query,string episodeorseries, string apiKey = ""){
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(omdbUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(omdbUrl + "s=" + query +"&type="+ episodeorseries);
				if (response.IsSuccessStatusCode)
				{
					movieList = await response.Content.ReadAsAsync<Movie>();
					return movieList;
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Get the specified requestType, data and timeOut.
		/// </summary>
		/// <param name="requestType">Request type.Weather Movie name or details</param>
		/// <param name="data">key passed from the UI layer</param>
		/// <param name="timeOut">Response Time out.</param>
		public async Task<JsonValue> Get(RequestType requestType, Dictionary<string, string> data, int timeOut)
		{
			new HttpClient()
			{
				Timeout = TimeSpan.FromMilliseconds(3000)
			};
			string url;
			string method;
			switch (requestType)
			{
			case RequestType.FIND_MOVIE:
				url = "http://www.omdbapi.com/";
				method = "GET";
				break;

			case RequestType.MOVIE_DATA:
				url = "http://www.omdbapi.com/";
				method = "GET";
				break;

			default:
				url = "";
				method = "GET";
				break;
			}

			try
			{
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url + buildParams(data)));
				request.ContentType = "application/json";
				request.Method = method;

				// Send the request to the server and wait for the response:
				using (WebResponse response = await request.GetResponseAsync())
				{
					// Get a stream representation of the HTTP web response:
					using (Stream stream = response.GetResponseStream())
					{
						// Use this stream to build a JSON document object:
						JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
						Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
						// Return the JSON document:
						return JsonValue.Parse(jsonDoc.ToString());
					}
				}
			}
			catch (HttpRequestException e)
			{
				Console.Write (e.Message);
				return null;
			}
			finally
			{
				Thread.Sleep(timeOut);
			}
		}

		/// <summary>
		/// Get the specified requestType and data.
		/// </summary>
		/// <param name="requestType">Request type.</param>
		/// <param name="data">Data.</param>
		public async Task<JsonValue> Get(RequestType requestType, Dictionary<string, string> data)
		{
			return await Get(requestType, data, 0);
		}

		/// <summary>
		/// Loops the request.
		/// </summary>
		/// <param name="requestType">Request type.</param>
		/// <param name="data">Data.</param>
		/// <param name="timeout">Timeout.</param>
		public async void loopRequest(RequestType requestType, Dictionary<string, string> data, int timeout)
		{
			loop = true;
			while (loop)
			{
				await Get(requestType, data, timeout);
			}
		}

		/// <summary>
		/// Stops the loop.
		/// </summary>
		public void stopLoop()
		{
			loop = false;
		}

		/// <summary>
		/// Builds the parameters and append.
		/// </summary>
		/// <returns>The parameters.</returns>
		/// <param name="data">Data.</param>
		public string buildParams(Dictionary<string, string> data)
		{
			if (data != null && data.Count > 0)
			{
				String parameters = data.Keys.Aggregate("?", (current, item) => current + (item + "=" + data[item] + "&"));
				parameters.Substring(0, parameters.Length - 2);
				return parameters;
			}
			return "";
		}
		#endregion

	}

	}
