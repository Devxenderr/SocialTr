using SocialTrading.Vipers.Entity;
using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.Post;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryCreatePost/* : IRepositoryUser*/
    {
        bool IsRepositoryCreatePostCleaned { get; }

        string AttachmentImage { get; set; }
        string SelectedTool { get; set; }
        CreatePostStrings CreatePostStrings { get; set; }

        ICreatePost LangCreatePost { get; }

        void ConfigRepositoryCreatePost();
        void DisposeRepositoryCreatePost();
    }
}
