using API.DbConext;
using API.DTOs;
using API.Models;
using API.Utils;
using AutoMapper;
using System.Net;

namespace API.DAO
{
    public class AuthenicationDAO
    {
        private readonly ShoesDbContext db;
        private readonly IConfiguration configuration;
        private readonly IMapper map;
        public AuthenicationDAO(ShoesDbContext db,IConfiguration _configuration,IMapper _mapper)
        {
            this.db = db;
            this.configuration = _configuration;
            this.map = _mapper;
        }

        public String Login(String Email, String Password)
        {
            
            try
            {
                string secretkey = configuration["JWT:SecretKey"];
                var checkLogin = db.accounts.FirstOrDefault(x => x.AccountEmail.Equals(Email) && x.Password.Equals(Password) && x.Status != "InActive");
                if (checkLogin == null)
                {
                    return null;
                }

                String token = JWTHandler.GenerateJWT(checkLogin, secretkey);
                return token;
            }
            catch (Exception ex) {
                return ex.Message;
            }
            
        }

        public ResponseMessage Register(RegisterDTO register)
        {
            if (string.IsNullOrWhiteSpace(register.AccountEmail) || string.IsNullOrWhiteSpace(register.Password))
            {
                return null;
            }
            var checkAlreadyEmail = db.accounts
                                      .FirstOrDefault(x => x.AccountEmail.Equals(register.AccountEmail));
            if (checkAlreadyEmail != null)
            {
                return new ResponseMessage { Success = false, 
                                             Message = "Email Already Exist", 
                                             Data = checkAlreadyEmail.AccountEmail, 
                                             StatusCode = (int)HttpStatusCode.AlreadyReported 
                                            };
            }
            Account registerAccount = new Account
            {
                AccountEmail = register.AccountEmail,
                Password = register.Password,
                Role = register.Role,
                Status = register.Status
            };
            db.accounts.Add(registerAccount);
            db.SaveChanges();
            var resultDto = map.Map<RegisterDTO>(registerAccount);

            return new ResponseMessage
            {
                Success = false,
                Message = "Register Successfully",
                Data = resultDto,
                StatusCode = (int)HttpStatusCode.OK
            };
        }


        public ProfileDTO GetProfileByID(int accountID)
        {
            var getProfile = db.accounts
                               .FirstOrDefault(x => x.AccountID == accountID);
            if (getProfile == null) {
                return null;
            }
            var profileDTO = map.Map<ProfileDTO>(getProfile);
            profileDTO.BirthDay = getProfile.BirthDay.Value.ToString("dd-MM-yyyy");
            return profileDTO;
        }

        public ChangePasswordDTO ChangePassword(ChangePasswordDTO changePassword)
        {
            var getAccount = db.accounts
                               .FirstOrDefault(x => x.AccountID == changePassword.accountID && x.Password.Equals(changePassword.OldPassword));
            if (getAccount == null) {

                return null;
            }
            getAccount.Password = changePassword.NewPassword;
            db.accounts.Update(getAccount);
            db.SaveChanges();
            var updateDTO = map.Map<ChangePasswordDTO>(getAccount);
            updateDTO.NewPassword = getAccount.Password;
            return updateDTO;
        }

        public ResponseMessage UpdateProfile(int id,ProfileDTO profileDTO )
        {
            var getUser = db.accounts.FirstOrDefault( x => x.AccountID == id);
            if (getUser != null)
            {
                getUser.AccountAddress = profileDTO.AccountAddress;
                getUser.AccountName = profileDTO.AccountName;
                getUser.BirthDay =DateTime.Parse(profileDTO.BirthDay);
                getUser.Gender = profileDTO.Gender;
                getUser.Phone = profileDTO.Phone;
                getUser.AccountAddress = profileDTO.AccountAddress;
                db.accounts.Update(getUser);
                db.SaveChanges();
                return new ResponseMessage
                {
                    Success = true,
                    Message = "Update Successfully",
                    Data = map.Map<ProfileDTO>(getUser),
                    StatusCode = (int)HttpStatusCode.OK,
                };
            }
            return new ResponseMessage
            {
                Success = false,
                Message = "Account Not Found",
                Data = new int[0],
                StatusCode = (int)HttpStatusCode.NotFound,
            };
        }

    }
}
