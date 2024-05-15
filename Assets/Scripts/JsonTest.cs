using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class JsonTest : MonoBehaviour
    {
        private string fileName = "2x2json.json";
        private string path;

        private Json _grid;

        private void Start()
        {
            path = Path.Combine(Application.streamingAssetsPath, fileName);
            
            Read();
        }

        public void Read()
        {
            string json = File.ReadAllText(path);

            _grid = JsonUtility.FromJson<Json>(json);

            foreach (var data in _grid.datas)
            {
                Debug.Log(data.solvableSteps);
            }
        }
    }

    [Serializable]
    public class Json
    {
        public List<Grid> datas;
    }

    [Serializable]
    public class Grid
    {
        public int[] gridTiles;
        public int solvableSteps;
    }
}