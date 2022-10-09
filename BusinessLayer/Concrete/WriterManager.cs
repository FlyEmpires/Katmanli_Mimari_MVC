using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;


        //WriterManager Üstüne ALT + ENTER Yoluyla Generate Constructor Seçilerek Oluşturuldu.
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID==id);

        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        //public List<Content> GetListByWriterSession(string p,int id)
        //{
        //    //var writeridinfo = _writerDal.Get(x => x.WriterMail == p &&x.WriterID==id);

        //    return 
        //}
        public int GetByEmailID(string mail)
        {
            //p = (string)HttpContext.Current.Session["WriterMail"];
            return _writerDal.List(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
        }
       

            //return (string)HttpContext.Current.Session["WriterMail"];

        
        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);

        }
    }
}
