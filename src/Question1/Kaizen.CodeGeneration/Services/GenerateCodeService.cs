using System.Security.Cryptography;

namespace Kaizen.CodeGeneration.Services
{
    public interface IGenerateCodeService
    {
        string GenerateCode();
    }

    public class GenerateCodeService : CharacterSetRuleField, IGenerateCodeService
    {
        public override string CharSetField { get => base.CharSetField; set => base.CharSetField = value; }

        public string GenerateCode()
        {
            char[] charSet = CharSetField.ToCharArray();

            using var rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[8];
            rng.GetBytes(bytes);
            string code = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                code += charSet[bytes[i] % charSet.Length];
            }

            return code;
        }
    }
}