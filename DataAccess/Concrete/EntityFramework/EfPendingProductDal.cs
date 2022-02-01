using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPendingProductDal : EfEntityRepositoryBase<PendingProducts, EmrOrgContext>, IPendingProductsDal
    {
        public List<PendingRequestDetailDto> GetPendingRequestDetailDto(Expression<Func<PendingProducts, bool>> filter = null)
        {
            using (var context = new EmrOrgContext())

            {
                var product = from pp in filter == null ? context.pending_product : context.pending_product.Where(filter)
                              join user in context.users 
                              on pp.UserId equals user.Id
                             join p in context.product
                             on pp.ProductId equals p.Id
                             join address in context.address
                             on pp.UserId equals address.UserId
                              select new PendingRequestDetailDto
                              {
                                  TotalPrice = pp.TotalPrice,
                                  isDone=pp.isDone,
                                 Street=address.Street,
                                 FirstName =  user.FirstName,
                                 City = address.City,
                                 ProductDate=pp.ProductDate,
                                 Quantity=pp.Quantity,
                                 ExtraDescription = address.ExtraDescription,
                                 Email = user.Email,
                                 HouseId = address.HouseId,
                                 Id = pp.Id,
                                 IsConfirmed = user.IsConfirmed,
                                 LastName = user.LastName,
                                 Neighborhood = address.Neighborhood,
                                 PhoneNumber = user.PhoneNumber,
                                 ProductId = p.Id,
                                 ProductName = p.ProductName,
                                 ProductShortDescription = p.ProductShortDescription
                              };
                return product.ToList();
            }
        }
    }
}
