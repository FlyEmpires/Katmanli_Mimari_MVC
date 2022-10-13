using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ChartManager : IChartService
    {
        IChartDal _chartDal;

        public ChartManager(IChartDal chartDal)
        {
            _chartDal = chartDal;
        }

        public List<Category> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
