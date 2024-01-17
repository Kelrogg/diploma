using Godot;
using System;

public partial class Node3D : Godot.Node3D
{
	PackedScene packedScene;

	public override void _Ready()
	{
		packedScene = ResourceLoader.Load<PackedScene>("res://Sprite.tscn");
	}

	public override void _PhysicsProcess(double delta)
	{
		// for (int index = 0; index < GetSlideCollisionCount(); index++)
        // {
        //     // We get one of the collisions with the player.
        //     KinematicCollision3D collision = GetSlideCollision(index);

        //     // If the collision is with a mob.
        //     // With C# we leverage typing and pattern-matching
        //     // instead of checking for the group we created.
        //     if (collision.GetCollider() is Mob mob)
        //     {
        //         // We check that we are hitting it from above.
        //         if (Vector3.Up.Dot(collision.GetNormal()) > 0.1f)
        //         {
        //             // If so, we squash it and bounce.
        //             mob.Squash();
        //             _targetVelocity.Y = BounceImpulse;
        //             // Prevent further duplicate calls.
        //             break;
        //         }
        //     }
        // }
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (Input.IsMouseButtonPressed(MouseButton.Left)
		    && packedScene != null) {
		  Node sptr = packedScene.Instantiate<Node>();
		//   GD.Print(sptr as Ri);
		//   (sptr.GetChild<RigidBody3D>(0)).Position = new Vector3(0, 0, 0);
		  AddChild(sptr);
		}
	}
}