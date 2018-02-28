using System;
using SocialTrading.Locale.Modules;
using SocialTrading.Tools.Interfaces;
using SocialTrading.Vipers.CreatePost.Interfaces;

namespace SocialTrading.Vipers.UpdatePost.Interfaces
{
    public interface IPresenterUpdatePost : IPresenterUpdatePostForInteractor, IPresenterUpdatePostForView, ISetConfig, IDisposable
    {
        void ImageSelected(string image);

        void SetLocale(ICreatePost lang);
        void SetTheme(IUpdatePostStylesHolder stylesHolder);

        void NeedToSaveData();
    }
}
