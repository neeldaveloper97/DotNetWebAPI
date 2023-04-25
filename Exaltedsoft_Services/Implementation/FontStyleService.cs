using Exaltedsoft_Model;
using Exaltedsoft_Model.Entities;
using Exaltedsoft_Model.ViewModels.Response;
using Exaltedsoft_Repository.Interface;
using Exaltedsoft_Services.Interface;

namespace Exaltedsoft_Services.Implementation
{
    public class FontStyleService : IFontStyleService
    {
        private readonly AppDbContext _context;
        private readonly IFontStyleRepository _fontStyleRepository;


        public FontStyleService(AppDbContext context, IFontStyleRepository fontStyleRepository)
        {
            _context = context;
            _fontStyleRepository = fontStyleRepository;
        }

        public int FontStyleInsert(FontStylesVM fontStyles)
        {
            FontStyles response = new FontStyles();
            response.FontThin = fontStyles.FontThin;
            response.FontRegular = fontStyles.FontHandWritten;
            response.FontMedium = fontStyles.FontHandWritten;
            response.FontBold = fontStyles.FontBold;
            response.FontExtraBold = fontStyles.FontExtraBold;
            response.FontHandWritten = fontStyles.FontHandWritten;
            _context.FontStyles.Add(response);
            return _fontStyleRepository.FontStyleInsert(response);
        }

        public int FontStyleUpdate(FontStylesVM fontStyles)
        {
            var response = _context.FontStyles.FirstOrDefault(x => x.Id == fontStyles.Id);
            if (response == null)
            {
                response = new FontStyles();
            }

            response.Id = fontStyles.Id;
            response.FontThin = fontStyles.FontThin;
            response.FontRegular = fontStyles.FontHandWritten;
            response.FontMedium = fontStyles.FontHandWritten;
            response.FontBold = fontStyles.FontBold;
            response.FontExtraBold = fontStyles.FontExtraBold;
            response.FontHandWritten = fontStyles.FontHandWritten;

            _context.FontStyles.Update(response);
            return _fontStyleRepository.FontStyleUpdate(response);
        }

        public List<FontStylesVM> GetAllFontStyle()
        {
            return _fontStyleRepository.GetAllFontStyle();
        }

        public FontStylesVM GetFontStyleById(Guid Id)
        {
            return _fontStyleRepository.GetFontStyleById(Id);
        }

        public int DeleteFontStyleById(Guid Id)
        {
            var response = _context.FontStyles.FirstOrDefault(c => c.Id == Id);
            if (response == null)
            {
                response = new FontStyles();
            }
            _context.FontStyles.Remove(response);
            return _fontStyleRepository.DeleteFontStyleById(Id);
        }
    }
}
