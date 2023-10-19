using GameEngineProject.Source.Core;
using GameEngineProject.Source.Core.Graphics;
using GameEngineProject.Source.Core.Utils;
using Raylib_cs;
using System.Numerics;

namespace GameEngineProject.Source.Entities
{
    public class Player
    {
        public GameObject gameObject;
        public int id; 
        public int MovementSpeed = 250;

        public Player(GameObject gameObject)
        {
            this.gameObject = gameObject;
            id = 0;
            GraphicsWindow2D.OnScreenRedraw += OnMovePlayer;
        }
        public void OnMovePlayer(object? sender, EventArgs e) => MovePlayer();
        public void MovePlayer()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) gameObject.transform.Move(-Vector3.UnitX * MovementSpeed * Raylib.GetFrameTime());
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) gameObject.transform.Move(Vector3.UnitX * MovementSpeed * Raylib.GetFrameTime());
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) gameObject.transform.Move(-Vector3.UnitY * MovementSpeed * Raylib.GetFrameTime());
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) gameObject.transform.Move(Vector3.UnitY * MovementSpeed * Raylib.GetFrameTime());
            if (Raylib.IsKeyDown(KeyboardKey.KEY_R)) gameObject.transform.MoveTo(Vector3.Zero);
            gameObject.transform.Rotation = VectorAndQuaternionMath.LookAtRotation(gameObject.transform.Position, Conversions.XYToVector3(Raylib.GetMousePosition()));
        }
    }
}
