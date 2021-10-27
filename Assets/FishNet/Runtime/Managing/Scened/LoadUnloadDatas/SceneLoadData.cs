﻿using FishNet.Object;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Scened
{
    /// <summary>
    /// Data about which scenes to load.
    /// </summary>
    public class SceneLoadData
    {
        /// <summary>
        /// SceneLookupData for each scene to load.
        /// </summary>
        public SceneLookupData[] SceneLookupDatas = new SceneLookupData[0];
        /// <summary>
        /// NetworkObjects to move to the new scenes. Objects will be moved to the first scene.
        /// </summary>
        public NetworkObject[] MovedNetworkObjects = new NetworkObject[0];
        /// <summary>
        /// True to replace current scenes with new ones. When true the first scene will be loaded as the active scene and the rest additive.
        /// False to add scenes onto currently loaded scenes.
        /// </summary>
        public bool ReplaceScenes = false;
        /// <summary>
        /// Parameters which may be set and will be included in load callbacks.
        /// </summary>
        public LoadParams Params = new LoadParams();
        /// <summary>
        /// Additional options to use for loaded scenes.
        /// </summary>
        public LoadOptions Options = new LoadOptions();

        public SceneLoadData() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene">Scene to load.</param>
        public SceneLoadData(Scene scene) : this(new Scene[] { scene }, null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName">Scene to load by name.</param>
        public SceneLoadData(string sceneName) : this(new string[] { sceneName }, null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneHandle">Scene to load by handle.</param>
        public SceneLoadData(int sceneHandle) : this(new int[] { sceneHandle }, null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenes">Scenes to load.</param>
        public SceneLoadData(List<Scene> scenes) : this(scenes.ToArray(), null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneNames">Scenes to load by name.</param>
        public SceneLoadData(List<string> sceneNames) : this(sceneNames.ToArray(), null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneHandles">Scenes to load by handle.</param>
        public SceneLoadData(List<int> sceneHandles) : this(sceneHandles.ToArray(), null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenes">Scenes to load.</param>
        public SceneLoadData(Scene[] scenes) : this(scenes, null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneNames">Scenes to load by name.</param>
        public SceneLoadData(string[] sceneNames) : this(sceneNames, null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneHandles">Scenes to load by handle.</param>
        public SceneLoadData(int[] sceneHandles) : this(sceneHandles, null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneLookupDatas">Scenes to load by SceneLookupDatas.</param>
        public SceneLoadData(SceneLookupData[] sceneLookupDatas) : this(sceneLookupDatas, null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenes">Scenes to load.</param>
        /// <param name="movedNetworkObjects">NetworkObjects to move to the first specified scene.</param>
        public SceneLoadData(Scene[] scenes, NetworkObject[] movedNetworkObjects)
        {
            SceneLookupDatas = SceneLookupData.CreateData(scenes);
            if (movedNetworkObjects == null)
                movedNetworkObjects = new NetworkObject[0];
            MovedNetworkObjects = movedNetworkObjects;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneNames">Scenes to load by Name.</param>
        /// <param name="movedNetworkObjects">NetworkObjects to move to the first specified scene.</param>
        public SceneLoadData(string[] sceneNames, NetworkObject[] movedNetworkObjects)
        {
            for (int i = 0; i < sceneNames.Length; i++)
                sceneNames[i] = Path.GetFileNameWithoutExtension(sceneNames[i]);

            SceneLookupDatas = SceneLookupData.CreateData(sceneNames);
            if (movedNetworkObjects == null)
                movedNetworkObjects = new NetworkObject[0];
            MovedNetworkObjects = movedNetworkObjects;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneHandles">Scenes to load by handle.</param>
        /// <param name="movedNetworkObjects">NetworkObjects to move to the first specified scene.</param>
        public SceneLoadData(int[] sceneHandles, NetworkObject[] movedNetworkObjects)
        {
            SceneLookupDatas = SceneLookupData.CreateData(sceneHandles);
            if (movedNetworkObjects == null)
                movedNetworkObjects = new NetworkObject[0];
            MovedNetworkObjects = movedNetworkObjects;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneLookupDatas">Scenes to load by SceneLookupDatas.</param>
        /// <param name="movedNetworkObjects">NetworkObjects to move to the first specified scene.</param>
        public SceneLoadData(SceneLookupData[] sceneLookupDatas, NetworkObject[] movedNetworkObjects)
        {
            SceneLookupDatas = sceneLookupDatas;

            if (movedNetworkObjects == null)
                movedNetworkObjects = new NetworkObject[0];
            MovedNetworkObjects = movedNetworkObjects;
        }

        /// <summary>
        /// Returns if any data is invalid, such as null entries.
        /// </summary>
        /// <returns></returns>
        internal bool DataInvalid()
        {
            //Null values.
            if (Params == null || MovedNetworkObjects == null || SceneLookupDatas == null ||
                Options == null)
                return true;

            return false;
        }


    }


}