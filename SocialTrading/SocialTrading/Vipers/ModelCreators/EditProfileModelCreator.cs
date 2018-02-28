using System;

using SocialTrading.Vipers.Entity;
using SocialTrading.DTO.Interfaces;
using SocialTrading.DTO.Request.EditContact;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Vipers.ModelCreators.Interfaces;

namespace SocialTrading.Vipers.ModelCreators
{
    public class EditProfileModelCreator : IEditProfileModelCreator
    {
        private readonly IRepositoryEditProfile _repository;


        public EditProfileModelCreator(IRepositoryEditProfile repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }


        public IEditProfileEntity GetModel()
        {
            var model = _repository.EditProfileUserInfo;
            return new EditProfileEntity(model.FirstName, model.LastName, model.UserStatus);
        }

        public UserInfoDTO GetRequestModel(IEditProfileEntity entity)
        {
            return new UserInfoDTO(entity ?? throw new NullReferenceException(nameof(entity)));
        }
    }
}