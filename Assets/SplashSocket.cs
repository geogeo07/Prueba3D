using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Windows;
using ZXing;

public class SplashSocket : MonoBehaviour
{
    public static int SceneNumber;
   
    
    static string msg;
    static byte[] msgByte;

    
    //Prueba de cambios en el repositorio.



    void Start()
    {
        Debug.Log("Inicio");
        

        if (SceneNumber == 0)
        {
            StartCoroutine(conexion("hola 1"));
            StartCoroutine(ToSplashTwo());

        }
        if (SceneNumber == 1)
        {
            StartCoroutine(conexion("hola 2"));
            StartCoroutine(ToMainMenu());

        }
    }




    IEnumerator conexion(string msg)
    {

        if (!Socket.OSSupportsIPv6)
        {
            Debug.Log("Your system does not support IPv6\r\n" +
                "Check you have IPv6 enabled and have changed machine.config");
            
        }
        Socket sock = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("fe80::117a:c0af:52ab:674f"), 9999);
        


        sock.Connect(ep);

        if (sock.Connected)
        {
            Debug.Log("Socket conectado");
            

            if (msg != null)
            {

                msgByte = System.Text.Encoding.ASCII.GetBytes(msg);
                int msgSend = sock.Send(msgByte, 0, msgByte.Length, SocketFlags.None);
                Debug.Log("Mensaje enviado");
            }
        }


        sock.Shutdown(SocketShutdown.Both);
        sock.Close();
        Debug.Log("Socket desconectado");
        yield return null;
    }


    IEnumerator ToSplashTwo()
    {
        yield return new WaitForSeconds(3);
        SceneNumber = 1;
        SceneManager.LoadScene("SplashScreen2", LoadSceneMode.Additive);
    }


    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(3);
        SceneNumber = 2;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }




    /*

    public void SendTo()
    {


        byte[] data = new byte[1024];

        //Send data when button is clicked
        Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.65"), 9999); // endpoint where server is listening
        string message = "Hola jotos";
        data = Encoding.ASCII.GetBytes(message);
        //sender.Send(data);

        try
        {

            //Connect Socket to the remote endpoint using method Connect() 
            sender.Connect(ep);

            // We print EndPoint information  
            // that we are connected 
            Console.WriteLine("Socket connected to -> {0} ",
            sender.RemoteEndPoint.ToString());

            // Creation of messagge that we will send to Server 
            byte[] messageSent = Encoding.ASCII.GetBytes("Holis, la maquina esta lista");
            int byteSent = sender.Send(messageSent);

            byte[] messageReceived = new byte[1024];
            int byteRecv = sender.Receive(messageReceived);
            Console.WriteLine("Message from Server -> {0}", Encoding.ASCII.GetString(messageReceived, 0, byteRecv));

            if (Encoding.ASCII.GetString(messageReceived, 0, byteRecv) == "gracias we que detalle")
            {
                messageSent = Encoding.ASCII.GetBytes("si ya sabes que onda we");
                sender.Send(messageSent);

                while (true)
                {
                    // Data buffer 
                    byteRecv = sender.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}", Encoding.ASCII.GetString(messageReceived, 0, byteRecv));

                    // We receive the messagge using the method Receive(). This method returns number of bytes 
                    // received, that we'll use to convert them to string 


                    if (Encoding.ASCII.GetString(messageReceived, 0, byteRecv) == "hola we")
                    {
                        messageSent = Encoding.ASCII.GetBytes("que pedo we?");
                        sender.Send(messageSent);
                    }

                    if (Encoding.ASCII.GetString(messageReceived, 0, byteRecv) == "exit")
                    {
                        messageSent = Encoding.ASCII.GetBytes("bye joto");
                        sender.Send(messageSent);

                        break;

                    }

                }
            }


            // Close Socket using the method Close() 

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        // Manage of Socket's Exceptions 
        catch (ArgumentNullException ane)
        {

            Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        }

        catch (SocketException se)
        {

            Console.WriteLine("SocketException : {0}", se.ToString());
        }

        catch (Exception e)
        {
            Console.WriteLine("Unexpected exception : {0}", e.ToString());
        }


    }
    */

}

