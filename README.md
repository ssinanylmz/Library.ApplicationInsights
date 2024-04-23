# .NET 8 Azure Application Insights Class Library

This repository contains the configuration and integration of Azure Application Insights within a .NET 8 application. This README provides guidance on setting up Application Insights to monitor and collect telemetry data effectively for your .NET applications.

## Prerequisites

Before integrating Azure Application Insights, ensure you have the following:
- An Azure subscription.
- An Azure Application Insights resource created in your Azure portal.
- .NET 8 SDK installed on your development machine.

## Configuration

The configuration in this class library is set up to enable detailed monitoring and telemetry data collection. Below are the steps and code snippets used in this project:

### Adding Application Insights to the Service Collection

To integrate Azure Application Insights into your .NET application, start by configuring the `ApplicationInsightsServiceOptions` in your application's startup logic. Here is how you can do it:

```csharp
var options = new ApplicationInsightsServiceOptions
{
    EnableHeartbeat = true,  // Enabling heartbeat to keep track of application health periodically
    InstrumentationKey = builder.Configuration["ApplicationInsights:InstrumentationKey"],
    ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"]
};

builder.Services.AddApplicationInsightsTelemetry(options);
```

## Telemetry Processors
Telemetry processors allow you to process telemetry data before it is sent to Azure Application Insights. In this project, we are adding custom telemetry processors to filter successful dependencies and requests:

```csharp
// Adding telemetry processors
builder.Services.AddApplicationInsightsTelemetryProcessor<SuccessfulDependencyFilter>();
builder.Services.AddApplicationInsightsTelemetryProcessor<SuccessfulRequestFilter>();
```

## Custom Application Insights Extensions
You might want to extend the default behavior of Application Insights. For this, we have a custom method:

```csharp
builder.Services.AddCustomApplicationInsights();
```
Ensure you define this extension method AddCustomApplicationInsights within your project to include any custom configuration or services required for your Application Insights setup.

## Usage
After configuration, your application will automatically send telemetry data to Azure Application Insights, where you can monitor and analyze the performance and health of your application.

For further customization and troubleshooting, refer to the official [Azure Application Insights documentation](https://learn.microsoft.com/tr-tr/azure/azure-monitor/app/app-insights-overview).

## Contributing
Contributions are welcome. Please fork this repository and submit a pull request for any enhancements.


