using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sandwych.SmartConfig.Networking
{
    public class DefaultDatagramClient : IDatagramClient
    {
        private readonly UdpClient _udp;

        public DefaultDatagramClient()
        {
            _udp = new UdpClient(AddressFamily.InterNetwork);
            _udp.EnableBroadcast = true;
        }

        public void Bind(IPEndPoint localEndPoint)
        {
            _udp.Client.Bind(localEndPoint);
        }

        public async Task SendAsync(byte[] datagram, int bytes, IPEndPoint target)
        {
            await _udp.SendAsync(datagram, bytes, target);
        }

        public async Task<DatagramReceiveResult> ReceiveAsync()
        {
            var result = await _udp.ReceiveAsync();
            return new DatagramReceiveResult(result.Buffer, result.RemoteEndPoint);
        }

        public void Dispose()
        {
            _udp.Dispose();
        }

        private static int GetFirstWifiInterfaceIndex()
        {
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            var wifi = adapters.Where(
                x => x.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
                && x.OperationalStatus == OperationalStatus.Up
                && !x.IsReceiveOnly
            ).FirstOrDefault();
            if(wifi == null)
            {
                throw new IOException("Cannot find available WiFi interface");
            }
            return wifi.GetIPProperties().GetIPv4Properties().Index;
        }

    }
}
