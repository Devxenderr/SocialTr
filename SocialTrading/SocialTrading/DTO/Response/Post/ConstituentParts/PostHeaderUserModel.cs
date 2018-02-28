using System.Collections.Generic;

namespace SocialTrading.DTO.Response.Post.ConstituentParts
{
    public class PostHeaderUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
     //   public string NickName { get; set; }
        public string Avatar { get; set; }
    //    public bool IsNickname { get; set; }
        public bool StatusUser { get; set; }

        public PostHeaderUserModel(string userInfoFirstName, string userInfoLastName, string userInfoImage, bool status)
        {
            FirstName = userInfoFirstName;
            LastName = userInfoLastName;
        //    NickName = userInfoNickname;
            Avatar = userInfoImage;
      //      IsNickname = isNickname;
            StatusUser = status;
        }

        public override bool Equals(object obj)
        {
            var postHeaderUser = obj as PostHeaderUserModel;

            return FirstName == postHeaderUser?.FirstName &&
                   LastName == postHeaderUser?.LastName &&
                   LastName == postHeaderUser?.LastName &&
           //        NickName == postHeaderUser?.NickName &&
                   Avatar == postHeaderUser?.Avatar &&
           //        IsNickname == postHeaderUser?.IsNickname &&
                   StatusUser == postHeaderUser?.StatusUser;
        }

        public override int GetHashCode()
        {
            var hashCode = -1699811320;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
          //  hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NickName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Avatar);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(StatusUser);
        //    hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IsNickname);

            return hashCode;
        }
    }
}