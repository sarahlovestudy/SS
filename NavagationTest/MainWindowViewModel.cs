using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavagationTest {
	class MainWindowViewModel:ViewModelBase {
		public List<PageViewModel> PageViewModels { get; set; } = new List<PageViewModel>();
		private PageViewModel _current;
		public PageViewModel CurrentPageViewModel 
			{ get => _current;
			set { _current = value;
				OnPropertyChanged();
			}
			}

		public MainWindowViewModel() {
			PageViewModels.Add(new HomeViewModel());
			PageViewModels.Add(new ProductVewModel());
			CurrentPageViewModel = PageViewModels[1];
			ChangePageCommand = new CommandBase(ExecuteChangePageCommand);
		}

		public CommandBase ChangePageCommand { get; set; }
		private void ExecuteChangePageCommand(object parameter) {
			PageViewModel viewModel = parameter as PageViewModel;
			if (!PageViewModels.Contains(viewModel))
				PageViewModels.Add(viewModel);
			CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
		}
	}
}
