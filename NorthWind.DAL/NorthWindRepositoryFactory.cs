namespace NorthWind.DAL
{
    using NorthWind.Services.Repositories;
    public static class NorthWindRepositoryFactory
    {
        public static INorthWindRepository GetNorthWindRepository(bool isUnitOfWork = false)
        {
            return new NorthWindRepository(isUnitOfWork);
        }
    }
}
