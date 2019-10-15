using CS321_W4D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W4D1_BookAPI.ApiModels
{
    public static class BookMappingExtenstions
    {

        public static BookModel ToApiModel(this Book needstobeconvertedbook)
        {
            //: map the Book domain object to a BookModel
            return new BookModel
            { 
                Id = needstobeconvertedbook.Id,
                Title = needstobeconvertedbook.Title,
                Genre = needstobeconvertedbook.Genre,
                OriginalLanguage = needstobeconvertedbook.OriginalLanguage,
                PublicationYear = needstobeconvertedbook.PublicationYear,
                PublisherId = needstobeconvertedbook.PublisherId,
                Publisher = needstobeconvertedbook.Publisher != null
                    ? needstobeconvertedbook.Publisher.Name +
                        ", " + needstobeconvertedbook.Publisher.HeadQuartersLocation
                    : "NA",
                AuthorId = needstobeconvertedbook.AuthorId,
                Author = needstobeconvertedbook.Author != null
                    ? needstobeconvertedbook.Author.LastName +
                        ", " + needstobeconvertedbook.Author.FirstName
                    : "NA"
             };          
        }

        public static Book ToDomainModel(this BookModel bookModel)
        {                                   //  Id     = bookmodel.Id
            //: map the BookModel to a Book domain object
            return new Book
            {
                
                Id = bookModel.Id,
                Title = bookModel.Title,
                Genre = bookModel.Genre,
                OriginalLanguage = bookModel.OriginalLanguage,
                PublicationYear = bookModel.PublicationYear,
                PublisherId = bookModel.PublisherId,
                AuthorId = bookModel.AuthorId,
                // Note that we don't set the Publisher or Author object properties. 
                // Setting the PublisherId and AuthorId fields is enough.
                
            };
        }

        public static IEnumerable<BookModel> ToApiModels(this IEnumerable<Book> authors)
        {
            return authors.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Book> ToDomainModel(this IEnumerable<BookModel> authorModels)
        {
            return authorModels.Select(a => a.ToDomainModel());
        }
    }
}
