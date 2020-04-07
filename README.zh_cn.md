# Sandwych.SmartConfig

Sandwych.SmartConfig ���㿪ʼʵ�ֵ�΢�� AirKiss ������ ESPTouch �� WiFi SmartConfig �������ܿ⡣

## ����

* ʹ�ô� C# �� .NET BCL �� `UDPClient` ��ʵ�֣��������豸���һ������ĵ�����������ͬʱ���� Xamarin �ֻ� App �����棻
* Ŀǰ֧�ֵ�Э�飺AirKiss��ESPTouch��
* �����ٶȿ죬�����Ժã�
* �����������չ����������������Э�飬Ҳ�ɲο�����Ŀ��д�������Ե� AirKiss �� ESPTouch ʵ�֣�
* IoC �����Ѻã�
* ���첽���

һ����˵����������� .NET �� Xamarin �����漰 WiFi �������豸���ֻ� App���� Sandwych.SmartConfig ���������õ��ġ�

## ��������


### ǰ������

* Microsoft Visual Studio 2019����������漴�ɣ�
* DocFX �������� API �ĵ�����ѡ��

### ֧��ƽ̨

* .NET Standard 2.0+

### ��װ

�� Sandwych.SmartConfig ͨ�� **[NuGet](http://www.google.com)** ��װ�������Ŀ�м���ʹ�á�


## ����

### �򵥵��ñ����������

�� ESPTouch Э��Ϊ����

```csharp

var provider = new EspSmartConfigProvider();
var ctx = provider.CreateContext();

// �豸ͨ�� UDP �㲥�ر� IP �Ժ��������¼���ע��ͬһ���豸 IP ֻ�ᴥ��һ��
ctx.DeviceDiscoveredEvent += (s, e) => {
	// ��������漰���� UI �Ļ���Ҫͬ�������߳�
	Console.Write("Found device: IP={0}, MAC={1}", e.Device.IPAddress, e.Device.MacAddress);
};

// ������������
var scArgs = new SmartConfigArguments()
{
	Ssid = "YourWiFiSSID",
	Bssid = PhysicalAddress.Parse("10-10-10-10-10-10"),
	Password = "YourWiFiPassword"
	LocalAddress = IPAddress.Parse("192.168.1.10")
};

// ���� SmartConfigJob ����ʵ�ʵ�����
using (var job = new SmartConfigJob(TimeSpan.FormSeconds(20))) // ���������ʱ�� 20��
{
	await job.ExecuteAsync(ctx, scArgs);
}

```

### ʹ�����ӳ���

����Ŀ������һ��ͨ�õ� Xamarin.Android ����������Ϊ���ӣ������б������У�Ҳ��ֱ�����ر���õ� `.APK` ��װ���ԣ�

APK ���ص�ַ�� TODO

## ֧�ֱ���Ŀ

���籾��Ŀ�������ã����Կ������Һȱ�ơ��:

΢�Ŵ��Ͷ�ά�룺

![΢��](https://github.com/oldrev/sandwych-smartconfig/blob/master/assets/wechat_qrcode.png)


* BTW �������Ҫ�ڱ���Ŀ�����ߴ�����������ʱ�뱸ע��

��Ȼ��Ҳ�ǳ���ӭ������ύ bug�����״��롢�������û�������⡢��д�ĵ�����Щ���ǽ�Ǯ���ܺ����ġ�

## ������

* **��ά** - *��ʼ��������ά����* - [oldrev](https://github.com/oldrev)

## ��ȨЭ��

��Ȩ���� &copy; Sandwych.SmartConfig �����ߡ�

����Ŀʹ�� MIT Э����Ȩ��������� [LICENSE.md](LICENSE.md)��

## ��л

* ���� EsptouchForAndroid: https://github.com/EspressifApp/EsptouchForAndroid
