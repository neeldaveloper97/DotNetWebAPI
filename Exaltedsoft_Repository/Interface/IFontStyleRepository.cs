using Exaltedsoft_Model.Entities;
using Exaltedsoft_Model.ViewModels.Response;

namespace Exaltedsoft_Repository.Interface
{
    public interface IFontStyleRepository
    {
        public int FontStyleInsert(FontStyles fontStyles);
        public int FontStyleUpdate(FontStyles fontStyles);
        public List<FontStylesVM> GetAllFontStyle();
        public FontStylesVM GetFontStyleById(Guid Id);
        public int DeleteFontStyleById(Guid Id);
    }
}
