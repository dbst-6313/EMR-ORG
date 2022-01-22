using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [SecuredOperation("accept.request,Admin")]
        public IResult AcceptsRequest(int userId)
        {
            
            var user = _userDal.Get(p => p.Id == userId);
            if(user.IsConfirmed == 0)
            {
                user.IsConfirmed = 1;
                _userDal.Update(user);
                return new SuccessResult("sa");
            }
            else
            {
                return new ErrorResult("");
            }
            
            
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
        [SecuredOperation("admin")]
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

    }
}