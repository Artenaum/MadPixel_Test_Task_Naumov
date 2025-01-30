using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using YG;
namespace Game.UI {
    public class InGameUi :MenuWindow {

        [SerializeField] InGameUIManager inGameUIManager;
        [SerializeField] Button settingButton;
        [SerializeField] TextMeshProUGUI currScoreText;
        [SerializeField] TextMeshProUGUI recordScoreText;

        public override void Init(bool isOpen = false) {
            base.Init(isOpen);
            settingButton.onClick.AddListener(OpenSetting);

			if (YG2.lang == "en") {
				recordScoreText.text = "High score: ";
			} else if (YG2.lang == "ru") {
				recordScoreText.text = "Рекорд: ";
			}
        }

        private void OpenSetting() => inGameUIManager.OpenSetting();

        public void SetScore(int score, int hightScore) {
            currScoreText.text = score.ToString();

			if (YG2.lang == "en") {
            	recordScoreText.text = "High score: " + hightScore.ToString();
			} else if (YG2.lang == "ru") {
				recordScoreText.text = "Рекорд: " + hightScore.ToString();
			}
        }
    }
}