using Godot;
using System;

public partial class Sprite : Godot.Sprite3D
{
	public override void _Ready()
	{
        GD.Print("Hello from C# to Godot :)");
	}

	public override void _Process(double delta)
	{
        uint randnum = GD.Randi() % 4;
        float AMOUNT = 0.1F;
        if (randnum == 0) {
            this.Position += new Vector3(0, -AMOUNT, 0);
        }
        if (randnum == 1) {
            this.Position += new Vector3(0, AMOUNT, 0);
        }
        if (randnum == 2) {
            this.Position += new Vector3(AMOUNT, 0, 0);
        }
        if (randnum == 3) {
            this.Position += new Vector3(-AMOUNT, 0, 0);
        }
	}
}