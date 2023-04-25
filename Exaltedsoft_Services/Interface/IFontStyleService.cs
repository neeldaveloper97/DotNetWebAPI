using Exaltedsoft_Model.ViewModels.Response;

namespace Exaltedsoft_Services.Interface
{
    public interface IFontStyleService
    {
        public int FontStyleInsert(FontStylesVM fontStyles);
        public int FontStyleUpdate(FontStylesVM fontStyles);
        public List<FontStylesVM> GetAllFontStyle();
        public FontStylesVM GetFontStyleById(Guid Id);
        public int DeleteFontStyleById(Guid Id);
    }
}
