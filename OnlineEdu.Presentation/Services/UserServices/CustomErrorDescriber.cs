using Microsoft.AspNetCore.Identity;

namespace OnlineEdu.Presentation.Services.UserServices
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Description = "Bir hata oluştu."
            };
        }

        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError
            {
                Description = "İşlem sırasında bir çakışma oluştu, lütfen tekrar deneyin."
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Description = "Şifre hatalı."
            };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Description = "Geçersiz işlem anahtarı."
            };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError
            {
                Description = "Bu kullanıcı hesabı zaten başka bir hesapla ilişkilendirilmiş."
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Description = $"'{userName}' geçerli bir kullanıcı adı değildir."
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Description = $"'{email}' geçerli bir e-posta adresi değildir."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Description = $"'{userName}' kullanıcı adı zaten kullanılmaktadır."
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Description = $"'{email}' e-posta adresi zaten kullanılmaktadır."
            };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Description = $"'{role}' geçerli bir rol adı değildir."
            };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Description = $"'{role}' rolü zaten bulunmaktadır."
            };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Description = "Kullanıcının zaten bir şifresi bulunmaktadır."
            };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Description = "Bu kullanıcı için hesap kilitleme aktif değil."
            };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Description = $"Kullanıcı zaten '{role}' rolüne sahip."
            };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Description = $"Kullanıcı '{role}' rolüne sahip değil."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Description = $"Şifre en az {length} karakter uzunluğunda olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir özel karakter içermelidir."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir rakam içermelidir."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir küçük harf içermelidir."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir büyük harf içermelidir."
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Description = $"Şifre en az {uniqueChars} farklı karakter içermelidir."
            };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError
            {
                Description = "Kurtarma kodu kullanılırken hata oluştu."
            };
        }
    }
}