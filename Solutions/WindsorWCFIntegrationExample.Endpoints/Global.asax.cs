namespace WindsorWCFIntegrationExample.Endpoints
{
    using System;
    using Castle.Facilities.WcfIntegration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class Global : System.Web.HttpApplication
    {
        public IWindsorContainer Container { get; private set; }

        protected void Application_End(object sender, EventArgs e)
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Container = new WindsorContainer()
                .AddFacility<WcfFacility>()
                .Install(Configuration.FromXmlFile("Configuration/Windsor.config"));
        }

    }
}
