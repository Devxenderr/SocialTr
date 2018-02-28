using SocialTrading.DTO.Request.RA;
using SocialTrading.Locale.Modules;
using SocialTrading.DTO.Response.RA;

namespace SocialTrading.Service.Interfaces.Repository
{
    public interface IRepositoryRA /*: IRepositoryUser*/
    {
        bool IsRepositoryRACleaned { get; }

        UserReg User { get; set; }
       
        DataModelAuth ModelAuth { get; set; }
        DataModelReg ModelReg { get; set; }
        //DataModelRegErrors ModelRegErrors { get; set; }

        IRegAuth LangRA { get; }

        void ConfigRepositoryRA();
        void DisposeRepositoryRA();
    }
}
