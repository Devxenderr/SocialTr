using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Request.EditContact;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.ModelCreators.Interfaces;

namespace SocialTrading.Vipers.ModelCreators
{
    public class EditContactModelCreator : IEditContactModelCreator
    {
        private readonly IRepositoryEditContact _repository;


        public EditContactModelCreator(IRepositoryEditContact repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }


        public EditContactEntity GetModel()
        {
            var model = _repository.EditContactUserInfo;
            return new EditContactEntity(model.Email, model.Skype, model.Country, model.City, model.Phone);
        }

        public UserInfoDTO GetRequestModel(IEditContactEntity entity)
        {
            return new UserInfoDTO(entity ?? throw new NullReferenceException(nameof(entity)));
        }
    }
}