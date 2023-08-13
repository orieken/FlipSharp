

## **Flipadelphia Component Documentation**

* [![.NET](https://github.com/orieken/FlipSharp/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/orieken/FlipSharp/actions/workflows/dotnet-desktop.yml)

### **Introduction**

The `Flipadelphia` component provides a flexible and robust mechanism for feature toggling within Blazor applications. It allows developers to dynamically display different content based on the state of a feature flag.

### **Installation**

1. Install the `Flipadelphia` Razor Class Library from the NuGet package manager or by adding a reference to your Blazor project.
2. Ensure you have the `Microsoft.Extensions.Configuration` namespace referenced in your project, as `Flipadelphia` requires it for feature flag checks.

### **Usage**

To use the `Flipadelphia` component, follow these steps:

1. Add the component to your Blazor page or component:

   ```html
   <Flipadelphia FeatureName="MyFeature" Configuration="@Configuration">
       <FeatureIsOnTemplate>
           <!-- Content to display when the feature is ON -->
       </FeatureIsOnTemplate>
       <FeatureIsOffTemplate>
           <!-- Content to display when the feature is OFF -->
       </FeatureIsOffTemplate>
   </Flipadelphia>
   ```

2. **Parameters**:

    - `FeatureName` *(Required)*: The name of the feature as defined in your application's configuration.
    - `Configuration` *(Required)*: An instance of `IConfiguration` that the component uses to check the feature's state.

3. **Templates**:

    - `FeatureIsOnTemplate`: Defines the content to display when the feature is turned on.
    - `FeatureIsOffTemplate`: Defines the content to display when the feature is turned off.

### **Configuration**

In your application's configuration (e.g., `appsettings.json`), define the state of your features:

```json
{
  "Features": {
    "MyFeature": true,
    "AnotherFeature": false
  }
}
```

Set the feature to `true` to turn it on, and `false` to turn it off.

### **Best Practices**

1. **Environment-Specific Configurations**: Maintain separate configuration files for different environments (Development, Staging, Production) to control feature flags independently.
2. **Code Reviews**: Regularly review any changes related to feature flags to ensure the desired behavior.
3. **Monitoring and Alerting**: Set up monitoring for feature flag changes, especially in production, to detect and react to any unexpected behavior.

### **Limitations**

- Features that should never be enabled in certain environments (e.g., production) should have additional checks in the code to prevent accidental activation.

### **Support**

For any issues, questions, or feature requests related to the `Flipadelphia` component, please [Add a GitHub Issues](https://github.com/orieken/FlipSharp/issues/new/choose).
