using LightBDD.Core.Configuration;
using LightBDD.Framework.Configuration;
using LightBDD.Framework.Reporting.Formatters;
using LightBDD.XUnit2;

[assembly: ConfiguredLightBddScope]
internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
{
    /// <summary>
    /// This method allows to customize LightBDD behavior.
    /// The code below configures LightBDD to produce also a plain text report after all tests are done.
    /// More information on what can be customized can be found on wiki: https://github.com/LightBDD/LightBDD/wiki/LightBDD-Configuration#configurable-lightbdd-features 
    /// </summary>
    protected override void OnConfigure(LightBddConfiguration configuration)
    {
        configuration
            .ReportWritersConfiguration()
            .AddFileWriter<XmlReportFormatter>("~\\Reports\\FeaturesReport.xml")
            .AddFileWriter<MarkdownReportFormatter>("~\\Reports\\FeaturesReport.md")
            .AddFileWriter<HtmlReportFormatter>("~\\Reports\\FeaturesReport.html")
            .AddFileWriter<PlainTextReportFormatter>("~\\Reports\\{TestDateTimeUtc:yyyy-MM-dd-HH_mm_ss}_FeaturesReport.txt");
    }
}