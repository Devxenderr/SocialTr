using System.Collections.Generic;

namespace SocialTrading.Vipers.Tools.Interfaces.Presenter
{
    public interface IPresenterToolsForInteractor
    {
        void SetDataSource(List<string> toolsList);
        void SetEnableCell(int index, bool isEnable);
        void SetScroll(int index);
        
        void GoBack(string selectedKey);
    }
}
