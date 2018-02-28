using Android.Views;
using Android.Support.V7.Widget;

using SocialTrading.Tools;
using SocialTrading.Droid.Theme;
using SocialTrading.Droid.Tools;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Implementation;

namespace SocialTrading.Droid.ViewHolders
{
    internal class OptionViewHolder : RecyclerView.ViewHolder, IOptionCell
    {
        private readonly View _view;
        private readonly IRouterOptionsCell _router;
        

        public OptionViewHolder(View view, IRouterOptionsCell router) : base(view)
        {
            _view = view;
            _router = router;
        }

        public void SetData(EItemsOptions data)
        {            
            IPresenterOptionsCell presenter = new PresenterOptionsCell(_view as IViewOptionsCell, new InteractorOptionsCell(DAL.DictionaryForOptions, data), _router, 
                new OptionsCellStylesHolderDroid<GlobalControlsTheme>(DroidDAL.ThemeParser));

            presenter.SetConfig();
        }
    }
}