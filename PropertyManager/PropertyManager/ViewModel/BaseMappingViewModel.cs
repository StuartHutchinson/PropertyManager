using AutoMapper;
using System.Threading.Tasks;

namespace PropertyManager.ViewModel
{
    public abstract class BaseMappingViewModel<TModel,TViewModel> : BaseNavigationViewModel where TViewModel : new()
    {
        public TaskCompletionSource<TModel> Retval = new TaskCompletionSource<TModel>();

        public static TViewModel CreateViewModel(TModel model)
        {
            TViewModel vm;
            if (model == null)
            {
                vm = new TViewModel();
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TModel, TViewModel>());
                vm = Mapper.Map<TViewModel>(model);
            }
            return vm;
        }

        protected TModel ReverseMap()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TViewModel, TModel>());
            return Mapper.Map<TModel>(this);
        }

        protected virtual async void OKPressed(object obj)
        {
            if (!Validate())
                return;

            TModel m = ReverseMap();
            Retval.SetResult(m);
            await PopAsync();
        }

        protected abstract bool Validate();

        protected void DisplayValidationError(string message)
        {
            DisplayAlert("Error", message, "OK");
        }
    }
}
