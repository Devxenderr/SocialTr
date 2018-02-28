using System;

using SocialTrading.Tools;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.MoreOptions.OptionsCell.Interfaces;

namespace SocialTrading.Vipers.MoreOptions.OptionsCell.Implementation
{
    public class InteractorOptionsCell : IInteractorOptionsCell
    {
        public IPresenterOptionsCellForInteractor Presenter { private get; set; }

        private readonly DictionaryForOptions _dictionary;
        private readonly EItemsOptions _optionType;

        public InteractorOptionsCell(DictionaryForOptions dictionary, EItemsOptions optionType)
        {
            _dictionary = dictionary ?? throw new NullReferenceException(nameof(dictionary));

            if (optionType == EItemsOptions.None)
            {
                throw new NullReferenceException(nameof(optionType));
            }

            _optionType = optionType;
        }
        public void CellClick()
        {
            Presenter.GoTo(_optionType);
        }

        public void SetConfig()
        {
            _dictionary.TryGetValue(_optionType, out Tuple<string, string> optionItems);

            if (optionItems != null)
            {
                Presenter.SetImage(optionItems.Item1);
                Presenter.SetText(optionItems.Item2);
            }
        }
    }
}
