using FluentValidation.Results;

namespace FluentValidation.ResultsToDictionary
{
    public static class FluentValidationExtensions
    {
        public static IDictionary<string, string[]> ToDictionary(this ValidationResult result)
        {
            var conversion = result.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(y => 
                        y.Key, 
                    y => 
                        y.Select(x => x.ErrorMessage).ToArray());
            return conversion;
        }
    }   
}