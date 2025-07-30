using System.Text.Json.Serialization;

namespace MPeyghoom.Contracts.Auth.GetVerificationCode;

public class GetVerificationCodeRequest {
    public long PhoneNumber { get; set; }
}