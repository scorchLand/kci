using System;
using System.Collections;
using System.IO;
using DevDev.Extensions;
using Unity.SharpZipLib.Checksum;
using Unity.SharpZipLib.Zip;
using UnityEngine;
using Debug = UnityEngine.Debug;
//com.unity.sharp-zip-lib, com.unity.nuget.newtonsoft-json 패키지에 추가 필요

public static class TableManager
{
    //public const string CDN_PATH = "https://knight-witch.s3.ap-northeast-2.amazonaws.com/";
    public const string CDN_PATH = "https://dkdxyv8nr8npp.cloudfront.net/";
    public const string SECURE_KEY = "@asik!ni32";
    public const string DOWNLOADED_DATA_VER_KEY = "CurrentDataVersion";
    public const string CHECKSUM_FILE_NAME = "info.bytes";
    public const string ZIP_FILE_NAME = "tables.zip";
    public const string EXT = "bytes";

    public static string DownloadPath => System.IO.Path.Combine(Application.persistentDataPath, "Table");


    public static bool IsRequireDownload(int serverVersion, long checksum)
    {
        if (HasDownloadData(serverVersion) == false)
        {
            int settingsDataVersion = 0;
            if (settingsDataVersion > serverVersion)
            {
                Debug.LogWarning($"로컬 버전이 서버버전보다 높습니다. local:{settingsDataVersion} server:{serverVersion}");
            }
            else if (settingsDataVersion <= serverVersion)
            {
                return true;
            }

            return false;
        }

        return CompareChecksum(serverVersion, checksum) == false;
    }

    public static long CalculateChecksum(byte[] buffer)
    {
        throw new Exception($"need Check sum");
        //var crc = new Crc32();
        //crc.Update(buffer);
        //return crc.Value;
    }

    public static bool HasDownloadData(int version)
    {
        //폴더 및 파일 존재 여부만 확인
        string versionPath = GetPath(version);
        if (System.IO.Directory.Exists(versionPath) == false)
        {
            return false;
        }

        string[] files = System.IO.Directory.GetFiles(versionPath);
        return files.IsNullOrEmpty() == false;
    }

    public static bool CompareChecksum(string filePath, long checksum)
    {
        //바이너리 파일 압축해서 체크섬 비교
        try
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            long calculated = CalculateChecksum(buffer);
            return calculated == checksum;
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return false;
        }
    }

    private static bool CompareChecksum(int version, long checksum)
    {
        //바이너리 파일 압축해서 체크섬 비교
        try
        {
            string zipPath = System.IO.Path.Combine(
                Application.temporaryCachePath,
                "compare.zip"
            );

            CreateZip(GetPath(version), zipPath);
            byte[] buffer = File.ReadAllBytes(zipPath);
            long calculated = CalculateChecksum(buffer);
            System.IO.File.Delete(zipPath);
            return calculated == checksum;
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return false;
        }
    }

    public static string PrepareDownloadFolder(int version)
    {
        //다운로드 밑준비
        string localVersionPath = GetPath(version);
        if (System.IO.Directory.Exists(localVersionPath))
        {
            System.IO.Directory.Delete(localVersionPath, true);
        }

        Directory.CreateDirectory(localVersionPath);
        return localVersionPath;
    }

    public static void CreateZip(string source, string path)
    {
        //throw new Exception($"need Check sum");
        string directoryPath = Path.GetDirectoryName(path);
        if (Directory.Exists(directoryPath) == false)
        {
            if (File.Exists(directoryPath))
            {
                File.Delete(directoryPath);
            }
        
            Directory.CreateDirectory(directoryPath);
        }

        var fastZip = new FastZip();
        string filter = $"^.*\\.({EXT})$";
        fastZip.CreateZip(path, source, false, filter);
    }

    public static void ExtractZip(string zipPath)
    {
        //throw new Exception($"need Check sum");
        var fastZip = new FastZip();
        string targetPath = System.IO.Path.GetDirectoryName(zipPath);
        fastZip.ExtractZip(zipPath, targetPath, string.Empty);
        System.IO.File.Delete(zipPath);
    }

    public static string GetPath(int version, string localPath = null)
    {
        string versionPath = System.IO.Path.Combine(DownloadPath, version.ToString());
        return localPath.IsNullOrWhiteSpace() ? versionPath : System.IO.Path.Combine(versionPath, localPath);
    }
}