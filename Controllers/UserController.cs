using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Pongpan.Helper;
using WebAPI_Pongpan.Service;

namespace WebAPI_Pongpan.Controllers
{
    public class UserController : ApiController
    {
        IUserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        // GET: api/User
        //public IEnumerable<string> Get()
        //{
            //return new string[] { "value1", "value2" };
        //}

        public IHttpActionResult GetAllData()
        {
            APIResponse<dynamic> response = new APIResponse<dynamic>() { IsSuccess = true };

            try
            {
                var res = userService.GetAllData();
                response.Data = res;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messege = ex.Message;
                return Ok(response);
            }
        }

        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            APIResponse<dynamic> response = new APIResponse<dynamic>() { IsSuccess = true };

            try
            {
                var res = userService.GetUserById(id);
                response.Data = res;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messege = ex.Message;
                return Ok(response);
            }            
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody]user data)
        {
            APIResponse<dynamic> response = new APIResponse<dynamic>() { IsSuccess = true };
            
            try
            {
                var id = userService.AddUser(data);
                response.Data = id;
                return Ok(response);
            }
            catch(Exception ex) 
            {
                response.IsSuccess = false;
                response.Messege = ex.Message;
                return Ok(response);
            }
        }


        // PUT: api/User/5
        public IHttpActionResult Put(int id ,user data)
        {
            APIResponse<dynamic> response = new APIResponse<dynamic>() { IsSuccess = true };

            try
            {
                var res = userService.UpdateUserById(id ,data);
                response.Data = res;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messege = ex.Message;
                return Ok(response);
            }
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            APIResponse<dynamic> response = new APIResponse<dynamic>() { IsSuccess = true };
            try
            {
                var res = userService.DeleteUserById(id);
                response.Data = res;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messege = ex.Message;
                return Ok(response);
            }
        }
    }
}