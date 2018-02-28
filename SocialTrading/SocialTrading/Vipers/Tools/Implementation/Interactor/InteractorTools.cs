using System;
using System.Linq;
using System.Collections.Generic;

using SocialTrading.Tools.Interfaces;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.Tools.Interfaces.Presenter;
using SocialTrading.Vipers.Tools.Interfaces.Interactor;

namespace SocialTrading.Vipers.Tools.Implementation
{
    public class InteractorTools : IInteractorTools
    {
        public IRepositoryNames RepoQcNames { private get; set; }
        public IPresenterToolsForInteractor Presenter
        {
            set
            {
                _presenter = value;

                _presenter.SetDataSource(CreateDataSourceForPresenter(_dataSource));

                if (_selectedKey != null)
                {
                    _selectedCell = GetSelectedIndexByKey(_dataSource, _selectedKey);

                    if (_selectedCell != -1)
                    {
                        _presenter.SetEnableCell(_selectedCell, true);
                    }
                }
            }
        }

      

        private IPresenterToolsForInteractor _presenter;
        private readonly ISearchHelper<string> _searchHelper;

        private readonly List<Tuple<string, string>> _dataSource;
        private List<string> _currentDataSource;
        private readonly string _selectedKey;
        private int _selectedCell = -1;

        public InteractorTools(IRepositoryNames repository, ISearchHelper<string> searchHelper, string selectedKey = null)
        {
            _searchHelper = searchHelper ?? throw new NullReferenceException(nameof(searchHelper));
            RepoQcNames = repository ?? throw new NullReferenceException(nameof(repository));

            _dataSource = RepoQcNames.GetNames();

            _currentDataSource = new List<string>();
            _currentDataSource = CreateDataSourceForPresenter(_dataSource);

            _selectedKey = selectedKey;
        }

        private int GetSelectedIndexByKey(List<Tuple<string, string>> dataSource, string key)
        {
            var result = dataSource?.IndexOf(dataSource?.Where(r => r.Item1 == key).FirstOrDefault());
            return result ?? -1;
        }

        private List<string> CreateDataSourceForPresenter(List<Tuple<string, string>> dataSource)
        {
            return dataSource?.Select(r => r.Item2).ToList();
        }

        public virtual void CellClick(int index)
        {
            if (index < 0 || index > _currentDataSource.Count)
            {
                return;
            }

            _presenter.SetEnableCell(_selectedCell, false);
            _presenter.SetEnableCell(index, true);

            _selectedCell = index;

            _presenter.GoBack(_currentDataSource[index]);
        }

        public void SearchEdit(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                _presenter.SetDataSource(CreateDataSourceForPresenter(_dataSource));
                _currentDataSource = CreateDataSourceForPresenter(_dataSource);
                return;
            }

            var foundList = _searchHelper.Search(_dataSource, str);

            if (foundList == null)
            {
                return;
            }

            _presenter.SetDataSource(CreateDataSourceForPresenter(foundList));
            _currentDataSource = CreateDataSourceForPresenter(foundList);
        }
    }
}
