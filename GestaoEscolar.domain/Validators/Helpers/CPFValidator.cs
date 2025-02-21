using System.Text.RegularExpressions;

namespace GestaoEscolar.domain.Validators.Helpers;

public class CPFValidator : ICPFValidator
{
    public bool CPFValido(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        if (!Regex.IsMatch(cpf, @"^\d{11}$"))
            return false;

        if (new string(cpf[0], cpf.Length) == cpf)
            return false;

        return true;
    }
}
