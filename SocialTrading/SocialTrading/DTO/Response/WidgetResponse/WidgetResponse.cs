using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SocialTrading.DTO.Response.WidgetResponse.Enumerations;

namespace SocialTrading.DTO.Response.WidgetResponse
{
    public class WidgetResponse
    {
        private ESocketModuleAnswer _module;
        private ESocketCMDAnswer _cmd;
        //private JObject _argsJObject;
        //private JArray _argsJArray;

        internal ESocketModuleAnswer Module
        {
            get
            {
                return _module;
            }

            private set
            {
                _module = value;
            }
        }
        internal ESocketCMDAnswer Cmd
        {
            get
            {
                return _cmd;
            }

            private set
            {
                _cmd = value;
            }
        }

        public JArray Args { get; }

        //public JObject ArgsJObject
        //{
        //    get
        //    {
        //        return _argsJObject;
        //    }

        //    private set
        //    {
        //        _argsJObject = value;
        //    }
        //}
        //public JArray ArgsJArray
        //{
        //    get
        //    {
        //        return _argsJArray;
        //    }

        //    private set
        //    {
        //        _argsJArray = value;
        //    }
        //}

        [JsonConstructor]
        public WidgetResponse(string module, string cmd, JArray args)
        {
            Module = GetSocketModuleAnswer(module);
            Cmd = GetSocketCMDAnswer(cmd);
            Args = args;

            //if (args is JObject)
            //{
            //    ArgsJObject = args;
            //}
            //else
            //{
            //    ArgsJArray = args;
            //}
        }

        private ESocketModuleAnswer GetSocketModuleAnswer(string module)
        {
            if (string.IsNullOrEmpty(module))
            {
                return ESocketModuleAnswer.error;
            }

            foreach (ESocketModuleAnswer item in Enum.GetValues(typeof(ESocketModuleAnswer)))
            {
                if (module == item.ToString())
                {
                    return item;
                }
            }

            return ESocketModuleAnswer.error;
        }

        private ESocketCMDAnswer GetSocketCMDAnswer(string cmd)
        {
            if (cmd == null)
            {
                return ESocketCMDAnswer.error;
            }
            else if (cmd == "")
            {
                return ESocketCMDAnswer.none;
            }

            foreach (ESocketCMDAnswer item in Enum.GetValues(typeof(ESocketCMDAnswer)))
            {
                if (cmd == item.ToString())
                {
                    return item;
                }
            }

            return ESocketCMDAnswer.error;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
