using System;

using SocialTrading.Tools.Interfaces;
using SocialTrading.DTO.Interfaces;

namespace SocialTrading.Vipers.EditContact.Interfaces
{
    public interface IInteractorEditContact : ISetConfig, IDisposable
    {
        IPresenterForInteractorEditContact Presenter { set; }

        void SaveClick(IEditContactEntity entity);
        void CancelClick();
        void CountryClick();

        void AlertOkClick();

        bool SkypeTextChanged(string skype);
        bool CityTextChanged(string city);
        bool PhoneTextChanged(string phone);
    }
}
