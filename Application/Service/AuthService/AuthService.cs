using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.AuthDTOs;
using Application.UnitOfWork;
using Domain.Models;

namespace Application.Service.UserService
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Register(RegisterUserDTO dto)
        {
            var existingUser=await _unitOfWork.UsersRepo.GetUserByEmail(dto.Email);
            if(existingUser!=null) throw new Exception("User with this email already exists");

            CreatePasswordHash(dto.Password, out var hash, out var salt);

            var user = new User(dto.Name, dto.Email, dto.PhoneNumber, (UserRole)dto.Role){
                PasswordHash = hash,
                PasswordSalt = salt 
            };

            await _unitOfWork.UsersRepo.AddUser(user);
            await _unitOfWork.Commit();
        }

        public async Task<AuthResponseDTO> Login(LoginDTO dto)
        {
            var user = await _unitOfWork.UsersRepo.GetUserByEmail(dto.Email);
            if(user==null)throw new Exception("Invalid email or password");

            if (!VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Invalid email or password");

            return new AuthResponseDTO
            {
                UserId = user.Id,
                Name = user.Name,
                Role = (int)user.Role,
                Token = null // later JWT
            };
        }

        public async Task<string> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user =await _unitOfWork.UsersRepo.GetUserByEmail(forgotPasswordDTO.Email);
            if (user == null) throw new Exception("User with this email does not exist");

            var token = GenerateSecureToken(); // raw token to send to user
            user.PasswordResetTokenHash = Sha256(token); // store hashed token
            user.ResetTokenExpiresAt = DateTime.UtcNow.AddMinutes(30);// token valid for 30 minutes

            _unitOfWork.UsersRepo.UpdateUser(user);
            await _unitOfWork.Commit();


            return token;

        }

        public async Task ResetPassword(ResetPasswordDTO dto)
        {
            var user = await _unitOfWork.UsersRepo.GetUserByEmail(dto.Email);
            if (user == null) throw new Exception("Invalid token");

            if (user.ResetTokenExpiresAt == null || user.ResetTokenExpiresAt < DateTime.UtcNow)
                throw new Exception("Token expired");

            var tokenHash = Sha256(dto.Token);
            if (user.PasswordResetTokenHash == null ||
                !user.PasswordResetTokenHash.SequenceEqual(tokenHash))
                throw new Exception("Invalid token");

            CreatePasswordHash(dto.NewPassword, out var newHash, out var newSalt);
            user.PasswordHash = newHash;
            user.PasswordSalt = newSalt;

            user.PasswordResetTokenHash = null;
            user.ResetTokenExpiresAt = null;

            _unitOfWork.UsersRepo.UpdateUser(user);
            await _unitOfWork.Commit();
        }


        // Password Hashing Methods
        private static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt) {
            
            salt = RandomNumberGenerator.GetBytes(16); // Generate a 16-byte salt, which is a common size for cryptographic salts.
                                                       // salt is used to add randomness to the password hashing process, making it more secure against attacks like rainbow tables.

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);// Create an instance of Rfc2898DeriveBytes using PBKDF2 with SHA-256.
                                                                                                         // The password is combined with the salt, and the hashing process is iterated 100,000 times to enhance security.

            hash = pbkdf2.GetBytes(32);// Derive a 32-byte hash from the password.
                                       // A 32-byte hash is suitable for SHA-256, which produces a 256-bit (32-byte) output.
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt) //this method checks if the provided password matches the stored hash using the stored salt.
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100_000, HashAlgorithmName.SHA256);// Recreate the PBKDF2 instance with the provided password and the stored salt
                                                                                                               // because the salt is needed to compute the same hash.

            var computed = pbkdf2.GetBytes(32);// Derive the hash from the provided password using the same parameters (salt and iterations) as used during registration.

            return computed.SequenceEqual(storedHash);// Compare the newly computed hash with the stored hash.
                                                      // If they are equal, the password is correct; otherwise, it is incorrect.
        }

        private static string GenerateSecureToken()// This method generates a secure random token,
                                                   // typically used for password resets or similar purposes.
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }

        private static byte[] Sha256(string value) // This method computes the SHA-256 hash of the provided string value.
        {
            using var sha = SHA256.Create();// Create an instance of the SHA256 hashing algorithm.
            return sha.ComputeHash(Encoding.UTF8.GetBytes(value)); // Compute the hash of the input string converted to a byte array using UTF-8 encoding.
        }
    }
}
