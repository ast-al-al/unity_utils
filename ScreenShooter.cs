using System.IO;
using UnityEngine;

/// <summary>
/// Сохранение скриншотов из окна Game. Скриншоты сохраняются в папку проекта /ScreenCaptures
/// </summary>
public class ScreenShooter : MonoBehaviour
{
	public KeyCode captureKey = KeyCode.Insert;
	public int counter = 0;
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}
	void Update()
	{
		if (Input.GetKeyDown(captureKey))
		{
			string path = Application.dataPath;
			path = path.Remove(path.LastIndexOf("/") + 1) + "ScreenCaptures";
			Directory.CreateDirectory(path);
			string finalPath = path + $"/{Application.productName}_{Screen.width}x{Screen.height}_{counter}.png";
			while (File.Exists(finalPath))
			{
				counter++;
				finalPath = path + $"/{Application.productName}_{Screen.width}x{Screen.height}_{counter}.png";
			}
			ScreenCapture.CaptureScreenshot(finalPath);
			counter++;
		}
	}
}
