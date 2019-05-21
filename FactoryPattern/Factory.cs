using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
     //定义身体部分
	 public interface IHead { string name { get; } }
	public interface IStature { string name { get; } }
	public interface ISkin { string name { get; } }
	//组成Human身体的类
	public class HumanHead : IHead { public string name { get { return "HumenHead"; } } }
	public class HumanStature : IStature { public string name { get { return "Human Stature"; } } }
	public class HumanSkin : ISkin { public string name { get { return "Human Skin"; } } }
	//组成elf身体的类
	public class ElfHead : IHead { public string name { get { return "Elf Head"; } } }
	public class ElfStature : IStature { public string name { get { return "Elf Stature"; } } }
	public class ElfSkin : ISkin { public string name { get { return "Elf Skin"; } } }

	public interface IRacePartFactory {
		IHead CreateHead();
		IStature CreateStature();
		ISkin CreateSkin();
	}
	public class HumanPartFactory : IRacePartFactory {
		IHead IRacePartFactory.CreateHead() {
			return new HumanHead();
		}

		ISkin IRacePartFactory.CreateSkin() {
			return new HumanSkin();
		}

		IStature IRacePartFactory.CreateStature() {
			return new HumanStature();
		}
		public HumanPartFactory() {

		}
	}
	public class ElfPartFactory : IRacePartFactory {
		public IHead CreateHead() {
			return new ElfHead();
		}

		public ISkin CreateSkin() {
			return new ElfSkin();
		}

		public IStature CreateStature() {
			return new ElfStature();
		}
	}
	public class Race {
		public IHead Head;
		public ISkin Skin;
		public IStature Stature;
		public Race (IRacePartFactory racePartFactory) {
			Head = racePartFactory.CreateHead();
			Skin = racePartFactory.CreateSkin();
			Stature = racePartFactory.CreateStature();
		}
	}
}
