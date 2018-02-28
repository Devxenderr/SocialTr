using System;

using SocialTrading.Tools;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Vipers.Post.Interfaces.Statistics;
using SocialTrading.DTO.Response.Post.ConstituentParts;

namespace SocialTrading.Vipers.Post.Implementation.Statistics
{
    public class PresenterPostStatistics : IPresenterPostStatistics
    {
        private readonly IViewPostStatistics _view;
        private readonly IInteractorPostStatistics _interactor;


        public PresenterPostStatistics(IViewPostStatistics view, IInteractorPostStatistics interactor)
        {
            if (view == null || interactor == null)
            {
                throw new NullReferenceException();
            }

            _view = view;
            _interactor = interactor;
            _view.Presenter = this;
            _interactor.Presenter = this;

            _view.SetConfig();
        }


        public void SetStatistic(PostStatisticsModel model)
        {
            _view.SetLong(
                _interactor.CalculateStatisticsLongLineSize(
                    model.PercentLong, 
                    _view.GetStatisticsLineSize()
                )
            );

            _view.SetLongPercent(model.PercentLong + "%");
            _view.SetShortPercent(model.PercentShort + "%");
            _view.SetDeals(model.Deals.ToString());
            _view.SetPnL(model.PnL.ToString());

            SetDealsState(model.Deals > 0);
            SetPnLState(model.PnL.GetPnLState());
        }

        private void SetDealsState(bool isAnyDeals)
        {
            if (isAnyDeals)
            {
                _view.SetDealsStatePositive();
            }
            else
            {
                _view.SetDealsStateNone();
            }
        }

        private void SetPnLState(EState state)
        {
            switch (state)
            {
                case EState.None:
                    _view.SetPnLStateNone();
                    break;
                case EState.Success:
                    _view.SetPnLStatePositive();
                    break;
                case EState.Fail:
                    _view.SetPnLStateNegative();
                    break;

                default:
                    break;
            }
        }
    }
}
