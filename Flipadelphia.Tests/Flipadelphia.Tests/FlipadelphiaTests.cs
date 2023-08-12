using Flipadelphia.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using TestContext = Bunit.TestContext;

namespace Flipadelphia.Tests;

public class FlipadelphiaTests : TestContext
{
    [Test]
    public void Flipadelphia_ShowsCorrectTemplateWhenMyFeatureTrue()
    {
        
        var inMemorySettings = new Dictionary<string, string>
        {
            { "Features:MyFeature", "true" },
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();


        var cut = RenderComponent<Flipadelphia<string>>(
            parameters => parameters
                .Add(p => p.FeatureName, "MyFeature")
                .Add(p => p.Configuration, configuration)
                .Add(p => p.FeatureIsOnTemplate, (RenderFragment)(builder =>
                {
                    builder.AddMarkupContent(0, "<p>Feature is ON</p>");
                }))
                .Add(p => p.FeatureIsOffTemplate, (RenderFragment)(builder =>
                {
                    builder.AddMarkupContent(0, "<p>Feature is Off</p>");
                }))
        );

        StringAssert.Contains("Feature is ON", cut.Markup);
    }
    
    [Test]
    public void Flipadelphia_ShowsCorrectTemplateWhenMyFeatureFalse()
    {
        
        var inMemorySettings = new Dictionary<string, string>
        {
            { "Features:MyFeature", "false" },
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();


        var cut = RenderComponent<Flipadelphia<string>>(
            parameters => parameters
                .Add(p => p.FeatureName, "MyFeature")
                .Add(p => p.Configuration, configuration)
                .Add(p => p.FeatureIsOnTemplate, (RenderFragment)(builder =>
                {
                    builder.AddMarkupContent(0, "<p>Feature is ON</p>");
                }))
                .Add(p => p.FeatureIsOffTemplate, (RenderFragment)(builder =>
                {
                    builder.AddMarkupContent(0, "<p>Feature is OFF</p>");
                }))
        );

        StringAssert.Contains("Feature is OFF", cut.Markup);
    }
}