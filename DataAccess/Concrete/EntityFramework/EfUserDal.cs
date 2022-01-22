using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,EmrOrgContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EmrOrgContext())
            {
                var result = from oc in context.operation_claims
                             join uoc in context.user_operation_claims
                             on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = oc.Id,
                                 Name = oc.Name
                             };

                return result.ToList();

            }
        }
    }
}
