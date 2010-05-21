namespace WindsorWCFIntegrationExample.Infrastructure.Services
{
    #region Using Directives

    using Core.Contracts;
    using Core.Domain;

    #endregion

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomer(int id)
        {
            return customerRepository.GetById(id);
        }
    }
}