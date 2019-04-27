namespace LogAn
{
    // Defines factory that can use and return custom manager
    public class ExtensionManagerFactory
    {
        private static IExtensionManager customManager = null;

        public static IExtensionManager Create()
        {
            if (customManager != null)
            {
                return customManager;
            }
            return new FileExtensionManager();
        }

        public static void SetManager(IExtensionManager manager)
        {
            customManager = manager;
        }
    }
}