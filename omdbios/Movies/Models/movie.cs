using System;

namespace MoviesDirectory
{
	/// <summary>
	/// Movie model class
	/// </summary>
    public class Movie
    {
            public string Title { get; set; }
			public string Year { get; set; }
            public string Rated { get; set; }
            public string Released { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Writer { get; set; }
            public string Actors { get; set; }
            public string Language { get; set; }
            public string Country { get; set; }
            public string Awards { get; set; }
            public string Poster { get; set; }
			public string IMDBRating { get; set; }
			public string ImdbVotes { get; set; }
            public string IMDBID { get; set; }
            public string Type { get; set; }
    }
}