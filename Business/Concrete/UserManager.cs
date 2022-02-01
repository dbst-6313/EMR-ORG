using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IUserOperationClaimService  _userOperationClaimManager;

        public UserManager(IUserDal userDal, IUserOperationClaimService userOperationClaimManager)
        {
            _userDal = userDal;
            _userOperationClaimManager = userOperationClaimManager;
        }


        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [SecuredOperation("admin")]
        public IResult AcceptsRequest(int userId)
        {
            
            var user = _userDal.Get(p => p.Id == userId);
            if(user.IsConfirmed == 0)
            {
                user.IsConfirmed = 1;
                _userDal.Update(user);
                return new SuccessResult("sa");
            }
            
                return new ErrorResult("");
            
            
            
        }
  
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        [SecuredOperation("admin")]
        public IResult RedRequest(int userId)
        {
          var user =  _userDal.Get(p => p.Id == userId);
            if (user.IsConfirmed == 0 )
            {
                user.IsConfirmed = 2;
                _userDal.Update(user);
                return new SuccessResult("Sa");

            }
            else
            {
                return new ErrorResult();
            }
           

        }
        [SecuredOperation("admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id));
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult SendConfirmationRequest(int userId)
        {
            var user = _userDal.Get(p => p.Id == userId);
            user.IsConfirmed = 0;
            _userDal.Update(user);
            return new SuccessResult();

        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        public IDataResult<List<User>> GetPendingRequests()
        {

            var result = _userDal.GetAll(u => u.IsConfirmed == 0);
           
            foreach (var res in result)
            {
                res.PasswordHash = null;
                res.PasswordSalt = null;
            }

            return new SuccessDataResult<List<User>>(result, "Listelendi");
        }

        public IResult GivePermission(int userId, int permId)
        {
            var data = _userDal.Get(u => u.Id == userId);
            var operationClaim = _userOperationClaimManager.GetById(userId);


            _userOperationClaimManager.Add(new UserOperationClaim
            {
                OperationClaimId = permId,
                UserId = data.Id
            });
            return new SuccessResult();
           
            
        }

        public IResult DeletePermission(int userId)
        {
            var data = _userOperationClaimManager.GetAll().Data;
            foreach (var datas in data)
            {
                if(datas.UserId == userId)
                {
                    var claim = _userOperationClaimManager.GetById(datas.UserId);
                    _userOperationClaimManager.Delete(claim.Data);
                }
            }
                
            return new SuccessResult();
        }

        public IResult UpdatePermission(int userId, int permId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UserForListDto>> GetUserForListDto()
        {
            return new SuccessDataResult<List<UserForListDto>>(_userDal.GetUserForListDtos(), "s");
        }
    }
}