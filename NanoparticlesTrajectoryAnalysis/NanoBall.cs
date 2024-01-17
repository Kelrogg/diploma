using Godot;
using System;


public partial class NanoBall : CharacterBody3D
{
    static private uint RandSpeed(uint maximum = 5) {
		return GD.Randi() % maximum + 1;
	}

	public NanoBall()
	{
		velocity = new Vector3(
		    GD.Randf() - GD.Randf(),
	        GD.Randf() - GD.Randf(),
	        GD.Randf() - GD.Randf()
	    ).Normalized() * RandSpeed(100);
	}

	private Vector3 velocity;

	public override void _Ready()
	{
		this.LookAt(new Vector3(GD.Randi(), GD.Randi(), GD.Randi()), Vector3.Up);
	}

	public override void _PhysicsProcess(double delta)
	{
        KinematicCollision3D collision = MoveAndCollide(velocity * (float)delta);

        if (collision is not null && collision.GetCollisionCount() > 0)
        {
            Vector3 normal = collision.GetNormal();

            velocity = -velocity.Reflect(normal);
        }
	}
}
