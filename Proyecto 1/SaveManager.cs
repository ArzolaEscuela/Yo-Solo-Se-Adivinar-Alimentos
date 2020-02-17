using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using System.Windows.Media.Animation;
using Newtonsoft.Json;

namespace Proyecto_1
{
    public static class SaveManager
    {
        //------------------------------------------------------------------------------------//
        /*----------------------------------- FIELDS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        private static List<Node> loadedNodes = null;

        //------------------------------------------------------------------------------------//
        /*--------------------------------- PROPERTIES ---------------------------------------*/
        //------------------------------------------------------------------------------------//

        private const string _SAVE_INFO_FILE_NAME = "SavedRuns.json";
        private static string SaveFilePath => $"{AppDomain.CurrentDomain.BaseDirectory}/{_SAVE_INFO_FILE_NAME}";
        private static bool SaveFileExists => File.Exists(SaveFilePath);

        private static readonly List<Node> InitialNodes = new List<Node>()
        {
            // Root
            new Node() { PathToNode = new List<EDirection>(), Content = "¿Estás pensando en una fruta?" },

            // 1st Level
            new Node() { PathToNode = new List<EDirection>() { EDirection.No }, Content = "¿Estás pensando en una verdura?" },
            new Node() { PathToNode = new List<EDirection>() { EDirection.Yes }, Content = "¿Se acostumbra usar para hacer jugo?" },

            // 2nd Level
            new Node(){PathToNode = new List<EDirection>(){EDirection.No, EDirection.No}, Content = "¿Estás pensando en algún tipo de carne?"},
            new Node(){PathToNode = new List<EDirection>(){EDirection.No, EDirection.Yes}, Content = "Brócoli"},
            new Node(){PathToNode = new List<EDirection>(){EDirection.Yes, EDirection.No}, Content = "Manzana"},
            new Node(){PathToNode = new List<EDirection>(){EDirection.Yes, EDirection.Yes}, Content = "Naranja"},

            // 3rd Level
            new Node(){PathToNode = new List<EDirection>(){EDirection.No, EDirection.No, EDirection.No}, Content = "Huevo"},
            new Node(){PathToNode = new List<EDirection>(){EDirection.No, EDirection.No, EDirection.Yes}, Content = "Pescado"},
        };

        public static List<Node> SavedData
        {
            get
            {
                if (!SaveFileExists) { loadedNodes = InitialNodes; Save(); }
                else
                {
                    using (StreamReader file = File.OpenText(SaveFilePath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        loadedNodes = (List<Node>)serializer.Deserialize(file, typeof(List<Node>));
                        if (loadedNodes == null || loadedNodes.Count == 0) { loadedNodes = InitialNodes; }
                    }
                }

                return loadedNodes;
            }
        }

        //------------------------------------------------------------------------------------//
        /*---------------------------------- METHODS -----------------------------------------*/
        //------------------------------------------------------------------------------------//

        public static void AddAndSaveRun(params Node[] finishedRun)
        {
            foreach (var item in finishedRun) { loadedNodes.Add(item); }
            Save();
        }

        public static void Save()
        {
            using (StreamWriter file = File.CreateText(SaveFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, loadedNodes);
            }
        }
    }
}