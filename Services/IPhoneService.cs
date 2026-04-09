using CoureAssessment.DTOs;

namespace CoureAssessment.Services
{
    public interface IPhoneService
    {
        PhoneResponseDto? GetCountryByPhone(string phoneNumber);
    }
}
