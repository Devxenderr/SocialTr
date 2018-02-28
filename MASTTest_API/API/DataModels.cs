using Newtonsoft.Json.Linq;

namespace MASTTest_API.API
{
    public static class DataModels
    {
        public static JObject GetDataModelUserInfo(string id, string first_name, string last_name, string nickname, string image,
            string email, string phone, string phone_2, string skype, string country, string city, string status)
        {
            return new JObject
            {
                ["data"] = new JObject
                {
                    ["user"] = new JObject
                    {
                        ["id"] = id,
                        ["first_name"] = first_name,
                        ["last_name"] = last_name,
                        ["nickname"] = nickname,
                        ["image"] = image,
                        ["email"] = email,
                        ["phone"] = phone,
                        ["phone_2"] = phone_2,
                        ["skype"] = skype,
                        ["country"] = country,
                        ["city"] = city,
                        ["status"] = status
                    }
                }
            };
        }
    }
}