using CoureAssessment.Data;
using CoureAssessment.DTOs;

namespace CoureAssessment.Services
{
    public class PhoneService : IPhoneService
    {
        public PhoneResponseDto? GetCountryByPhone(string phoneNumber)
        {
            var country = InMemoryData.Countries
                .FirstOrDefault(c => phoneNumber.StartsWith(c.CountryCode));

            if (country == null)
                return null;

            return new PhoneResponseDto
            {
                Number = phoneNumber,
                Country = new CountryDto
                {
                    CountryCode = country.CountryCode,
                    Name = country.Name,
                    CountryIso = country.CountryIso,
                    CountryDetails = country.CountryDetails.Select(cd => new CountryDetailDto
                    {
                        Operator = cd.Operator,
                        OperatorCode = cd.OperatorCode
                    }).ToList()
                }
            };
        }
    }
}
