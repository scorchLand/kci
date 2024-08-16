using System.IO;
using System.Text;
using DevDev.Extensions;
using UnityEditor;
using UnityEngine;


public static class TableBuilder
{
	[MenuItem("Table/Build Patch Data")]
	public static void BuildPatchData()
	{
		string directoryName = "1";
		string zipDirectoryPath = Path.Combine(Application.temporaryCachePath, directoryName);
		string filePath = Path.Combine(zipDirectoryPath, TableManager.ZIP_FILE_NAME);
		TableManager.CreateZip(DevDev.Table.Editor.CodeGen.Define.EXPORT_PATH, filePath);
		Debug.Log($"Zip Path: {filePath}");
		
		//체크섬 파일 생성
		//byte[] buffer = File.ReadAllBytes(filePath);
		//long checksum = TableManager.CalculateChecksum(buffer);
		
		string checksumFilePath = Path.Combine(zipDirectoryPath, TableManager.CHECKSUM_FILE_NAME);
		//byte[] bytes = Encoding.UTF8.GetBytes(checksumEncrypt);
		byte[] bytes = Encoding.UTF8.GetBytes(checksumFilePath);
		File.WriteAllBytes(checksumFilePath, bytes);
		
		EditorUtility.RevealInFinder(zipDirectoryPath + "/");
	}

	private static void UploadTable()
	{
		//기존 코드 제거하고, AWS 플러그인 설치해서 에디터에서만 로드되게 설정,
		//AWS S3 API키로 업로드하는게 명료해보임
		
		// var settings = NetworkManager.GetNetworkSettings();
		// string directoryName = settings.dataVersion.ToString();
		// string zipDirectoryPath = Path.Combine(Application.temporaryCachePath, directoryName);
		//
		// //SFTP 접속
		// string ppkPath = GetPpkFilePath();
		// Debug.Log($"PPK Path: {ppkPath}");
		//
		// var sessionOptions = new SessionOptions
		// {
		// 	Protocol = Protocol.Sftp,
		// 	HostName = "s-86cc4c843b0746459.server.transfer.ap-northeast-2.amazonaws.com",
		// 	UserName = "grooz-manager",
		// 	SshPrivateKeyPath = ppkPath,
		// 	SshHostKeyFingerprint = "ssh-rsa 2048 bY/f01FxMFWdaOSjc82"
		// };
		//
		// using var session = new Session();
		// session.DisableVersionCheck = true;
		// session.DebugLogPath = $"{zipDirectoryPath}/log.txt";
		// session.Open(sessionOptions);
		//
		// var transferOptions = new TransferOptions();
		// transferOptions.TransferMode = TransferMode.Automatic;
		// transferOptions.OverwriteMode = OverwriteMode.Overwrite;
		//
		// if (session.Opened == false)
		// {
		// 	string errorMsg = string.Empty;
		// 	foreach (string output in session.Output)
		// 	{
		// 		errorMsg += output + "\n";
		// 	}
		//
		// 	Debug.LogError($"세션 오픈 실패: {errorMsg}");
		// 	return;
		// }
		// Debug.Log("세션 오픈 성공.");
		//
		// var result = session.PutFilesToDirectory(zipDirectoryPath, $"Table/{directoryName}", options: transferOptions);
		// if (result.IsSuccess == false)
		// {
		// 	string errorMsg = string.Empty;
		// 	foreach (SessionRemoteException exception in result.Failures)
		// 	{
		// 		errorMsg += exception.Message + "\n";
		// 	}
		//
		// 	Debug.LogError($"업로드 실패: {errorMsg}");
		// 	return;
		// }
		//
		// Debug.Log($"업로드 성공. Version:{settings.dataVersion}");
	}

	private static string GetPpkFilePath()
	{
		const string PREFS_KEY = "TablePpkFilePath";

		string ppkPath = EditorPrefs.GetString(PREFS_KEY);
		if (ppkPath.IsNullOrWhiteSpace() || System.IO.File.Exists(ppkPath) == false)
		{
			ppkPath = EditorUtility.OpenFilePanelWithFilters("FTP PPK 파일 선택", string.Empty, new[]
			{
				"Private", "ppk"
			});

			if (ppkPath.IsNullOrWhiteSpace())
			{
				return null;
			}

			EditorPrefs.SetString(PREFS_KEY, ppkPath);
		}

		return ppkPath;
	}
}
