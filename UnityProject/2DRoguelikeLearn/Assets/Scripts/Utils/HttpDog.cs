

using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class HttpDog{

    public static string send(string url, string data = null) {
        try {
            //实例化一个HttpWebrequst对象
            HttpWebRequest Info_Request = (HttpWebRequest)WebRequest.Create(url);

            //设置Requst的模式
            Info_Request.Method = null != data ? "POST" : "GET";
            //设置Content-Type Http标头的值，该值为默认值
            Info_Request.ContentType = "application/json";
            //预设响应等待时间
            Info_Request.Timeout = 20000;

            if (null != data)
            {
                //建立一个Stream对象来写入Requst请求的参数流内涵url和key值等
                Stream Info_Stream = Info_Request.GetRequestStream();
                //调用Write方法第一个参数是获取传递参数的值得类型，第二个是流起始位置，第三个参数指流的长度
                Info_Stream.Write(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetBytes(data).Length);
            }
            //实例化一个HttpWebResponse用GetResponse方法用以获取服务器返回的响应
            HttpWebResponse Info_Response = (HttpWebResponse)Info_Request.GetResponse();
            //实例化一个StreamReader对象来获取Response的GetResponseStream返回的响应的体
            StreamReader Info_Reader = new StreamReader(Info_Response.GetResponseStream(), Encoding.UTF8); 
              
            return Info_Reader.ReadToEnd();
        }
        catch (System.Exception ex) {
            Debug.Log(ex);
            return "";
        }
    }
}