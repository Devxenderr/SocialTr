using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using SocialTrading.DTO.Response.Qc;
using SocialTrading.Vipers.ModelCreators;
using SocialTrading.DTO.Response.Post.ConstituentParts;

namespace MASTTests.Vipers.ModelCreators
{
    [TestFixture, Author("Oleh Marchenko")]
    public class PostHeaderBrokerModelTests
    {
        private DataModelQc _qc;

        [SetUp]
        public void SetUp()
        {
            _qc = new DataModelQc(1, "AUDCAD", "123.45", 123.45f, "123.45f", 123.45f, 123.45f, 123.45f, 123.45f, "Open", 123.45f, 123L, 123L);
        }


        [Test]
        public void TestConstructor()
        {
            var creator = new PostHeaderBrokerModelCreator(_qc);
            var field = creator.GetType().GetRuntimeFields().FirstOrDefault();

            var actual = field?.GetValue(creator) as DataModelQc;

            Assert.AreEqual(_qc, actual);
        }

        [Test]
        public void TestConstructorException()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new PostHeaderBrokerModelCreator(null));
        }

        [Test]
        public void TestGetModel()
        {
            var brokerModel = new PostHeaderBrokerModel(_qc);
            var creator = new PostHeaderBrokerModelCreator(_qc);

            var actual = creator.GetModel();

            Assert.AreEqual(brokerModel, actual);
        }
    }
}