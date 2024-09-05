namespace ASPProjekat.API.Core
{
    public interface IToken
    {
        bool Exists(Guid tokenId);
        void Add(Guid tokenId);
        void Remove(Guid tokenId);
    }
}
