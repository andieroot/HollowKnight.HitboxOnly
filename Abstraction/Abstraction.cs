using Modding;
using System.Collections.Generic;
using UnityEngine;


namespace Abstraction
{
    public class Abstraction : Mod
    {
        GameObject titleBackground;
        public Abstraction() : base("Abstraction") { }
        public override string GetVersion() => "1.0";
        public override List<(string, string)> GetPreloadNames()
        {
            return new List<(string, string)>
            {
                 ("GG_Radiance", "Boss Control"),
                 ("GG_Grey_Prince_Zote", "Mighty_Zote_0005_17"),
            };
        }
        private void ActiveSceneChanged(UnityEngine.SceneManagement.Scene from, UnityEngine.SceneManagement.Scene to)
        {
            var titleBackground_ = Object.Instantiate(titleBackground);
            titleBackground_.SetActive(true);
            titleBackground_.name = "titleBackground";
            titleBackground_.AddComponent<HitboxRender>();
            foreach (GameObject gameObject in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (gameObject.GetComponent<HitboxRender>() == null)
                {
                    gameObject.AddComponent<HitboxRender>();
                }
            }
        }
        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += ActiveSceneChanged;
            var bossControl = preloadedObjects["GG_Radiance"]["Boss Control"];
            titleBackground = preloadedObjects["GG_Grey_Prince_Zote"]["Mighty_Zote_0005_17"];
            var spriteRenderer = titleBackground.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerID = -349214895;
            var whiteFader = bossControl.transform.Find("White Fader").gameObject;
            spriteRenderer.sprite = whiteFader.GetComponent<SpriteRenderer>().sprite;
            spriteRenderer.color = new Color(0.25f, 0.25f, 0.25f, 1);
            titleBackground.transform.position = new Vector3(0, 0, -16);
            titleBackground.transform.localScale = Vector3.one * 256;
        }
    }
}
