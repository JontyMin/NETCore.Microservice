using Microsoft.Extensions.Configuration;

namespace ConfigurationCustom
{
    public class MyConfigurationSource:IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MyConfigurationProvider();
        }
    }
}