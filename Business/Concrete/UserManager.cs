using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        private EfUserDal efUserDal;

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
        public IDataResult<User> AcceptsRequest(int userId)
        {
            
            var user = _userDal.Get(p => p.Id == userId);
            //var tempUser = new User
            //{
            //    FirstName = user.FirstName,
            //    Email = user.Email,
            //    Id = user.Id,

            //    IsConfirmed = user.IsConfirmed,
            //    LastName = user.LastName,
            //    PasswordHash = null,
            //    PasswordSalt = null,
            //    PhoneNumber = user.PhoneNumber
            //};
            if (user.IsConfirmed == 0)
            {
                user.IsConfirmed = 1;
                _userDal.Update(user);
                return new SuccessDataResult<User>(user);
            }
            
                return new ErrorDataResult<User>(user);
            
            
            
        }
  
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> RedRequest(int userId)
        {
          var user =  _userDal.Get(p => p.Id == userId);
            var tempUser = new User
            {
                FirstName = user.FirstName,
                Email = user.Email,
                Id = user.Id,

                IsConfirmed = user.IsConfirmed,
                LastName = user.LastName,
                PasswordHash = null,
                PasswordSalt = null,
                PhoneNumber = user.PhoneNumber
            };
            user.IsConfirmed = 2;
                _userDal.Update(user);
                return new SuccessDataResult<User>(tempUser);

                return new ErrorDataResult<User>(tempUser);
  
     
        }
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

        public IDataResult<User> SendConfirmationRequest(int userId)
        {
            var user = _userDal.Get(p => p.Id == userId);
            var tempUser = new User
            {
                FirstName = user.FirstName,
                Email = user.Email,
                Id = user.Id,

                IsConfirmed = user.IsConfirmed,
                LastName = user.LastName,
                PasswordHash = null,
                PasswordSalt = null,
                PhoneNumber = user.PhoneNumber
            };
            user.IsConfirmed = 0;
            
            _userDal.Update(user);
            return new SuccessDataResult<User>(tempUser);

        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
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

        public IDataResult<List<User>> GetAcceptRequest()
        {

            var result = _userDal.GetAll(u => u.IsConfirmed == 1);

            foreach (var res in result)
            {
                res.PasswordHash = null;
                res.PasswordSalt = null;
            }

            return new SuccessDataResult<List<User>>(result, "Listelendi");
        }

        public IDataResult<List<User>> GetRetailUser()
        {

            var result = _userDal.GetAll(u => u.IsConfirmed == 2);

            foreach (var res in result)
            {
                res.PasswordHash = null;
                res.PasswordSalt = null;
            }

            return new SuccessDataResult<List<User>>(result, "Listelendi");
        }

        public IDataResult<User> GivePermission(int userId, int permId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            var operationClaim = _userOperationClaimManager.GetById(userId);

            var tempUser = new User
            {
                FirstName = user.FirstName,
                Email = user.Email,
                Id = user.Id,

                IsConfirmed = user.IsConfirmed,
                LastName = user.LastName,
                PasswordHash = null,
                PasswordSalt = null,
                PhoneNumber = user.PhoneNumber
            };
            _userOperationClaimManager.Update(new UserOperationClaim
            {
                OperationClaimId = permId,
                UserId = user.Id
            });
            return new SuccessDataResult<User>(tempUser);
           
            
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
          
           
          
            return new SuccessDataResult<List<UserForListDto>>(_userDal.GetUserForListDtos());
        }
    }
}