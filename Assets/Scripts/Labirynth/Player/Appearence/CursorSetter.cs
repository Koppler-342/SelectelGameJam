using Labirynth.Player.Base;
using UnityEngine;

namespace Labirynth.Player.Appearence
{
    public class CursorSetter : PlayerBehaviour
    {
        [SerializeField] private Texture2D live = null;
        [SerializeField] private Texture2D dead = null;

        private Vector2 liveHotspot;
        private Vector2 deadHotspot;

        protected override void OnAwake()
        {
            liveHotspot = new Vector2(live.width / 2, live.height / 2);
            deadHotspot = new Vector2(dead.width / 2, dead.height / 2);
        }

        protected override void OnRespawn()
        {
            Cursor.SetCursor(live, liveHotspot, CursorMode.Auto);
        }

        protected override void OnDeath()
        {
            Cursor.SetCursor(dead, deadHotspot, CursorMode.Auto);
        }
    }
}