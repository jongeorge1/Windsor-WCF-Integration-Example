namespace WindsorWCFIntegrationExample.Core.Contracts
{
    #region Using Directives

    using System.ServiceModel;
    using Domain;

    #endregion

    [ServiceContract(Namespace = "WindsorWCFIntegrationExample.Core.Contracts")]
    public interface ICustomerService
    {
        [OperationContract]
        Customer GetCustomer(int id);
    }
}