using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SocialTrading.DTO.Response.RA;
using SocialTrading.DTO.Response.Qc;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Tools.Exceptions.Parse;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.DTO.Response.WidgetResponse;

namespace SocialTrading.Connection.Dispatcher
{
    public static class WebMsgParser
    {
        private static T CheckParseValidity<T>(Func<T> parseMethod)
        {
            try
            {
                return parseMethod.Invoke();
            }
            catch (Exception e)
            {
                throw new ParseException("Deserialization issue!", e.InnerException);
            }
        }

        //public static DataModelRegErrors ParseResponseRegErrors(string dataFromServer)
        //{
        //    var deserializeObject = JsonConvert.DeserializeObject<JObject>(dataFromServer);
        //    var msgs = deserializeObject["errors"]["full_messages"].ToObject<string[]>();
        //    var model = new DataModelRegErrors(msgs);

        //    return model;
        //}

        public static string ParseUrlArguments(string data)
        {
            return CheckParseValidity(() =>
            {
                var jObj = JObject.Parse(data);
                return jObj["url_args"]?.ToString();
            });
        }

        public static DataModelAuth ParseResponseAuth(string dataFromServer)
        {
            if (string.IsNullOrEmpty(dataFromServer))
            {
                throw new ParseException("Data for auth is null or empty!");
            }

            return CheckParseValidity(() =>
            {
                try
                {
                    var jObj = JObject.Parse(dataFromServer);
                    var json = jObj["data"]?.ToString();
                    var model = JsonConvert.DeserializeObject<DataModelAuth>(json);
                    return model;
                }
                catch (Exception)
                {
                    var model = JsonConvert.DeserializeObject<DataModelAuth>(dataFromServer);
                    return model;
                }
            });
        }

        public static DataModelReg ParseResponseReg(string dataFromServer)
        {
            if (string.IsNullOrEmpty(dataFromServer))
            {
                throw new ParseException("Data for reg is null or empty!");
            }

            return CheckParseValidity(() =>
            {
                try
                {
                    var jObj = JObject.Parse(dataFromServer);
                    var json = jObj["data"]?.ToString();
                    var model = JsonConvert.DeserializeObject<DataModelReg>(json);
                    return model;
                }
                catch (Exception)
                {
                    var model = JsonConvert.DeserializeObject<DataModelReg>(dataFromServer);
                    return model;
                }              
            });
        }

        public static DataModelPost ParseResponseCreatePost(string dataFromServer)
        {
            if (string.IsNullOrEmpty(dataFromServer))
            {
                throw new ParseException("Data is null or empty!");
            }

            return CheckParseValidity(() =>
            {
                try
                {
                    var jObj = JObject.Parse(dataFromServer);
                    var json = jObj["data"]["post"]?.ToString();
                    var model = JsonConvert.DeserializeObject<DataModelPost>(json);
                    return model;
                }
                catch (Exception)
                {
                    var model = JsonConvert.DeserializeObject<DataModelPost>(dataFromServer);
                    return model;
                }
               
            });
        }

        public static List<DataModelPost> ParseResponsePosts(string dataFromServer)
        {
            return CheckParseValidity(() =>
            {
                var jObj = JObject.Parse(dataFromServer);
                var json = string.Empty;

                if (dataFromServer.Contains("posts")) // HARDCODE
                {
                    json = jObj["data"]["posts"]?.ToString();
                }
                else if (dataFromServer.Contains("post"))
                {
                    json = jObj["data"]["post"]?.ToString();
                }

                var model = JsonConvert.DeserializeObject<List<DataModelPost>>(json);

                return model;
            });
        }

        public static DataRecoveryPasswordResponse ParseResponseRecoveryPassword(string dataFromServer)
        {
            return CheckParseValidity(() =>
            {
                if (string.IsNullOrWhiteSpace(dataFromServer))
                {
                    throw new ArgumentException("dataFromServer cannot be null, empty");
                }

                var model = JsonConvert.DeserializeObject<DataRecoveryPasswordResponse>(dataFromServer);

                if (model == null)
                {
                    throw new ParseException("Can't parse dataFromServer");
                }
                return model;
            });
        }

        public static DataModelPostLike ParseResponsePostLike(string dataFromServer)
        {
            return CheckParseValidity(() =>
            {
                var jObj = JObject.Parse(dataFromServer);
                var json = jObj["data"]?.ToString();
                var model = JsonConvert.DeserializeObject<DataModelPostLike>(json);
                return model;
            });
        }

        public static DataModelUserInfo ParseResponseUserSettings(string dataFromServer)
        {
            return CheckParseValidity(() =>
            {
                var jObj = JObject.Parse(dataFromServer);
                var json = jObj["data"]["user_info"]?.ToString();
                var model = JsonConvert.DeserializeObject<DataModelUserInfo>(json);
                return model;
            });
        }

        public static DataModelUserInfo ParseResponsePersonalInfo(string dataFromServer)
        {
            return CheckParseValidity(() =>
            {
                var jObj = JObject.Parse(dataFromServer);
                var json = jObj["data"]["user"]?.ToString();
                var model = JsonConvert.DeserializeObject<DataModelUserInfo>(json);
                return model;
            });
        }

        public static DataModelDeletePost ParseResponseDeletePost(string dataFromServer)
        {
            return CheckParseValidity(() =>
            {
                var model = JsonConvert.DeserializeObject<DataModelDeletePost>(dataFromServer);
                return model;
            });
        }

        public static WidgetResponse ParseResponseWidget(string dataFromServer)
        {
            return CheckParseValidity(() =>
            {
                var model = JsonConvert.DeserializeObject<WidgetResponse>(dataFromServer);
                return model;
            });
        }

        public static List<DataModelQc> ParseResponseQuotations(JArray jArray)
        {
            return CheckParseValidity(() =>
            {
                var model = JsonConvert.DeserializeObject<List<DataModelQc>>(jArray?.ToString());
                return model;
            });
        }
    }
}
