using System;
using CSharpDHCP.Core;
class Program
{
    static void Main(string[] args)
    {
        DHCP dHCP=new DHCP();
        dHCP.StartDHCPServer();
        Console.WriteLine("DHCP Server");
        while(true){
            
        }
    }
}

