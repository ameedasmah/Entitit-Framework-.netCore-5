using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.Resourse;

namespace WebApplication1.Helper
{
    public static class Extinsion
    {
        public static BookResourse ToResource(this Book entitiy)
        {
            return new BookResourse()
            {
                Id = entitiy.Id,
                PublisherId = entitiy.PublisherId,
                Title = entitiy.Title,
                discraptions = entitiy.Discraptions,
                publisher = entitiy.Publisher
            };
        }

        public static BookLightResource ToLightResource(this Book entitiy)
        {
            return new BookLightResource()
            {
                Id = entitiy.Id,
                Title = entitiy.Title,
                discraptions = entitiy.Discraptions
            };
        }


        

        public static PublisherResourse ToResource(this Publisher entities)
        {
            return new PublisherResourse()
            {
                Id = entities.Id,
                Name = entities.Name,
                Books = entities.Books.Select(x => x.ToLightResource()).ToList()
            };
        }


        public static Book_AuthorsResourse ToResource(this Book_Author entities)
        {
            return new Book_AuthorsResourse()
            {
                //Id = entities.Id,
               BookId = entities.BookId,
               AuthorId= entities.AuthorId
            };
        }



        public static NewBookResourse ToResourceNew(this Book entitiy)
        {
            return new NewBookResourse()
            {
                Id = entitiy.Id,
                PublisherId = entitiy.PublisherId,
                discraptions = entitiy.Discraptions,
                Title = entitiy.Title,
                Newpublisher = entitiy.Publisher.ToResourceNew(),
                book_Authors = entitiy.book_Authors?.Select(x => new Book_AuthorsResourse { AuthorId = x.AuthorId, BookId = x.BookId }).ToList(),
            };
        }




        public static List<Book_AuthorsResourse> ToResource(this List<Book_Author> Entitiy)
        {
            var responseBookAuthor = new List<Book_AuthorsResourse>();
            foreach(var item in Entitiy)
            {
                responseBookAuthor.Add(item.ToResource());
            }
            return responseBookAuthor;
        }

        public static PublisherBookResourse ToResourceNew(this Publisher entities)
        {
            return new PublisherBookResourse()
            {
                Id = entities.Id,
                Name = entities.Name,
            };
        }



        public static AuthorResource ToResource(this Author entitiy)
        {
            return new AuthorResource()
            {
                FullName = entitiy.FullName,
                Id = entitiy.Id
            };

        }
        //public static newPublisherResource ToResourceTry(this Publisher Entitiy)
        //{
        //    return new newPublisherResource
        //    {
        //        Id = Entitiy.Id,
        //        Name = Entitiy.Name,
        //        Books = Entitiy.Books?.ToResourcseTry()
        //    };
        //}

        //public static BookWithPublisherResourcse ToResourceTry(this Book Entitiy)
        //{
        //    return new BookWithPublisherResourcse
        //    {
        //        Id = Entitiy.Id,
        //        Title = Entitiy.Title,
        //        discraptions = Entitiy.Discraptions,
        //    };
        //}

        //public static List<PublisherBookResourse> ToResourcseTry(this List<BookWithPublisherResourcse> publishers)
        //{
        //    var ResponsePublisherBook = new List<PublisherBookResourse>();
        //    foreach(var item in Entities)
        //    {
        //        ResponsePublisherBook.Add(item.ToResourceTry());
        //    }
        //    return ResponsePublisherBook;
        //}

    }
}


