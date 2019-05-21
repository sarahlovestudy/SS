using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern {

	public abstract class Weapon {
		protected string description;
		public virtual string GetDescription() {
			return description;
		}
		public abstract int Damage();

	}
	public class SWord : Weapon {
		public SWord() {
			description = "sword";
		}
		public override int Damage() {
			return 15;
		}
	}
	public abstract class Diamond : Weapon {
		protected Weapon weapon;
	}
	public class BlueDiamond : Diamond {
		private int iceDamage = 2;

		public BlueDiamond(Weapon weapon) {
			this.weapon = weapon;
		}
		public override int Damage() {
			return weapon.Damage() + iceDamage;
		}
		public string IceEffect() {
			return "\nAddtional Effect:Frozen";
		}
		public override string GetDescription() {
			return base.GetDescription()+IceEffect();
		}

	}

	public class RedDiamond : Diamond {
		private int iceDamage = 3;

		public RedDiamond(Weapon weapon) {
			this.weapon = weapon;
		}
		public override int Damage() {
			return weapon.Damage() + iceDamage;
		}
		public string IceEffect() {
			return "\nAddtional Effect:Frozen";
		}
		public override string GetDescription() {
			return base.GetDescription() + IceEffect();
		}

	}


}
