
using System;
using System.IO;

public class FileUtils{

/**
 * 将二进制写入到文件
 */
public static void write(byte[] myByte, string path, string fileName)
{
if (!Directory.Exists(path))
Directory.CreateDirectory(path);
using (FileStream fsWrite = new FileStream(path + fileName, FileMode.Create))
{
fsWrite.Write(myByte, 0, myByte.Length);
}; 
}

/**
 * 读取二进制文件
 */
public static byte[] read(string path)
{
using (FileStream fsRead = new FileStream(path, FileMode.Open))
{
int fsLen = (int)fsRead.Length;
byte[] heByte = new byte[fsLen];
int r = fsRead.Read(heByte, 0, heByte.Length);
return heByte;
} 
}
}