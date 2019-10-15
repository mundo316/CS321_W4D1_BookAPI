using System;
using CS321_W4D1_BookAPI.Models;
using System.Collections.Generic;
namespace CS321_W4D1_BookAPI.Services
{
    
    public interface IPublisherService
        {
            // create
            Publisher Add(Publisher publisher);
        // read
            Publisher Get(int id);
        // update
            Publisher Update(Publisher updatedPublisher);
        // delete
            void Remove(Publisher publisher);
        // list
            IEnumerable<Publisher> GetAll();
    }
    
}
