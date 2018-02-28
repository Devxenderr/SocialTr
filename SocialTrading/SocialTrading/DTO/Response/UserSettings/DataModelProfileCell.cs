using System.Collections.Generic;

using SocialTrading.Tools.Enumerations;
using SocialTrading.Connection.Interfaces;

namespace SocialTrading.DTO.Response.UserSettings
{
    public class DataModelProfileCell : IModel
    {
        public EControllerStatus ControllerStatus { get; set; }

        public string Name { get; }
        public string Image { get;}

        public DataModelProfileCell(string name, string image)
        {
            Name = name;
            Image = image;
        }


        public override bool Equals(object obj)
        {
            var data = obj as DataModelProfileCell;
            return data != null &&
                   Name == data.Name &&
                   Image == data.Image;
        }

        public override int GetHashCode()
        {
            var hashCode = 2033062288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            return hashCode;
        }
    }
}
