using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ProZaghdadV1.Localization
{
    public static class ProZaghdadV1LocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ProZaghdadV1Consts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ProZaghdadV1LocalizationConfigurer).GetAssembly(),
                        "ProZaghdadV1.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
