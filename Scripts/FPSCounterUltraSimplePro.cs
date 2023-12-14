using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Kulibin.Space.FpsCounter {

	public class FPSCounterUltraSimplePro : MonoBehaviour {

		public static FPSCounterUltraSimplePro instance;
		public bool persistent; // persist between scenes
		public TextMeshProUGUI text;
		public float rate = 0.5f;
		float startTime;
		float startFrame;

		void Awake () {
			if (persistent) {
				if (instance == null) {
					DontDestroyOnLoad(gameObject);
					instance = this;
				}
				else if (instance != this) {
					DestroyImmediate(gameObject);
				}
			}
		}
		private void Start () {
			startTime = Time.realtimeSinceStartup;
			startFrame = Time.frameCount;
		}

		void Update () {
			if (Time.realtimeSinceStartup - startTime > rate) {
				text.text = "FPS " + ((float)(Time.frameCount - startFrame) / (Time.realtimeSinceStartup - startTime)).ToString("#.0");
				startTime = Time.realtimeSinceStartup;
				startFrame = Time.frameCount;
			}
		}
	}

}