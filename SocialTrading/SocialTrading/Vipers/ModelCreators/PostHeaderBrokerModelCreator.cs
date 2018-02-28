using System;
using System.Collections.Generic;

using SocialTrading.DTO.Response.Qc;
using SocialTrading.Vipers.ModelCreators.Interfaces;
using SocialTrading.DTO.Response.Post.ConstituentParts;

namespace SocialTrading.Vipers.ModelCreators
{
    public class PostHeaderBrokerModelCreator : IPostHeaderBrokerModelCreator
    {
        private readonly DataModelQc _quotations;


        public PostHeaderBrokerModelCreator(DataModelQc qcs)
        {
            _quotations = qcs ?? throw new ArgumentNullException();
        }


        public PostHeaderBrokerModel GetModel()
        {
            return new PostHeaderBrokerModel(_quotations);
        }


        public override bool Equals(object obj)
        {
            var creator = obj as PostHeaderBrokerModelCreator;
            return creator != null &&
                   EqualityComparer<DataModelQc>.Default.Equals(_quotations, creator._quotations);
        }

        public override int GetHashCode()
        {
            return 76059033 + EqualityComparer<DataModelQc>.Default.GetHashCode(_quotations);
        }
    }
}
