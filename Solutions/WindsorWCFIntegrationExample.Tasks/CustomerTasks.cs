namespace WindsorWCFIntegrationExample.Tasks
{
    #region Using Directives

    using System;
    using System.Threading;
    using Core.Contracts;

    #endregion

    public class CustomerTasks : ICustomerTasks
    {
        private readonly ICustomerService customerService;

        public CustomerTasks(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public void DoTask()
        {
            WriteClientDetails(customerService);
        }

        private static void WriteClientDetails(ICustomerService customerService)
        {
            var customer = customerService.GetCustomer(24);
            
            // Wait for 2ms
            Thread.Sleep(10);
        }
    }
}