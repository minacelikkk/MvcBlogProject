using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll(string p);
        List<Content> GetAll();
        List<Content> GetAllByHeadingId(int headingId);
        List<Content> GetAllByWriter(int writerId);
        void Add(Content content);
        void Delete(Content content);
        void Update(Content content);
        Content GetById(int id);
    }
}
