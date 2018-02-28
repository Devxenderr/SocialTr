using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using SocialTrading.Connection.Markers;
using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request.Posts
{
    public class CreateSimplePostRequestModel : IModelSend
    {
        protected string Market { get; }
        protected string Access { get; }
        protected string Image { get; }
        protected string Content { get; }

        public EResponseModule ResponseModule { get; set; }
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public Type TypeMarker { get; protected set; } = typeof(RestRorMarker);


        public CreateSimplePostRequestModel(string market, EAccessMode access, string content, string image)
        {
            if (string.IsNullOrWhiteSpace(image) && string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content) + " or " + nameof(image));
            }

            if (access == EAccessMode.None)
            {
                throw new ArgumentNullException(nameof(access));
            }

            Market = market;
            Content = content;
            Image = image;
            Access = access.ToString();

            ApiPath = "/api/v3/posts";
            Method = ERestCommands.POST;
            ResponseModule = EResponseModule.CreatePost;
        }

        public virtual JObject PerformQuery()
        {
            var json = new JObject
            {
                ["market"] = Market,
                ["access"] = Access,
            };

            if (!string.IsNullOrWhiteSpace(Image))
            {
                json["image"] = "data:image/gif;base64," + Image;
            }
            if (!string.IsNullOrWhiteSpace(Content))
            {
                json["content"] = Content;
            }

            return json;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            var model = obj as CreateSimplePostRequestModel;

            if (obj == null)
            {
                return result;
            }

            if (Content == model?.Content && Access == model?.Access && Image == model?.Image && Market == model?.Market)
            {
                result = true;
            }

            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = 229093474;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Market);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Access);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            hashCode = hashCode * -1521134295 + ResponseModule.GetHashCode();
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            return hashCode;
        }
    }
}
