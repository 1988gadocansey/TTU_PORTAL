namespace Students.Entities.Dto;

public record PaymentDto
{
    public string? amount { get; set; } = default;
    public string? bank { get; set; } = default;

    public string? feeType { get; set; } = default;
    public string? date { get; set; }

}