using System;
using CS321_W4D1_BookAPI.Models;
using CS321_W4D1_BookAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace CS321_W4D1_BookAPI.Services

{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.Publishers.ToList();
        }

        public Publisher Get(int publisherId)
        {
            return _bookContext.Publishers.FirstOrDefault(p => p.Id == publisherId);

        }

        public Publisher Add(Publisher publisher)
        {
            _bookContext.Publishers.Add(publisher);
            _bookContext.SaveChanges();
            return publisher;


        }
        public Publisher Update(Publisher updatedPublisher)
        {
            var currentPublisher = this.Get(updatedPublisher.Id);
            if (currentPublisher == null) return null;
            _bookContext.Entry(currentPublisher).CurrentValues.SetValues(updatedPublisher);
            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
        }
        public void Remove(Publisher publisher)
        {
            _bookContext.Publishers.Remove(publisher);
            _bookContext.SaveChanges(); //update the database
        }
    }
}
