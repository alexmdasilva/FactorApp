namespace API.Responses
{
    public record GetDivisorsResponse(IEnumerable<int> Divisors, IEnumerable<int> PrimeDivisors);
}
