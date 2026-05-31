namespace Core.UI
{
    public abstract class AbstractUIViewT<TVm> : AbstractUIView where TVm : IUIViewModel
    {
        protected TVm ViewModel;

        public virtual void Construct(TVm viewModel)
        {
            ViewModel = viewModel;
        }
    }
}