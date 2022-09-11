using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : Entity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Günlük Fiyatı
        /// </summary>
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public virtual Brand? Brand { get; set; }
        public Model():base()
        {
            Brand=new Brand();
        }

        public Model(int id, int brandId, string name, decimal dailyPrice, string imageUrl) : base(id)
        {

            BrandId = brandId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;

        }
        public Model(int id, int brandId, string name, decimal dailyPrice, string imageUrl, Brand brand) : this(id, brandId, name, dailyPrice, imageUrl)
        {
            Brand = brand;
        }
    }
}
