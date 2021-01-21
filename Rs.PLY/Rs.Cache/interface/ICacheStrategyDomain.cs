namespace Rs.Cache
{
    public interface ICacheStrategyDomain
    {
        /// <summary>
        /// 唯一名称（建议使用GUID）
        /// </summary>
        string IdentityName { get; }

        /// <summary>
        /// 域的名称
        /// </summary>
        string DomainName { get; }
    }
}