using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Game.CubeNS {
    public class CubeView :MonoBehaviour {
		
        [SerializeField] List<TextMeshProUGUI> cubeNum;
        [SerializeField] CubeInfo cubeInfo;
        [SerializeField] MeshRenderer meshRenderer;

        public void Init() {
            if (meshRenderer == null) meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetNewParam(int currentIndexOfArray) {
            int currentNumber = (int)Mathf.Pow(2, currentIndexOfArray + 1);
            int i = 0;
            while (i < cubeNum.Count) {
                cubeNum[i].text = currentNumber.ToString();
                i++;
            }
            if (currentIndexOfArray > cubeInfo.colorsOfCube.Count - 1) {
                currentIndexOfArray = cubeInfo.colorsOfCube.Count - 1;
            }
            meshRenderer.material = cubeInfo.colorsOfCube[currentIndexOfArray];
        }
    }
}