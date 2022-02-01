using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entity.Concrete;

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

        public List<UserForListDto> GetUserForListDtos()
        {
            using (var context = new EmrOrgContext())
            {
                var result = from user in context.users
                             join userOperationClaim in context.user_operation_claims
                             on user.Id equals userOperationClaim.UserId
                             join operationClaims in context.operation_claims
                             on userOperationClaim.OperationClaimId equals operationClaims.Id
                             
                             select new UserForListDto
                             {
                                 ClaimName = operationClaims.Name,
                                 FirstName = user.FirstName,
                                 Email = user.Email,
                                 Id = user.Id,
                                 LastName = user.LastName 
                                 ,OperationClaimId = operationClaims.Id,
                                 PhoneNumber = user.PhoneNumber,
                                 UserOperationClaimId= userOperationClaim.Id
                                 
                             };
            

                return result.ToList();

            }
        }
    }
}
