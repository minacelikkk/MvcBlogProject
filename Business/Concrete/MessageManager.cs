using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAllInbox(string mail)
        {
            return _messageDal.GetAll(m=>m.ReceiverMail== mail);
        }

        public List<Message> GetAllSendbox(string mail)
        {
            return _messageDal.GetAll(m => m.SenderMail == mail);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(m => m.MessageId == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
