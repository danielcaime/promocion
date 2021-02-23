using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace promociones.data.Configurations
{
    public interface IPromotionConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string PromotionCollectionName { get; set; }
    }

    public class PromotionConfiguration : IPromotionConfiguration
    {
        public string PromotionCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
