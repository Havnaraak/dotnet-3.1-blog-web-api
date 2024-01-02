using System;

namespace BlogWebApi.Domain.Common.Validation
{
    public static class ValidationExtensions
    {
        public static void NullOrEmpty(string value, string property)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentException($"Propriedade {property} não pode ser nula/vazia");
        }
        
        public static void CheckLength(
            string value,
            string property,
            long minLength,
            long maxLength
            )
        {
            if (!(value.Length >= minLength && value.Length <= maxLength))
                throw new ArgumentException(
                    $"Propriedade {property} fora do tamanho esperado, tamanho mínimo {minLength}, máximo {maxLength}");
        }
    }
}