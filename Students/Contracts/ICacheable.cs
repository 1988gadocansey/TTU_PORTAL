namespace Students.Contracts;
public interface ICacheable
{
    bool BypassCache { get; }
    string CacheKey { get; }
    TimeSpan? SlidingExpiration { get; }
}