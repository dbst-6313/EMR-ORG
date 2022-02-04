using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int Id);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<User> SendConfirmationRequest(int userId);
        IDataResult<User> AcceptsRequest(int userId);
        IDataResult<User> RedRequest(int userId);
        IDataResult<List<User>> GetPendingRequests();
        IDataResult<List<User>> GetAcceptRequest();
        IDataResult<List<User>> GetRetailUser();
        IDataResult<List<UserForListDto>> GetUserForListDto();
        IDataResult<User> GivePermission(int userId,int permId);
        IResult DeletePermission(int userId);

        IResult UpdatePermission(int userId, int permId);
    }
}
