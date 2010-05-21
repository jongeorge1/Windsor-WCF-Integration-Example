namespace WindsorWCFIntegrationExample.Core.Contracts
{
    #region Using Directives

    using Domain;

    #endregion

    public interface ICustomerRepository
    {
        Customer GetById(int id);
    }
}