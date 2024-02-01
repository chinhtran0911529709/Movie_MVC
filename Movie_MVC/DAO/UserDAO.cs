using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie_MVC.Models;
namespace Movie_MVC.DAO
{
    
    public class UserDAO
    {
        MovieProjectV2Entities db = new MovieProjectV2Entities();

        public int Login(string username, string password, bool isLoginAdmin = false)
        {
            // search account login 
            var account_login = db.Users.Where(s => s.UserName == username).FirstOrDefault();
            // 
            if(account_login == null)
            {
                return 0;
                // return 0 tuc la khong co tai khoan nao co ten nhu the
            }
            else
            {
                if(isLoginAdmin == true)
                {
                    // == true tuc la dang nhap bang admin
                    if(account_login.GroupID == "ADMIN" || account_login.GroupID == "MOD")
                    {
                        if(account_login.Status == false)
                        {
                            // == false tuc la tai khoan k duoc phep hoat dong
                            return -1;
                        }
                        else
                        {
                            if(account_login.Password == password)
                            {
                                return 1;
                            }
                            else
                            {
                                return -2;
                            }
                        }
                    }
                    else
                    {
                        return -4;
                    }
                }
                else
                {
                    return -3;
                }
            }
        }
        public User GetByUserName(string username)
        {
            return db.Users.Where(s => s.UserName == username).FirstOrDefault();
            
        }
    }
}