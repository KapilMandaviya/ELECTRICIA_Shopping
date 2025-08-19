using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace RepositoryLayer.IRepo
{
    public interface IProductServiceDetails
    {
        Task<List<ProductsMaster_DTO>> getProductCategoryListDetils(int category);
        Task<ProductsMaster_DTO> getProductDetils(int productId);
    }
}
