using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Network
{
    /// <summary> 
    /// This utility function displays all the IP (v4, not v6) addresses of the local computer. 
    /// </summary> 
    public static string GetIpAddresses()
    {
        StringBuilder sb = new StringBuilder();

        // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection) 
        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface network in networkInterfaces)
        {
            // Read the IP configuration for each network 
            IPInterfaceProperties properties = network.GetIPProperties();

            // Each network interface may have multiple IP addresses 
            foreach (IPAddressInformation address in properties.UnicastAddresses)
            {
                // We're only interested in IPv4 addresses for now 
                if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                    continue;

                // Ignore loopback addresses (e.g., 127.0.0.1) 
                if (IPAddress.IsLoopback(address.Address))
                    continue;

                sb.AppendLine(address.Address.ToString());
            }
        }

        var result = sb.ToString().Replace('\n', ',');
        return result;
    }
}

