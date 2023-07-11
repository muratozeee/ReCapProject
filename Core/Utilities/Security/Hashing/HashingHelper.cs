using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //we created passwordHash
        //also it will create the salt
        //out= we are giving out the reference
        //taking password and we are giving out passwordHash and out passwordSalt
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            //IDisposible pattern
            //hmac=crypto  class
            //we are creating the cyrptograhy method using Sha512 algorithm
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                //we are giving out with hcmac.key
                //every each user has a different key.
                passwordSalt = hmac.Key;

                //we are giving hashing for password to out also we can not write just password
                //we have to take byte type but it is string that's why we have to encoding.UTF8.GetBytes(password) 
                // then we can use it.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
             
        }
        //we verified passwordHash
        //we will not use out because we are taking here that's why no need it.we are using for verifypassword.
        //we will compare password(from user) and passwordhash(from database) to verify in here.Also salt we will execute it.-
        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt )
        {
            //also we are using salt from here.
            using (var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt))
            {
                //password is user password.User trying the password in the system and we will hash and we will compare them
                //to verify.

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                //we are checking form user password with database password to verify. if they are same, it will return false
                //if they are different, it will return true.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!= passwordHash[i])
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
