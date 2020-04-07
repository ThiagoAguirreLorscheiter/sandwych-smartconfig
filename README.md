# Sandwych.SmartConfig

Sandwych.SmartConfig is a pure C# implementation of various WiFi SmartConfig protocols that build from scretch.

(�����ĵ�)[README.md]

## Getting Started

## Features

* A .NET Standard class library, works on both Xamarin and desktop.
* No third-party library referenced.
* Supported protocols currently: WeChat's AirKiss and Espressif's ESPTouch.
* Clean architecture, easy to learn and add your own protocol.
* IoC container frendly.

## Getting Started

### Prerequisites

* Microsoft Visual Studio 2019 
* DocFX for API documents generation (Optional)

### Supported Platforms

* .NET Standard 2.0+

### Installation


## Examples

### Usage

```csharp

var provider = new EspSmartConfigProvider();
var ctx = provider.CreateContext();

ctx.DeviceDiscoveredEvent += (s, e) => {
	Console.Write("Found device: IP={0}, MAC={1}", e.Device.IPAddress, e.Device.MacAddress);
};

var scArgs = new SmartConfigArguments()
{
	Ssid = "YourWiFiSSID",
	Bssid = PhysicalAddress.Parse("10-10-10-10-10-10"),
	Password = "YourWiFiPassword"
	LocalAddress = IPAddress.Parse("192.168.1.10")
};

// Do the SmartConfig job
using (var job = new SmartConfigJob(TimeSpan.FormSeconds(20))) // Set the time out to 20 seconds
{
	await job.ExecuteAsync(ctx, scArgs);
}

```

### The Demo Android App

APK Download: TODO

## Donation

If this project is useful to you, you can buy me a beer:

[![Support via PayPal.me](https://cdn.rawgit.com/oldrev/sandwych-smartconfig/assets/paypal_button.svg)](https://www.paypal.me/oldrev)

## Contributiors

* **Li "oldrev" Wei** - *Init work and the main maintainer* - [oldrev](https://github.com/oldrev)

## License

Copyright &copy; Sandwych.SmartConfig Contributors.

[LICENSE.md](LICENSE.md)��

## Credits

* Espressif EsptouchForAndroid: https://github.com/EspressifApp/EsptouchForAndroid
