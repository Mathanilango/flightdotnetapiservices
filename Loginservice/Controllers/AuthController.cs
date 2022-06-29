using AutoMapper;
using Adminservice.Interface;
using Adminservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Loginservice.Dto;



namespace Adminservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _cnfg;
        private readonly IMapper _Imapper;
        private readonly IUser _user;
        bool rst;
        string msg;

        public AuthController(IConfiguration cnfg,IMapper imap,IUser user)
        {
            _cnfg = cnfg;
            _Imapper = imap;
            _user = user;
        }

        [HttpGet("testazure")]
        public string azure()
        {
            return "Service Deployed successfully!!";

        }
        [HttpPost("Register")]
        //public async Task<ActionResult<User>> Userregister (UserDto userDto)
        public async Task<ActionResult<string>> Userregister (UserDto userDto)
        {
            
            createhashsalt(userDto.Password, out byte[] passwordhash, out byte[] passwordsalt);
            
            
            
            var ts=_Imapper.Map<UserDto, User>(userDto);
            ts.Passwordhash = passwordhash;
            ts.PasswordSalt = passwordsalt;
            bool res = _user.FindUser(ts.Username);

            if (res)
            { 
                rst = _user.adduser(ts);
                msg = "Registered Sucessfully!!";
            }
            if(!res)
            {
                msg = "Registered Already";
            }
            if(!rst)
            {
                msg = "Save Failed";
            }
            return msg;
        }
       
        private void createhashsalt(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using(var hc= new HMACSHA512())
            {
                passwordsalt = hc.Key;
                passwordhash = hc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginDto rqst)
        {
            

            var usr = _user.login(rqst.Username);
            //if (user.Username != rqst.Username)
            //    return BadRequest("User not exsist");
            if (!verifypassword(rqst.Password, usr.Passwordhash, usr.PasswordSalt))
                return BadRequest("Wrong Password");
            string token = createtoken(usr);
            var gnrttkn = GetRefreshToken();
            setrefreshtoken(gnrttkn);
            return Ok(token);
            //return Ok(user);


        }
        [HttpPost("Refreshtoken")]
        public async Task<ActionResult<string>> refreshtoken ()
        {
            var rf = Request.Cookies["refreshtoken"];
            if(!user.Refreshtoken.Equals(rf))
            {
                return Unauthorized("Invalid refresh token");
            }
            else if (user.tokenexpired< DateTime.Now)
            {
                return Unauthorized("Token expired");
            }
            string tkn = createtoken(user);
            var rftkn = GetRefreshToken();
            setrefreshtoken(rftkn);
            return Ok(tkn);

            
        }

        private void setrefreshtoken (RefreshToken rfstkn)

        {

            var cookie = new CookieOptions
            {
                HttpOnly = true,
                Expires = rfstkn.Expires

            };
            Response.Cookies.Append("refreshtoken", rfstkn.Token, cookie);
            user.Refreshtoken = rfstkn.Token;
            user.tokenexpired = rfstkn.Expires;
            user.tokencreated = rfstkn.Created;


        }
        private ActionResult<string> Unauthorized(string v)
        {
            return v;
        }

        private static RefreshToken GetRefreshToken()
        {

            var byt = BitConverter.GetBytes(64);
            var rfshtkn = new RefreshToken
            {
               
                Token = Convert.ToBase64String(byt),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return rfshtkn;

        }
        private bool verifypassword(string password,  byte[] passwordHash,  byte[] passwordsalt)
        {
            using (var hm = new HMACSHA512(passwordsalt))
            {
                var computehash = hm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computehash.SequenceEqual(passwordHash);
            }
            }
        private string createtoken(User user)
        {
            List<Claim> clm = new List<Claim>()
                { new Claim(ClaimTypes.Name,user.Username),
              
                new Claim(ClaimTypes.Role,user.Role)
                   
            };
            var rs = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_cnfg.GetSection("AppSettings:Token").Value));
            var crd = new SigningCredentials(rs, SecurityAlgorithms.HmacSha256Signature);
            var tkn = new JwtSecurityToken(claims: clm, expires: DateTime.Now.AddDays(1), signingCredentials: crd);
            var jwt = new JwtSecurityTokenHandler().WriteToken(tkn);
            return jwt;
        }
    }
}
