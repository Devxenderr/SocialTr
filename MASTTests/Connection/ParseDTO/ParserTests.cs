using System;
using NUnit.Framework;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

using SocialTrading.Connection;
using SocialTrading.DTO.Response.Qc;
using SocialTrading.DTO.Response.RA;
using SocialTrading.DTO.Response.Post;
using SocialTrading.Connection.Dispatcher;
using SocialTrading.DTO.Request.EditContact;
using SocialTrading.DTO.Request.RA;
using SocialTrading.DTO.Response.UserSettings;
using SocialTrading.Service;
using SocialTrading.Service.Interfaces.Repository;
using SocialTrading.Tools;
using SocialTrading.Vipers.Entity;

namespace MASTTests.Connection.ParseDTO
{
    [TestFixture]
    public class ParserTests
    {
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase(null, null, null, null, null, null, null, null, null, null, null, Author = "Oleh Marchenko")]
        [TestCase("", "", "", "", "", "", "", "", "", "", "", Author = "Oleh Marchenko")]
        [TestCase(null, "dmitrysh@123software.ru", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1deedbbb-14c5-4e86-89ad-89b7e1e04e3b", null, "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1deedbbb-14c5-4e86-89ad-89b7e1e04e3b", "dmitrysh@123software.ru", null, "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1deedbbb-14c5-4e86-89ad-89b7e1e04e3b", "dmitrysh@123software.ru", "qwe", null, "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1deedbbb-14c5-4e86-89ad-89b7e1e04e3b", "dmitrysh@123software.ru", "qwe", "qwe", null, "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1deedbbb-14c5-4e86-89ad-89b7e1e04e3b", "dmitrysh@123software.ru", "qwe", "qwe", "qwe", null, "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1deedbbb-14c5-4e86-89ad-89b7e1e04e3b", "dmitrysh@123software.ru", "qwe", "qwe", "qwe", "провайдер", null, "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", null, "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", null, "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", null, "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", null, Author = "Oleh Marchenko")]
        [TestCase("", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "", "2017-07-11T13:34:16.312Z", Author = "Oleh Marchenko")]
        [TestCase("1d", "q@q.qq", "qwe", "qwe", "qwe", "провайдер", "uid", "uid", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "", Author = "Oleh Marchenko")]
        public void ParseModelReg(string id, string provider, string uid, string email, string first_name, string last_name, string nickname,
                                   string image, string lasted_at, string created_at, string updated_at)
        {
            var jObj = new JObject
            {
                ["data"] = new JObject
                {
                    ["id"] = id,
                    ["email"] = email,
                    ["first_name"] = first_name,
                    ["last_name"] = last_name,
                    ["nickname"] = nickname,
                    ["provider"] = provider,
                    ["uid"] = uid,
                    ["image"] = image,
                    ["lasted_at"] = lasted_at,
                    ["created_at"] = created_at,
                    ["updated_at"] = updated_at
                }
            };

            var modelAct = WebMsgParser.ParseResponseReg(jObj.ToString());
            var modelExp = new DataModelReg(id, email, first_name, last_name, nickname, provider, uid, image, lasted_at, created_at, updated_at, null);

            var result = modelExp.Equals(modelAct);

            Assert.AreEqual(true, result);
        }

        [TestCase("", "", "", "", "", "", "", "", "", "", "", "", "", true, 0, 0, 0, Author = "Elena Pakhomova")]
        [TestCase(null, null, null, null, null, null, null, null, null, null, null, null, null, true, 0, 0, 0, Author = "Elena Pakhomova")]
        [TestCase(null, "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", null, "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", null, "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", null, "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", null, "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", null, "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", null, "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", null, "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", null, "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", null, "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", null, "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", null, "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", null, true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 0, 123456, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 0, 12354646, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 0, Author = "Elena Pakhomova")]
        [TestCase("1d", "provider", "uid", "q@q.qq", "2017-07-11T13:34:16.312Z", "2017-07-11T13:34:16.312Z", "img", "backImg", "2017-07-11T13:34:16.312Z", "Ivan", "Ivanov", "Super trader", "EN", true, 12345678, 123456, 12354646, Author = "Elena Pakhomova")]
        public void ParseModelAuth(string id, string provider, string uid, string email, string lasted_at, string created_at,
                                   string image, string back_image, string updated_at, string first_name, string last_name,
                                   string nickname, string language, bool is_nickname, long created_at_long, long updated_at_long,
                                   long lasted_at_long)
        {
            var jObj = new JObject
            {
                ["data"] = new JObject
                {
                    ["id"] = id,
                    ["provider"] = provider,
                    ["uid"] = uid,
                    ["email"] = email,
                    ["lasted_at"] = lasted_at,
                    ["created_at"] = created_at,
                    ["image"] = image,
                    ["background_image"] = back_image,
                    ["updated_at"] = updated_at,
                    ["first_name"] = first_name,
                    ["last_name"] = last_name,
                    ["nickname"] = nickname,
                    ["language"] = language,
                    ["is_nickname"] = is_nickname,
                    ["created_at_long"] = created_at_long,
                    ["updated_at_long"] = updated_at_long,
                    ["lasted_at_long"] = lasted_at_long

                }
            };

            var modelAct = WebMsgParser.ParseResponseAuth(jObj.ToString());
            var modelExp = new DataModelAuth(id, provider, uid, email, lasted_at, created_at, image, back_image, updated_at, first_name,
                last_name, nickname, language, is_nickname, created_at_long, updated_at_long, lasted_at_long, null);

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }


        [TestCase(null, null, null, null, null, 0f, null, null, null, null, null, null, null, null, 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("", "", "", "", "", 0f, "", "", "", "", "", "", "", "", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(null, "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", null, "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", null, "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", null, "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", null, 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, null, "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", null, "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", null, "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", null, "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", null, "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", null, "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", null, "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase("id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        public void ParseModelPost(string id, string userId, string quote, string market, string recommend, float price, string access, string image,
            string content, string forecast, string createdAt, string updatedAt, string name, string avatar, int likeCount, int commentCount, bool liked)
        {
            var jObj = new JObject
            {
                ["data"] = new JObject
                {
                    ["post"] = new JObject
                    {
                        ["id"] = id,
                        ["user_id"] = userId,
                        ["quote"] = quote,
                        ["market"] = market,
                        ["recommend"] = recommend,
                        ["price"] = price,
                        ["access"] = access,
                        ["image"] = image,
                        ["content"] = content,
                        ["forecast"] = forecast,
                        ["created_at"] = createdAt,
                        ["updated_at"] = updatedAt,
                        ["author_name"] = name,
                        ["author_avatar"] = avatar,
                        ["likes_count"] = likeCount,
                        ["comments_count"] = commentCount,
                        ["liked"] = liked
                    }
                }
            };

            var modelAct = WebMsgParser.ParseResponseCreatePost(jObj.ToString());
            var modelExp = new DataModelPost(id, userId, quote, market, recommend, price, access, image, content, forecast, createdAt, updatedAt, name, avatar,
                likeCount, commentCount, liked);

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }

        [TestCase(0, null, null, null, null, null, 0f, null, null, null, null, null, null, null, null, 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, null, null, null, null, null, 0f, null, null, null, null, null, null, null, null, 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "", "", "", "", "", 0f, "", "", "", "", "", "", "", "", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, null, "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", null, "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", null, "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", null, "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", null, 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, null, "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", null, "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", null, "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", null, "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", null, "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", null, "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", null, "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(1, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, null, null, null, null, null, 0f, null, null, null, null, null, null, null, null, 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "", "", "", "", "", 0f, "", "", "", "", "", "", "", "", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, null, "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", null, "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", null, "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", null, "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", null, 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, null, "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", null, "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", null, "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", null, "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", null, "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", null, "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", null, "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        [TestCase(10, "id", "userId", "quote", "market", "recommend", 0f, "access", "file", "content", "forecast", "createdAt", "updatedAt", "first", "avatar", 0, 0, false, Author = "Oleh Marchenko")]
        public void ParseListModelPost(int countItems, string id, string userId, string quote, string market, string recommend, float price, string access, string image,
            string content, string forecast, string createdAt, string updatedAt, string name, string avatar, int likeCount, int commentCount, bool liked)
        {
            var jArray = new JArray();

            for (int i = 0; i < countItems; i++)
            {
                jArray.Add(new JObject
                {
                    ["id"] = id,
                    ["user_id"] = userId,
                    ["quote"] = quote,
                    ["market"] = market,
                    ["recommend"] = recommend,
                    ["price"] = price,
                    ["access"] = access,
                    ["image"] = image,
                    ["content"] = content,
                    ["forecast"] = forecast,
                    ["created_at"] = createdAt,
                    ["updated_at"] = updatedAt,
                    ["author_name"] = name,
                    ["author_avatar"] = avatar,
                    ["likes_count"] = likeCount,
                    ["comments_count"] = commentCount,
                    ["liked"] = liked
                });
            }

            var jObj = new JObject
            {
                ["data"] = new JObject
                {
                    ["post"] = jArray
                }
            };

            var modelAct = WebMsgParser.ParseResponsePosts(jObj.ToString());
            var modelExp = new List<DataModelPost>();
            for (int i = 0; i < countItems; i++)
            {
                modelExp.Add(new DataModelPost(id, userId, quote, market, recommend, price, access, image, content, forecast, createdAt, updatedAt, name, avatar,
                    likeCount, commentCount, liked));
            }

            CollectionAssert.AreEqual(modelExp, modelAct);
        }


        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", int.MinValue, false, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", -1, false, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", 0, false, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", 1, false, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", 10, false, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", int.MaxValue, false, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", int.MinValue, true, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", -1, true, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", 0, true, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", 1, true, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", 10, true, Author = "Oleh Marchenko")]
        [TestCase("bad82816-9caf-4c1a-919c-468a0c05d035", int.MaxValue, true, Author = "Oleh Marchenko")]
        [TestCase("", int.MinValue, false, Author = "Oleh Marchenko")]
        [TestCase("", -1, false, Author = "Oleh Marchenko")]
        [TestCase("", 0, false, Author = "Oleh Marchenko")]
        [TestCase("", 1, false, Author = "Oleh Marchenko")]
        [TestCase("", 10, false, Author = "Oleh Marchenko")]
        [TestCase("", int.MaxValue, false, Author = "Oleh Marchenko")]
        [TestCase("", int.MinValue, true, Author = "Oleh Marchenko")]
        [TestCase("", -1, true, Author = "Oleh Marchenko")]
        [TestCase("", 0, true, Author = "Oleh Marchenko")]
        [TestCase("", 1, true, Author = "Oleh Marchenko")]
        [TestCase("", 10, true, Author = "Oleh Marchenko")]
        [TestCase("", int.MaxValue, true, Author = "Oleh Marchenko")]
        public void ParseModelPostLike(string postId, int countLikes, bool liked)
        {
            var jObj = new JObject
            {
                ["data"] = new JObject
                {
                    ["liked_id"] = postId,
                    ["count_likes"] = countLikes,
                    ["liked"] = liked.ToString().ToLower()
                }
            };
            var modelAct = WebMsgParser.ParseResponsePostLike(jObj.ToString());
            var modelExp = new DataModelPostLike(postId, countLikes, liked, null);

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }

        [TestCase(int.MinValue, false, Author = "Oleh Marchenko")]
        [TestCase(-1, false, Author = "Oleh Marchenko")]
        [TestCase(0, false, Author = "Oleh Marchenko")]
        [TestCase(1, false, Author = "Oleh Marchenko")]
        [TestCase(10, false, Author = "Oleh Marchenko")]
        [TestCase(int.MaxValue, false, Author = "Oleh Marchenko")]
        [TestCase(int.MinValue, true, Author = "Oleh Marchenko")]
        [TestCase(-1, true, Author = "Oleh Marchenko")]
        [TestCase(0, true, Author = "Oleh Marchenko")]
        [TestCase(1, true, Author = "Oleh Marchenko")]
        [TestCase(10, true, Author = "Oleh Marchenko")]
        [TestCase(int.MaxValue, true, Author = "Oleh Marchenko")]
        public void ParseModelPostLikeNull(int countLikes, bool liked)
        {
            var jObj = new JObject
            {
                ["data"] = new JObject
                {
                    ["post_id"] = null,
                    ["count_likes"] = countLikes,
                    ["liked"] = liked.ToString().ToLower()
                }
            };
            var modelAct = WebMsgParser.ParseResponsePostLike(jObj.ToString());
            var modelExp = new DataModelPostLike(null, countLikes, liked, null);

            var result = modelExp.Equals(modelAct);

            Assert.IsTrue(result);
        }

        [TestCase(0, 1, "", "", 0f, "", 0f, 0f, 0f, 0f, "", 0f, 0L, 0L, Author = "OLeh Marchenko")]
        [TestCase(1, 1, "", "", 0f, "", 0f, 0f, 0f, 0f, "", 0f, 0L, 0L, Author = "OLeh Marchenko")]
        [TestCase(1, 1, null, null, 0f, null, 0f, 0f, 0f, 0f, null, 0f, 0L, 0L, Author = "OLeh Marchenko")]
        [TestCase(1, 1, "name", "1254", 0.123f, "123", 0.123f, 0.123f, 0.123f, 0.123f, "sess", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(1, 1, "", "125", 0.123f, "123", 0.123f, 0.123f, 0.123f, 0.123f, "sess", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(1, 1, "name", "123", 0.123f, "13", 0.123f, 0.123f, 0.123f, 0.123f, "", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(1, 1, null, "123", 0.123f, "12", 0.123f, 0.123f, 0.123f, 0.123f, "sess", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(1, 1, "name", "123", 0.123f, "12", 0.123f, 0.123f, 0.123f, 0.123f, null, 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(1, 1, null, "123", 0.123f, "12", 0.123f, 0.123f, 0.123f, 0.123f, null, 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(10, 1, "", "", 0f, "", 0f, 0f, 0f, 0f, "", 0f, 0L, 0L, Author = "OLeh Marchenko")]
        [TestCase(10, 1, null, null, 0f, null, 0f, 0f, 0f, 0f, null, 0f, 0L, 0L, Author = "OLeh Marchenko")]
        [TestCase(10, 1, "name", "123", 0.123f, "123", 0.123f, 0.123f, 0.123f, 0.123f, "sess", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(10, 1, "", "123", 0.123f, "13", 0.123f, 0.123f, 0.123f, 0.123f, "sess", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(10, 1, "name", "123", 0.123f, "13", 0.123f, 0.123f, 0.123f, 0.123f, "", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(10, 1, null, "123", 0.123f, "13", 0.123f, 0.123f, 0.123f, 0.123f, "sess", 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(10, 1, "name", "123", 0.123f, "13", 0.123f, 0.123f, 0.123f, 0.123f, null, 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        [TestCase(10, 1, null, "123", 0.123f, "13", 0.123f, 0.123f, 0.123f, 0.123f, null, 0.123f, 123L, 123L, Author = "Oleh Marchenko")]
        public void ParseResponseQuotations(int count, int id, string name, string ask, float ssv, string bid, float diff, float rate, float min, float max, 
            string sess, float esv, long per, long timestamp)
        {
            var jArray = new JArray();

            for (int i = 0; i < count; i++)
            {
                jArray.Add(
                    new JObject
                    {
                        ["ID"] = id,
                        ["Name"] = name,
                        ["Ask"] = ask,
                        ["SSV"] = ssv,
                        ["Bid"] = bid,
                        ["Diff"] = diff,
                        ["Rate"] = rate,
                        ["Min"] = min,
                        ["Max"] = max,
                        ["Sess"] = sess,
                        ["ESV"] = esv,
                        ["Per"] = per,
                        ["Timestamp"] = timestamp
                    }
                );
            }

            var jObj = new JObject
            {
                ["module"] = "rates",
                ["cmd"] = "",
                ["args"] = jArray,
            };

            var modelAct = WebMsgParser.ParseResponseQuotations(jArray);
            var modelExp = new List<DataModelQc>();

            for (var i = 0; i < count; i++)
            {
                modelExp.Add(new DataModelQc(id, name, ask, ssv, bid, diff, rate, min, max, sess, esv, per, timestamp));
            }

            CollectionAssert.AreEqual(modelExp, modelAct);
        }

        [Test, Author("Oleh Marchenko")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        public void ParseResponsePersonalInfoTestApi(string id, string first_name, string last_name, string nickname, string image, 
            string email, string phone, string phone_2, string skype, string country, string city, string status)
        {
            //Test(id, first_name, last_name, nickname, image, email, phone, phone_2, skype, country, city, status);

            //Thread.Sleep(140000);

            
        }

        [Test, Author("Oleh Marchenko")]
        [TestCase(null, null, null, null, null, null, null, null, null, null, null, null)]
        [TestCase(null, "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", null, "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", null, "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", null, "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", null, "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", null, "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", null, "phone_2", "skype", "country", "city", "status")]
        [TestCase(null, "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", null, "skype", "country", "city", "status")]
        [TestCase(null, "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", null, "country", "city", "status")]
        [TestCase(null, "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", null, "city", "status")]
        [TestCase(null, "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", null, "status")]
        [TestCase(null, "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", null)]
        [TestCase("", "", "", "", "", "", "", "", "", "", "", "")]
        [TestCase("", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "", "phone", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "", "phone_2", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "", "skype", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "", "country", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "", "city", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "", "status")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "")]
        [TestCase("id", "Jon", "Snow", "nickname", "https://s3-eu-central-1.amazonaws.com/investarena-avatar/1511784812", "tvma@i.ua", "phone", "phone_2", "skype", "country", "city", "status")]
        public void ParseResponsePersonalInfoTest(string id, string first_name, string last_name, string nickname, string image,
            string email, string phone, string phone_2, string skype, string country, string city, string status)
        {
            var jObj = new JObject
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

            var modelExp = WebMsgParser.ParseResponsePersonalInfo(jObj.ToString());

            var modelAct = new DataModelUserInfo(id, first_name, last_name, nickname, image, email, phone, phone_2, skype, country, city, status, false, new string[] { });

            Assert.AreEqual(modelExp, modelAct);
        }
    }
}