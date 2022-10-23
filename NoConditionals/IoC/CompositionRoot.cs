using NoConditionals.Properties;

namespace NoConditionals.IoC
{
    internal class CompositionRoot
    {
        private IStore store;

        internal void Run()
        {
            // TODO 4. add examples how to build controler without IF statements:
            // Use parameters in constructor injection
            // Use plugins for application extensability
            this.store = this.CreateStore();

            //registruju interfaces a tz se predaji IOC jako singletons, delal jsem to ale nejsem si jsit terminologii
        }

        private IStore CreateStore()
        {
            if (Settings.Default.StoreId == "DatabaseStore")
                 return new DatabaseStore();

            return new FileStore();
        }
    }
}
