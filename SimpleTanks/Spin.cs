using System;
using TankAILib;

namespace TankAI.SimpleTanks
{
	/// <summary>
	/// Sample tank that spins around
	/// </summary>
	public class Spin : Tank
	{
		public Spin(NewTankArgs e): base(e)
		{			
			MaxSpeed = 5;
			Forward();
			TurnRight();
		}

		public override void HitWall()
		{
			Forward();
		}

		public override void HitTank(HitTankArgs e)
		{
			Forward();
		}

		public override void ScannedTank(TankArgs e)
		{
			Fire(1);
		}
	}
}
