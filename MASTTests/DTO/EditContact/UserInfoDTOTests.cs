using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

using SocialTrading.Vipers.Entity;
using SocialTrading.Connection.Enumerations;
using SocialTrading.DTO.Request.EditContact;

namespace MASTTests.DTO.EditContact
{
    [TestFixture, Author("Oleh Marchenko")]
    public class UserInfoDTOTests
    {
        [Test]
        public void EditContactDTOExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new UserInfoDTO(null);
            });
        }

        [Test]
        public void EditContactDTOTest()
        {
            var entity = new EditContactEntity("email", "skype", "country", "city", "phone");
            var modelAct = new UserInfoDTO(entity);

            var modelExp = new UserInfoDTO(entity)
            {
                Method = ERestCommands.PUT,
                ApiPath = "/api/v3/update_personal_info"
            };
            modelExp.GetType().GetRuntimeFields().First(f => f.Name.Equals("_entity")).SetValue(modelExp, entity);

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }
    }
}