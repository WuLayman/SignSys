using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProj.ConfigConnectionString
{
    public class EncryptionHelper
    {
        byte[] buffer;
        DESCryptoServiceProvider DesCSP = new DESCryptoServiceProvider();

        /// <summary>
        /// 加密存储
        /// </summary>
        public void EncrytAndSave(string connStr)
        {
            //var encryptedStr = MD5Encrypt(connStr);
            var encryptedStr = Encryption(connStr);
            //Console.WriteLine(encryptedStr);

            FileStream fs = new FileStream(Application.StartupPath + "EncryptionInfo.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(encryptedStr);
            sw.Close();
            fs.Close();
            sw.Dispose();
            fs.Dispose();

            //解密算法测试
            //var str = Decryption();
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string strText)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.  
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.  
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strText));

            // Create a new Stringbuilder to collect the bytes  
            // and create a string.  
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data   
            // and format each one as a hexadecimal string.  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.  
            return sBuilder.ToString();
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        private string Encryption(string express)
        {
            MemoryStream ms = new MemoryStream();//先创建 一个内存流
            CryptoStream cryStream = new CryptoStream(ms, DesCSP.CreateEncryptor(), CryptoStreamMode.Write);//将内存流连接到加密转换流
            StreamWriter sw = new StreamWriter(cryStream);
            sw.WriteLine(express);//将要加密的字符串写入加密转换流
            sw.Close();
            cryStream.Close();
            buffer = ms.ToArray();//将加密后的流转换为字节数组
            return Convert.ToBase64String(buffer);//将加密后的字节数组转换为字符串
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <returns></returns>
        private string Decryption()
        {
            //FileStream fs = new FileStream(System.Environment.CurrentDirectory + "EncryptionInfo.txt", FileMode.Open);
            MemoryStream ms = new MemoryStream(buffer);//将加密后的字节数据加入内存流中
            CryptoStream cryStream = new CryptoStream(ms, DesCSP.CreateDecryptor(), CryptoStreamMode.Read);//内存流连接到解密流中
            StreamReader sr = new StreamReader(cryStream);
            var connStr = sr.ReadLine();//将解密流读取为字符串
            sr.Close();
            cryStream.Close();
            ms.Close();
            return connStr;
        }
    }
}
