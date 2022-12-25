using System.Text.RegularExpressions;

namespace Kaizen.CodeGeneration.Services
{
    public interface ICheckCodeService
    {
        bool CheckCodeIsValid(string code);
    }

    public class CheckCodeService : CharacterSetRuleField, ICheckCodeService
    {
        public override string CharSetField { get => base.CharSetField; set => base.CharSetField = value; }

        public bool CheckCodeIsValid(string code)
        {
            if (code.Length != 8)
                return false;

            string pattern = "^[" + CharSetField + "]+$";
            bool patternIsValid = Regex.IsMatch(code, pattern);

            if (!patternIsValid)
                return false;

            //I couldn't IsUnique Check Not Implemented without any data structure or database.

            return true;
        }
    }
}