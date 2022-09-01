using Microsoft.Extensions.Localization;
using System.Reflection;

namespace BasicMVC.Models
{
    public class LanguageService
    {
        private readonly IStringLocalizer localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(TestResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            localizer = factory.Create(nameof(TestResource), assemblyName.Name);
        }

        public string Get(string key)
        {
            return localizer[key];
        }
    }
}
