using System;
using TankAILib;

namespace TankAI.SimpleTanks
{
	/// <summary>
	/// Sample tank that strafes back and forth
	/// </summary>
	public class Strafe : Tank
	{
		public Strafe(NewTankArgs e): base(e)
		{
			TurnGunLeft(Heading + 90 + 15);
		}

		public override void Tick()
		{
			if (Time % 50 == 0)
			{
                Forward();
				TurnLeft(Heading + 15);				
			}

			if (Time % 50 == 25)
			{
				Backward();
			}
		}

		public override void HitByBullet(BulletArgs e)
		{
			double newHeading = (e.Heading + 90) % 360;

			if ((newHeading - Heading + 360) % 360 < 180)
			{
				TurnLeft(newHeading);
			}
			else
			{
				TurnRight(newHeading);
			}
		}


		public override void ScannedTank(TankArgs e)
		{
			Fire(1);
		}
	}
}
