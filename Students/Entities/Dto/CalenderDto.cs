namespace Students.Entities.Dto
{
    public record CalenderDto
    {

        public string? ResultOpened { get; init; }
        public int? FeePaymentOpen { get; init; }
        public int? LiaisonOpen { get; init; }

        public int? RegistrationOpen { get; init; }

        public int? ResitOpen { get; init; }

    }
}
