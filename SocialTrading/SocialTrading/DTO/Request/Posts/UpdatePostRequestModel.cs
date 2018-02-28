using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Markers;
using SocialTrading.Connection.Enumerations;

namespace SocialTrading.DTO.Request.Posts
{
    public class UpdatePostRequestModel : IModelSend
    {
        public string Access { get; }
        public string Image { get; }
        public string Content { get; }
        
        public ERestCommands Method { get; set; }
        public string ApiPath { get; set; }

        public Type TypeMarker { get; protected set; } = typeof(RestRorMarker);


        public UpdatePostRequestModel(string id, EAccessMode access, string content, string image)
        {
            if (string.IsNullOrWhiteSpace(image) && string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content) + " or " + nameof(image));
            }

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (access == EAccessMode.None)
            {
                throw new ArgumentNullException(nameof(access));
            }

            Content = content;
            Image = image;
            Access = access.ToString();

            ApiPath = "/api/v3/posts/" + id; 
            Method = ERestCommands.PUT;
        }

        public JObject PerformQuery()
        {
            var json = new JObject
            {
                ["post"] = new JObject
                {
                    ["access"] = Access,
                    ["content"] = Content,
                    ["image"] = !string.IsNullOrWhiteSpace(Image) ? "data:image/gif;base64," + Image : string.Empty
                }
            };

            return json;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            var model = obj as UpdatePostRequestModel;

            if (obj == null)
            {
                return result;
            }

            if (Content == model?.Content && Access == model?.Access && Image == model?.Image)
            {
                result = true;
            }

            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = -1054101487;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Access);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = hashCode * -1521134295 + Method.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ApiPath);
            return hashCode;
        }
    }
}
