﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(w => w.WriterId == id);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
