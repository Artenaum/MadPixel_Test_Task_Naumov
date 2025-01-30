using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.CubeNS;
using YG;
namespace Menu {
    public class MenuManager :MonoBehaviour {

        [SerializeField] MenuUIManager menuUIManager;

        [HideInInspector] public List<GameObject> collisionCube;
        [SerializeField] List<MenuCube> menuCubesList;

        private void Awake() {
            Init();
            menuUIManager.Init();
			YG2.StickyAdActivity(true);
        }

        private void Init() {
            int i = 0;
            while (i < menuCubesList.Count) {
                menuCubesList[i].FoundManager(this);
                i++;
            }
        }

        private void Update() {
            if (collisionCube.Count > 0) {
                MenuCube localCube = collisionCube[0].GetComponent<MenuCube>();
                localCube.currentIndexOfArray++;
                localCube.SetNewParam();
                int i = 1;
                do {
                    collisionCube[i].gameObject.SetActive(false);
                    i++;
                }
                while (i < collisionCube.Count);
                collisionCube.Clear();
            }
        }

        public void PlayGame() {
			YG2.InterstitialAdvShow();
			ChangeScene(1);
		}

        private void ChangeScene(int i) => SceneManager.LoadScene(i);
    }
}