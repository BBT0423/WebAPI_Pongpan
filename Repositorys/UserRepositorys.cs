using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Pongpan.Models;

namespace WebAPI_Pongpan.Repositorys
{
    public interface IUserRepository
    {
        int? AddUser(user model);
        GetUserByIdResult GetUserById(int id);
        List<GetAllDataResult> GetAllData();
        int? DeleteUserById(int id);
        UpdateUserByIdResult UpdateUserById(int id, user model);
    }
    
    public class UserRepositorys: IUserRepository
    {
        DbConnection connection = new DbConnection();
        DataClasses1DataContext context;
        public UserRepositorys()
        {
            context = connection.GetConnection();
        }

        public int? AddUser(user model)
        {
            var res = context.AddUser(model.fullname,model.email,model.age,model.phone,model.address).SingleOrDefault(); //SingleOrDefault = การ return ค่าให้ได้ผลลัพธ์เดียว 1 แถว
            if(res == null)
            {
                return null;
            }
            //id จากค่าการ return จาก SQL
            return res.id;
        }

        public GetUserByIdResult GetUserById(int id) 
        {         
            GetUserByIdResult res = context.GetUserById(id).SingleOrDefault();
            if (res == null)
            {
                return null;
            }
            return res;
        }

        public List<GetAllDataResult> GetAllData()
        {
            var res = context.GetAllData().ToList();
            if (res == null)
            {
                return null;
            }
            return res;
        }

        public int? DeleteUserById(int id)
        {
            var res = context.DeleteUser(id);
            return res;
        }
        
        public UpdateUserByIdResult UpdateUserById(int id, user model)
        {
            UpdateUserByIdResult res = context.UpdateUserById(model.id,model.fullname,model.email,model.age,model.phone,model.address).SingleOrDefault();
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}