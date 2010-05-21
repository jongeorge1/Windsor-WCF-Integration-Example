namespace WindsorWCFIntegrationExample.Infrastructure.Repositories
{
    #region Using Directives

    using WindsorWCFIntegrationExample.Core.Contracts;
    using WindsorWCFIntegrationExample.Core.Domain;

    #endregion

    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetById(int id)
        {
            return new Customer
                       {
                           FirstName = "Dan",
                           Surname = "Tedson",
                           Age = 52,
                           Address = new Address
                                         {
                                             Line1 = "27 Lucky Duck Lane",
                                             Line2 = "Bishopsland Lane",
                                             Town = "Egham",
                                             County = "Surrey",
                                             Postcode = "TW20 0AP"
                                         }
                       };
        }
    }
}