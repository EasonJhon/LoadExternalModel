using System.Collections;
using System.Collections.Generic;
using System.IO;
using TriLibCore;
using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
  
    //文件路径要加载的模型的绝对路径，不能为空
    string modelFilename;
    [Header("模型贴图必须在同级目录，会自动读取原始模型的使用贴图")]
    //文件名称
    public string name;
    public AssetLoaderOptions options;//这个就是你创建管理渲染的物体
    void Start()
    {
        modelFilename = Application.streamingAssetsPath + "/Model/";
        LoadNameModel(name);
    }

    void LoadNameModel(string name)
    {
       modelFilename += name;
       AssetLoader.LoadModelFromFile(modelFilename, OnLoad, OnMaterialsLoad, OnProgress, OnError, null, options);     
    }

    /// <summary>
    /// Called when any error occurs.
    /// </summary>
    /// <param name="obj">The contextualized error, containing the original exception and the context passed to the method where the error was thrown.</param>
    private void OnError(IContextualizedError obj)
    {
        Debug.LogError($"An error occurred while loading your Model: {obj.GetInnerException()}"); //加载模型时发生错误
    }

    /// <summary>
    /// Called when the Model loading progress changes.
    /// </summary>
    /// <param name="assetLoaderContext">The context used to load the Model.</param>
    /// <param name="progress">The loading progress.</param>
    private void OnProgress(AssetLoaderContext assetLoaderContext, float progress)
    {
        Debug.Log($"Loading Model. Progress: {progress:P}");
    }

    /// <summary>
    /// Called when the Model (including Textures and Materials) has been fully loaded.
    /// </summary>
    /// <remarks>The loaded GameObject is available on the assetLoaderContext.RootGameObject field.</remarks>
    /// <param name="assetLoaderContext">The context used to load the Model.</param>材料加载。模型完全加载
    private void OnMaterialsLoad(AssetLoaderContext assetLoaderContext)
    {

    }

    /// <summary>
    /// Called when the Model Meshes and hierarchy are loaded.
    /// </summary>
    /// <remarks>The loaded GameObject is available on the assetLoaderContext.RootGameObject field.</remarks>
    /// <param name="assetLoaderContext">The context used to load the Model.</param>模型加载。装材料
    private void OnLoad(AssetLoaderContext assetLoaderContext)
    {
        Debug.Log("Model loaded. Loading materials.");
    }

    void Update() 
    {
    }
}
