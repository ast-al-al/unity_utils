using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Утилита для очистки PlayerPrefs и файлов сохранения в persistentDataPath.
/// </summary>
public class ClearSavedData : MonoBehaviour
{
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ClearPersistentDataPath()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] fileInfos = directoryInfo.GetFiles();
        foreach (var item in fileInfos)
        {
            File.Delete(item.FullName);
        }
        DirectoryInfo[] dirInfos = directoryInfo.GetDirectories();
        foreach (var item in dirInfos)
        {
            Directory.Delete(item.FullName, true);
        }
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(ClearSavedData))]
public class ClearSavedDataEditor : Editor
{
    private ClearSavedData _target;
    private void OnEnable()
    {
        _target = target as ClearSavedData;
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Clear PlayerPrefs"))
        {
            _target.ClearPlayerPrefs();
        }
        if (GUILayout.Button("Clear PersistentDataPath"))
        {
            _target.ClearPersistentDataPath();
        }
    }
}
#endif

