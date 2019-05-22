using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern2 {
	public sealed class Order {
		private State current;
		public Order() {
			current = new WaitForAcceptance();
			IsCancel = false;
		}
		 
		public double Minute {
			get;set;
		}
		public bool IsCancel { get; set; }
		private bool finish;
		public bool TaskFinished {
			get { return finish; }
			set {
				finish = value;
			}
		}
		public void SetState(State s) {
			current = s;
		}
		public void Action() {
			current.Process(this);
		}
	}
	public interface State {
		void Process(Order order);
	}

	public sealed class WaitForAcceptance : State {
		public void Process(Order order) {
			Console.WriteLine("开始受理，准备出货");
			if(order.Minute<30&&order.IsCancel) {
				System.Console.WriteLine("半小时内科取消");
				order.SetState(new CancelOrder());
				order.Action();
			}
			order.SetState(new AcceptAndDeliver());
			order.TaskFinished = false;
			order.Action();
		}
	}
	public sealed class AcceptAndDeliver : State {
		public void Process(Order order) {
			Console.WriteLine("可以发货");
			if (order.Minute < 30 && order.IsCancel) {
				System.Console.WriteLine("半小时内科取消");
				order.SetState(new CancelOrder());
				order.Action();
			}
			if(order.TaskFinished == false) {
				order.SetState(new ConfirmationReceipt());
				order.Action();
			}
		}
	}
	public sealed class Sucucess : State {
		public void Process(Order order) {
			Console.WriteLine("完成");
			order.TaskFinished = true;
		}
	}
	public sealed class ConfirmationReceipt : State {
		public void Process(Order order) {
			System.Console.WriteLine("签收");
			order.SetState(new Sucucess());
			order.TaskFinished = false;
			order.Action();
		}
	}
	public sealed class CancelOrder:State {
		public void Process(Order order) {
			System.Console.WriteLine("取消订单");
			order.TaskFinished = true;
		}
	}

}
