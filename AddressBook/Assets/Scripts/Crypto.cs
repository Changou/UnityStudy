using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;


public class Crypto
{
    private const int SaveSlot = 0;
    private byte[] key;
    private byte[] iv;

    public Crypto()
    {
        if (PlayerPrefs.HasKey("EncryptionKey") && PlayerPrefs.HasKey("EncryptionIV"))
        {
            key = Convert.FromBase64String(PlayerPrefs.GetString("EncryptionKey"));
            iv = Convert.FromBase64String(PlayerPrefs.GetString("EncryptionIV"));
        }
        else
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.GenerateKey();
                aesAlg.GenerateIV();
                key = aesAlg.Key;
                iv = aesAlg.IV;

                SaveKeyAndIVToPlayerPrefs(key, iv);
            }
        }
    }
    private void SaveKeyAndIVToPlayerPrefs(byte[] key, byte[] iv)
    {
        PlayerPrefs.SetString("EncryptionKey", Convert.ToBase64String(key));
        PlayerPrefs.SetString("EncryptionIV", Convert.ToBase64String(iv));
        PlayerPrefs.Save();
    }
    public string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }
    public string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256hash = SHA256.Create())
        {
            byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public string Decrypt(string cipherText)
    {
        string plaintext = null;
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return plaintext;
    }
}
