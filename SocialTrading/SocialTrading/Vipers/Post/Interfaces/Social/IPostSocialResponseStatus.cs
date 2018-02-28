using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialTrading.Vipers.Post.Implementation.Social;

namespace SocialTrading.Vipers.Post.Interfaces.Social
{
    public interface IPostSocialResponseStatus
    {
        EPostSocialResponseStatus Status { get; }
    }
}
