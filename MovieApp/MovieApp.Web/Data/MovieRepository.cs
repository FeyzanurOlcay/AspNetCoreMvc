using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using MovieApp.Web.Models;
using System.Linq;

namespace MovieApp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;
        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie
                {
                    MovieId = 1,
                    Title = "Deadpool",
                    Description = "Deadpool, intikam almak için hayatını değiştiren bir deneyin ardından olağanüstü yeteneklere sahip olan eski bir özel asker Wade Wilson'ın hikayesini anlatıyor.Yıkıcı bir kahraman olarak, Deadpool kötülükle savaşırken acımasız mizahını kullanıyor.",
                    Director = "Tim Miller",
                    Players = new string[] { "Ryan Reynolds", "Morena Baccarin", "T.J. Miller", "Ed Skrein"  },
                    ImageUrl = "1.jpg",
                    GenreId=1
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Deadpool 2",
                    Description = "Deadpool 2, Wade Wilson'ın (Deadpool) hayatının zorluklarıyla yüzleşmesini ve bir grup süper kahramanla birlikte dünyayı koruma mücadelesini konu alıyor. Bu filmde Deadpool, geçmişiyle yüzleşmeye ve yeni arkadaşlar edinmeye çalışırken, eski düşmanlarıyla tekrar karşılaşır.",
                    Director = "David Leitch",
                    Players = new string[] { "Ryan Reynolds", "Josh Brolin", "Morena Baccarin", "T.J. Miller", "Zazie Beetz"  },
                    ImageUrl = "2.jpg",
                     GenreId=1

                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Deadpool 3",
                    Description = "Deadpool 3, Wade Wilson (Deadpool) ve sevdiklerinin yeni bir maceraya atıldığı, zaman yolculuğu ve yeni süper kahraman karakterlerinin tanıtıldığı aksiyon dolu bir devam filmidir. Deadpool, geçmiş ve gelecek arasındaki sınırları zorlayarak, yeni düşmanlarla mücadele ederken, daha önce hiç görülmemiş kahramanlarla işbirliği yapar.",
                    Director = "Shawn Levy",
                    Players = new string[] {  "Ryan Reynolds", "Hugh Jackman", "Vanessa Kirby", "Karan Soni", "Morena Baccarin" },
                    ImageUrl = "3.jpg",
                    GenreId=4

                },
                new Movie
                {
                    MovieId = 4,
                    Title = "Titanic",
                    Description = "Titanic, 1912 yılında batmak üzere olan ünlü yolcu gemisi Titanic'te geçen bir aşk hikayesini anlatıyor. Rose, zengin bir genç kadın, Jack ise fakir bir sanatçıdır. İkisi arasındaki tutkulu aşk, geminin trajik batışı sırasında hayatta kalma mücadelesi verirken gelişir.",
                    Director = "James Cameron",
                    Players = new string[] { "Leonardo DiCaprio", "Kate Winslet", "Billy Zane", "Danny Nucci", "Jonathan Hyde"},
                    ImageUrl = "4.jpg",
                     GenreId=3
                },
                new Movie
                {
                    MovieId = 5,
                    Title = "Joker",
                    Description = "Joker, toplumsal dışlanma ve kişisel travmalarla boğuşan Arthur Fleck'in trajik hikayesini anlatıyor. Bir komedyen olarak kariyer yapmak isteyen Arthur, toplumun acımasızlığına karşı tepki olarak Joker'a dönüşür. Film, karakterin karanlık yolculuğunu ve Gotham şehrinin çöküşünü ele alıyor.",
                    Director ="Todd Phillips",
                    Players = new string[] { "Joaquin Phoenix", "Robert De Niro", "Zazie Beetz", "Frances Conroy", "Brett Cullen"  },
                    ImageUrl = "5.jpg",
                    GenreId=4
                },
                new Movie
                {
                    MovieId = 6,
                    Title = "Interstellar",
                    Description = "Interstellar, insanlığın hayatta kalabilmesi için uzaya yapılan bir keşif yolculuğunu konu alıyor. Dünya'nın yaşanmaz hale gelmesinin ardından, bir grup astronot farklı galaksilere doğru yol alarak yeni bir yaşam alanı aramaya başlar. Film, zaman, uzay ve insanlığın varoluşu üzerine derin felsefi sorular soruyor.",
                    Director =  "Christopher Nolan",
                    Players = new string[] {  "Matthew McConaughey", "Anne Hathaway", "Jessica Chastain", "Michael Caine", "Matt Damon" },
                    ImageUrl = "6.jpg",
                    GenreId=1
                }
            }
            ;
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }

        }
        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie);
        }
        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }
        public static void Edit(Movie m)
        {
            foreach (var movie in _movies)
            {
                if(movie.MovieId == m.MovieId)
                {
                    movie.Title = m.Title;
                    movie.Description = m.Description;
                    movie.Director = m.Director;
                    movie.ImageUrl = m.ImageUrl;
                    movie.GenreId = m.GenreId;
                    break;

                }
            }
        }
    }
}
