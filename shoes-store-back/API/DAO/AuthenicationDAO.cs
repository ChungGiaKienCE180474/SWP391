using API.DbConext;
using API.DTOs;
using API.Models;
using API.Utils;
using AutoMapper;

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

        public RegisterDTO Register(RegisterDTO register)
        {
            if (string.IsNullOrWhiteSpace(register.AccountEmail) || string.IsNullOrWhiteSpace(register.Password))
            {
                return null;
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

            return resultDto;
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

    }
}
