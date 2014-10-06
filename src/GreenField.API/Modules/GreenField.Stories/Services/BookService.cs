using GreenField.Books.Data;
using GreenField.Books.Data.DomainModels;
using GreenField.Framework.Data;
using System.Collections.Generic;
using System.Linq;

namespace GreenField.Books.Services
{
    public interface IStoryService
    {
        List<Story> GetAll();
    }

    public class StoryService : IStoryService
    {
        private readonly IRepository<Story> _storyRepository;

        public StoryService()
        {
            _storyRepository = new EfRepository<Story>(new StoryContext());
        }

        public List<Story> GetAll()
        {
            return _storyRepository.Table.ToList();
        }
    }
}
