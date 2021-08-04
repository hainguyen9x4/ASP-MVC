﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace OnlineShop.Common
{
  public static class Encryptor
  {
    public static string MD5Hash(string text)
    {
      if (String.IsNullOrEmpty(text))
      {
        return null;
      }
      MD5 md5 = new MD5CryptoServiceProvider();

      //compute hash from the bytes of text  
      md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

      //get hash result after compute it  
      byte[] result = md5.Hash;

      StringBuilder strBuilder = new StringBuilder();
      for (int i = 0; i < result.Length; i++)
      {
        //change it into 2 hexadecimal digits  
        //for each byte  
        strBuilder.Append(result[i].ToString("x2"));
      }

      return strBuilder.ToString();
    }
  }
}