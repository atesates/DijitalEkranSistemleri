using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Entities.ComplexTypes.EczaneNobet;
using WM.Northwind.Entities.Concrete.EczaneNobet;
//using WM.Northwind.Entities.Concrete.Optimization.EczaneNobet;

namespace WM.Northwind.Business.Abstract.EczaneNobet
{
    public interface ICozunurlukService
    {
        Cozunurluk GetById(int cozunurlukId);
        List<Cozunurluk> GetList();
        //List<Cozunurluk> GetByCategory(int categoryId);
        void Insert(Cozunurluk cozunurluk);
        void Update(Cozunurluk cozunurluk);
        void Delete(int cozunurlukId);
                        
    }
} 