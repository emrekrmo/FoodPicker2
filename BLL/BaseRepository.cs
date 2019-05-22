using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repos
{
    public class BaseRepository<TEntity, TKey> where TEntity : class
    {
        FoodContext _db;

        public BaseRepository(FoodContext db)
        {
            _db = db;
        }

        public List<TEntity> Listele()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity IdIleGetir(TKey id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Sil(TKey id)
        {
            var silinecek = IdIleGetir(id);
            _db.Set<TEntity>().Remove(silinecek);
        }

        public void Ekle(TEntity yeni)
        {
            _db.Set<TEntity>().Add(yeni);
        }

        public void Guncelle(TEntity guncel)
        {
            Type t = typeof(TEntity);
            string classAdi = t.Name;
            //var idProp = t.GetProperty(classAdi + "Id");
            var idProp = t.GetProperty("Id");
            TKey id = (TKey)idProp.GetValue(guncel);

            var eski = IdIleGetir(id);
            _db.Entry(eski).CurrentValues.SetValues(guncel);
        }



        public int RandomGenerator(int val)
        {
            Random rnd = new Random();
            int RandomNum = rnd.Next(0, val);
            return RandomNum;
        }



        public string Recommend()
        {



            List<int> positions = new List<int>();
            List<int> foods = new List<int>();


            foreach (var row in _db.Foods)
            {
                //foods.Add(row.FoodId);
                foods.Add(row.Id);
            }



            for (int i = 0; i < _db.Foods.Count(); i++)
            {


                positions.Add(i);

            }

            int[] positionsArray = positions.ToArray();
            int randomPosition = positions[RandomGenerator(positionsArray.Length)];
            return positionsArray[randomPosition].ToString();


        }
    }
}

