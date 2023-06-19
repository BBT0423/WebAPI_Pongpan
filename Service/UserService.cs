using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Pongpan;
using WebAPI_Pongpan.Repositorys;

namespace WebAPI_Pongpan.Service
{
    public interface IUserService
    {
        int? AddUser(user model);
        GetUserByIdResult GetUserById(int id);
        List<GetAllDataResult> GetAllData();
        int? DeleteUserById(int id);
        UpdateUserByIdResult UpdateUserById(int id, user model);
    }
    public class UserService: IUserService
    {
        IUserRepository userRepository;
        public UserService() 
        { 
            userRepository = new UserRepositorys();
        }

        public int? AddUser(user model)
        {
            if (string.IsNullOrEmpty(model.fullname))
            {
                throw new Exception("Invalid Fullname");
            }

            var res = userRepository.AddUser(model);
            return res;
        }

        public GetUserByIdResult GetUserById(int id) 
        {
            var res = userRepository.GetUserById(id);
            if (id <= 0)
            {
                throw new Exception("Invalid ID");
            }
            return res;
        }

        public List<GetAllDataResult> GetAllData()
        {
            var res = userRepository.GetAllData();
            if (res == null)
            {
                throw new Exception("Invalid Data");
            }          
            return res;
        }

        public int? DeleteUserById(int id)
        {
            var res = userRepository.DeleteUserById(id);
            return res;
        }
        
        public UpdateUserByIdResult UpdateUserById(int id ,user model)
        {
            if (string.IsNullOrEmpty(model.fullname))
            {
                throw new Exception("Invalid Fullname");
            }

            var res = userRepository.UpdateUserById(id ,model);
            return res;
        }
    }
}
  