using Godot;
using System;

public partial class Camera3D : Godot.Camera3D
{
	[Export]
	private uint speed = 5;
	private float speedModifier = 0.6f;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Vector3 dirX = Transform.Basis.X;
		Vector3 dirZ = Transform.Basis.Z;
		Vector3 velocity = Vector3.Zero;

        if (Input.IsActionPressed("move_right"))
        {
			velocity += dirX;
			// this.Transform = newTransform.TranslatedLocal(newTransform.Basis.X * (float)delta);
        }
        if (Input.IsActionPressed("move_left"))
        {
			velocity -= dirX;
			// this.Transform = newTransform.TranslatedLocal(-newTransform.Basis.X * (float)delta);
        }
        if (Input.IsActionPressed("move_back"))
        {
			velocity += dirZ;
			// this.Transform = newTransform.TranslatedLocal(newTransform.Basis.Z * (float)delta);
        }
        if (Input.IsActionPressed("move_forward"))
        {
			velocity -= dirZ;
			// this.Transform = newTransform.TranslatedLocal(-newTransform.Basis.Z * (float)delta);
        }

		// this.Position += velocity.Normalized() * speed * speedModifier;
		this.Transform = Transform.TranslatedLocal(velocity.Normalized() * speed * speedModifier * (float)delta);
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (Input.IsMouseButtonPressed(MouseButton.WheelUp)) {
			speedModifier = Mathf.Clamp(speedModifier + 0.1f, 0.1f, 1);
		}

		if (Input.IsMouseButtonPressed(MouseButton.WheelDown)) {
		    speedModifier = Mathf.Clamp(speedModifier - 0.1f, 0.1f, 1);
		}

		if (Input.IsMouseButtonPressed(MouseButton.Right) &&
		    @event is InputEventMouseMotion e)
        {
			Vector2 rotateDir = e.Relative;
			this.Transform = Transform.RotatedLocal(Vector3.Up, Mathf.DegToRad(-rotateDir.X));
			this.Transform = Transform.RotatedLocal(Vector3.Right, Mathf.DegToRad(-rotateDir.Y));
        }

	}
}
