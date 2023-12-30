using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;
using Org.BouncyCastle.Crypto.Generators;
using System.Data;
using System.Security.Claims;
using Technical_Test.Contracts;
using Technical_Test.Data;
using Technical_Test.DTOs.Authorization;
using Technical_Test.DTOs.Company;
using Technical_Test.Models;

namespace Technical_Test.Services
{
    public class AuthenticationServices
    {
        private readonly BookingDbContext _bookingDbContext;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IManagerLogistics _managerLogistics ;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationServices(BookingDbContext bookingDbContext, ICompanyRepository companyRepository, IUserRepository userRepository, IManagerLogistics managerLogistics, ITokenHandler tokenHandler)
        {
            _bookingDbContext = bookingDbContext;
            _companyRepository = companyRepository;
            _managerLogistics = managerLogistics;
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        public RegisterDTO Register(RegisterDTO registerDto)
        {
            //Register ini hanya untuk registrasi company saja
            //untuk ManagerLogistics atau Admin silahkan masukan data lewat API
            //Masukan data di table manager daftarkan email, password, usertype, managerID di table user

            using var transaction = _bookingDbContext.Database.BeginTransaction();

            try
            {
                var company = new Company
                {
                    CompanyName = registerDto.CompanyName,
                    CompanyEmail = registerDto.CompanyEmail,
                    CompanyPhoneNumber = registerDto.CompanyPhoneNumber,
                    CompanyPhoto = registerDto.CompanyPhoto,
                    ApprovalStatus = "Pending",
                };
                var createdCompany = _companyRepository.Create(company);

                var createdUser = new User
                {
                    Email = company.CompanyEmail,
                    Password = registerDto.Password,
                    UserType = Utilities.Enums.UserType.Company
                };
                var createdAccount = _userRepository.Create(createdUser);

                var toDto = new RegisterDTO
                {
                    CompanyName = createdCompany.CompanyName,
                    CompanyEmail = createdCompany.CompanyName,
                    CompanyPhoneNumber= createdCompany.CompanyPhoneNumber,
                    CompanyPhoto = createdCompany.CompanyPhoto,
                    Password = createdUser.Password,
                    UserType = Utilities.Enums.UserType.Company
                };

                transaction.Commit();
                return toDto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public string Login(LoginDTO loginDto)
        {
            var user = _userRepository.GetByEmail(loginDto.Email);

            if (user is null)
            {
                return "USER_NOT_FOUND";
            }

            // Verify hashed passwords
            if (!VerifyPassword(loginDto.Password, user.Password))
            {
                return "INVALID_PASSWORD";
            }

            var claims = new List<Claim>
    {
        new Claim("Id", $"{user.UserID}"),
        new Claim("Email", loginDto.Email),
        new Claim("UserType", $"{user.UserType}")
    };

            try
            {
                var getToken = _tokenHandler.GenerateToken(claims);
                return getToken;
            }
            catch
            {

                return "Error";
            }
        }

        private string HashPassword(string password)
        {
           
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // Verify the password using the hashed value
            // Example using BCrypt.Net library
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}
